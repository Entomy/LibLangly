using System.Runtime.CompilerServices;

namespace System.Traits.Concepts {
	public static partial class Collection {
		/// <summary>
		/// Postpends the elements onto this object, as a batch.
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
	}
}
