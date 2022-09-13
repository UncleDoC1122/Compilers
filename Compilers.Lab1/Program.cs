using Compilers.Lab1;

LexemProcessor processor = new LexemProcessor();
var result = processor.ProcessFile("./Examples/Example1.txt");

Console.WriteLine("Lexems: ");
Console.WriteLine("================================================");
foreach (var lexem in result.Item1)
{
	Console.WriteLine(lexem.ToString());
}
Console.WriteLine("================================================");
Console.WriteLine("Variables: ");
foreach (var variable in result.Item2)
{
	Console.WriteLine(variable.ToString());
}
Console.WriteLine("================================================");

Console.Read();
