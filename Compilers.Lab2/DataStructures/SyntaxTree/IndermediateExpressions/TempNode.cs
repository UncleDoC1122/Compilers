using System;
using Compilers.Lab2.Constants;
using Compilers.Lab2.Models;

namespace Compilers.Lab2.DataStructures.SyntaxTree
{
	public class TempNode : ExpressionNode
	{
		static int Count = 0;
		int Number = 0;

		public TempNode(DataType dataType) : base(Words.Temp, dataType)
		{
			Number = ++Count;
		}

		public override string ToString()
		{
			return $"t {Number}";
		}
	}
}

