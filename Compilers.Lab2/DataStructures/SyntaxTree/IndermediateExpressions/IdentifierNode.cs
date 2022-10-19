using System;
using Compilers.Lab2.Models;

namespace Compilers.Lab2.DataStructures.SyntaxTree
{
	public class IdentifierNode : ExpressionNode
	{
		public int Offset;

		public IdentifierNode(Word id, DataType p, int offset) : base(id, p)
		{
			Offset = offset;
		}
	}
}

