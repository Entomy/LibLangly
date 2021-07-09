using System.Diagnostics.CodeAnalysis;
using System.Traits;
using System.Traits.Concepts;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Determines whether this collection contains all of the specified <paramref name="elements"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if all of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		public static Boolean ContainsAll<TElement, TEnumerator>([DisallowNull] this ISequence<TElement, TEnumerator> collection, [AllowNull] params TElement?[] elements) where TEnumerator : notnull, ICount, ICurrent<TElement>, IMoveNext, IReset => ContainsAll(collection, elements.AsSpan());

		/// <summary>
		/// Determines whether this collection contains all of the specified <paramref name="elements"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if all of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		public static Boolean ContainsAll<TElement, TEnumerator>([DisallowNull] this ISequence<TElement, TEnumerator> collection, ArraySegment<TElement?> elements) where TEnumerator : notnull, ICount, ICurrent<TElement>, IMoveNext, IReset => ContainsAll(collection, elements.AsSpan());

		/// <summary>
		/// Determines whether this collection contains all of the specified <paramref name="elements"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if all of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		public static Boolean ContainsAll<TElement, TEnumerator>([DisallowNull] this ISequence<TElement, TEnumerator> collection, Memory<TElement?> elements) where TEnumerator : notnull, ICount, ICurrent<TElement>, IMoveNext, IReset => ContainsAll(collection, elements.Span);

		/// <summary>
		/// Determines whether this collection contains all of the specified <paramref name="elements"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if all of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		public static Boolean ContainsAll<TElement, TEnumerator>([DisallowNull] this ISequence<TElement, TEnumerator> collection, ReadOnlyMemory<TElement?> elements) where TEnumerator : notnull, ICount, ICurrent<TElement>, IMoveNext, IReset => ContainsAll(collection, elements.Span);

		/// <summary>
		/// Determines whether this collection contains all of the specified <paramref name="elements"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if all of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		public static Boolean ContainsAll<TElement, TEnumerator>([DisallowNull] this ISequence<TElement, TEnumerator> collection, Span<TElement?> elements) where TEnumerator : notnull, ICount, ICurrent<TElement>, IMoveNext, IReset => ContainsAll(collection, (ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Determines whether this collection contains all of the specified <paramref name="elements"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if all of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		public static Boolean ContainsAll<TElement, TEnumerator>([DisallowNull] this ISequence<TElement, TEnumerator> collection, ReadOnlySpan<TElement?> elements) where TEnumerator : notnull, ICount, ICurrent<TElement>, IMoveNext, IReset {
			foreach (TElement? element in elements) {
				if (!collection.Contains(element)) {
					return false;
				}
			}
			return true;
		}
	}
}
