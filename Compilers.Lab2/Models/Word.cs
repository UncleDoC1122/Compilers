using System;
namespace Compilers.Lab2.Models
{
	public class Word : Token
	{
		public string Lexeme = "";

		public Word(string lexeme, int tag) : base(tag)
		{
			Lexeme = lexeme;
		}

		public override string ToString()
		{
			return Lexeme;
		}
	}
}

