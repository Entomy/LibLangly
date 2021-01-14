using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Langly.DataStructures.Lists {
	public partial class Chain<TElement> {
		/// <summary>
		/// Represents a <see cref="Node"/> holding multiple contiguous elements.
		/// </summary>
		private sealed class MemoryNode : Node, ISlice<MemoryNode> {
			/// <summary>
			/// The contiguous memory contained in the node.
			/// </summary>
			private readonly ReadOnlyMemory<TElement> Memory;

			/// <summary>
			/// Initializes a new <see cref="MemoryNode"/>.
			/// </summary>
			/// <param name="memory">The contiguous memory contained in the node.</param>
			/// <param name="previous">The previous node in the chain.</param>
			/// <param name="next">The next node in the chain.</param>
			public MemoryNode(ReadOnlyMemory<TElement> memory, [AllowNull] Node previous, [AllowNull] Node next) : base(previous, next) => Memory = memory;

			/// <inheritdoc/>
			public override nint Count => Memory.Length;

			/// <inheritdoc/>
			public override ref readonly TElement this[nint index] {
				get {
					if (0 > index || index >= Count) {
						throw new IndexOutOfRangeException();
					}
					return ref Memory.Span[(Int32)index];
				}
			}

			/// <inheritdoc/>
			public override Boolean Equals([AllowNull] Node other) {
				switch (other) {
				case MemoryNode node:
					return Memory.Equals(node.Memory);
				default:
					return false;
				}
			}

			/// <inheritdoc/>
			public override (Node Head, Node Tail) Insert(nint index, [AllowNull] TElement element) {
				Node head;
				Node tail;
				if (index == 0) {
					tail = this;
					head = new ElementNode(element, previous: null, next: tail);
					tail.Previous = head;
				} else if (index == Count) {
					head = this;
					tail = new ElementNode(element, previous: head, next: null);
					head.Next = tail;
				} else {
					head = Slice(0, index);
					tail = Slice(index, Count - index);
					Node mid = new ElementNode(element, previous: head, next: tail);
					head.Next = mid;
					tail.Previous = mid;
				}
				return (head, tail);
			}

			/// <inheritdoc/>
			public override (Node Head, Node Tail) Insert(nint index, ReadOnlyMemory<TElement> elements) {
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
			public override (Node Head, Node Tail) Replace([AllowNull] TElement search, [AllowNull] TElement replace) {
				Node head = this;
				Node tail = this;
				Node prev = null;
				Int32 o = 0;
				// Iterate through the node
				for (Int32 i = 0; i < Count; i++) {
					// Determine whether a match occurred or not
					if (Memory.Span[i] is null ^ search is null) {
						continue;
					} else if (!Memory.Span[i]?.Equals(search) ?? false) {
						continue;
					}
					// If we're replacing the very start
					if (i == 0) {
						head = new ElementNode(replace, previous: null, next: null);
						tail = head;
					} else
					// We're replacing somewhere after the start
					{
						// Reuse everything up to this point
						// If head hasn't been reassigned
						if (ReferenceEquals(head, this)) {
							// Do so now
							head = new MemoryNode(Memory[o..i], previous: tail, next: null);
							tail = head;
						} else {
							// If there's reusable elements
							if (i > o) {
								// Add them
								tail.Next = new MemoryNode(Memory[o..i], previous: tail, next: null);
								tail = tail.Next;
							}
						}
						// Add the replacement
						tail.Next = new ElementNode(replace, previous: tail, next: null);
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
						tail.Next = new MemoryNode(Memory[o..], previous: tail, next: null);
						tail = tail.Next;
					}
				}
				return (head, tail);
			}

			/// <inheritdoc/>
			public MemoryNode Slice(nint start, nint length) => new MemoryNode(Memory.Slice((Int32)start, (Int32)length), previous: null, next: null);

			/// <inheritdoc/>
			[return: NotNull]
			public override System.String ToString() {
				StringBuilder builder = new StringBuilder();
				nint i = 0;
				foreach (TElement element in Memory.Span) {
					if (++i == Count) {
						builder.Append(element);
					} else {
						builder.Append(element).Append(',').Append(' ');
					}
				}
				return $"[{builder}]";
			}
		}
	}
}
