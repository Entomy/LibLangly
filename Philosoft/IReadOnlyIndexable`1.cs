using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the collection is indexable, read-only.
	/// </summary>
	/// <typeparam name="TElement">The type in the collection.</typeparam>
	[SuppressMessage("Major Code Smell", "S3246:Generic type parameters should be co/contravariant when possible", Justification = "Agreed, they should. However this isn't even remotely possible in this situation.")]
	public interface IReadOnlyIndexable<TElement> : IReadOnlyIndexable<nint, TElement> {
	}

	public static partial class Extensions {
		/// <summary>
		/// Searches for the specified <paramref name="item"/> and returns the index of its first occurrence.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements of the collection.</typeparam>
		/// <param name="collection">The collection to search.</param>
		/// <param name="item">The item to locate in the collection.</param>
		/// <returns>The index of the first occurrence of <paramref name="item"/> in <paramref name="collection"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOf<TElement>(this IReadOnlyIndexable<TElement> collection, [MaybeNull] Object item) {
			if (collection is null) {
				return -1;
			}
			for (nint i = 0; i < collection.Count; i++) {
				if (collection[i].Equals(item)) {
					return i;
				}
			}
			return -1;
		}

		/// <summary>
		/// Searches for the specified <paramref name="item"/> and returns the index of its first occurrence.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements of the collection.</typeparam>
		/// <param name="collection">The collection to search.</param>
		/// <param name="item">The item to locate in the collection.</param>
		/// <returns>The index of the first occurrence of <paramref name="item"/> in <paramref name="collection"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOf<TElement>(this IReadOnlyIndexable<TElement> collection, [MaybeNull] TElement item) where TElement : IEquatable<TElement> {
			if (collection is null) {
				return -1;
			}
			for (nint i = 0; i < collection.Count; i++) {
				if (collection[i].Equals(item)) {
					return i;
				}
			}
			return -1;
		}

		/// <summary>
		/// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence in the entire collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="match">The <see cref="Predicate{T}"/> delegate the defines the conditions of the element to search for.</param>
		/// <returns>The zero-based index of the first occurrence of an element that matches the conditions defined by <paramref name="match"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOf<TElement>(this IReadOnlyIndexable<TElement> collection, [MaybeNull] Predicate<TElement> match) {
			if (collection is null) {
				return -1;
			}
			if (match is null) {
				// Overload resolution in C# tends to prefer this method when the search parameter is null, so we have to handle this as it was meant to be handled
				for (nint i = 0; i < collection.Count; i++) {
					if (collection[i] is null) {
						return i;
					}
				}
			} else {
				// Actually handle the predicate
				for (nint i = 0; i < collection.Count; i++) {
					if (match(collection[i])) {
						return i;
					}
				}
			}
			return -1;
		}
	}
}
