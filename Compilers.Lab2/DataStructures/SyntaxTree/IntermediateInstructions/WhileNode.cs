using System;
using Compilers.Lab2.Constants;

namespace Compilers.Lab2.DataStructures.SyntaxTree.IntermediateInstructions
{
	public class WhileNode : StatementNode
	{
		ExpressionNode Expression;
		StatementNode Statement;

		public WhileNode()
		{
			Expression = null;
			Statement = null;
		}

		public void Init(ExpressionNode expression, StatementNode statement)
		{
			Expression = expression;
			Statement = statement;
			if (expression.Type != DataTypes.Bool)
			{
				expression.Error("Boolean instruction is required in while statement");
			}
		}
	}
}

