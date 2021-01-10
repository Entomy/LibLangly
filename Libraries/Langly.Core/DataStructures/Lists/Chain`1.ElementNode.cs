using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures.Lists {
	public partial class Chain<TElement> {
		/// <summary>
		/// Represents a <see cref="Node"/> holding a single element.
		/// </summary>
		private sealed class ElementNode : Node {
			/// <summary>
			/// The element contained in the node.
			/// </summary>
			[AllowNull]
			private readonly TElement Element;

			/// <summary>
			/// Initializes a new <see cref="ElementNode"/>.
			/// </summary>
			/// <param name="element">The element contained in the node.</param>
			/// <param name="previous">The previous node in the chain.</param>
			/// <param name="next">The next node in the chain.</param>
			public ElementNode([AllowNull] TElement element, [AllowNull] Node previous, [AllowNull] Node next) : base(previous, next) => Element = element;

			/// <inheritdoc/>
			public override nint Count => 1;

			/// <inheritdoc/>
			public override ref readonly TElement this[nint index] {
				get {
					if (index != 0) {
						throw new IndexOutOfRangeException();
					}
					return ref Element;
				}
			}

			/// <inheritdoc/>
			public override Boolean Equals([AllowNull] Node other) {
				switch (other) {
				case ElementNode node:
					return Element.Equals(node.Element);
				default:
					return false;
				}
			}

			/// <inheritdoc/>
			public override (Node Head, Node Tail) Insert(nint index, [AllowNull] TElement element) {
				Node head;
				Node tail;
				switch (index) {
				case 0:
					tail = this;
					head = new ElementNode(element, previous: null, next: tail);
					tail.Previous = head;
					break;
				case 1:
					head = this;
					tail = new ElementNode(element, previous: head, next: null);
					head.Next = tail;
					break;
				default:
					throw new IndexOutOfRangeException();
				}
				return (head, tail);
			}

			/// <inheritdoc/>
			public override (Node Head, Node Tail) Insert(nint index, ReadOnlyMemory<TElement> elements) {
				Node head;
				Node tail;
				switch (index) {
				case 0:
					tail = this;
					head = new MemoryNode(elements, previous: null, next: tail);
					tail.Previous = head;
					break;
				case 1:
					head = this;
					tail = new MemoryNode(elements, previous: head, next: null);
					head.Next = tail;
					break;
				default:
					throw new IndexOutOfRangeException();
				}
				return (head, tail);
			}

			/// <inheritdoc/>
			[return: NotNull]
			public override System.String ToString() => Element.ToString();
		}
	}
}
