using System;
using System.Traits;

namespace Stringier {
	public partial class Rope {
		/// <summary>
		/// Represents a node of a <see cref="Rope"/>, whos backing is <see cref="ReadOnlyMemory{T}"/>.
		/// </summary>
		private sealed class MemoryNode : Node, ISlice<MemoryNode> {
			/// <summary>
			/// The elements contained in this node.
			/// </summary>
			private readonly ReadOnlyMemory<Char> Memory;

			/// <summary>
			/// Initializes a new <see cref="Node"/>.
			/// </summary>
			/// <param name="memory">The elements contained in this node.</param>
			/// <param name="next">The next node in the list.</param>
			/// <param name="previous">The previous node in the list.</param>
			public MemoryNode(ReadOnlyMemory<Char> memory, Node? next, Node? previous) : base(next, previous) => Memory = memory;

			/// <inheritdoc/>
			public override Char this[Int32 index] => Memory.Span[index];

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
			public override Int32 Count => Memory.Length;

			/// <inheritdoc/>
			public override Boolean Contains(Char element) {
				for (Int32 i = 0; i < Count; i++) {
					if (Equals(Memory.Span[i], element)) { return true; }
				}
				return false;
			}

			/// <inheritdoc/>
			public override Boolean Contains(Predicate<Char>? predicate) {
				for (Int32 i = 0; i < Count; i++) {
					if (predicate?.Invoke(Memory.Span[i]) ?? false) { return true; }
				}
				return false;
			}

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
			public override (Node Head, Node Tail) Insert(Int32 index, String elements) {
				Node head;
				Node tail;
				if (index == 0) {
					tail = this;
					head = new StringNode(elements, previous: null, next: tail);
					tail.Previous = head;
				} else if (index == Count) {
					head = this;
					tail = new StringNode(elements, previous: head, next: null);
					head.Next = tail;
				} else {
					head = Slice(0, index);
					tail = Slice(index, Count - index);
					Node mid = new StringNode(elements, previous: head, next: tail);
					head.Next = mid;
					tail.Previous = mid;
				}
				return (head, tail);
			}

			/// <inheritdoc/>
			public override (Node Head, Node Tail) Insert(Int32 index, Char[] elements) {
				Node head;
				Node tail;
				if (index == 0) {
					tail = this;
					head = new ArrayNode(elements, previous: null, next: tail);
					tail.Previous = head;
				} else if (index == Count) {
					head = this;
					tail = new ArrayNode(elements, previous: head, next: null);
					head.Next = tail;
				} else {
					head = Slice(0, index);
					tail = Slice(index, Count - index);
					Node mid = new ArrayNode(elements, previous: head, next: tail);
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
					if (!Equals(Memory.Span[i], search)) {
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
							head = new MemoryNode(Memory.Slice(o, i - o), previous: tail, next: null);
							tail = head;
						} else {
							// If there's reusable elements
							if (i > o) {
								// Add them
								tail.Next = new MemoryNode(Memory.Slice(o, i - o), previous: tail, next: null);
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
						tail.Next = new MemoryNode(Memory.Slice(o), previous: tail, next: null);
						tail = tail.Next;
					}
				}
				return (head, tail);
			}

			/// <inheritdoc/>
			public MemoryNode Slice() => Slice(0, Count);

			/// <inheritdoc/>
			public MemoryNode Slice(Int32 start) => Slice(start, Count - start);

			/// <inheritdoc/>
			public MemoryNode Slice(Int32 start, Int32 length) => new MemoryNode(Memory.Slice(start, length), previous: null, next: null);

			/// <inheritdoc/>
			public override String ToString() => Memory.ToString();
		}
	}
}
