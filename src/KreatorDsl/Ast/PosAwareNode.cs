namespace KreatorDsl.Ast
{
    using Sprache;

    /// <summary>
	/// Wraps an AST-node such that Sprache
	/// can set the position in the input string where the node was found.
	/// </summary>
	/// <typeparam name="TNode">The type of the contained node.</typeparam>
	internal class PosAwareNode<TNode> : IPositionAware<PosAwareNode<TNode>> where TNode: AstNode
	{
		public PosAwareNode(TNode node)
		{
			Node = node;
		}

		public TNode Node { get; set; }

		public PosAwareNode<TNode> SetPos(Position startPos, int length)
		{
			Node.SetPositionAndLength(startPos.Pos, startPos.Line, startPos.Column, length);
			return this;
		}
	}
}