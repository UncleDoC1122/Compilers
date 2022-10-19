using System;
namespace Compilers.Lab2.DataStructures.SyntaxTree.IntermediateInstructions
{
	public class BreakNode : StatementNode
	{
		StatementNode Statement;

		public BreakNode()
		{
			if (StatementNode.Enclosing == null)
			{
				Error("Unenclosed break");
			}
			Statement = StatementNode.Enclosing;
		}
	}
}

