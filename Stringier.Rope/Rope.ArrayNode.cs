using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using System.Traits.Concepts;

namespace Stringier {
	public partial class Rope {
		/// <summary>
		/// Represents a node of a <see cref="Rope"/>, whos backing is an <see cref="System.Array"/> of <see cref="Char"/>.
		/// </summary>
		private sealed class ArrayNode : Node, ISlice<MemoryNode> {
			/// <summary>
			/// The elements contained in this node.
			/// </summary>
			[DisallowNull, NotNull]
			private readonly Char[] Array;

			/// <summary>
			/// Initializes a new <see cref="Node"/>.
			/// </summary>
			/// <param name="array">The elements contained in this node.</param>
			/// <param name="next">The next node in the list.</param>
			/// <param name="previous">The previous node in the list.</param>
			public ArrayNode([DisallowNull] Char[] array, [AllowNull] Node next, [AllowNull] Node previous) : base(next, previous) => Array = array;

			/// <inheritdoc/>
			public override Char this[Int32 index] => Array[index];

#if NETCOREAPP3_0_OR_GREATER
			/// <inheritdoc/>
			public MemoryNode this[Range range] {
				get {
					(Int32 offset, Int32 length) = range.GetOffsetAndLength(Count);
					return Slice(offset, length);
				}
			}
#endif

			/// <inheritdoc/>
			public override Int32 Count => Array.Length;

			/// <inheritdoc/>
			public override Boolean Contains([AllowNull] Char element) => Collection.Contains(Array, Count, element);

			/// <inheritdoc/>
			public override Boolean Contains([AllowNull] Predicate<Char> predicate) => Collection.Contains(Array, Count, predicate);

			/// <inheritdoc/>
			public override (Node Head, Node Tail) Insert(Int32 index, [AllowNull] Char element) {
				Node head;
				Node tail;
				if (index == 0) {
					tail = this;
					head = new CharNode(element, previous: null, next: tail);
					tail.Previous = head;
				} else if (index == Count) {
					head = this;
					tail = new CharNode(element, previous: head, next: null);
					head.Next = tail;
				} else {
					head = Slice(0, index);
					tail = Slice(index, Count - index);
					Node mid = new CharNode(element, previous: head, next: tail);
					head.Next = mid;
					tail.Previous = mid;
				}
				return (head, tail);
			}

			/// <inheritdoc/>
			public override (Node Head, Node Tail) Insert(Int32 index, [DisallowNull] String element) {
				Node head;
				Node tail;
				if (index == 0) {
					tail = this;
					head = new StringNode(element, previous: null, next: tail);
					tail.Previous = head;
				} else if (index == Count) {
					head = this;
					tail = new StringNode(element, previous: head, next: null);
					head.Next = tail;
				} else {
					head = Slice(0, index);
					tail = Slice(index, Count - index);
					Node mid = new StringNode(element, previous: head, next: tail);
					head.Next = mid;
					tail.Previous = mid;
				}
				return (head, tail);
			}

			/// <inheritdoc/>
			public override (Node Head, Node Tail) Insert(Int32 index, [DisallowNull] Char[] element) {
				Node head;
				Node tail;
				if (index == 0) {
					tail = this;
					head = new ArrayNode(element, previous: null, next: tail);
					tail.Previous = head;
				} else if (index == Count) {
					head = this;
					tail = new ArrayNode(element, previous: head, next: null);
					head.Next = tail;
				} else {
					head = Slice(0, index);
					tail = Slice(index, Count - index);
					Node mid = new ArrayNode(element, previous: head, next: tail);
					head.Next = mid;
					tail.Previous = mid;
				}
				return (head, tail);
			}

			/// <inheritdoc/>
			public override (Node Head, Node Tail) Remove([AllowNull] Char element) => throw new NotImplementedException();

			/// <inheritdoc/>
			public override (Node Head, Node Tail) Replace([AllowNull] Char search, [AllowNull] Char replace) {
				Node head = this;
				Node tail = this;
				Node prev = null;
				Int32 o = 0;
				// Iterate through the node
				for (Int32 i = 0; i < Count; i++) {
					// Determine whether a match occurred or not
					if (!Equals(Array[i], search)) {
						continue;
					}
					// If we're replacing the very start
					if (i == 0) {
						head = new CharNode(replace, previous: null, next: null);
						tail = head;
					} else
					// We're replacing somewhere after the start
					{
						// Reuse everything up to this point
						// If head hasn't been reassigned
						if (ReferenceEquals(head, this)) {
							// Do so now
							head = new MemoryNode(Array.AsMemory(o, i - o), previous: tail, next: null);
							tail = head;
						} else {
							// If there's reusable elements
							if (i > o) {
								// Add them
								tail.Next = new MemoryNode(Array.AsMemory(o, i - o), previous: tail, next: null);
								tail = tail.Next;
							}
						}
						// Add the replacement
						tail.Next = new CharNode(replace, previous: tail, next: null);
						tail = tail.Next;
					}
					prev = tail;
					o = i + 1;
				}
				// If there's anything left
				if (o != Count) {
					// Had anything been replaced?
					if (!ReferenceEquals(head, this)) {
						// Attach the remaining parts
						tail.Next = new MemoryNode(Array.AsMemory(o), previous: tail, next: null);
						tail = tail.Next;
					}
				}
				return (head, tail);
			}

			/// <inheritdoc/>
			[return: NotNull]
			public MemoryNode Slice() => Slice(0, Count);

			/// <inheritdoc/>
			[return: NotNull]
			public MemoryNode Slice(Int32 start) => Slice(start, Count - start);

			/// <inheritdoc/>
			[return: NotNull]
			public MemoryNode Slice(Int32 start, Int32 length) => new MemoryNode(Array.AsMemory(start, length), previous: null, next: null);

			/// <inheritdoc/>
			[return: NotNull]
			public override String ToString() => Array.AsSpan().ToString();
		}
	}
}
