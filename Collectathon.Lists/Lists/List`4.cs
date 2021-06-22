using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Collectathon.Nodes;

namespace Collectathon.Lists {
	/// <summary>
	/// Represents any linked list.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the list.</typeparam>
	/// <typeparam name="TNode">The type of the nodes of the list.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	/// <typeparam name="TEnumerator">The type of the enumerator for the list.</typeparam>
	[DebuggerDisplay("{ToString(5), nq}")]
	public abstract class List<TElement, TNode, TSelf, TEnumerator> :
		IAdd<TElement>,
		IClear,
		IContains<TElement>,
		IEquatable<TSelf>, IEquatable<List<TElement, TNode, TSelf, TEnumerator>>,
		IIndex<Int32, TElement>,
		IInsert<Int32, TElement>,
		IPostpend<TElement>,
		IPrepend<TElement>,
		IRemove<TElement>,
		IReplace<TElement>,
		ISequence<TElement, TEnumerator>
		where TNode : ListNode<TElement, TNode>
		where TSelf : List<TElement, TNode, TSelf, TEnumerator>
		where TEnumerator : struct, IEnumerator<TElement> {
		/// <summary>
		/// The head node of the list; the first element.
		/// </summary>
		[AllowNull, MaybeNull]
		protected TNode Head;

		/// <summary>
		/// The tail node of the list; the last element.
		/// </summary>
		[AllowNull, MaybeNull]
		protected TNode Tail;

		/// <summary>
		/// Initializes a new <see cref="List{TElement, TNode, TSelf, TEnumerator}"/>.
		/// </summary>
		protected List() { }

		/// <inheritdoc/>
		public Int32 Count { get; protected set; }

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public abstract TElement this[Int32 index] { get; set; }

		/// <inheritdoc/>
		[MemberNotNull(nameof(Head), nameof(Tail))] 
		public void Add([AllowNull] TElement element) => Postpend(element);

		/// <inheritdoc/>
		public void Clear() {
			Collection.Clear(Head);
			Head = null;
			Tail = null;
			Count = 0;
		}

		/// <inheritdoc/>
		public Boolean Contains([AllowNull] TElement element) => Collection.Contains(Head, element);

		/// <inheritdoc/>
		public sealed override Boolean Equals([AllowNull] Object obj) {
			switch (obj) {
			case TSelf other:
				return Equals(other);
			case List<TElement, TNode, TSelf, TEnumerator> other:
				return Equals(other);
			case System.Collections.Generic.IEnumerable<TElement> other:
				return Equals(other);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals([AllowNull] TSelf other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals([AllowNull] List<TElement, TNode, TSelf, TEnumerator> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals([AllowNull] System.Collections.Generic.IEnumerable<TElement> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public abstract TEnumerator GetEnumerator();

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.Generic.IEnumerator<TElement> System.Collections.Generic.IEnumerable<TElement>.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		[SuppressMessage("Major Bug", "S3249:Classes directly extending \"object\" should not call \"base\" in \"GetHashCode\" or \"Equals\"", Justification = "I'm literally enforcing correct behavior by ensuring downstream doesn't violate what this analyzer is trying to enforce...")]
		public sealed override Int32 GetHashCode() => base.GetHashCode();

		/// <inheritdoc/>
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public abstract void Insert(Int32 index, [AllowNull] TElement element);

		/// <inheritdoc/>
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public void Postpend([AllowNull] TElement element) {
			if (Count > 0) {
				Tail!.Next = Tail!.Postpend(element);
				Tail = Tail.Next;
			} else {
				Head = NewUnlinkedNode(element);
				Tail = Head;
			}
			Count++;
		}

		/// <inheritdoc/>
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public void Prepend([AllowNull] TElement element) {
			if (Count > 0) {
				Head = Head!.Prepend(element);
			} else {
				Head = NewUnlinkedNode(element);
				Tail = Head;
			}
			Count++;
		}

		/// <inheritdoc/>
		public abstract void Remove([AllowNull] TElement element);

		/// <inheritdoc/>
		public abstract void RemoveFirst([AllowNull] TElement element);

		/// <inheritdoc/>
		public abstract void RemoveLast([AllowNull] TElement element);

		/// <inheritdoc/>
		public void Replace([AllowNull] TElement search, [AllowNull] TElement replace) => Collection.Replace(Head, search, replace);

		/// <inheritdoc/>
		[return: NotNull]
		public sealed override String ToString() => Collection.ToString(Head, Count);

		/// <inheritdoc/>
		[return: NotNull]
		public String ToString(Int32 amount) => Collection.ToString(Head, Count, amount);

		/// <summary>
		/// Creates a new, unlinked, node.
		/// </summary>
		/// <param name="element">The element to put into the node.</param>
		/// <returns>A node containing the <paramref name="element"/> with no links to other nodes.</returns>
		[return: NotNull]
		protected abstract TNode NewUnlinkedNode([AllowNull] TElement element);
	}
}
