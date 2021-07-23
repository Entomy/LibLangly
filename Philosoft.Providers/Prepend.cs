using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Traits.Providers {
	public static partial class Collection {
		/// <summary>
		/// Prepends the elements onto this collection.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="element">The element to prepend.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Prepend<TElement>(TElement[] collection, ref Int32 count, TElement element) {
			ShiftRight(collection, count, 1);
			collection[0] = element;
			count++;
		}

		/// <summary>
		/// Prepends the elements onto this collection, as a batch.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="elements">The elements to prepend.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Prepend<TElement>(TElement[] collection, ref Int32 count, ReadOnlySpan<TElement> elements) {
			ShiftRight(collection, count, elements.Length);
			elements.CopyTo(collection);
			count += elements.Length;
		}

		/// <summary>
		/// Prepends the elements onto this collection.
		/// </summary>
		/// <param name="head">The head node of the collection.</param>
		/// <param name="tail">The tail node of the collection.</param>
		/// <param name="element">The element to prepend.</param>
		/// <param name="newNode">The function which constructs a new <typeparamref name="TNode"/>.</param>
		[CLSCompliant(false)]
		[LinksNewNode(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static unsafe void Prepend<TElement, TNode>(ref TNode? head, ref TNode? tail, TElement element, delegate*<TElement, TNode> newNode) where TNode : class, INext<TNode?> {
			if (head is not null && tail is not null) {
				TNode oldHead = head;
				head = newNode(element);
				head.Next = oldHead;
			} else {
				head = newNode(element);
				tail = head;
			}
		}
	}
}
