namespace KreatorDsl.Ast
{
	/// <summary>
	/// The base class for AST-nodes.
	/// </summary>
	public abstract class AstNode
	{
		/// <summary>
		/// Gets the position at which this node starts in the input string.
		/// </summary>
		public int Pos { get; private set; }

		/// <summary>
		/// Gets the line on which this node starts in the input string.
		/// </summary>
		public int Line { get; private set; }

		/// <summary>
		/// Gets the column on which this node starts in the input string.
		/// </summary>
		public int Column { get; private set; }

		/// <summary>
		/// Gets the length of the substring corresponding to this node.
		/// </summary>
		public int Length { get; private set; }

		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public sealed override string ToString()
		{
			return $"{GetType().Name}({ToStringImpl()}) at Line {Line}, Column {Column}, length {Length}.";
		}

		/// <summary>
		/// When overridden in a derived class, returns the string representation part
		/// specific to this particular AST Node class.
		/// </summary>
		public abstract string ToStringImpl();

		internal void SetPositionAndLength(int pos, int line, int column, int length)
		{
			Pos = pos;
			Line = line;
			Column = column;
			Length = length;
		}
	}
}