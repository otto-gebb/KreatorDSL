namespace ParserRunner
{
	using System;
	using System.Linq;
	using KreatorDsl;
	using KreatorDsl.Ast;

	internal class Program
	{
		private static void Main(string[] args)
		{
			string s = @"# Kreator DSL sample
Widget                     # Instruction name.
 'x'                       # First arg.
 True $i 'o' 555 ['c', 1]  # More args (boolean, variable, string, integer, list).
 flags=[1, 2, 4]           # Named args go after regular ones.
 created=5<monthsAgo>      # Dimensioned value.
 dirs=[src->dst,           # Directions are allowed inside lists only.
  USD->EUR]                # Single line comments are possible almost after each token.
 x = 2;                    # Last arg.
$g1 = Gadget 'g1@email.com';
$g2 = Gadget 'g2@email.com';
Connnection $g1 $g1 state='active';";
			try
			{
				InstructionNode[] result = InstructionParser.FromString(s);
				Console.WriteLine(string.Join(";"+Environment.NewLine, result.Select(x => x.ToString())));
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			Console.ReadKey();

		}
	}
}