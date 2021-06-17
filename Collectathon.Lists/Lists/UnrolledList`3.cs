using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Collectathon.Nodes;

namespace Collectathon.Lists {
	/// <summary>
	/// Represents any linked list where each node contains multiple elements.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the list.</typeparam>
	/// <typeparam name="TNode">The type of the nodes of the list.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	public abstract partial class UnrolledList<TElement, TNode, TSelf> : List<TElement, TNode, TSelf, UnrolledList<TElement, TNode, TSelf>.Enumerator>,
		IAddMemory<TElement>,
		IInsertMemory<nint, TElement>,
		IPostpendMemory<TElement>,
		IPrependMemory<TElement>
		where TNode : UnrolledListNode<TElement, TNode>
		where TSelf : UnrolledList<TElement, TNode, TSelf> {
		/// <summary>
		/// Initializes a new <see cref="UnrolledList{TElement, TNode, TSelf}"/>.
		/// </summary>
		protected UnrolledList() { }

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public sealed override TElement this[nint index] {
			get {
				throw new IndexOutOfRangeException();
			}
			set {
				throw new IndexOutOfRangeException();
			}
		}

		/// <inheritdoc/>
		public void Add([AllowNull] params TElement[] elements) => Postpend(elements);

		/// <inheritdoc/>
		public void Add(Memory<TElement> elements) => Postpend(elements);

		/// <inheritdoc/>
		public void Add(ReadOnlyMemory<TElement> elements) => Postpend(elements);

		/// <inheritdoc/>
		public sealed override Enumerator GetEnumerator() => new Enumerator(this);

		/// <inheritdoc/>
		public void Insert([DisallowNull] nint index, [AllowNull] params TElement[] elements) => Insert(index, elements.AsMemory());

		/// <inheritdoc/>
		public void Insert([DisallowNull] nint index, Memory<TElement> elements) => Insert(index, (ReadOnlyMemory<TElement>)elements);

		/// <inheritdoc/>
		public void Insert([DisallowNull] nint index, ReadOnlyMemory<TElement> elements) => throw new NotImplementedException();

		/// <inheritdoc/>
		public void Postpend([AllowNull] params TElement[] elements) => Postpend(elements.AsMemory());

		/// <inheritdoc/>
		public void Postpend(Memory<TElement> elements) => Postpend((ReadOnlyMemory<TElement>)elements);

		/// <inheritdoc/>
		public void Postpend(ReadOnlyMemory<TElement> elements) {
			if (Count > 0) {
				Tail!.Next = Tail!.Postpend(elements);
				Tail = Tail.Next;
			} else {
				Head = NewUnlinkedNode(elements);
				Tail = Head;
			}
			Count += elements.Length;
		}

		/// <inheritdoc/>
		public void Prepend([AllowNull] params TElement[] elements) => Prepend(elements.AsMemory());

		/// <inheritdoc/>
		public void Prepend(Memory<TElement> elements) => Prepend((ReadOnlyMemory<TElement>)elements);

		/// <inheritdoc/>
		public void Prepend(ReadOnlyMemory<TElement> elements) {
			if (Count > 0) {
				Head = Head!.Prepend(elements);
			} else {
				Head = NewUnlinkedNode(elements);
				Tail = Head;
			}
			Count += elements.Length;
		}

		/// <summary>
		/// Creates a new, unlinked, node.
		/// </summary>
		/// <param name="elements">The elements to put into the node.</param>
		/// <remarks>
		/// A node containing the <paramref name="elements"/> with no links to other nodes.
		/// </remarks>
		[return: NotNull]
		protected abstract TNode NewUnlinkedNode(ReadOnlyMemory<TElement> elements);
	}
}
