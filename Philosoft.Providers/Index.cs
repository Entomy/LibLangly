using System.Runtime.CompilerServices;

namespace System.Traits.Providers {
	public static partial class Collection {
		/// <summary>
		/// Gets the element at the specified <paramref name="index"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in this collection.</typeparam>
		/// <typeparam name="TNode">The type of the nodes that make up this collection.</typeparam>
		/// <param name="head">The head node of this collection.</param>
		/// <param name="count">The count of the elements in this collection.</param>
		/// <param name="index">The index of the element to get.</param>
		/// <returns>The element at the specified <paramref name="index"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TElement Index<TElement, TNode>(TNode? head, Int32 count, Int32 index) where TNode : class, IElement<TElement>, INext<TNode?> {
			if (index < count) {
				TNode? N = head;
				for (Int32 i = 0; N is not null; i++) {
					if (i == index) {
						return N.Element;
					}
					N = N.Next;
				}
			}
			throw new IndexOutOfRangeException();
		}

		/// <summary>
		/// Sets the element at the specified <paramref name="index"/> to <paramref name="element"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in this collection.</typeparam>
		/// <typeparam name="TNode">The type of the nodes that make up this collection.</typeparam>
		/// <param name="head">The head node of this collection.</param>
		/// <param name="count">The count of the elements in this collection.</param>
		/// <param name="index">The index of the element to set.</param>
		/// <param name="element">The element to set.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Index<TElement, TNode>(TNode? head, Int32 count, Int32 index, TElement element) where TNode : class, IElement<TElement>, INext<TNode?> {
			if (index < count) {
				TNode? N = head;
				for (Int32 i = 0; N is not null; i++) {
					if (i == index) {
						N.Element = element;
					}
					N = N.Next;
				}
			}
			throw new IndexOutOfRangeException();
		}
	}
}
