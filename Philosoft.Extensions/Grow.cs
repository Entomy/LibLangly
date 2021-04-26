using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Grows the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TSelf Grow<TSelf>([AllowNull] this IResize<TSelf> collection) where TSelf : IResize<TSelf> => collection is not null ? collection.Grow() : default;

		/// <summary>
		/// Grows the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TElement[] Grow<TElement>([AllowNull] this TElement[] collection) {
			if (collection is null) {
				return null;
			}
			return GrowKernel<TElement>(collection);
		}

		/// <summary>
		/// Grows the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static Memory<TElement> Grow<TElement>(this Memory<TElement> collection) => GrowKernel<TElement>(collection.Span);

		/// <summary>
		/// Grows the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static Span<TElement> Grow<TElement>(this Span<TElement> collection) => GrowKernel<TElement>(collection);

		[return: NotNull]
		private static TElement[] GrowKernel<TElement>(ReadOnlySpan<TElement> collection) {
			TElement[] array = new TElement[collection.Length <= 8 ? 13 : (nint)(collection.Length * φ)];
			collection.CopyTo(array);
			return array;
		}
	}
}
