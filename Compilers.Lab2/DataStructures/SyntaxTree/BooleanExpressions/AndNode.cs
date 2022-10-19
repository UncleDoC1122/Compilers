using System;
using Compilers.Lab2.Models;

namespace Compilers.Lab2.DataStructures.SyntaxTree
{
	public class AndNode : LogicalNode
	{
		public AndNode(Token token, ExpressionNode expression1, ExpressionNode expression2)
			: base(token, expression1, expression2)
		{
		}
	}
}

