using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class PhilosoftExtensions {
		/// <summary>
		/// Searches for the specified <paramref name="element"/> and returns the index of its last occurrence.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements of the collection.</typeparam>
		/// <param name="collection">The collection to search.</param>
		/// <param name="element">The item to locate in the collection.</param>
		/// <returns>The index of the last occurrence of <paramref name="element"/> in <paramref name="collection"/>, if found; otherwise, <c>-1</c>.</returns>
		[SuppressMessage("Performance", "HAA0601:Value type to reference type conversion causing boxing allocation", Justification = "There's nothing I can do about this.")]
		public static nint IndexOfLast<TElement>([AllowNull] this IIndexReadOnly<TElement> collection, [AllowNull] TElement element) {
			if (collection is null) {
				return -1;
			} else if (element is null) {
				return IndexOfLastNull(collection);
			}
			for (nint i = collection.Count - 1; i >= 0; i--) {
				if (element.Equals(collection[i])) {
					return i;
				}
			}
			return -1;
		}

		/// <summary>
		/// Searches for the specified <paramref name="element"/> and returns the index of its last occurrence.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements of the collection.</typeparam>
		/// <param name="collection">The collection to search.</param>
		/// <param name="element">The item to locate in the collection.</param>
		/// <returns>The index of the last occurrence of <paramref name="element"/> in <paramref name="collection"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfLast<TElement>([AllowNull] this IIndexReadOnly<TElement> collection, [AllowNull] IEquatable<TElement> element) {
			if (collection is null) {
				return -1;
			} else if (element is null) {
				return IndexOfLastNull(collection);
			}
			for (nint i = collection.Count - 1; i >= 0; i--) {
				if (element.Equals(collection[i])) {
					return i;
				}
			}
			return -1;
		}

		/// <summary>
		/// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the last occurrence in the entire collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="match">The <see cref="Predicate{T}"/> delegate the defines the conditions of the element to search for.</param>
		/// <returns>The zero-based index of the first occurrence of an element that matches the conditions defined by <paramref name="match"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfLast<TElement>([AllowNull] this IIndexReadOnly<TElement> collection, [AllowNull] Predicate<TElement> match) {
			if (collection is null) {
				return -1;
			} else if (match is null) {
				return IndexOfLastNull(collection);
			}
			for (nint i = collection.Count - 1; i >= 0; i--) {
				if (match(collection[i])) {
					return i;
				}
			}
			return -1;
		}

		/// <summary>
		/// Searches for the specified <paramref name="element"/> and returns the index of its last occurrence.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements of the collection.</typeparam>
		/// <param name="collection">The collection to search.</param>
		/// <param name="element">The item to locate in the collection.</param>
		/// <returns>The index of the last occurrence of <paramref name="element"/> in <paramref name="collection"/>, if found; otherwise, <c>-1</c>.</returns>
		[SuppressMessage("Performance", "HAA0601:Value type to reference type conversion causing boxing allocation", Justification = "There's nothing I can do about this.")]
		public static nint IndexOfLast<TElement>([AllowNull] this IIndexRefReadOnly<TElement> collection, [AllowNull] TElement element) {
			if (collection is null) {
				return -1;
			} else if (element is null) {
				return IndexOfLastNull(collection);
			}
			for (nint i = collection.Count - 1; i >= 0; i--) {
				if (element.Equals(collection[i])) {
					return i;
				}
			}
			return -1;
		}

		/// <summary>
		/// Searches for the specified <paramref name="element"/> and returns the index of its last occurrence.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements of the collection.</typeparam>
		/// <param name="collection">The collection to search.</param>
		/// <param name="element">The item to locate in the collection.</param>
		/// <returns>The index of the last occurrence of <paramref name="element"/> in <paramref name="collection"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfLast<TElement>([AllowNull] this IIndexRefReadOnly<TElement> collection, [AllowNull] IEquatable<TElement> element) {
			if (collection is null) {
				return -1;
			} else if (element is null) {
				return IndexOfLastNull(collection);
			}
			for (nint i = collection.Count - 1; i >= 0; i--) {
				if (element.Equals(collection[i])) {
					return i;
				}
			}
			return -1;
		}

		/// <summary>
		/// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the last occurrence in the entire collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="match">The <see cref="Predicate{T}"/> delegate the defines the conditions of the element to search for.</param>
		/// <returns>The zero-based index of the first occurrence of an element that matches the conditions defined by <paramref name="match"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfLast<TElement>([AllowNull] this IIndexRefReadOnly<TElement> collection, [AllowNull] Predicate<TElement> match) {
			if (collection is null) {
				return -1;
			} else if (match is null) {
				return IndexOfLastNull(collection);
			}
			for (nint i = collection.Count - 1; i >= 0; i--) {
				if (match(collection[i])) {
					return i;
				}
			}
			return -1;
		}

		private static nint IndexOfLastNull<TElement>([DisallowNull] IIndexReadOnly<TElement> collection) {
			for (nint i = collection.Count - 1; i >= 0; i--) {
				if (collection[i] is null) {
					return i;
				}
			}
			return -1;
		}

		private static nint IndexOfLastNull<TElement>([DisallowNull] IIndexRefReadOnly<TElement> collection) {
			for (nint i = collection.Count - 1; i >= 0; i--) {
				if (collection[i] is null) {
					return i;
				}
			}
			return -1;
		}
	}
}
