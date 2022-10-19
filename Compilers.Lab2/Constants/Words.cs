using System;
using Compilers.Lab2.Models;

namespace Compilers.Lab2.Constants
{
	public static class Words
	{
		public static Word And = new Word("&&", (int)Tags.And);
		public static Word Or = new Word("||", (int)Tags.Or);
		public static Word Eq = new Word("==", (int)Tags.Eq);
		public static Word Ne = new Word("!=", (int)Tags.Ne);
		public static Word Le = new Word("<=", (int)Tags.Le);
		public static Word Ge = new Word(">=", (int)Tags.Ge);
		public static Word Minus = new Word("minus", (int)Tags.Minus);
		public static Word True = new Word("true", (int)Tags.True);
		public static Word False = new Word("false", (int)Tags.False);
		public static Word Temp = new Word("t", (int)Tags.Temp);
	}
}

