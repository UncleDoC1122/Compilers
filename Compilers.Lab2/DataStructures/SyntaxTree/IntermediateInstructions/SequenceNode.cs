using System;
namespace Compilers.Lab2.DataStructures.SyntaxTree.IntermediateInstructions
{
	public class SequenceNode : StatementNode
	{
		StatementNode Statement1;
		StatementNode Statement2;

		public SequenceNode(StatementNode statement1, StatementNode statement2)
		{
			Statement1 = statement1;
			Statement2 = statement2;
		}
	}
}

