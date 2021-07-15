using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Determines whether this collection contains any of the specified <paramref name="elements"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		public static Boolean ContainsAny<TElement, TEnumerator>([DisallowNull] this IGetEnumerator<TElement, TEnumerator> collection, params TElement[]? elements) where TEnumerator : notnull, ICurrent<TElement>, IMoveNext => ContainsAny(collection, elements.AsSpan());

		/// <summary>
		/// Determines whether this collection contains any of the specified <paramref name="elements"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		public static Boolean ContainsAny<TElement, TEnumerator>([DisallowNull] this IGetEnumerator<TElement, TEnumerator> collection, ArraySegment<TElement> elements) where TEnumerator : notnull, ICurrent<TElement>, IMoveNext => ContainsAny(collection, elements.AsSpan());

		/// <summary>
		/// Determines whether this collection contains any of the specified <paramref name="elements"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		public static Boolean ContainsAny<TElement, TEnumerator>([DisallowNull] this IGetEnumerator<TElement, TEnumerator> collection, Memory<TElement> elements) where TEnumerator : notnull, ICurrent<TElement>, IMoveNext => ContainsAny(collection, elements.Span);

		/// <summary>
		/// Determines whether this collection contains any of the specified <paramref name="elements"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		public static Boolean ContainsAny<TElement, TEnumerator>([DisallowNull] this IGetEnumerator<TElement, TEnumerator> collection, ReadOnlyMemory<TElement> elements) where TEnumerator : notnull, ICurrent<TElement>, IMoveNext => ContainsAny(collection, elements.Span);

		/// <summary>
		/// Determines whether this collection contains any of the specified <paramref name="elements"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		public static Boolean ContainsAny<TElement, TEnumerator>([DisallowNull] this IGetEnumerator<TElement, TEnumerator> collection, Span<TElement> elements) where TEnumerator : notnull, ICurrent<TElement>, IMoveNext => ContainsAny(collection, (ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Determines whether this collection contains any of the specified <paramref name="elements"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		public static Boolean ContainsAny<TElement, TEnumerator>([DisallowNull] this IGetEnumerator<TElement, TEnumerator> collection, ReadOnlySpan<TElement> elements) where TEnumerator : notnull, ICurrent<TElement>, IMoveNext {
			foreach (TElement element in elements) {
				if (collection.Contains(element)) {
					return true;
				}
			}
			return false;
		}
	}
}
