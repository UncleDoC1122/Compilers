using System;
using Compilers.Lab1.Models;
using Compilers.Lab2.Constants;
using Compilers.Lab2.DataStructures.IdentifiersTable;
using Compilers.Lab2.DataStructures.SyntaxTree;
using Compilers.Lab2.DataStructures.SyntaxTree.IntermediateInstructions;
using Compilers.Lab2.Models;

namespace Compilers.Lab2
{
	public class Parser
	{
		private LexemAnalyzer Analyzer;
		private Token Lookahead;
		IdentifiersTable top = null;

		public Parser(LexemAnalyzer analyzer)
		{
			Analyzer = analyzer;
			Move();
		}

		public StatementNode Program()
		{
			StatementNode statementNode = Block();
			Console.WriteLine(statementNode.ToString());
			return statementNode;
		}

		private void Move()
		{
			Lookahead = Analyzer.ScanNext();
			if (Lookahead.Tag == '\0')
			{
				return;
			}
		}

		private void Error(string s)
		{
			throw new Exception($"Error in line {LexemAnalyzer.Line} {s}");
		}

		private void Match(int t)
		{
			if (Lookahead.Tag == t)
			{
				Move();
			}
			else
			{
				Error("Syntax error");
			}
		}

		private StatementNode Block()
		{
			Match('{');
			IdentifiersTable table = top;
			top = new IdentifiersTable(top);
			Declare();
			StatementNode node = Statements();
			Match('}');
			top = table;
			return node;
		}

		private void Declare()
		{
			while (Lookahead.Tag == (int)Tags.Basic)
			{
				DataType type = Type();
				Token token = Lookahead;
				Match((int) Tags.Id);
				Match(';');
				IdentifierNode node = new IdentifierNode((Word)token, type, 0);
				top.Put(token, node);
			}
		}

		private DataType Type()
		{
			DataType type = (DataType)Lookahead;
			Match((int)Tags.Basic);
			if (Lookahead.Tag != '[')
			{
				return type;
			}
			else
			{
				Error("Arrays are not supported yet");
				return null;
			}
		}

		private StatementNode Statements()
		{
			if (Lookahead.Tag == '}')
			{
				return StatementNode.Null;
			}
			else
			{
				return new SequenceNode(Statement(), Statements());
			}
		}

		private StatementNode Statement()
		{
			ExpressionNode expression;
			StatementNode statement,
				statement1,
				statement2,
				savedStatement;

			switch(Lookahead.Tag)
			{
				case ':':
					Move();
					return StatementNode.Null;
				case (int) Tags.If:
					Match((int)Tags.If);
					Match('(');
					expression = Bool();
					Match(')');
					statement1 = Statement();
					if (Lookahead.Tag != (int) Tags.Else)
					{
						return new IfNode(expression, statement1);
					}
					Match((int)Tags.Else);
					statement2 = Statement();
					return new ElseNode(expression, statement1, statement2);
				case (int)Tags.While:
					WhileNode whileNode = new WhileNode();
					savedStatement = StatementNode.Enclosing;
					StatementNode.Enclosing = whileNode;
					Match((int)Tags.While);
					Match('(');
					expression = Bool();
					Match(')');
					statement1 = Statement();
					whileNode.Init(expression, statement1);
					StatementNode.Enclosing = savedStatement;
					return whileNode;
				case (int)Tags.Do:
					DoNode doNode = new DoNode();
					savedStatement = StatementNode.Enclosing;
					StatementNode.Enclosing = doNode;
					Match((int)Tags.Do);
					statement1 = Statement();
					Match((int)Tags.While);
					Match('(');
					expression = Bool();
					Match(')');
					Match(';');
					doNode.Init(statement1, expression);
					StatementNode.Enclosing = savedStatement;
					return doNode;
				case (int)Tags.Break:
					Match((int)Tags.Break);
					Match(';');
					return new BreakNode();
				case '{':
					return Block();
				default:
					return Assign();
			}
		}

		private StatementNode Assign()
		{
			StatementNode statement;
			Token token = Lookahead;
			Match((int)Tags.Id);
			IdentifierNode identifier = top.Get(token);
			if (identifier == null)
			{
				Error($"Use of undeclared variable {token.ToString()}");
			}
			if (Lookahead.Tag == '=')
			{
				Move();
				statement = new SetNode(identifier, Bool());
			}
			else
			{
				AccessNode accessNode = Offset(identifier);
				Match('=');
				statement = new SetElementNode(accessNode, Bool());
			}
			Match(';');
			return statement;
		}

