// See https://aka.ms/new-console-template for more information
using Compilers.Lab2;
using Compilers.Lab2.DataStructures.SyntaxTree;

LexemAnalyzer analyzer = new LexemAnalyzer("./Examples/Example1.txt");
Parser parser = new Parser(analyzer);

var syntaxTree = parser.Program(); 

Console.ReadKey();