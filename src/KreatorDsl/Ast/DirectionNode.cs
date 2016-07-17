namespace KreatorDsl.Ast
{
	/// <summary>
	/// Represents a direction (an ordered pair of symbols like src->dst).
	/// </summary>
	public class DirectionNode : ValueNode
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DirectionNode"/> class.
		/// </summary>
		/// <param name="source">The source.</param>
		/// <param name="target">The target.</param>
		public DirectionNode(string source, string target)
		{
			Source = source;
			Target = target;
		}

		/// <summary>
		/// Gets the source.
		/// </summary>
		public string Source { get; }

		/// <summary>
		/// Gets the target.
		/// </summary>
		public string Target { get; }

		/// <summary>
		/// Returns the string representation part
		/// specific to this particular AST Node class.
		/// </summary>
		public override string ToStringImpl()
		{
			return $"{Source} -> {Target}";
		}
	}
}