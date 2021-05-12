using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Grows the collection by a computed factor.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static void Grow([DisallowNull] this IResize collection) {
			if (collection.Capacity >= 8) {
				collection.Resize((nint)(collection.Capacity * φ));
			} else {
				collection.Resize(13);
			}
		}

		/// <summary>
		/// Grows the collection by a computed factor, to at least a specified <paramref name="minimum"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="minimum">The minimum allowed size.</param>
		public static void Grow([DisallowNull] this IResize collection, nint minimum) {
			Double size = collection.Capacity;
			while (size < minimum) {
				size += 4.0;
				size *= φ;
			}
			collection.Resize((nint)size);
		}
	}
}
