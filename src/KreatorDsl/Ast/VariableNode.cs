namespace KreatorDsl.Ast
{
	/// <summary>
	///   Represents a variable.
	/// </summary>
	public class VariableNode : ValueNode
	{
		/// <summary>
		///   Initializes a new instance of the <see cref="VariableNode" /> class.
		/// </summary>
		/// <param name="variable">The variable name.</param>
		public VariableNode(string variable)
		{
			Variable = variable;
		}

		/// <summary>
		///   Gets the variable name.
		/// </summary>
		public string Variable { get; }

		/// <summary>
		///   Returns the string representation part
		///   specific to this particular AST Node class.
		/// </summary>
		public override string ToStringImpl()
		{
			return Variable;
		}
	}
}