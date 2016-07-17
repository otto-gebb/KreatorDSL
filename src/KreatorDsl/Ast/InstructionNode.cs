namespace KreatorDsl.Ast
{
	using System.Collections.Generic;
	using Sprache;

	/// <summary>
	///   Represents an instruction.
	/// </summary>
	public class InstructionNode : AstNode
	{
		private readonly Dictionary<string, NamedArgNode> _namedArgMap;

		/// <summary>
		///   Initializes a new instance of the <see cref="InstructionNode" /> class.
		/// </summary>
		/// <param name="name">The instruction name.</param>
		/// <param name="args">The positional arguments.</param>
		/// <param name="namedArgs">The named arguments.</param>
		/// <param name="variable">
		///   The variable associated with the result of the instruction.
		/// </param>
		public InstructionNode(
			string name,
			ValueNode[] args,
			NamedArgNode[] namedArgs,
			string variable)
		{
			Name = name;
			Args = args;
			_namedArgMap = new Dictionary<string, NamedArgNode>();
			foreach (NamedArgNode namedArg in namedArgs)
			{
				if (_namedArgMap.ContainsKey(namedArg.Name))
				{
					throw new ParseException(
						"Ambiguous named argument specification " +
						$"while parsing '{namedArg}'." +
						$"The argument '{namedArg.Name}' was specified more than once.");
				}
				_namedArgMap.Add(namedArg.Name, namedArg);
			}

			NamedArgs = namedArgs;
			Variable = variable;
		}

		/// <summary>
		///   Gets the instruction name.
		/// </summary>
		public string Name { get; }

		/// <summary>
		///   Gets the positional arguments.
		/// </summary>
		public ValueNode[] Args { get; }

		/// <summary>
		///   Gets the named arguments.
		/// </summary>
		public NamedArgNode[] NamedArgs { get; }

		/// <summary>
		///   Gets the variable associated with the result of the instruction.
		/// </summary>
		public string Variable { get; }

		/// <summary>
		///   Gets the named argument with the specified name.
		///   Returns null if the argument is not found.
		/// </summary>
		/// <param name="argName">The name of the argument.</param>
		/// <returns>The named argument.</returns>
		public NamedArgNode GetNamedArgOrDefault(string argName)
		{
			NamedArgNode arg;
			return _namedArgMap.TryGetValue(argName, out arg) ? arg : null;
		}

		/// <summary>
		///   Gets the positional argument at the specified position.
		///   Returns null if there are fewer positional arguments than the position implies.
		/// </summary>
		/// <param name="position">The position.</param>
		/// <returns>The argument.</returns>
		public ValueNode GetPositionalArgOrDefault(int position)
		{
			return position >= Args.Length ? null : Args[position];
		}

		/// <summary>
		///   Returns the string representation part
		///   specific to this particular AST Node class.
		/// </summary>
		public override string ToStringImpl()
		{
			return (Variable == null ? "" : Variable + "=")
				+ $"{Name}(...{Args.Length + NamedArgs.Length} args...)";
		}
	}
}