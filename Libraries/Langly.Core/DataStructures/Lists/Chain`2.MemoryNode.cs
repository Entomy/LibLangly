using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Langly.DataStructures.Lists {
	public partial class Chain<TIndex, TElement> {
		/// <summary>
		/// Represents a <see cref="Node"/> holding multiple contiguous members.
		/// </summary>
		private sealed class MemoryNode : Node, ISlice<MemoryNode> {
			/// <summary>
			/// The contiguous memory contained in the code.
			/// </summary>
			private readonly ReadOnlyMemory<(TIndex Index, TElement Element)> Memory;

			/// <summary>
			/// Initializes a new <see cref="MemoryNode"/>.
			/// </summary>
			/// <param name="memory">The contiguous memory contained in the node.</param>
			/// <param name="previous">The previous node in the chain.</param>
			/// <param name="next">The next node in the chain.</param>
			public MemoryNode(ReadOnlyMemory<(TIndex, TElement)> memory, [AllowNull] Node previous, [AllowNull] Node next) : base(previous, next) => Memory = memory;

			/// <inheritdoc/>
			public override nint Count => Memory.Length;

			/// <inheritdoc/>
			public override (TIndex Index, TElement Element) this[nint index] {
				get {
					if (0 > index || index >= Count) {
						throw new IndexOutOfRangeException();
					}
					return Memory.Span[(Int32)index];
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
			public override (Boolean Inserted, Node Head, Node Tail) Insert([DisallowNull] TIndex index, [AllowNull] TElement element) {
				Int32 i = -1;
				Node head;
				Node tail;
				while (Memory.Span[++i].Index!.Equals(index)) { /* No-op */ }
				if (i == Count) {
					return (false, this, this);
				} else if (i == 0) {
					tail = this;
					head = new ElementNode(index, element, previous: null, next: tail);
					tail.Previous = head;
				} else if (i == Count - 1) {
					head = this;
					tail = new ElementNode(index, element, previous: head, next: null);
					head.Next = tail;
				} else {
					head = Slice(0, i);
					tail = Slice(i, Count - i);
					Node mid = new ElementNode(index, element, previous: head, next: tail);
					head.Next = mid;
					tail.Previous = mid;
				}
				return (true, head, tail);
			}

			/// <inheritdoc/>
			[return: NotNull]
			public override (Node Head, Node Tail) Replace([AllowNull] TElement search, [AllowNull] TElement replace) {
				Node head = this;
				Node tail = this;
				Node prev = null;
				Int32 o = 0;
				// Iterate through the node
				for (Int32 i = 0; i < Count; i++) {
					// Determine whether a match occurred or not
					if (Memory.Span[i].Element is null ^ search is null) {
						continue;
					} else if (!Memory.Span[i].Element?.Equals(search) ?? false) {
						continue;
					}
					// If we're replacing the very start
					if (i == 0) {
						head = new ElementNode(Memory.Span[i].Index, replace, previous: null, next: null);
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
						tail.Next = new ElementNode(Memory.Span[i].Index, replace, previous: tail, next: null);
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
			[return: NotNull]
			public MemoryNode Slice(nint start, nint length) => new MemoryNode(Memory.Slice((Int32)start, (Int32)length), previous: null, next: null);

			/// <inheritdoc/>
			[return: NotNull]
			public override String ToString() {
				StringBuilder builder = new StringBuilder();
				nint i = 0;
				foreach ((TIndex index, TElement element) in Memory.Span) {
					if (++i == Count) {
						_ = builder.Append(index).Append(':').Append(element?.ToString() ?? "null");
					} else {
						_ = builder.Append(index).Append(':').Append(element?.ToString() ?? "null").Append(',').Append(' ');
					}
				}
				return $"[{builder}]";
			}
		}
	}
}
