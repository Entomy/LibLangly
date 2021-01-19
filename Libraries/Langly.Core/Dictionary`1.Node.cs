using System;
using System.Diagnostics.CodeAnalysis;
using Langly.DataStructures.Filters;
using Langly.DataStructures.Trees.Multiway;

namespace Langly {
	public sealed partial class Dictionary<TElement> {
		/// <summary>
		/// Represents the <see cref="Node"/> of a <see cref="Dictionary{TElement}"/>.
		/// </summary>
		private sealed class Node : MultiwayNode<Glyph, TElement, Node>,
			IIndex<Glyph, TElement> {
			/// <summary>
			/// The element of this node.
			/// </summary>
			[AllowNull, MaybeNull]
			public TElement Element;

			/// <summary>
			/// The <see cref="Filter{TIndex, TElement}"/> being used.
			/// </summary>
			/// <remarks>
			/// This is never <see langword="null"/>; a sentinel is used by default.
			/// </remarks>
			[NotNull, DisallowNull]
			private readonly Filter<Glyph, TElement> Filter;

			/// <summary>
			/// The index of this node.
			/// </summary>
			private readonly Glyph Index;

			/// <summary>
			/// Initializes a new <see cref="Node"/>.
			/// </summary>
			/// <param name="index">The index of this node.</param>
			/// <param name="element">The element of this node.</param>
			/// <param name="filter">The <see cref="Filter{TIndex, TElement}"/> to reuse.</param>
			/// <param name="parent">The parent node of this node.</param>
			/// <param name="children">The child nodes of this node.</param>
			public Node(Glyph index, [AllowNull] TElement element, [DisallowNull] Filter<Glyph, TElement> filter, [DisallowNull] Node parent, [DisallowNull] params Node[] children) : base(parent, children) {
				Index = index;
				Element = element;
				Filter = filter;
			}

			/// <inheritdoc/>
			[AllowNull, MaybeNull]
			public TElement this[Glyph index] {
				get {
					foreach (Node child in Children) {
						if (child.Index == index) {
							return child.Element;
						}
					}
					return Filter.IndexOutOfBounds(this, index);
				}
				set {
					foreach (Node child in Children) {
						if (child.Index == index) {
							child.Element = value;
						}
					}
					Filter.IndexOutOfBounds(this, index, value);
				}
			}

			/// <inheritdoc/>
			public override Boolean Equals([AllowNull] Node other) => ReferenceEquals(this, other);

			/// <inheritdoc/>
			[return: NotNull]
			public override Node Insert(Glyph index, [AllowNull] TElement element) {
				// Determine if this child already exists
				for (nint i = 0; i < Count; i++) {
					if (Children[i].Index == index) {
						// Node already present, so replace the element
						Children[i].Element = element;
						return this;
					}
				}
				// Determine if we need to resize
				if (Count == Capacity) {
					this.Grow();
				}
				// Insert the element
				Children[Count] = new Node(index, element, filter: Filter, parent: this);
				Count++;
				return this;
			}

			/// <inheritdoc/>
			[return: NotNull]
			public override Node Replace([AllowNull] TElement search, [AllowNull] TElement replace) {
				if (Element is null && search is null) {
					Element = replace;
				}
				foreach (Node child in Children) {
					_ = child.Replace(search, replace);
				}
				return this;
			}

			/// <inheritdoc/>
			public override String ToString() => $"{Index}:{Element}";
		}
	}
}
