using System;
using Compilers.Lab2.Constants;
using Compilers.Lab2.Infrastructure;
using Compilers.Lab2.Models;

namespace Compilers.Lab2.DataStructures.SyntaxTree
{
	public class UnaryNode : OperationNode
	{
		public ExpressionNode Expression;

		public UnaryNode(Token token, ExpressionNode expression) : base(token, null)
		{
			Expression = expression;
			Type = DataTypesRules.Maximize(DataTypes.Int, expression.Type);

			if (Type == null)
			{
				Error("Type error");
			}
		}

		public override ExpressionNode Generate()
		{
			return new UnaryNode(Operation, Expression.Reduce());
		}

		public override string ToString()
		{
			return $"{Operation} {Expression}";
		}
	}
}

