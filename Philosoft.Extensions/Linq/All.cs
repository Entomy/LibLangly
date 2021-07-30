using System.Traits;

namespace System.Linq {
	public static partial class TraitExtensions {
		/// <summary>
		/// Determines whether all elements of a sequence satisfy a condition.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="source"/>.</typeparam>
		/// <param name="source">An <see cref="IGetEnumerator{TElement, TEnumerator}"/> that contains the elements to apply the predicate to.</param>
		/// <param name="predicate">A function to test each element for a condition.</param>
		/// <returns><see langword="true"/> if every element of the source sequence passes the test in the specified predicate, or if the sequence is empty; otherwise, <see langword="false"/>.</returns>
		public static Boolean All<TSource, TEnumerator>(this IGetEnumerator<TSource, TEnumerator>? source, Func<TSource, Boolean>? predicate) where TEnumerator : notnull, ICurrent<TSource>, IMoveNext {
			if (source is null) { throw new ArgumentNullException(nameof(source)); }
			if (predicate is null) { throw new ArgumentNullException(nameof(predicate)); }
			foreach (TSource element in source) {
				if (!predicate(element)) {
					return false;
				}
			}
			return true;
		}
	}
}
