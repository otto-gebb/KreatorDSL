namespace KreatorDsl.Ast
{
	/// <summary>
	/// Repreaents a dimensioned value (an integer with a unit of measure).
	/// </summary>
	public class DimensionedNode : ValueNode
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DimensionedNode"/> class.
		/// </summary>
		/// <param name="integerValue">The integer value.</param>
		/// <param name="unit">The unit of measure.</param>
		public DimensionedNode(int integerValue, string unit)
		{
			IntegerValue = integerValue;
			Unit = unit;
		}

		/// <summary>
		/// Gets the integer value.
		/// </summary>
		public int IntegerValue { get; }

		/// <summary>
		/// Gets the unit of measure.
		/// </summary>
		public string Unit { get; }

		/// <summary>
		/// Returns the string representation part
		/// specific to this particular AST Node class.
		/// </summary>
		public override string ToStringImpl()
		{
			return $"{IntegerValue}<{Unit}>";
		}
	}
}