using Compilers.Lab1.Constants;

namespace Compilers.Lab1.Models
{
	public class Lexem
	{
		public LexemTypes Type { get; private set; }
		public int Lex { get; private set; }
		public string Value { get; private set; }

		/// <summary>
		/// Creates a new lexem object
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="_lex"></param>
		/// <param name="_val"></param>
		public Lexem(LexemTypes _type, int _lex, string _val)
		{
			Type = _type;
			Lex = _lex;
			Value = _val;
		}

		public override string ToString()
		{
			return $"lexem type: {Type};\t lexem id: {Lex};\t value: {Value}";
		}
	}
}

