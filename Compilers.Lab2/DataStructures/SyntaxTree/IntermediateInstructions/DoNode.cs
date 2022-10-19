using System;
using Compilers.Lab2.Constants;

namespace Compilers.Lab2.DataStructures.SyntaxTree.IntermediateInstructions
{
	public class DoNode : StatementNode
	{
		ExpressionNode Expression;
		StatementNode Statement;

		public DoNode()
		{
			Expression = null;
			Statement = null;
		}

		public void Init(StatementNode statement, ExpressionNode expression)
		{
			Expression = expression;
			Statement = statement;

			if (expression.Type != DataTypes.Bool)
			{
				expression.Error("Do statement requires boolean");
			}
		}
	}
}

