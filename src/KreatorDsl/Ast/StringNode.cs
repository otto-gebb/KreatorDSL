namespace KreatorDsl.Ast
{
	/// <summary>
	/// Represents a string literal.
	/// </summary>
	public class StringNode : ValueNode
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="StringNode"/> class.
		/// </summary>
		/// <param name="stringValue">The string value.</param>
		public StringNode(string stringValue)
		{
			StringValue = stringValue;
		}

		/// <summary>
		/// Gets the string value.
		/// </summary>
		public string StringValue { get; }

		/// <summary>
		/// Returns the string representation part
		/// specific to this particular AST Node class.
		/// </summary>
		public override string ToStringImpl()
		{
			return $"'{StringValue}'";
		}
	}
}