using System;
using System.Diagnostics.CodeAnalysis;
using Collectathon.Enumerators;
using Collectathon.Nodes;

namespace Collectathon.Lists {
	/// <summary>
	/// Represents any associative linked list where each node contains a single element.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the elements.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the list.</typeparam>
	/// <typeparam name="TNode">The type of the nodes of the list.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	public abstract class StandardList<TIndex, TElement, TNode, TSelf> : List<TIndex, TElement, TNode, TSelf, StandardListEnumerator<TIndex, TElement, TNode>>
		where TNode : StandardListNode<TIndex, TElement, TNode>
		where TSelf : StandardList<TIndex, TElement, TNode, TSelf> {
		/// <summary>
		/// Initializes a new <see cref="StandardList{TIndex, TElement, TNode, TSelf}"/>.
		/// </summary>
		protected StandardList() { }

		/// <summary>
		/// Initializes a new <see cref="StandardList{TIndex, TElement, TNode, TSelf}"/> witht he given <paramref name="entries"/>.
		/// </summary>
		/// <param name="entries">The initial entries of the list.</param>
		protected StandardList([DisallowNull] (TIndex Index, TElement Element)[] entries) {
			foreach ((TIndex Index, TElement Element) in entries) {
				Insert(Index, Element);
			}
		}

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public sealed override TElement this[[DisallowNull] TIndex index] {
			get {
				TNode? N = Head;
				for (nint i = 0; N is not null; i++) {
					if (Equals(N.Index, index)) {
						return N.Element;
					}
					N = N.Next;
				}
				throw new IndexOutOfRangeException();
			}
			set {
				TNode? N = Head;
				for (nint i = 0; N is not null; i++) {
					if (Equals(N.Index, index)) {
						N.Element = value;
					}
					N = N.Next;
				}
				throw new IndexOutOfRangeException();
			}
		}

		/// <inheritdoc/>
		public sealed override StandardListEnumerator<TIndex, TElement, TNode> GetEnumerator() => new StandardListEnumerator<TIndex, TElement, TNode>(Head, Count);
	}
}
