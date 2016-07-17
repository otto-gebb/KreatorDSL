namespace KreatorDsl.Ast
{
	/// <summary>
	/// Represents an integer literal.
	/// </summary>
	public class IntegerNode : ValueNode
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="IntegerNode"/> class.
		/// </summary>
		/// <param name="integerValue">The integer value.</param>
		public IntegerNode(string integerValue)
		{
			IntegerValue = int.Parse(integerValue);
		}

		/// <summary>
		/// Gets the integer value.
		/// </summary>
		public int IntegerValue { get; }

		/// <summary>
		/// Returns the string representation part
		/// specific to this particular AST Node class.
		/// </summary>
		public override string ToStringImpl()
		{
			return IntegerValue.ToString();
		}
	}
}