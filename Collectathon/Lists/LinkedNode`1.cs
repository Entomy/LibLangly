namespace Collectathon.Lists {
	/// <summary>
	/// Represents any linked list node.
	/// </summary>
	/// <typeparam name="TElement">The type of the element in the node.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	/// <remarks>
	/// This is intended as a reusable base to make implementing nodes for custom lists easier. It can not be used on its own, both because it's <see langword="abstract"/> but also a CRTP receiver and would recurse if you tried to use it. Rather, you derive from this type, passing your derived type into <typeparamref name="TSelf"/>, and all the node links will be of <typeparamref name="TSelf"/>, not some base type that you have to upcast.
	/// </remarks>
	public abstract class LinkedNode<TElement, TSelf> : BaseNode<TElement, TSelf> where TSelf : LinkedNode<TElement, TSelf> {
		/// <summary>
		/// The next node.
		/// </summary>
		public TSelf Next;

		/// <inheritdoc/>
		protected LinkedNode(TElement element, TSelf next) : base(element) => Next = next;
	}
}
