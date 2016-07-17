namespace KreatorDsl.Ast
{
	/// <summary>
	/// Represents a named argument.
	/// </summary>
	public class NamedArgNode : AstNode
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="NamedArgNode"/> class.
		/// </summary>
		/// <param name="name">The argument name.</param>
		/// <param name="argNode">The argument node.</param>
		public NamedArgNode(string name, ValueNode argNode)
		{
			Name = name;
			ArgNode = argNode;
		}

		/// <summary>
		/// Gets the argument name.
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Gets the argument node.
		/// </summary>
		public ValueNode ArgNode { get; }

		/// <summary>
		/// Returns the string representation part
		/// specific to this particular AST Node class.
		/// </summary>
		public override string ToStringImpl()
		{
			return $"{Name} = {ArgNode.ToStringImpl()}";
		}
	}
}