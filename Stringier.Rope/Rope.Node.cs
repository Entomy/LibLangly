using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Stringier {
	public partial class Rope {
		/// <summary>
		/// Represents a node of a <see cref="Rope"/>.
		/// </summary>
		public abstract class Node : IContains<Char>, IIndexReadOnly<Int32, Char>, INext<Node>, IPrevious<Node>, IUnlink {
			/// <summary>
			/// Initializes a new <see cref="Node"/>.
			/// </summary>
			/// <param name="next">The next node in the list.</param>
			/// <param name="previous">The previous node in the list.</param>
			protected Node([AllowNull] Node next, [AllowNull] Node previous) {
				Next = next;
				Previous = previous;
			}

			/// <inheritdoc/>
			public abstract Int32 Count { get; }

			/// <inheritdoc/>
			[AllowNull, MaybeNull]
			public Node Next { get; set; }

			/// <inheritdoc/>
			[AllowNull, MaybeNull]
			public Node Previous { get; set; }

			/// <inheritdoc/>
			public abstract Char this[Int32 index] { get; }

			/// <inheritdoc/>
			public abstract Boolean Contains(Char element);

			/// <inheritdoc/>
			public abstract Boolean Contains([AllowNull] Predicate<Char> predicate);

			/// <summary>
			/// Inserts the <paramref name="element"/> into this <see cref="Node"/> at the specified <paramref name="index"/>.
			/// </summary>
			/// <param name="index">The position at which to insert the <paramref name="element"/>.</param>
			/// <param name="element">The element to insert.</param>
			/// <returns>A chain section representing the insert.</returns>
			public abstract (Node Head, Node Tail) Insert(Int32 index, [AllowNull] Char element);

			/// <summary>
			/// Inserts the <paramref name="element"/> into this <see cref="Node"/> at the specified <paramref name="index"/>.
			/// </summary>
			/// <param name="index">The position at which to insert the <paramref name="element"/>.</param>
			/// <param name="element">The element to insert.</param>
			/// <returns>A chain section representing the insert.</returns>
			public abstract (Node Head, Node Tail) Insert(Int32 index, [DisallowNull] String element);

			/// <summary>
			/// Inserts the <paramref name="element"/> into this <see cref="Node"/> at the specified <paramref name="index"/>.
			/// </summary>
			/// <param name="index">The position at which to insert the <paramref name="element"/>.</param>
			/// <param name="element">The element to insert.</param>
			/// <returns>A chain section representing the insert.</returns>
			public abstract (Node Head, Node Tail) Insert(Int32 index, [DisallowNull] Char[] element);

			/// <summary>
			/// Postpends the <paramref name="element"/> onto this <see cref="Node"/>.
			/// </summary>
			/// <param name="element">The <see cref="Char"/> to postpend.</param>
			/// <returns>The postpended <see cref="Node"/>.</returns>
			[return: NotNull]
			public Node Postpend([AllowNull] Char element) {
				Next = new CharNode(element, next: null, previous: this);
				return Next;
			}

			/// <summary>
			/// Postpends the <paramref name="element"/> onto this <see cref="Node"/>.
			/// </summary>
			/// <param name="element">The <see cref="String"/> to postpend.</param>
			/// <returns>The postpended <see cref="Node"/>.</returns>
			[return: NotNull]
			public Node Postpend([DisallowNull] String element) {
				Next = new StringNode(element, next: null, previous: this);
				return Next;
			}

			/// <summary>
			/// Postpends the <paramref name="element"/> onto this <see cref="Node"/>.
			/// </summary>
			/// <param name="element">The <see cref="Array"/> of <see cref="Char"/> to postpend.</param>
			/// <returns>The postpended <see cref="Node"/>.</returns>
			[return: NotNull]
			public Node Postpend([DisallowNull] Char[] element) {
				Next = new ArrayNode(element, next: null, previous: this);
				return Next;
			}

			/// <summary>
			/// Prepends the <paramref name="element"/> onto this <see cref="Node"/>.
			/// </summary>
			/// <param name="element">The <see cref="Char"/> to prepend.</param>
			/// <returns>The prepended <see cref="Node"/>.</returns>
			[return: NotNull]
			public Node Prepend([AllowNull] Char element) => new CharNode(element, next: this, previous: null);

			/// <summary>
			/// Prepends the <paramref name="element"/> onto this <see cref="Node"/>.
			/// </summary>
			/// <param name="element">The <see cref="String"/> to prepend.</param>
			/// <returns>The prepended <see cref="Node"/>.</returns>
			[return: NotNull]
			public Node Prepend([DisallowNull] String element) => new StringNode(element, next: this, previous: null);

			/// <summary>
			/// Prepends the <paramref name="element"/> onto this <see cref="Node"/>.
			/// </summary>
			/// <param name="element">The <see cref="Array"/> of <see cref="Char"/> to prepend.</param>
			/// <returns>The prepended <see cref="Node"/>.</returns>
			[return: NotNull]
			public Node Prepend([DisallowNull] Char[] element) => new ArrayNode(element, next: this, previous: null);

			/// <summary>
			/// 
			/// </summary>
			/// <param name="element"></param>
			/// <returns></returns>
			public abstract (Node Head, Node Tail) Remove([AllowNull] Char element);

			/// <summary>
			/// Replaces each instance of <paramref name="search"/> in this <see cref="Node"/> with <paramref name="replace"/>.
			/// </summary>
			/// <param name="search">The <see cref="Char"/> to search for.</param>
			/// <param name="replace">The <see cref="Char"/> to replace with.</param>
			/// <returns>A chain section representing the replace.</returns>
			public abstract (Node Head, Node Tail) Replace(Char search, Char replace);

			/// <inheritdoc/>
			public void Unlink() {
				Next = null;
				Previous = null;
			}
		}
	}
}
