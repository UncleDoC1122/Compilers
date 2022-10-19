using System;
using Compilers.Lab2.Models;

namespace Compilers.Lab2.DataStructures.SyntaxTree
{
	public class NotNode : LogicalNode
	{
		public NotNode(Token token, ExpressionNode expression1)
			: base(token, expression1, expression1)
		{
		}

		public override string ToString()
		{
			return $"{Operation} {Expression1}";
		}
	}
}

