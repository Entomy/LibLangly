using System.Diagnostics.CodeAnalysis;
using System.Traits;
using System.Traits.Concepts;
using Numbersome;

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
		public static Boolean ContainsOnly<TElement, TEnumerator>([DisallowNull] this ISequence<TElement, TEnumerator> collection, [AllowNull] TElement element) where TEnumerator : notnull, ICount, ICurrent<TElement>, IMoveNext, IReset {
			TEnumerator enumerator = collection.GetEnumerator();
			while (enumerator.MoveNext()) {
				if (!Equals(enumerator.Current, element)) return false;
			}
			return true;
		}

		/// <summary>
		/// Determines whether this collection contains the specified <paramref name="elements"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if <paramref name="elements"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		public static Boolean ContainsOnly<TElement, TEnumerator>([DisallowNull] this ISequence<TElement, TEnumerator> collection, [AllowNull] params TElement[] elements) where TEnumerator : notnull, ICount, ICurrent<TElement>, IMoveNext, IReset => ContainsOnly(collection, elements.AsSpan());

		/// <summary>
		/// Determines whether this collection contains the specified <paramref name="elements"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if <paramref name="elements"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		public static Boolean ContainsOnly<TElement, TEnumerator>([DisallowNull] this ISequence<TElement, TEnumerator> collection, ArraySegment<TElement?> elements) where TEnumerator : notnull, ICount, ICurrent<TElement>, IMoveNext, IReset => ContainsOnly(collection, elements.AsSpan());

		/// <summary>
		/// Determines whether this collection contains the specified <paramref name="elements"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if <paramref name="elements"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		public static Boolean ContainsOnly<TElement, TEnumerator>([DisallowNull] this ISequence<TElement, TEnumerator> collection, Memory<TElement?> elements) where TEnumerator : notnull, ICount, ICurrent<TElement>, IMoveNext, IReset => ContainsOnly(collection, elements.Span);

		/// <summary>
		/// Determines whether this collection contains the specified <paramref name="elements"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if <paramref name="elements"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		public static Boolean ContainsOnly<TElement, TEnumerator>([DisallowNull] this ISequence<TElement, TEnumerator> collection, Span<TElement?> elements) where TEnumerator : notnull, ICount, ICurrent<TElement>, IMoveNext, IReset => ContainsOnly(collection, (ReadOnlySpan<TElement?>)elements);

		/// <summary>
		/// Determines whether this collection contains the specified <paramref name="elements"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if <paramref name="elements"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		public static Boolean ContainsOnly<TElement, TEnumerator>([DisallowNull] this ISequence<TElement, TEnumerator> collection, ReadOnlySpan<TElement?> elements) where TEnumerator : notnull, ICount, ICurrent<TElement>, IMoveNext, IReset {
			Boolean[] found = new Boolean[elements.Length];
			TEnumerator enumerator = collection.GetEnumerator();
			while (enumerator.MoveNext()) {
				for (Int32 i = 0; i < elements.Length; i++) {
					if (!Equals(enumerator.Current, elements[i])) found[i] = true;
				}
			}
			return found.ContainsOnlyTrue();
		}

		/// <summary>
		/// Determines whether this collection contains any elements described by the <paramref name="predicate"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="predicate">The predicate describing the element to attempt to find.</param>
		/// <returns><see langword="true"/> if an element described by the <paramref name="predicate"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		public static Boolean ContainsOnly<TElement, TEnumerator>([DisallowNull] this ISequence<TElement, TEnumerator> collection, [AllowNull] Predicate<TElement?> predicate) where TEnumerator : notnull, ICount, ICurrent<TElement>, IMoveNext, IReset {
			foreach (TElement? item in collection) {
				if (!(predicate?.Invoke(item) ?? item is null)) return false;
			}
			return true;
		}
	}
}
