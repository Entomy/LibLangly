using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Stringier {
	public partial class Rope {
		/// <summary>
		/// Represents a node of a <see cref="Rope"/> whos backing is pointed to, and probably in unmanaged memory.
		/// </summary>
		private sealed unsafe class PointerNode : Node, ISlice<PointerNode> {
			/// <summary>
			/// The elements contained in this node.
			/// </summary>
			private readonly Char* Pointer;

			/// <summary>
			/// Initializes a new <see cref="Node"/>.
			/// </summary>
			/// <param name="pointer">The elements contained in this node.</param>
			/// <param name="length">The length of the <paramref name="pointer"/>.</param>
			/// <param name="next">The next node in the list.</param>
			/// <param name="previous">The previous node in the list.</param>
			public PointerNode([DisallowNull] Char* pointer, Int32 length, [AllowNull] Node next, [AllowNull] Node previous) : base(next, previous) {
				Pointer = pointer;
				Count = length;
			}

			/// <inheritdoc/>
			public override Char this[Int32 index] => Pointer[index];

#if NETCOREAPP3_0_OR_GREATER
			/// <inheritdoc/>
			public PointerNode this[Range range] {
				get {
					(Int32 offset, Int32 length) = range.GetOffsetAndLength((Int32)Count);
					return Slice(offset, length);
				}
			}
#endif

			/// <inheritdoc/>
			public override Int32 Count { get; }

			/// <inheritdoc/>
			public override Boolean Contains(Char element) => Collection.Contains(Pointer, Count, element);

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
					if (!Equals(Pointer[i], search)) {
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
							head = new PointerNode(&Pointer[o], i - o, previous: tail, next: null);
							tail = head;
						} else {
							// If there's reusable elements
							if (i > o) {
								// Add them
								tail.Next = new PointerNode(&Pointer[o], i - o, previous: tail, next: null);
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
						tail.Next = new PointerNode(&Pointer[o], (Int32)Count - o, previous: tail, next: null);
						tail = tail.Next;
					}
				}
				return (head, tail);
			}

			/// <inheritdoc/>
			[return: MaybeNull]
			public PointerNode Slice() => Slice(0, Count);

			/// <inheritdoc/>
			[return: MaybeNull]
			public PointerNode Slice(Int32 start) => Slice(start, Count - start);

			/// <inheritdoc/>
			[return: MaybeNull]
			public PointerNode Slice(Int32 start, Int32 length) => new PointerNode(&Pointer[(Int32)start], (Int32)length, previous: null, next: null);
		}
	}
}
