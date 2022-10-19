using System;
using Compilers.Lab2.Constants;

namespace Compilers.Lab2.Models
{
	public class Num : Token
	{
		public int Value { get; private set; }

		public Num(int val) : base((int)Tags.Num)
		{
			Value = val;
		}

		public override string ToString()
		{
			return $"{Value}";
		}
	}
}

