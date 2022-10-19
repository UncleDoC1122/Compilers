using System;
using Compilers.Lab2.Constants;

namespace Compilers.Lab2.DataStructures.SyntaxTree
{
	public class ElseNode : StatementNode
	{
		ExpressionNode Expression;
		StatementNode Statement1;
		StatementNode Statement2;

		public ElseNode(ExpressionNode expression, StatementNode statement1, StatementNode statement2)
		{
			Expression = expression;
			Statement1 = statement1;
			Statement2 = statement2;

			if (expression.Type != DataTypes.Bool)
			{
				expression.Error("Boolean statement required in if statement");
			}
		}
	}
}

