using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Shrinks the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TSelf Shrink<TSelf>([AllowNull] this IResize<TSelf> collection) where TSelf : IResize<TSelf> => collection is not null ? collection.Shrink() : default;

		/// <summary>
		/// Shrinks the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TElement[] Shrink<TElement>([AllowNull] this TElement[] collection) => ShrinkKernel<TElement>(collection);

		/// <summary>
		/// Shrinks the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static Memory<TElement> Shrink<TElement>(this Memory<TElement> collection) => ShrinkKernel<TElement>(collection.Span);

		/// <summary>
		/// Shrinks the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static Span<TElement> Shrink<TElement>(this Span<TElement> collection) => ShrinkKernel<TElement>(collection);

		[return: NotNull]
		private static TElement[] ShrinkKernel<TElement>(ReadOnlySpan<TElement> collection) {
			nint capacity = (nint)(collection.Length / φ);
			TElement[] array = new TElement[capacity];
			collection.Slice(0, capacity).CopyTo(array);
			return array;
		}
	}
}
