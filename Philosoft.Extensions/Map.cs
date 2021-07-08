using System.Diagnostics.CodeAnalysis;
using System.Traits;
using System.Traits.Concepts;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Applies the <paramref name="func"/> to each element of the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="func">The <see cref="Func{T, TResult}"/> to apply to each element.</param>
		/// <remarks>
		/// This is a mutating operation. It mutates the collection rather than constructing a new collection for the result. This is done for two reasons. First is that we can't generalize <see cref="Map{TElement}(IList{Int32, TElement}, Func{TElement, TElement})"/> like this while also allowing arbitrary collections to be constructed. Second is performance, as mutating in-place is substantially more efficient. Philosoft is not a pure functional programming library, it just takes inspiration in the form of more practical application of many functional principals.
		/// </remarks>
		public static void Map<TElement>([DisallowNull] this IList<Int32, TElement> collection, [DisallowNull] Func<TElement, TElement> func) {
			for (Int32 i = 0; i < collection.Count; i++) {
				collection[i] = func(collection[i]);
			}
		}
	}
}
