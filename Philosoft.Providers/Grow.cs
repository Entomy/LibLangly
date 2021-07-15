using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Traits.Concepts {
	public static partial class Collection {
		/// <summary>
		/// Grows this collection by a computed factor.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static TElement?[] Grow<TElement>([DisallowNull] TElement?[] collection) => Resize(collection, (Int32)((collection.Length + 4) * φ));

		/// <summary>
		/// Grows this collection by a computed factor, to at least a specified <paramref name="minimum"/>.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		/// <param name="minimum">The minimum allowed size.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: NotNull]
		public static TElement?[] Grow<TElement>([DisallowNull] TElement?[] collection, Int32 minimum) {
			Double size = collection.Length;
			while (size < minimum) {
				size += 4.0;
				size *= φ;
			}
			return Resize(collection, (Int32)size);
		}
	}
}
