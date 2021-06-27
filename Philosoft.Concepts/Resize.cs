using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Traits.Concepts {
	public static partial class Collection {
		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="collection">The collection to resize.</param>
		/// <param name="capacity">The new capacity of the collection.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static TElement[] Resize<TElement>([AllowNull] TElement[] collection, Int32 capacity) => ResizeKernel<TElement>(collection.AsSpan(), capacity);

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="collection">The collection to resize.</param>
		/// <param name="capacity">The new capacity of the collection.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Memory<TElement> Resize<TElement>(Memory<TElement> collection, Int32 capacity) => ResizeKernel<TElement>(collection.Span, capacity);

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="collection">The collection to resize.</param>
		/// <param name="capacity">The new capacity of the collection.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ReadOnlyMemory<TElement> Resize<TElement>(ReadOnlyMemory<TElement> collection, Int32 capacity) => ResizeKernel<TElement>(collection.Span, capacity);

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="collection">The collection to resize.</param>
		/// <param name="capacity">The new capacity of the collection.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Span<TElement> Resize<TElement>(Span<TElement> collection, Int32 capacity) => ResizeKernel<TElement>(collection, capacity);

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="collection">The collection to resize.</param>
		/// <param name="capacity">The new capacity of the collection.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ReadOnlySpan<TElement> Resize<TElement>(ReadOnlySpan<TElement> collection, Int32 capacity) => ResizeKernel<TElement>(collection, capacity);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		private static TElement[] ResizeKernel<TElement>(ReadOnlySpan<TElement> collection, Int32 capacity) {
			TElement[] newBuffer = new TElement[capacity];
			collection.Slice(0, capacity > collection.Length ? collection.Length : capacity).CopyTo(newBuffer);
			return newBuffer;
		}
	}
}
