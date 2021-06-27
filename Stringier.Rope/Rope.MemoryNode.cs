using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using System.Traits.Concepts;

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
			public MemoryNode(ReadOnlyMemory<Char> memory, [AllowNull] Node next, [AllowNull] Node previous) : base(next, previous) => Memory = memory;

			/// <inheritdoc/>
			public override Char this[Int32 index] => Memory.Span[index];

#if NETCOREAPP3_0_OR_GREATER
			/// <inheritdoc/>
			public MemoryNode this[Range range] {
				get {
					(Int32 offset, Int32 length) = range.GetOffsetAndLength((Int32)Count);
					return Slice(offset, length);
				}
			}
#endif

			/// <inheritdoc/>
			public override Int32 Count => Memory.Length;

			/// <inheritdoc/>
			public override Boolean Contains([AllowNull] Char element) => Collection.Contains(Memory, Count, element);

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
			public override (Node Head, Node Tail) Insert(Int32 index, ReadOnlyMemory<Char> elements) {
				Node head;
				Node tail;
				if (index == 0) {
					tail = this;
					head = new MemoryNode(elements, previous: null, next: tail);
					tail.Previous = head;
				} else if (index == Count) {
					head = this;
					tail = new MemoryNode(elements, previous: head, next: null);
					head.Next = tail;
				} else {
					head = Slice(0, index);
					tail = Slice(index, Count - index);
					Node mid = new MemoryNode(elements, previous: head, next: tail);
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
			[return: NotNull]
			public MemoryNode Slice() => Slice(0, Count);

			/// <inheritdoc/>
			[return: NotNull]
			public MemoryNode Slice(Int32 start) => Slice(start, Count - start);

			/// <inheritdoc/>
			[return: NotNull]
			public MemoryNode Slice(Int32 start, Int32 length) => new MemoryNode(Memory.Slice((Int32)start, (Int32)length), previous: null, next: null);

			/// <inheritdoc/>
			[return: NotNull]
			public override String ToString() => Memory.ToString();
		}
	}
}
