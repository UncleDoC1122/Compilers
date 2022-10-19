using System;
namespace Compilers.Lab2.DataStructures.SyntaxTree
{
	public class StatementNode : SyntaxTreeNode
	{
		public StatementNode()
		{
		}

		public static StatementNode Null = new StatementNode();

		public void Generate(int a, int b) { }

		int After = 0;

		public static StatementNode Enclosing = StatementNode.Null;
	}
}

