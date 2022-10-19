using System;
using Compilers.Lab2.Constants;

namespace Compilers.Lab2.Models
{
	public class ArrayType : DataType
	{
		public DataType Of;
		public int Size = 1;

		public ArrayType(int size, DataType type) : base("[]", (int) Tags.Index, size * type.Width)
		{
			Of = type;
			Size = size;
		}

		public override string ToString()
		{
			return $"[{Size}] {Of}";
		}
	}
}

