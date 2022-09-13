using System;
namespace Compilers.Lab1.Constants
{
	public static class Constants
	{
		//Contains search criteria for data type lexems and attributes list for it (for now - id + comment)
		public static readonly Dictionary<string, (int, string)> Types = new Dictionary<string, (int, string)>() {
			{ "int", (0, "32-bit integer") },
			{ "uint", (1, "32-bit unsigned integer") },
			{ "long", (2, "64-bit integer") },
			{ "ulong", (3, "64-bit unsigned integer") },
			{ "string", (4, "string of chars")},
		};

		public static readonly Dictionary<string, (int, string)> Operators = new Dictionary<string, (int, string)>() {
			{"=", (0, "assign_operation")},
			{"+", (1, "sum_operation")},
			{"-", (2, "subtract_operation")},
			{"*", (3, "multiply_operation")},
			{"/", (4, "divide_operation")},
			{"+=", (5, "add_amount_operation")},
			{"-=", (6, "subtract_amount_operation")},
			{"==", (7, "are_equal_operation")},
			{">", (8, "more_operation")},
			{"<", (9, "less_operation")},
			{"++", (10, "increment_operation")},
			{"--", (11, "decrement_operation")},
			{"%", (12, "modulo_operation")},
		};
		public static readonly string[] Keywords = { "class", "public", "private", "for", "return", "if", "else", "while" };

		public static readonly string[] KeySymbols = { ".", ";", ",", "(", ")", "[", "]", "{", "}" };
	}
}

