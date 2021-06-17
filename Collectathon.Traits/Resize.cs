using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Traits {
	public static partial class Collection {
		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="collection">The collection to resize.</param>
		/// <param name="capacity">The new capacity of the collection.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static TElement[] Resize<TElement>([AllowNull] TElement[] collection, nint capacity) => ResizeKernel<TElement>(collection.AsSpan(), capacity);

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="collection">The collection to resize.</param>
		/// <param name="capacity">The new capacity of the collection.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Memory<TElement> Resize<TElement>(Memory<TElement> collection, nint capacity) => ResizeKernel<TElement>(collection.Span, capacity);

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="collection">The collection to resize.</param>
		/// <param name="capacity">The new capacity of the collection.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ReadOnlyMemory<TElement> Resize<TElement>(ReadOnlyMemory<TElement> collection, nint capacity) => ResizeKernel<TElement>(collection.Span, capacity);

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="collection">The collection to resize.</param>
		/// <param name="capacity">The new capacity of the collection.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Span<TElement> Resize<TElement>(Span<TElement> collection, nint capacity) => ResizeKernel<TElement>(collection, capacity);

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="collection">The collection to resize.</param>
		/// <param name="capacity">The new capacity of the collection.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ReadOnlySpan<TElement> Resize<TElement>(ReadOnlySpan<TElement> collection, nint capacity) => ResizeKernel<TElement>(collection, capacity);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		private static TElement[] ResizeKernel<TElement>(ReadOnlySpan<TElement> collection, nint capacity) {
			TElement[] newBuffer = new TElement[capacity];
			collection.Slice(0, (Int32)(capacity > collection.Length ? collection.Length : capacity)).CopyTo(newBuffer);
			return newBuffer;
		}
	}
}
