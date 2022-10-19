using System;
namespace Compilers.Lab2.DataStructures.SyntaxTree
{
	public class SyntaxTreeNode
	{
		public int LexLine = 0;

		public SyntaxTreeNode()
		{
		}

		public void Error(string s)
		{
			throw new Exception($"Error around {LexLine}: s");
		}
	}
}

