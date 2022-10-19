using System;
using Compilers.Lab2.Models;

namespace Compilers.Lab2.Constants
{
	public static class DataTypes
	{
		public static DataType Int = new DataType("int", (int)Tags.Basic, 4);
		public static DataType Float = new DataType("float", (int)Tags.Basic, 8);
		public static DataType Char = new DataType("char", (int)Tags.Basic, 1);
		public static DataType Bool = new DataType("bool", (int)Tags.Basic, 1);
		public static DataType Array = new DataType("arr", (int)Tags.Basic, 1);
	}
}

