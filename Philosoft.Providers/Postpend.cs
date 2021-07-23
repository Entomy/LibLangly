using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Traits.Providers {
	public static partial class Collection {
		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="element">The element to postpend.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Postpend<TElement>(TElement[] collection, ref Int32 count, TElement element) => collection[count++] = element;

		/// <summary>
		/// Postpends the elements onto this object, as a batch.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="elements">The elements to postpend.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Postpend<TElement>(TElement[] collection, ref Int32 count, ReadOnlySpan<TElement> elements) {
			elements.CopyTo(collection.AsSpan(count));
			count += elements.Length;
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement"></typeparam>
		/// <typeparam name="TNode"></typeparam>
		/// <param name="head">The head node of this collection.</param>
		/// <param name="tail">The tail node of this collection.</param>
		/// <param name="element">The element to postpend.</param>
		/// <param name="newNode">The function which constructs a new <typeparamref name="TNode"/>.</param>
		[CLSCompliant(false)]
		[LinksNewNode(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static unsafe void Postpend<TElement, TNode>(ref TNode? head, ref TNode? tail, TElement element, delegate*<TElement, TNode> newNode) where TNode : class, INext<TNode?> {
			if (head is not null && tail is not null) {
				tail.Next = newNode(element);
				tail = tail.Next;
			} else {
				head = newNode(element);
				tail = head;
			}
		}
	}
}
