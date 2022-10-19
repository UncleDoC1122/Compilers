using System;
using Compilers.Lab2.Infrastructure;
using Compilers.Lab2.Models;

namespace Compilers.Lab2.DataStructures.SyntaxTree
{
	public class ArithmeticNode : OperationNode
	{
		public ExpressionNode Expression1, Expression2;

		public ArithmeticNode(Token token, ExpressionNode expression1, ExpressionNode expression2) : base(token, null)
		{
			Expression1 = expression1;
			Expression2 = expression2;

			Type = DataTypesRules.Maximize(expression1.Type, expression2.Type);
			if (Type == null)
			{
				this.Error("Type error");
			}
		}

		public override ExpressionNode Generate()
		{
			return new ArithmeticNode(this.Operation, this.Expression1, this.Expression2);
		}

		public override string ToString()
		{
			return $"{Expression1} {Operation} {Expression2}";
		}
	}
}

