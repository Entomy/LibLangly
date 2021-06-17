using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Traits {
	public static partial class Collection {
		/// <summary>
		/// Grows this collection by a computed factor.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static TElement[] Grow<TElement>([AllowNull] TElement[] collection) => GrowKernel<TElement>(collection.AsSpan());

		/// <summary>
		/// Grows this collection by a computed factor.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Memory<TElement> Grow<TElement>(Memory<TElement> collection) => GrowKernel<TElement>(collection.Span);

		/// <summary>
		/// Grows this collection by a computed factor.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ReadOnlyMemory<TElement> Grow<TElement>(ReadOnlyMemory<TElement> collection) => GrowKernel<TElement>(collection.Span);

		/// <summary>
		/// Grows this collection by a computed factor.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Span<TElement> Grow<TElement>(Span<TElement> collection) => GrowKernel<TElement>(collection);

		/// <summary>
		/// Grows this collection by a computed factor.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ReadOnlySpan<TElement> Grow<TElement>(ReadOnlySpan<TElement> collection) => GrowKernel<TElement>(collection);

		/// <summary>
		/// Grows this collection by a computed factor, to at least a specified <paramref name="minimum"/>.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		/// <param name="minimum">The minimum allowed size.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static TElement[] Grow<TElement>([AllowNull] TElement[] collection, nint minimum) => GrowKernel<TElement>(collection.AsSpan(), minimum);

		/// <summary>
		/// Grows this collection by a computed factor, to at least a specified <paramref name="minimum"/>.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		/// <param name="minimum">The minimum allowed size.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Memory<TElement> Grow<TElement>(Memory<TElement> collection, nint minimum) => GrowKernel<TElement>(collection.Span, minimum);

		/// <summary>
		/// Grows this collection by a computed factor, to at least a specified <paramref name="minimum"/>.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		/// <param name="minimum">The minimum allowed size.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ReadOnlyMemory<TElement> Grow<TElement>(ReadOnlyMemory<TElement> collection, nint minimum) => GrowKernel<TElement>(collection.Span, minimum);

		/// <summary>
		/// Grows this collection by a computed factor, to at least a specified <paramref name="minimum"/>.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		/// <param name="minimum">The minimum allowed size.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Span<TElement> Grow<TElement>(Span<TElement> collection, nint minimum) => GrowKernel<TElement>(collection, minimum);

		/// <summary>
		/// Grows this collection by a computed factor, to at least a specified <paramref name="minimum"/>.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		/// <param name="minimum">The minimum allowed size.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ReadOnlySpan<TElement> Grow<TElement>(ReadOnlySpan<TElement> collection, nint minimum) => GrowKernel<TElement>(collection, minimum);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		private static TElement[] GrowKernel<TElement>(ReadOnlySpan<TElement> collection) => ResizeKernel(collection, (nint)((collection.Length + 4) * φ));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		private static TElement[] GrowKernel<TElement>(ReadOnlySpan<TElement> collection, nint minimum) {
			Double size = collection.Length;
			while (size < minimum) {
				size += 4.0;
				size *= φ;
			}
			return ResizeKernel(collection, (nint)size);
		}
	}
}
