using System;
using System.Traits;
using System.Traits.Concepts;
using System.Traits.Providers;

namespace Stringier {
	public partial class Rope {
		/// <summary>
		/// Represents a node of a <see cref="Rope"/>, whos backing is an <see cref="System.Array"/> of <see cref="Char"/>.
		/// </summary>
		private sealed class ArrayNode : Node, ISlice<MemoryNode> {
			/// <summary>
			/// The elements contained in this node.
			/// </summary>
			private readonly Char[] Array;

			/// <summary>
			/// Initializes a new <see cref="Node"/>.
			/// </summary>
			/// <param name="array">The elements contained in this node.</param>
			/// <param name="next">The next node in the list.</param>
			/// <param name="previous">The previous node in the list.</param>
			public ArrayNode(Char[] array, Node? next, Node? previous) : base(next, previous) => Array = array;

			/// <inheritdoc/>
			public override Char this[Int32 index] => Array[index];

			/// <inheritdoc/>
			public MemoryNode this[Range range] {
				get {
					(Int32 offset, Int32 length) = range.GetOffsetAndLength(Count);
					return Slice(offset, length);
				}
			}

			/// <inheritdoc/>
			public override Int32 Count => Array.Length;

			/// <inheritdoc/>
			public override Boolean Contains(Char element) => Collection.Contains(Array, Count, element);

			/// <inheritdoc/>
			public override Boolean Contains(Predicate<Char>? predicate) => Collection.Contains(Array, Count, predicate);

			/// <inheritdoc/>
			public override (Node Head, Node Tail) Insert(Int32 index, Char element) {
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
			public override (Node Head, Node Tail) Insert(Int32 index, String element) {
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
			public override (Node Head, Node Tail) Insert(Int32 index, Char[] element) {
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
			public override (Node Head, Node Tail) Remove(Char element) => throw new NotImplementedException();

			/// <inheritdoc/>
			public override (Node Head, Node Tail) Replace(Char search, Char replace) {
				Node head = this;
				Node tail = this;
				Node? prev = null;
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
			public MemoryNode Slice() => Slice(0, Count);

			/// <inheritdoc/>
			public MemoryNode Slice(Index start) {
				Int32 strt = start.GetOffset(Count);
				return Slice(strt, Count - strt);
			}

			/// <inheritdoc/>
			public MemoryNode Slice(Index start, Int32 length) {
				Int32 strt = start.GetOffset(Count);
				return new MemoryNode(Array.AsMemory(strt, length), previous: null, next: null);
			}

			/// <inheritdoc/>
			public override String ToString() => Array.AsSpan().ToString();
		}
	}
}
