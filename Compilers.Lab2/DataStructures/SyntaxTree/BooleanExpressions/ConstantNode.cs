using Compilers.Lab2.Constants;
using Compilers.Lab2.Models;
using DataType = Compilers.Lab2.Models.DataType;

namespace Compilers.Lab2.DataStructures.SyntaxTree
{
	public class ConstantNode : ExpressionNode
	{
		public ConstantNode(Token token, DataType dataType) : base (token, dataType) 
		{
		}

		public ConstantNode(int number) : base(new Num(number), DataTypes.Int)
		{
		}
	}
}

