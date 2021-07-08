using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Traits.Concepts {
	public static partial class Collection {
		/// <summary>
		/// Prepends the elements onto this object, as a batch.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="element">The element to prepend.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Prepend<TElement>([AllowNull] TElement?[] collection, ref Int32 count, [AllowNull] TElement element) => Prepend(collection.AsSpan(), ref count, element);

		/// <summary>
		/// Prepends the elements onto this object, as a batch.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="element">The element to prepend.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Prepend<TElement>(Memory<TElement?> collection, ref Int32 count, [AllowNull] TElement element) => Prepend(collection.Span, ref count, element);

		/// <summary>
		/// Prepends the elements onto this object, as a batch.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="element">The element to prepend.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Prepend<TElement>(Span<TElement?> collection, ref Int32 count, [AllowNull] TElement element) {
			ShiftRight(collection, count, 1);
			collection[0] = element;
			count++;
		}

		/// <summary>
		/// Prepends the elements onto this object, as a batch.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="elements">The elements to prepend.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Prepend<TElement>([AllowNull] TElement?[] collection, ref Int32 count, ReadOnlySpan<TElement?> elements) => Prepend(collection.AsSpan(), ref count, elements);

		/// <summary>
		/// Prepends the elements onto this object, as a batch.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="elements">The elements to prepend.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Prepend<TElement>(Memory<TElement?> collection, ref Int32 count, ReadOnlySpan<TElement?> elements) => Prepend(collection.Span, ref count, elements);

		/// <summary>
		/// Prepends the elements onto this object, as a batch.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="elements">The elements to prepend.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Prepend<TElement>(Span<TElement?> collection, ref Int32 count, ReadOnlySpan<TElement?> elements) {
			ShiftRight(collection, count, elements.Length);
			elements.CopyTo(collection);
			count += elements.Length;
		}
	}
}
