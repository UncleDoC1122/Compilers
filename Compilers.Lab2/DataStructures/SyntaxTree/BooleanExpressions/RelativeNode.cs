using System;
using Compilers.Lab2.Constants;
using Compilers.Lab2.Models;

namespace Compilers.Lab2.DataStructures.SyntaxTree
{
	public class RelativeNode : LogicalNode
	{
		public RelativeNode(Token token, ExpressionNode expression1, ExpressionNode expression2)
			: base(token, expression1, expression2)
		{
		}

		public override DataType Check(DataType type1, DataType type2)
		{
			if (type1.Tag == (int) Tags.Index || type2.Tag == (int) Tags.Index)
			{
				return null;
			}

			if (type1 == type2)
			{
				return DataTypes.Bool;
			}

			return null;
		}
	}
}

