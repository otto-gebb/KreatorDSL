namespace KreatorDsl
{
	using System;
	using System.Linq;
	using Ast;
	using Sprache;

	/// <summary>
	///   Represents a parser of a list of KreatorDSL instructions.
	/// </summary>
	public static class InstructionParser
	{
		internal static readonly Func<char, Parser<char>> C = Parse.Char;

		internal static readonly Parser<ValueNode> Variable =
			Parse.Identifier(C('$'), Parse.LetterOrDigit)
				.Select(s => new VariableNode(s)).Named("Variable");

		internal static readonly Parser<ValueNode> Assignment =
			Variable.Token().Then(a => C('=').Return(a));

		internal static readonly Parser<string> Atom =
			Parse.Identifier(Parse.Letter, Parse.LetterOrDigit);

		internal static readonly Parser<ValueNode> Boolean =
			Parse.String("True").Or(Parse.String("False")).Text()
				.Select(s => new BooleanNode(s)).Named("Boolean literal");

		internal static CommentParser Comment = new CommentParser
		{
			Single = "#",
			NewLine = Environment.NewLine
		};

		internal static readonly Parser<ValueNode> Integer =
			Parse.Number.Select(s => new IntegerNode(s)).Named("Integer literal");

		internal static readonly Parser<ValueNode> DimensionedInteger = (
			from i in Integer
			from op in C('<')
			from unit in Atom
			from cl in C('>')
			select new DimensionedNode(((IntegerNode) i).IntegerValue, unit)).Named("Dimensioned integer");

		internal static readonly Parser<ValueNode> StringLiteral = (
			from text in Parse.CharExcept('\'').Many().Contained(C('\''), C('\'')).Text()
			select new StringNode(text)).Named("String literal");

		// Docs for X*-parsers: https://github.com/sprache/Sprache/issues/46
		internal static readonly Parser<ValueNode> SingleValue =
			StringLiteral.XOr(Variable).XOr(DimensionedInteger).Or(Integer).XOr(Boolean);

		internal static readonly Parser<ValueNode> LangPair =
			from lngFrom in Atom
			from arrow in Parse.String("->")
			from lngTo in Atom
			select new DirectionNode(lngFrom, lngTo) as ValueNode;

		internal static readonly Parser<ValueNode> List =
			from items in
			PosToken(SingleValue.XOr(LangPair))
				.XDelimitedBy(Token(C(',')))
				.Contained(C('['), C(']'))
			select new ListNode(items.ToArray()) as ValueNode;

		internal static readonly Parser<ValueNode> Arg = PosToken(SingleValue.XOr(List));

		internal static readonly Parser<NamedArgNode> KwArg = PosToken(
			from name in Atom
			from eq in Token(C('='))
			// Calling PosAware instead of PosToken here
			// to exclude the trailing comment from KwArg's position.
			from arg in SingleValue.XOr(List).PosAware()
			select new NamedArgNode(name, arg));

		internal static Parser<InstructionNode> Instruction =
			from w in Parse.WhiteSpace.Many().Text().Or(Comment.SingleLineComment).Many()
			from instuction in PosToken(
				from variable in Assignment.Optional()
				from instructionName in Token(Atom).Named("Instruction name")
				from operands in Arg.AtLeastOnce()
				from kwOperands in KwArg.Many()
				from semicolon in Token(C(';')).Named("Instruction terminator ';'")
				select new InstructionNode(
					instructionName,
					operands.ToArray(),
					kwOperands.ToArray(),
					(variable.GetOrDefault() as VariableNode)?.Variable))
			select instuction;

		private static Parser<T> PosAware<T>(this Parser<T> parser) where T : AstNode
		{
			return parser.Select(node => new PosAwareNode<T>(node)).Positioned().Select(x => x.Node);
		}

		private static Parser<T> PosToken<T>(this Parser<T> parser) where T : AstNode
		{
			// Make the parser of the "useful" part positioned.
			Parser<T> posAware = PosAware(parser);
			return Token(posAware);
		}

		private static Parser<T> Token<T>(Parser<T> parser)
		{
			Parser<char> whitespace = Parse.WhiteSpace.Except(Parse.LineEnd);
			return from leading in whitespace.Many()
				from item in parser
				from trailing in whitespace.Many()
				from comm in Comment.SingleLineComment.Optional()
				from le in Parse.LineEnd.Many()
				select item;
		}

		/// <summary>
		///   Parses the specified string that contains a sequence of instructions.
		/// </summary>
		/// <param name="s">The string to parse.</param>
		/// <returns>The parsed array of AST nodes representing instructions.</returns>
		public static InstructionNode[] FromString(string s)
		{
			InstructionNode[] result = Instruction.XAtLeastOnce().End().Parse(s).ToArray();
			return result;
		}
	}
}