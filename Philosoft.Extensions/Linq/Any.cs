using System.Traits;

namespace System.Linq {
	public static partial class TraitExtensions {
		/// <summary>
		/// Determines whether a sequence contains any elements.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="source"/>.</typeparam>
		/// <param name="source">The <see cref="IGetEnumerator{TElement, TEnumerator}"/> to check for emptiness.</param>
		/// <returns><see langword="true"/> if the source sequence contains any elements; otherwise, <see langword="false"/>.</returns>
		public static Boolean Any<TSource, TEnumerator>(this IGetEnumerator<TSource, TEnumerator>? source) where TEnumerator : notnull, ICurrent<TSource>, IMoveNext => source?.GetEnumerator().MoveNext() ?? throw new ArgumentNullException(nameof(source));

		/// <summary>
		/// Determines whether any element of a sequence satisfies a condition.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="source"/>.</typeparam>
		/// <param name="source">An <see cref="IGetEnumerator{TElement, TEnumerator}"/> whos elements to apply the predicate to.</param>
		/// <param name="predicate">A function to test each element for a condition.</param>
		/// <returns><see langword="true"/> if the source sequence is not empty and at least one of its elements passes the test in the specified predicate; otherwise, <see langword="false"/>.</returns>
		public static Boolean Any<TSource, TEnumerator>(this IGetEnumerator<TSource, TEnumerator>? source, Func<TSource, Boolean> predicate) where TEnumerator : notnull, ICurrent<TSource>, IMoveNext {
			if (source is null) { throw new ArgumentNullException(nameof(source)); }
			if (predicate is null) { throw new ArgumentNullException(nameof(predicate)); }
			foreach (TSource element in source) {
				if (predicate(element)) { return true; }
			}
			return false;
		}
	}
}
