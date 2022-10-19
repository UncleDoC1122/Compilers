using System;
using Compilers.Lab2.Constants;
using Compilers.Lab2.Models;

namespace Compilers.Lab2.DataStructures.SyntaxTree.IntermediateInstructions
{
	public class SetElementNode : StatementNode
	{
		public IdentifierNode Array;
		public ExpressionNode Index;
		public ExpressionNode Expression;

		public SetElementNode(AccessNode accessNode, ExpressionNode expressionNode)
		{
			Array = accessNode.Array;
			Index = accessNode.Index;
			Expression = expressionNode;

			if (Check(Expression.Type, accessNode.Type) == null)
			{
				Error("Type definition error");
			} 
		}

		public DataType Check(DataType dataType1, DataType dataType2)
		{
			if (dataType1 == dataType2)
			{
				return dataType2;
			}

			return null;
		}
	}
}

