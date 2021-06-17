using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Traits {
	public static partial class Collection {
		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Insert<TElement>([AllowNull] TElement?[] collection, ref nint count, nint index, [AllowNull] TElement element) => Insert(collection.AsSpan(), ref count, index, element);

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Insert<TElement>(Memory<TElement?> collection, ref nint count, nint index, [AllowNull] TElement element) => Insert(collection.Span, ref count, index, element);

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Insert<TElement>(Span<TElement?> collection, ref nint count, nint index, [AllowNull] TElement element) {
			collection.Slice((Int32)index, (Int32)count - (Int32)index).CopyTo(collection.Slice((Int32)index + 1));
			collection[(Int32)index] = element;
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
		public static void Insert<TElement>([AllowNull] TElement?[] collection, ref nint count, nint index, ReadOnlySpan<TElement?> elements) => Insert(collection.AsSpan(), ref count, index, elements);

		/// <summary>
		/// Inserts the elements into the collection at the specified index, as a batch.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Insert<TElement>(Memory<TElement?> collection, ref nint count, nint index, ReadOnlySpan<TElement?> elements) => Insert(collection.Span, ref count, index, elements);

		/// <summary>
		/// Inserts the elements into the collection at the specified index, as a batch.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Insert<TElement>(Span<TElement?> collection, ref nint count, nint index, ReadOnlySpan<TElement?> elements) {
			collection.Slice((Int32)index, (Int32)count - (Int32)index).CopyTo(collection.Slice((Int32)index + elements.Length));
			elements.CopyTo(collection.Slice((Int32)index));
			count += elements.Length;
		}
	}
}
