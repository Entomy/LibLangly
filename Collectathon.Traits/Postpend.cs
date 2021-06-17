using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Traits {
	public static partial class Collection {
		/// <summary>
		/// Postpends the elements onto this object, as a batch.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="element">The element to postpend.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Postpend<TElement>([AllowNull] TElement[] collection, ref nint count, [AllowNull] TElement element) => Postpend(collection.AsSpan(), ref count, element);

		/// <summary>
		/// Postpends the elements onto this object, as a batch.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="element">The element to postpend.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Postpend<TElement>(Memory<TElement> collection, ref nint count, [AllowNull] TElement element) => Postpend(collection.Span, ref count, element);

		/// <summary>
		/// Postpends the elements onto this object, as a batch.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="element">The element to postpend.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Postpend<TElement>(Span<TElement> collection, ref nint count, [AllowNull] TElement element) => collection[(Int32)count++] = element;

		/// <summary>
		/// Postpends the elements onto this object, as a batch.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="elements">The elements to postpend.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Postpend<TElement>([AllowNull] TElement[] collection, ref nint count, ReadOnlySpan<TElement> elements) => Postpend(collection.AsSpan(), ref count, elements);

		/// <summary>
		/// Postpends the elements onto this object, as a batch.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="elements">The elements to postpend.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Postpend<TElement>(Memory<TElement> collection, ref nint count, ReadOnlySpan<TElement> elements) => Postpend(collection.Span, ref count, elements);

		/// <summary>
		/// Postpends the elements onto this object, as a batch.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="elements">The elements to postpend.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Postpend<TElement>(Span<TElement> collection, ref nint count, ReadOnlySpan<TElement> elements) {
			elements.CopyTo(collection.Slice((Int32)count));
			count += elements.Length;
		}
	}
}
