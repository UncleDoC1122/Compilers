using System;
using Compilers.Lab2.Constants;
using Compilers.Lab2.Infrastructure;
using Compilers.Lab2.Models;

namespace Compilers.Lab2.DataStructures.SyntaxTree.IntermediateInstructions
{
	public class SetNode : StatementNode
	{
		public IdentifierNode Identifier;
		public ExpressionNode Expression;

		public SetNode(IdentifierNode identifier, ExpressionNode expression)
		{
			Identifier = identifier;
			Expression = expression;

			if (Check(identifier.Type, expression.Type) == null)
			{
				Error("Type definition error");
			}
		}

		public DataType Check(DataType dataType1, DataType dataType2)
		{
			if (DataTypesRules.IsNumeric(dataType1) && DataTypesRules.IsNumeric(dataType2))
			{
				return dataType2;
			}
			if (dataType1 == DataTypes.Bool && dataType2 == DataTypes.Bool)
			{
				return dataType2;
			}
			return null;
		}
	}
}

