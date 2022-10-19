﻿using System;
using System.Reflection;
using System.Text;
using Compilers.Lab2.Constants;
using Compilers.Lab2.Models;

namespace Compilers.Lab2
{
	public class LexemAnalyzer
	{
		public static int Line = 1;
		char Peek = ' ';
		Dictionary<string, Word> keywords = new Dictionary<string, Word>();
		private string FileContent;
		private int Pointer = 0;

		private void Reserve(Word word)
		{
			keywords.Add(word.Lexeme, word);
		}

		public LexemAnalyzer(string filePath)
		{
			Reserve(new Word("if",		(int)Tags.If));
			Reserve(new Word("else",	(int)Tags.Else));
			Reserve(new Word("while",	(int)Tags.While));
			Reserve(new Word("do",		(int)Tags.Do));
			Reserve(new Word("break",	(int)Tags.Break));
			Reserve(Words.True);
			Reserve(Words.False);
			Reserve(DataTypes.Int);
			Reserve(DataTypes.Char);
			Reserve(DataTypes.Float);
			Reserve(DataTypes.Bool);
			FileContent = File.ReadAllText(filePath);
		}

		void ReadChar()
		{
			if (Pointer == FileContent.Length)
			{
				Peek = '\0';
			}
			else
			{
				Peek = FileContent[Pointer++];
			}
		}

		bool ReadChar(char c)
		{
			ReadChar();
			if (Peek != c)
			{
				return false;
			}
			Peek = ' ';
			return true;
		}

		public Token ScanNext()
		{
			for (; ; ReadChar())
			{
				if (Peek == ' ' || Peek == '\t')
				{
					continue;
				}
				else if (Peek == '\0')
				{
					return new Token('\0');
				}
				else if (Peek == '\n')
				{
					Line = Line + 1;
				}
				else
				{
					break;
				}
			}

			switch(Peek)
			{
				case '&':
					if (ReadChar('&'))
					{
						return Words.And;
					}
					else
					{
						return new Token('&');
					}
				case '|':
					if (ReadChar('|'))
					{
						return Words.Or;
					}
					else
					{
						return new Token('|');
					}
				case '=':
					if (ReadChar('='))
					{
						return Words.Eq;
					}
					else
					{
						return new Token('=');
					}
				case '!':
					if (ReadChar('='))
					{
						return Words.Ne;
					}
					else
					{
						return new Token('!');
					}
				case '<':
					if (ReadChar('='))
					{
						return Words.Le;
					}
					else
					{
						return new Token('<');
					}
				case '>':
					if (ReadChar('='))
					{
						return Words.Ge;
					}
					else
					{
						return new Token('>');
					}
			}

			if (char.IsDigit(Peek))
			{
				int value = 0;
				do
				{
					value = 10 * value + Convert.ToInt32(Peek);
					ReadChar();
				} while (char.IsDigit(Peek));

				if (Peek != '.')
				{
					return new Num(value);
				}

				float fValue = value;
				float d = 10;

				for (; ; )
				{
					ReadChar();
					if (!char.IsDigit(Peek))
					{
						break;
					}
					fValue = fValue + Convert.ToInt32(Peek) / d;
					d = d * 10;
				}

				return new Real(fValue);
			}

			if (char.IsLetter(Peek))
			{
				StringBuilder buffer = new StringBuilder();

				do
				{
					buffer.Append(Peek);
					ReadChar();
				} while (char.IsLetterOrDigit(Peek));

				string s = buffer.ToString();
				bool isKeyword = keywords.ContainsKey(s);
				if (isKeyword)
				{
					return keywords[s];
				}

				Word word = new Word(s, (int)Tags.Id);
				keywords.Add(s, word);
				return word;
			}

			Token token = new Token(Peek);
			Peek = ' ';
			return token;
		}
	}
}

