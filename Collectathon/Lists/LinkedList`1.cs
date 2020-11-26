using System;
using System.Diagnostics.CodeAnalysis;
using Collectathon.Filters;
using Langly;

namespace Collectathon.Lists {
	/// <summary>
	/// Represents any linked list.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
	/// <typeparam name="TSelf">THe implementing type; itself.</typeparam>
	/// <typeparam name="TNode">The type of the nodes that make up this list.</typeparam>
	/// <remarks>
	/// This is intended as a reusable base to make implementing custom lists easier. It can not be used on its own, as it's <see langword="abstract"/>. Rather, you derive this type, and also derive a <see cref="LinkedNode{TElement, TSelf}"/>, and pass your derived node into <typeparamref name="TNode"/>. This will create most of your list for you, with all links being of <typeparamref name="TNode"/>, not some base type that you have to upcast.
	/// </remarks>
	public abstract partial class LinkedList<TElement, TSelf, TNode> : DataStructure<TElement, TSelf, LinkedList<TElement, TSelf, TNode>.Enumerator>, IAddable<TElement>, IClearable, IContainable<TElement>, IDequeueable<TElement>, IEnqueueable<TElement>, IEquatable<LinkedList<TElement, TSelf, TNode>>, IIndexable<TElement>, IInsertable<TElement>, IPeekable<TElement>, IPoppable<TElement>, IPushable<TElement>, IRemovable<TElement>, IReplaceable<TElement> where TSelf : LinkedList<TElement, TSelf, TNode> where TNode : LinkedNode<TElement, TNode> {
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
		public ref TElement this[nint index] {
			get {
				TNode N = Head;
				nint i = 0;
				while (N is not null) {
					if (i++ == index) {
						return ref N.Element;
					}
					N = N.Next;
				}
				throw new ArgumentOutOfRangeException(nameof(index));
			}
		}

		/// <inheritdoc/>
		ref readonly TElement IReadOnlyIndexable<nint, TElement>.this[nint index] => ref this[index];

		/// <inheritdoc/>
		void IClearable.Clear() {
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
		Boolean IContainable<TElement>.Contains(TElement element) => Contains(element);

		/// <inheritdoc/>
		TElement IDequeueable<TElement>.Dequeue() => Pop();

		/// <inheritdoc/>
		void IEnqueueable<TElement>.Enqueue(TElement element) => Add(element);

		/// <inheritdoc/>
		public sealed override Boolean Equals(DataStructure<TElement, TSelf, Enumerator> other) {
			switch (other) {
			case LinkedList<TElement, TSelf, TNode> list:
				return Equals(list);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		[SuppressMessage("Microsoft.Design", "UnhandledExceptions:Unhandled exception(s)", Justification = "We can't magically add these to an interface we don't own.")]
		public Boolean Equals(LinkedList<TElement, TSelf, TNode> other) {
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
		public sealed override Boolean Equals(TElement[] other) {
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
		void IInsertable<nint, TElement>.Insert(nint index, TElement element) => Insert(index, element);

		/// <inheritdoc/>
		public ref readonly TElement Peek() {
			if (Head is null) {
				throw new InvalidOperationException("Collection is empty");
			}
			return ref Head.Element;
		}

		/// <inheritdoc/>
		TElement IPoppable<TElement>.Pop() => Pop();

		/// <inheritdoc/>
		void IPushable<TElement>.Push(TElement element) => Push(element);

		/// <inheritdoc/>
		void IRemovable<TElement>.Remove(TElement element) => Remove(element);

		/// <inheritdoc/>
		void IRemovable<TElement>.Remove(Predicate<TElement> match) => Remove(match);

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
		void IAddable<TElement>.Add(TElement element) => Add(element);

		/// <inheritdoc/>
		protected abstract void Add(TElement element);

		/// <inheritdoc/>
		protected virtual Boolean Contains(TElement element) {
			if (Filterer.FiltersContains && Filterer.Contains(element).Not().Possible()) {
				return false;
			}
			TNode N = Head;
			while (N is not null) {
				if (N.Element?.Equals(element) ?? false) {
					return true;
				}
				N = N.Next;
			}
			return false;
		}

		/// <inheritdoc/>
		protected abstract void Insert(nint index, TElement element);

		/// <inheritdoc/>
		protected abstract TElement Pop();

		/// <inheritdoc/>
		protected abstract void Push(TElement element); //TODO: We could implement this here if we could get information about the constructor, without reflection.

		/// <inheritdoc/>
		protected abstract void Remove(TElement element);

		/// <inheritdoc/>
		protected abstract void Remove(Predicate<TElement> match);
	}
}
