using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class PhilosoftExtensions {
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
		public static TElement[] Shrink<TElement>([AllowNull] this TElement[] collection) => collection is not null ? collection.Resize((nint)(collection.Length / φ)) : null;

		/// <summary>
		/// Shrinks the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static Memory<TElement> Shrink<TElement>(this Memory<TElement> collection) => collection.Resize((nint)(collection.Length / φ));

		/// <summary>
		/// Shrinks the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static ReadOnlyMemory<TElement> Shrink<TElement>(this ReadOnlyMemory<TElement> collection) => collection.Resize((nint)(collection.Length / φ));
	}
}
