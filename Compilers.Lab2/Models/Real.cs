using System;
using Compilers.Lab2.Constants;

namespace Compilers.Lab2.Models
{
	public class Real : Token
	{
		public double Value;

		public Real(double value) : base((int)Tags.Real)
		{
			Value = value; 
		}

		public override string ToString()
		{
			return $"{Value}";
		}
	}
}

