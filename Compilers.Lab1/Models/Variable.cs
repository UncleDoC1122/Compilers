using System;
using Compilers.Lab1.Constants;
namespace Compilers.Lab1.Models
{
	public class Variable
	{
		public int Id { get; private set; }
		public string DataType { get; private set; }
		public string Name { get; private set; }

		public Variable(int _id, string _dataType, string _varName)
		{
			Id = _id;
			DataType = _dataType;
			Name = _varName;
		}

		public override string ToString()
		{
			return $"<{Id}> Variable of type <{DataType}> with name <{Name}>";
		}
	}
}

