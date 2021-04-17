using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class PhilosoftExtensions {
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
		public static TElement[] Grow<TElement>([AllowNull] this TElement[] collection) => collection is null || collection.Length <= 8 ? collection.Resize(13) : collection.Resize((nint)(collection.Length * φ));

		/// <summary>
		/// Grows the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static Memory<TElement> Grow<TElement>(this Memory<TElement> collection) => collection.Length <= 8 ? collection.Resize(13) : collection.Resize((nint)(collection.Length * φ));

		/// <summary>
		/// Grows the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static Span<TElement> Grow<TElement>(this Span<TElement> collection) => collection.Length <= 8 ? collection.Resize(13) : collection.Resize((nint)(collection.Length * φ));

	}
}
