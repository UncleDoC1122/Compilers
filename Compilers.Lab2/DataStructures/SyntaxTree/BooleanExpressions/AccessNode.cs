using System;
using Compilers.Lab2.Constants;
using Compilers.Lab2.Models;

namespace Compilers.Lab2.DataStructures.SyntaxTree
{
	public class AccessNode : OperationNode
	{
		public IdentifierNode Array;
		public ExpressionNode Index;

		public AccessNode(IdentifierNode array, ExpressionNode index, DataType type)
			: base(new Word("[]", (int) Tags.Index), type)
		{
			Array = array;
			Index = index;
		}

		public override ExpressionNode Generate()
		{
			return new AccessNode(Array, Index.Reduce(), Type);
		}
	}
}

