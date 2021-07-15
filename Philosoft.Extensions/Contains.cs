using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Determines whether this collection contains the specified <paramref name="element"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to attempt to find.</param>
		/// <returns><see langword="true"/> if <paramref name="element"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains<TElement, TEnumerator>([DisallowNull] this IGetEnumerator<TElement, TEnumerator> collection, TElement element) where TEnumerator : notnull, ICurrent<TElement>, IMoveNext {
			foreach (TElement item in collection) {
				if (Equals(element, item)) {
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Determines whether this collection contains any elements described by the <paramref name="predicate"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="predicate">The predicate describing the element to attempt to find.</param>
		/// <returns><see langword="true"/> if an element described by the <paramref name="predicate"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains<TElement, TEnumerator>([DisallowNull] this IGetEnumerator<TElement, TEnumerator> collection, Predicate<TElement>? predicate) where TEnumerator : notnull, ICurrent<TElement>, IMoveNext {
			foreach (TElement item in collection) {
				if (predicate?.Invoke(item) ?? item is null) {
					return true;
				}
			}
			return false;
		}
	}
}
