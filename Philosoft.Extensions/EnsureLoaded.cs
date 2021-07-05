using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Ensures <paramref name="amount"/> bytes are loaded into this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of <typeparamref name="TElement"/> to have loaded.</param>
		/// <param name="source">The source to load data from.</param>
		public static void EnsureLoaded<TElement>([DisallowNull] this IWrite<TElement> collection, nint amount, [AllowNull] IRead<TElement> source) {
			if (source is not null) {
				for (nint i = 0; i < amount; i++) {
					collection.Load(source);
				}
			}
		}
	}
}
