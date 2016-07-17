namespace KreatorDsl.Ast
{
	using System.Linq;

	/// <summary>
	/// Represents a list.
	/// </summary>
	public class ListNode : ValueNode
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ListNode"/> class.
		/// </summary>
		/// <param name="items">The items.</param>
		public ListNode(ValueNode[] items)
		{
			Items = items;
		}

		/// <summary>
		/// Gets the list items.
		/// </summary>
		public ValueNode[] Items { get; }

		/// <summary>
		/// Returns the string representation part
		/// specific to this particular AST Node class.
		/// </summary>
		public override string ToStringImpl()
		{
			return "[" + string.Join(", ", Items.Select(i => i.ToStringImpl())) + "]";
		}
	}
}