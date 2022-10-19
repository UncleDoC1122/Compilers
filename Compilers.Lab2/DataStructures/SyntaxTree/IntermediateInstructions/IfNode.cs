using System;
using Compilers.Lab2.Constants;

namespace Compilers.Lab2.DataStructures.SyntaxTree
{
	public class IfNode : StatementNode
	{
		ExpressionNode Expression;
		StatementNode Statement;

		public IfNode(ExpressionNode expression, StatementNode statement)
		{
			Expression = expression;
			Statement = statement;

			if (Expression.Type != DataTypes.Bool)
			{
				Expression.Error($"If statement requires boolean construction");
			}
		}
	}
}

