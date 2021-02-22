using System;
using System.Diagnostics.CodeAnalysis;
using Langly.DataStructures.Filters;
using Langly.DataStructures.Trees.Multiway;

namespace Langly {
	public sealed partial class Dictionary<TElement> {
		/// <summary>
		/// Represents the <see cref="Node"/> of a <see cref="Dictionary{TElement}"/>.
		/// </summary>
		private sealed class Node : MultiwayNode<Char, TElement, Node>, IIndexReadOnlyText<Node>, IIndexReadOnlyUnsafe<Char, Node> {
			/// <summary>
			/// The <see cref="Filter{TIndex, TElement}"/> being used.
			/// </summary>
			/// <remarks>
			/// This is never <see langword="null"/>; a sentinel is used by default.
			/// </remarks>
			[NotNull, DisallowNull]
			private readonly Filter<Char, TElement> Filter;

			/// <summary>
			/// Initializes a new linkage <see cref="Node"/>.
			/// </summary>
			/// <param name="index">The index of this node.</param>
			/// <param name="filter">The <see cref="Filter{TIndex, TElement}"/> to reuse.</param>
			/// <param name="parent">The parent node of this node.</param>
			/// <param name="children">The child nodes of this node.</param>
			public Node(Char index, [DisallowNull] Filter<Char, TElement> filter, [DisallowNull] Node parent, [DisallowNull] params Node[] children) : base(index, default, parent, children) {
				Terminal = false;
				Filter = filter;
			}

			/// <summary>
			/// Initializes a new terminal <see cref="Node"/>.
			/// </summary>
			/// <param name="index">The index of this node.</param>
			/// <param name="element">The element of this node.</param>
			/// <param name="filter">The <see cref="Filter{TIndex, TElement}"/> to reuse.</param>
			/// <param name="parent">The parent node of this node.</param>
			/// <param name="children">The child nodes of this node.</param>
			public Node(Char index, [AllowNull] TElement element, [DisallowNull] Filter<Char, TElement> filter, [DisallowNull] Node parent, [DisallowNull] params Node[] children) : base(index, element, parent, children) {
				Terminal = true;
				Filter = filter;
			}

			/// <summary>
			/// Is this a terminal node?
			/// </summary>
			public Boolean Terminal { get; set; }

			/// <inheritdoc/>
			[MaybeNull]
			public Node this[Char index] {
				get {
					foreach (Node child in Children) {
						if (child.Index == index) {
							return child;
						}
					}
					return null;
				}
			}

			/// <inheritdoc/>
			[AllowNull, MaybeNull]
			public Node this[[DisallowNull] String index] => this[index.AsMemory()];

			/// <inheritdoc/>
			[AllowNull, MaybeNull]
			public Node this[[DisallowNull] Char[] index] => this[index.AsMemory()];

			/// <inheritdoc/>
			[AllowNull, MaybeNull]
			public Node this[Memory<Char> index] => this[(ReadOnlyMemory<Char>)index];

			/// <inheritdoc/>
			[AllowNull, MaybeNull]
			public Node this[ReadOnlyMemory<Char> index] => this[index.Span];

			/// <inheritdoc/>
			[AllowNull, MaybeNull]
			public Node this[Span<Char> index] => this[(ReadOnlySpan<Char>)index];

			/// <inheritdoc/>
			[MaybeNull]
			public Node this[ReadOnlySpan<Char> index] {
				get {
					Node N = this;
					foreach (Char item in index) {
						N = N[item];
						if (N is null) {
							goto Result;
						}
					}
				Result:
					return N;
				}
			}

			/// <inheritdoc/>
			[AllowNull, MaybeNull]
			public unsafe Node this[[DisallowNull] Char* index, Int32 length] => this[new ReadOnlySpan<Char>(index, length)];

			/// <inheritdoc/>
			public override Boolean Equals([AllowNull] Node other) => ReferenceEquals(this, other);

			/// <summary>
			/// Inserts a new linkage node into the collection for the specified index.
			/// </summary>
			/// <param name="index">The index of the linkage node.</param>
			/// <returns>The <see cref="Node"/> that was inserted, if successful; otherwise, <see langword="null"/>.</returns>
			[return: NotNull]
			public Node Insert(Char index) {
				// Determine if this child already exists
				for (nint i = 0; i < Count; i++) {
					if (Children[i].Index == index) {
						// Node already present, so do nothing
						return Children[i];
					}
				}
				// Determine if we need to resize
				if (Count == Capacity) {
					this.Grow();
				}
				// Insert the linkage
				Children[Count] = new Node(index, filter: Filter, parent: this);
				return Children[Count++];
			}

			/// <summary>
			/// Inserts a new terminal node into the collection for the specified index.
			/// </summary>
			/// <param name="index">The index of the terminal node.</param>
			/// <param name="element">The element of the terminal node.</param>
			/// <returns>The <see cref="Node"/> that was inserted, if successful; otherwise, <see langword="null"/>.</returns>
			[return: NotNull]
			public override Node Insert(Char index, [AllowNull] TElement element) {
				// Determine if this child already exists
				for (nint i = 0; i < Count; i++) {
					if (Children[i].Index == index) {
						// Node already present, so replace the element
						Children[i].Element = element;
						return Children[i];
					}
				}
				// Determine if we need to resize
				if (Count == Capacity) {
					this.Grow();
				}
				// Insert the element
				Children[Count] = new Node(index, element, filter: Filter, parent: this);
				return Children[Count++];
			}

			/// <inheritdoc/>
			[return: MaybeNull]
			public override Node Replace([AllowNull] TElement search, [AllowNull] TElement replace) {
				if (Element is null && search is null) {
					Element = replace;
				}
				foreach (Node child in Children) {
					if (child.Replace(search, replace) is null) {
						return null;
					}
				}
				return this;
			}
		}
	}
}
