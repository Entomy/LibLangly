using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Traits.Providers {
	public static partial class Collection {
		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Insert<TElement>(TElement[] collection, ref Int32 count, Index index, TElement element) {
			Int32 idx = index.GetOffset(count);
			collection.AsSpan(idx, count - idx).CopyTo(collection.AsSpan(idx + 1));
			collection[index] = element;
			count++;
		}

		/// <summary>
		/// Inserts the elements into the collection at the specified index, as a batch.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Insert<TElement>(TElement[] collection, ref Int32 count, Index index, ReadOnlySpan<TElement> elements) {
			Int32 idx = index.GetOffset(count);
			collection.AsSpan(idx, count - idx).CopyTo(collection.AsSpan(idx + elements.Length));
			elements.CopyTo(collection.AsSpan(index.Value));
			count += elements.Length;
		}

		/// <summary>
		/// Inserts the element into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in this collection.</typeparam>
		/// <typeparam name="TNode">The type of the nodes that make up this collection.</typeparam>
		/// <param name="head">The head node of this collection.</param>
		/// <param name="tail">The tail node of this collection.</param>
		/// <param name="count">The amount of elements in this collection.</param>
		/// <param name="index">The index at which the <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <param name="newNode">The function which constructs a new <typeparamref name="TNode"/>.</param>
		[CLSCompliant(false)]
		[LinksNewNode(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static unsafe void Insert<TElement, TNode>(ref TNode? head, ref TNode? tail, Int32 count, Index index, TElement element, delegate*<TElement, TNode> newNode) where TNode : class, INext<TNode?> {
			Int32 idx = index.GetOffset(count);
			if (0 <= idx && idx <= count) {
				if (idx == 0) {
					Prepend(ref head, ref tail, element, newNode);
				} else if (idx == count) {
					Postpend(ref head, ref tail, element, newNode);
				} else if (head is null || tail is null) {
					head = newNode(element);
					tail = head;
				} else {
					TNode P = null!;
					TNode? N = head;
					for (Int32 i = 0; N is not null;) {
						P = N;
						N = N.Next;
						if (++i == idx) { break; }
					}
					P.Next = newNode(element);
					P.Next.Next = N;
				}
			} else {
				throw new IndexOutOfRangeException();
			}
		}
	}
}
