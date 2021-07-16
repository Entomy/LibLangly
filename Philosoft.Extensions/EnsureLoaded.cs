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
		public static void EnsureLoaded<TElement>(this IWrite<TElement> collection, Int32 amount, IRead<TElement> source) {
			if (source is not null) {
				for (Int32 i = 0; i < amount; i++) {
					collection.Load(source);
				}
			}
		}
	}
}
