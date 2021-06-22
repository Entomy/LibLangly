using System;
using System.Diagnostics.CodeAnalysis;
using Collectathon.Enumerators;
using Collectathon.Nodes;

namespace Collectathon.Lists {
	/// <summary>
	/// Represents any linked list where each node contains a single element.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the list.</typeparam>
	/// <typeparam name="TNode">The type of the nodes of the list.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	public abstract class StandardList<TElement, TNode, TSelf> : List<TElement, TNode, TSelf, StandardListEnumerator<TElement, TNode>>
		where TNode : StandardListNode<TElement, TNode>
		where TSelf : StandardList<TElement, TNode, TSelf> {
		/// <summary>
		/// Initializes a new <see cref="StandardList{TElement, TNode, TSelf}"/>.
		/// </summary>
		protected StandardList() { }

		/// <summary>
		/// Initializes a new <see cref="StandardList{TElement, TNode, TSelf}"/> with the given <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The initial elements of the list.</param>
		protected StandardList([DisallowNull] TElement[] elements) {
			foreach (TElement element in elements) {
				Add(element);
			}
		}

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public sealed override TElement this[Int32 index] {
			get {
				TNode? N = Head;
				for (Int32 i = 0; N is not null; i++) {
					if (i == index) {
						return N.Element;
					}
					N = N.Next;
				}
				throw new IndexOutOfRangeException();
			}
			set {
				TNode? N = Head;
				for (Int32 i = 0; N is not null; i++) {
					if (i == index) {
						N.Element = value;
					}
					N = N.Next;
				}
				throw new IndexOutOfRangeException();
			}
		}

		/// <inheritdoc/>
		public sealed override StandardListEnumerator<TElement, TNode> GetEnumerator() => new StandardListEnumerator<TElement, TNode>(Head, Count);
	}
}
