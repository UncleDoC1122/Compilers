using System;
using Compilers.Lab2.DataStructures.SyntaxTree;
using Compilers.Lab2.Models;

namespace Compilers.Lab2.DataStructures.IdentifiersTable
{
	public class IdentifiersTable
	{
		private Dictionary<Token, IdentifierNode> _table;
		protected IdentifiersTable _previous;

		public IdentifiersTable(IdentifiersTable prev)
		{
			_table = new Dictionary<Token, IdentifierNode>();
			_previous = prev;
		}

		public void Put(Token token, IdentifierNode identifier)
		{
			_table.Add(token, identifier);
		}

		public IdentifierNode? Get(Token token)
		{
			for (IdentifiersTable t = this; t != null; t = t._previous)
			{
				if (t._table.ContainsKey(token))
				{
					return t._table[token];
				}
			}

			return null;
		}
	}
}