		private ExpressionNode Bool()
		{
			ExpressionNode expression = Join();
			while (Lookahead.Tag == (int)Tags.Or)
			{
				Token token = Lookahead;
				Move();
				expression = new OrNode(token, expression, Join());
			}
			return expression;
		}

		private ExpressionNode Join()
		{
			ExpressionNode expression = Equality();
			while (Lookahead.Tag == (int)Tags.And)
			{
				Token token = Lookahead;
				Move();
				expression = new AndNode(token, expression, Equality());
			}
			return expression;
		}

		private ExpressionNode Equality()
		{
			ExpressionNode expression = Relative();
			while (Lookahead.Tag == (int)Tags.Eq || Lookahead.Tag == (int)Tags.Ne)
			{
				Token token = Lookahead;
				Move();
				expression = new RelativeNode(token, expression, Relative());
			}
			return expression;
		}

		private ExpressionNode Relative()
		{
			ExpressionNode expression = Expression();
			switch (Lookahead.Tag)
			{
				case '<':
				case (int)Tags.Le:
				case (int)Tags.Ge:
				case '>':
					Token token = Lookahead;
					Move();
					return new RelativeNode(token, expression, Expression());
				default:
					return expression;
			}
		}

		private ExpressionNode Expression()
		{
			ExpressionNode expression = Term();
			while (Lookahead.Tag == '+'
				|| Lookahead.Tag == '-')
			{
				Token token = Lookahead;
				Move();
				expression = new ArithmeticNode(token, expression, Term());
			}
			return expression;
		}

		private ExpressionNode Term()
		{
			ExpressionNode expression = Unary();
			while (Lookahead.Tag == '*'
				|| Lookahead.Tag == '/')
			{
				Token token = Lookahead;
				Move();
				expression = new ArithmeticNode(token, expression, Unary());
			}
			return expression;
		}

		private ExpressionNode Unary()
		{
			if (Lookahead.Tag == '-')
			{
				Move();
				return new UnaryNode(Words.Minus, Unary());
			}
			else if (Lookahead.Tag == '!')
			{
				Token token = Lookahead;
				Move();
				return new NotNode(token, Unary());
			}
			else
			{
				return Factor();
			}
		}

		private ExpressionNode Factor()
		{
			ExpressionNode expressionNode = null;

			switch (Lookahead.Tag)
			{
				case '(':
					Move();
					expressionNode = Bool();
					Match(')');
					return expressionNode;
				case (int)Tags.Num:
					expressionNode = new ConstantNode(Lookahead, DataTypes.Int);
					Move();
					return expressionNode;
				case (int)Tags.Real:
					expressionNode = new ConstantNode(Lookahead, DataTypes.Float);
					Move();
					return expressionNode;
				case (int)Tags.True:
					expressionNode = Constants.Constants.True;
					Move();
					return expressionNode;
				case (int)Tags.False:
					expressionNode = Constants.Constants.False;
					Move();
					return expressionNode;
				case (int)Tags.Id:
					string s = Lookahead.ToString();
					IdentifierNode identifier = top.Get(Lookahead);
					if (identifier == null)
					{
						Error($"Use of undeclared variable {Lookahead}");
					}
					Move();
					if (Lookahead.Tag != '[')
					{
						return identifier;
					}
					else
					{
						return Offset(identifier);
					}
				default:
					Error("Syntax error");
					return expressionNode;
			}
		}

		private AccessNode Offset(IdentifierNode identifier)
		{
			ExpressionNode i,
				value, term1, term2, loc;

			DataType type = identifier.Type;

			Match('[');
			i = Bool();
			Match(']');

			type = DataTypes.Array;
			value = new ConstantNode(0);
			term1 = new ArithmeticNode(new Token('*'), i, value);
			loc = term1;

			while (Lookahead.Tag == '[')
			{
				Match('[');
				i = Bool();
				Match(']');
				type = DataTypes.Array;
				value = new ConstantNode(0);
				term1 = new ArithmeticNode(new Token('*'), i, value);
				term2 = new ArithmeticNode(new Token('+'), loc, term1);
				loc = term2;
			}

			return new AccessNode(identifier, loc, type);
		} 
	}
}

