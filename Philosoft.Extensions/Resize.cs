using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="capacity">The new capacity of the collection.</param>
		[return: MaybeNull]
		public static TSelf Resize<TSelf>([AllowNull] this IResize<TSelf> collection, nint capacity) where TSelf : IResize<TSelf> => collection is not null ? collection.Resize(capacity) : default;

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="capacity">The new capacity of the collection.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TElement[] Resize<TElement>([AllowNull] this TElement[] collection, nint capacity) {
			if (collection is null) {
				return null;
			}
			return ResizeKernel<TElement>(collection, capacity);
		}

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="capacity">The new capacity of the collection.</param>
		public static Memory<TElement> Resize<TElement>(this Memory<TElement> collection, nint capacity) => ResizeKernel<TElement>(collection.Span, capacity);

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="capacity">The new capacity of the collection.</param>
		public static Span<TElement> Resize<TElement>(this Span<TElement> collection, nint capacity) => ResizeKernel<TElement>(collection, capacity);

		[return: NotNull]
		private static TElement[] ResizeKernel<TElement>(ReadOnlySpan<TElement> collection, nint capacity) {
			TElement[] array = new TElement[capacity];
			collection.CopyTo(array);
			return array;
		}
	}
}
