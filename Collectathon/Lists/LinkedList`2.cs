using Collectathon.Filters;
using Collectathon.Views;
using Langly;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Collectathon.Lists {
	/// <summary>
	/// Represents any linked list.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the collection.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
	/// <typeparam name="TNode">The type of the nodes that make up this list.</typeparam>
	/// <remarks>
	/// This is intended as a reusable base to make implementing custom associative lists easier. It can not be used on its own, as it's <see langword="abstract"/>. Rather, you derive this type, and also derive a <see cref="LinkedNode{TIndex, TElement, TNode}"/>, and pass your derived node into <typeparamref name="TNode"/>. This will create most of your list for you, with all links being of <typeparamref name="TNode"/>, not some base type that you have to upcast.
	/// </remarks>
	public abstract partial class LinkedList<TIndex, TElement, TSelf, TNode> : DataStructure<TIndex, TElement, TSelf, LinkedList<TIndex, TElement, TSelf, TNode>.Enumerator>, IAddable<TIndex, TElement>, IAssociator<TIndex, TElement, LinkedList<TIndex, TElement, TSelf, TNode>, LinkedList<TIndex, TElement, TSelf, TNode>.Enumerator>, IClearable, IEquatable<LinkedList<TIndex, TElement, TSelf, TNode>>, IIndexable<TIndex, TElement>, IRemovable<TIndex, TElement>, IReplaceable<TElement> where TIndex : IEquatable<TIndex> where TSelf : LinkedList<TIndex, TElement, TSelf, TNode> where TNode : LinkedNode<TIndex, TElement, TNode> {
		/// <summary>
		/// The node at the head of the list.
		/// </summary>
		protected TNode Head;

		/// <summary>
		/// The node at the tail of the list.
		/// </summary>
		protected TNode Tail;

		/// <summary>
		/// Initializes a new <see cref="LinkedList{TElement, TSelf, TNode}"/>.
		/// </summary>
		/// <param name="filter">The type of filter to use.</param>
		protected LinkedList(Filter filter) : base(filter) { }

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="filterer">The <see cref="Filter{TElement}"/> responsible for this data structure.</param>
		protected LinkedList(Filter<TElement> filterer) : base(filterer) { }

		/// <inheritdoc/>
		public nint Count { get; protected set; }

		/// <inheritdoc/>
		public ElementView<TIndex, TElement, LinkedList<TIndex, TElement, TSelf, TNode>, Enumerator> Elements => new ElementView<TIndex, TElement, LinkedList<TIndex, TElement, TSelf, TNode>, Enumerator>(this);

		/// <inheritdoc/>
		public IndexView<TIndex, TElement, LinkedList<TIndex, TElement, TSelf, TNode>, Enumerator> Indicies => new IndexView<TIndex, TElement, LinkedList<TIndex, TElement, TSelf, TNode>, Enumerator>(this);

		/// <inheritdoc/>
		public ref TElement this[TIndex index] {
			get {
				TNode N = Head;
				while (N is not null) {
					if (index.Equals(N.Index)) {
						return ref N.Element;
					}
					N = N.Next;
				}
				throw new ArgumentOutOfRangeException(nameof(index));
			}
		}

		/// <inheritdoc/>
		ref readonly TElement IReadOnlyIndexable<TIndex, TElement>.this[TIndex index] => ref this[index];

		/// <inheritdoc/>
		void IAddable<TIndex, TElement>.Add(TIndex index, TElement element) => Add(index, element);

		/// <inheritdoc/>
		public void Clear() {
			TNode P = Head;
			TNode N = Head?.Next;
			while (P is not null) {
				P.Clear();
				P = N;
				N = N?.Next;
				Count--;
			}
			Head = null;
			Tail = null;
		}

		/// <inheritdoc/>
		public sealed override Boolean Equals(DataStructure<TIndex, TElement, TSelf, Enumerator> other) {
			switch (other) {
			case LinkedList<TIndex, TElement, TSelf, TNode> list:
				return Equals(list);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		[SuppressMessage("Microsoft.Design", "UnhandledExceptions:Unhandled exception(s)", Justification = "We can't magically add these to an interface we don't own.")]
		public Boolean Equals(LinkedList<TIndex, TElement, TSelf, TNode> other) {
			// We're calling this off an instance, so if the other is null
			if (other is null) {
				// They aren't equal
				return false;
			}
			// Check the lengths of each, since that's a really quick inequality
			if (Count != other.Count) {
				// They aren't equal
				return false;
			}
			// Get enumerators for each
			Enumerator ths = GetEnumerator();
			Enumerator oth = other.GetEnumerator();
			// Now iterate through both
			while (ths.MoveNext() && oth.MoveNext()) {
				// If the current elements are not equal to each other
				if (!Equals(ths.Current, oth.Current)) {
					// They aren't equal
					return false;
				}
			}
			// We've validated that the enumerables are the same length and contain the same elements in the same order, so are therefore equal
			return true;
		}

		/// <inheritdoc/>
		public sealed override Boolean Equals(Association<TIndex, TElement>[] other) {
			// We're calling this off an instance, so if the other is null
			if (other is null) {
				// They aren't equal
				return false;
			}
			// Check the lengths of each, since that's a really quick inequality
			if (Count != other.Length) {
				// They aren't equal
				return false;
			}
			// Get enumerator for this list
			Enumerator ths = GetEnumerator();
			// And index for the array
			nint o = 0;
			// Now iterate through both
			while (ths.MoveNext() && o < other.Length) {
				// If the current elements are not equal to each other
				if (!Equals(ths.Current, other[o++])) {
					// They aren't equal
					return false;
				}
			}
			// We've validated that the enumerable and array are the same length and contain the same elements in the same order, so are therefore equal
			return true;
		}

		/// <inheritdoc/>
		void IRemovable<TElement>.Remove(TElement element) => Remove(element);

		/// <inheritdoc/>
		void IRemovable<TElement>.Remove(Predicate<TElement> match) => Remove(match);

		/// <inheritdoc/>
		void IRemovable<TIndex, TElement>.RemoveAt(TIndex index) => RemoveAt(index);

		/// <inheritdoc/>
		void IReplaceable<TElement, TElement>.Replace(TElement oldElement, TElement newElement) {
			TNode N = Head;
			while (N is not null) {
				if (N.Element?.Equals(oldElement) ?? false) {
					N.Element = newElement;
				}
				N = N.Next;
			}
		}

		/// <inheritdoc/>
		void IReplaceable<TElement, TElement>.Replace(Predicate<TElement> match, TElement newElement) {
			if (match is null) {
				return;
			}
			TNode N = Head;
			while (N is not null) {
				if (match(N.Element)) {
					N.Element = newElement;
				}
				N = N.Next;
			}
		}

		/// <inheritdoc/>
		protected abstract void Add(TIndex index, TElement element);

		/// <inheritdoc/>
		protected abstract void Remove(TElement element);

		/// <inheritdoc/>
		protected abstract void Remove(Predicate<TElement> match);

		/// <inheritdoc/>
		protected abstract void RemoveAt(TIndex index);
	}
}
