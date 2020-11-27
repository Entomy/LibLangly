using System;

namespace Langly.DataStructures.Lists {
	/// <summary>
	/// Represents any associative linked list node.
	/// </summary>
	/// <typeparam name="TIndex">The type of the index of the node.</typeparam>
	/// <typeparam name="TElement">The type of the element in the node.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	/// <remarks>
	/// This is intended as a reusable base to make implementing associative nodes for custom lists easier. It can not be used on its own, both because it's <see langword="abstract"/> but also a CRTP receiver and would recurse if you tried to use it. Rather, you derive from this type, passing your derived type into <typeparamref name="TSelf"/>, and all the node links will be of <typeparamref name="TSelf"/>, not some base type that you have to upcast.
	/// </remarks>
	public abstract class LinkedNode<TIndex, TElement, TSelf> : BaseNode<TIndex, TElement, TSelf> where TIndex : IEquatable<TIndex> where TSelf : LinkedNode<TIndex, TElement, TSelf> {
		/// <summary>
		/// The next node.
		/// </summary>
		public TSelf Next;

		/// <inheritdoc/>
		protected LinkedNode(TIndex index, TElement element, TSelf next) : base(index, element) => Next = next;
	}
}
