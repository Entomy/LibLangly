using System;
using System.Diagnostics.CodeAnalysis;
using Collectathon.Nodes;

namespace Collectathon.Lists {
	/// <summary>
	/// Represents any linked list where each node contains a single element.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the list.</typeparam>
	/// <typeparam name="TNode">The type of the nodes of the list.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	public abstract partial class StandardList<TElement, TNode, TSelf> : List<TElement, TNode, TSelf, StandardList<TElement, TNode, TSelf>.Enumerator>
		where TNode : StandardListNode<TElement, TNode>
		where TSelf : StandardList<TElement, TNode, TSelf> {
		/// <summary>
		/// Initializes a new <see cref="StandardList{TElement, TNode, TSelf}"/> with the given <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The initial elements of the list.</param>
		/// <param name="filter">The type of filter to use.</param>
		protected StandardList([DisallowNull] TElement[] elements, Filters filter) : base(filter) {
			foreach (TElement element in elements) {
				Add(element);
			}
		}

		/// <summary>
		/// Initializes a new <see cref="StandardList{TElement, TNode, TSelf}"/>.
		/// </summary>
		/// <param name="filter">The type of filter to use.</param>
		protected StandardList(Filters filter) : base(filter) { }

		/// <summary>
		/// Copy constructor
		/// </summary>
		/// <param name="filter">The <see cref="Filter{TIndex, TElement}"/> to reuse.</param>
		protected StandardList([DisallowNull] Filter<nint, TElement> filter) : base(filter) { }

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public sealed override TElement this[nint index] {
			get {
				TNode? N = Head;
				nint i = 0;
				while (N is not null) {
					if (i == index) {
						return N.Element;
					}
					N = N.Next;
					i++;
				}
				throw new IndexOutOfRangeException();
			}
			set {
				TNode? N = Head;
				nint i = 0;
				while (N is not null) {
					if (i == index) {
						N.Element = value;
					}
					N = N.Next;
					i++;
				}
				throw new IndexOutOfRangeException();
			}
		}

		/// <inheritdoc/>
		public sealed override Enumerator GetEnumerator() => new Enumerator(this);

		/// <inheritdoc/>
		public override void Replace([AllowNull] TElement search, [AllowNull] TElement replace) {
			TNode? N = Head;
			while (N is not null) {
				N.Replace(search, replace);
				N = N.Next;
			}
		}
	}
}
