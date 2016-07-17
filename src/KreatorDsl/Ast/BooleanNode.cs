namespace KreatorDsl.Ast
{
	/// <summary>
	/// Represents a boolean literal.
	/// </summary>
	public class BooleanNode : ValueNode
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BooleanNode"/> class.
		/// </summary>
		/// <param name="booleanValue">The boolean value.</param>
		public BooleanNode(string booleanValue)
		{
			BooleanValue = bool.Parse(booleanValue);
		}

		/// <summary>
		/// Gets the boolean value.
		/// </summary>
		public bool BooleanValue { get; }

		/// <summary>
		/// Returns the string representation part
		/// specific to this particular AST Node class.
		/// </summary>
		public override string ToStringImpl()
		{
			return BooleanValue.ToString();
		}
	}
}