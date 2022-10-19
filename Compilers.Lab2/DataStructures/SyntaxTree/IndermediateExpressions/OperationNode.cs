using System;
using Compilers.Lab2.Models;

namespace Compilers.Lab2.DataStructures.SyntaxTree
{
	public class OperationNode : ExpressionNode
	{
		public OperationNode(Token token, DataType type) : base(token, type)
		{

		}

		public override ExpressionNode Reduce()
		{
			ExpressionNode expression = Generate();
			TempNode t = new TempNode(Type);
			return t;
		}
	}
}

