using System;
namespace Compilers.Lab2.Models
{
	public class DataType : Word
	{
		public int Width = 0;

		public DataType(string lexeme, int tag, int width) : base (lexeme, tag)
		{
			Width = width;
		}
	}
}

