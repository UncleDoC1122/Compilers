using System;
using Compilers.Lab2.Constants;
using Compilers.Lab2.Infrastructure;
using Compilers.Lab2.Models;

namespace Compilers.Lab2.DataStructures.SyntaxTree
{
	public class LogicalNode : ExpressionNode
	{
		public ExpressionNode Expression1, Expression2;

		public LogicalNode(Token token, ExpressionNode expression1, ExpressionNode expression2)
			: base(token, null)
		{
			Expression1 = expression1;
			Expression2 = expression2;

			Type = Check(Expression1.Type, Expression2.Type);
			if (Type == null)
			{
				Error("Type error");
			}
		}

		public virtual DataType? Check(DataType p1, DataType p2)
		{
			if (p1 == DataTypes.Bool && p2 == DataTypes.Bool)
			{
				return DataTypes.Bool;
			}
			return null;
		}
	}
}

