using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures.Lists {
	public partial class Chain<TIndex, TElement> {
		/// <summary>
		/// Represents a <see cref="Node"/> holding a single element.
		/// </summary>
		private sealed class ElementNode : Node {
			/// <summary>
			/// The hash of the <see cref="Index"/>.
			/// </summary>
			private readonly Int32 Hash;

			/// <summary>
			/// The index of the node.
			/// </summary>
			[NotNull, DisallowNull]
			private readonly TIndex Index;

			/// <summary>
			/// The element contained in the node.
			/// </summary>
			[MaybeNull, AllowNull]
			private TElement Element;

			/// <summary>
			/// Initializes a new <see cref="ElementNode"/>.
			/// </summary>
			/// <param name="element">The element contained in the node.</param>
			/// <param name="previous">The previous node in the chain.</param>
			/// <param name="next">The next node in the chain.</param>
			public ElementNode([DisallowNull] TIndex index, [AllowNull] TElement element, [AllowNull] Node previous, [AllowNull] Node next) : base(previous, next) {
				Hash = index.GetHashCode();
				Index = index;
				Element = element;
			}

			/// <inheritdoc/>
			public override (TIndex Index, TElement Element) this[nint index] {
				get {
					if (index != 0) {
						throw new IndexOutOfRangeException();
					}
					return (Index, Element);
				}
			}

			/// <inheritdoc/>
			public override nint Count => 1;

			/// <inheritdoc/>
			public override Boolean Equals([AllowNull] Node other) {
				switch (other) {
				case ElementNode node:
					return Hash.Equals(node.Hash) && Index.Equals(node.Index) && (Element?.Equals(node.Element) ?? false);
				default:
					return false;
				}
			}

			/// <inheritdoc/>
			public override (Boolean Inserted, Node Head, Node Tail) Insert([DisallowNull] TIndex index, [AllowNull] TElement element) {
				if (Index.Equals(index)) {
					Node result = new ElementNode(index, element, previous: null, next: null);
					return (true, result, result);
				}
				return (false, this, this);
			}

			/// <inheritdoc/>
			public override (Node Head, Node Tail) Replace([AllowNull] TElement search, [AllowNull] TElement replace) {
				if (Element is null && search is null) {
					goto True;
				} else if (Element is null || search is null) {
					goto False;
				} else if (Element.Equals(search)) {
					goto True;
				} else {
					goto False;
				}
			True:
				Node rep = new ElementNode(Index, replace, previous: null, next: null);
				return (rep, rep);
			False:
				return (this, this);
			}

			/// <inheritdoc/>
			[return: NotNull]
			public override String ToString() => $"{Index}:{Element?.ToString() ?? "null"}";
		}
	}
}
