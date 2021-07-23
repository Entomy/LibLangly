using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences<TElement, TEnumerator>(this IGetEnumerator<TElement, TEnumerator> collection, TElement element) where TEnumerator : notnull, ICurrent<TElement>, IMoveNext {
			nint count = 0;
			foreach (TElement item in collection) {
				if (Equals(element, item)) {
					count++;
				}
			}
			return count;
		}

		/// <summary>
		/// Count all occurrences of elements that match the provided predicate in the collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="predicate">The <see cref="Predicate{T}"/> describing a match of the elements to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences<TElement, TEnumerator>(this IGetEnumerator<TElement, TEnumerator> collection, Predicate<TElement>? predicate) where TEnumerator : notnull, ICurrent<TElement>, IMoveNext {
			nint count = 0;
			foreach (TElement item in collection) {
				if (predicate?.Invoke(item) ?? item is null) {
					count++;
				}
			}
			return count;
		}
	}
}
