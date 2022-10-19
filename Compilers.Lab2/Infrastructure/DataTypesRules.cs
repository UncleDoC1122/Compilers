using System;
using Compilers.Lab2.Constants;
using Compilers.Lab2.Models;

namespace Compilers.Lab2.Infrastructure
{
	public static class DataTypesRules
	{
		public static bool IsNumeric(DataType p)
		{
			return (p == DataTypes.Char || p == DataTypes.Int || p == DataTypes.Float);
		}

		public static DataType? Maximize(DataType p1, DataType p2)
		{
			if (!IsNumeric(p1) || !IsNumeric(p2))
			{
				return null;
			}
			else if (p1 == DataTypes.Float || p2 == DataTypes.Float)
			{
				return DataTypes.Float;
			}
			else if (p1 == DataTypes.Int || p2 == DataTypes.Int)
			{
				return DataTypes.Int;
			}
			else
			{
				return DataTypes.Char;
			}
		}
	}
}

