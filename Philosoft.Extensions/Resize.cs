using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class PhilosoftExtensions {
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
			} else if (collection.Length == 0) {
				return new TElement[capacity];
			}
			TElement[] Array = new TElement[capacity];
			System.Array.Copy(collection, Array, collection.Length);
			return Array;
		}

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="capacity">The new capacity of the collection.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static Memory<TElement> Resize<TElement>(this Memory<TElement> collection, nint capacity) {
			if (collection.Length == 0) {
				return new TElement[capacity];
			}
			TElement[] Array = new TElement[capacity];
			collection.CopyTo(Array);
			return Array;
		}

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="capacity">The new capacity of the collection.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static ReadOnlyMemory<TElement> Resize<TElement>(this ReadOnlyMemory<TElement> collection, nint capacity) {
			if (collection.Length == 0) {
				return new TElement[capacity];
			}
			TElement[] Array = new TElement[capacity];
			collection.CopyTo(Array);
			return Array;
		}
	}
}
