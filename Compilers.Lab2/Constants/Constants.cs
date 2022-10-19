using System;
using Compilers.Lab2.DataStructures.SyntaxTree;

namespace Compilers.Lab2.Constants
{
	public static class Constants
	{
		public static ConstantNode True = new ConstantNode(Words.True, DataTypes.Bool);
		public static ConstantNode False = new ConstantNode(Words.False, DataTypes.Bool);
	}
}

