using System;
namespace Compilers.Lab2.Models
{
	public class Token
	{
		public int Tag { get; private set; }

		public Token(int tag)
		{
			Tag = tag;
		}

		public override string ToString()
		{
			return $"{Tag}";
		}
	}
}

