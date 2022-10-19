using System;
using Compilers.Lab2.Models;

namespace Compilers.Lab2.DataStructures.SyntaxTree
{
	public class ExpressionNode : SyntaxTreeNode
	{
		public Token Operation;
		public DataType Type;

		public ExpressionNode(Token operation, DataType type)
		{
			Operation = operation;
			Type = type;
		}

		public virtual ExpressionNode Generate()
		{
			return this;
		}

		public virtual ExpressionNode Reduce()
		{
			return this;
		}

		public override string ToString()
		{
			return Operation.ToString();
		}
	}
}

