using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class PhilosoftExtensions {
		#region IndexOfFirst(Collection, TElement)
		/// <summary>
		/// Searches for the specified <paramref name="element"/> and returns the index of its first occurrence.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements of the collection.</typeparam>
		/// <param name="collection">The collection to search.</param>
		/// <param name="element">The item to locate in the collection.</param>
		/// <returns>The index of the first occurrence of <paramref name="element"/> in <paramref name="collection"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfFirst<TElement>([AllowNull] this IIndexReadOnly<TElement> collection, [AllowNull] TElement element) {
			if (collection is null) {
				return -1;
			} else if (element is null) {
				return IndexOfFirstNull(collection);
			}
			for (nint i = 0; i < collection.Count; i++) {
				if (element.Equals(collection[i])) {
					return i;
				}
			}
			return -1;
		}

		/// <summary>
		/// Searches for the specified <paramref name="element"/> and returns the index of its first occurrence.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements of the collection.</typeparam>
		/// <param name="collection">The collection to search.</param>
		/// <param name="element">The item to locate in the collection.</param>
		/// <returns>The index of the first occurrence of <paramref name="element"/> in <paramref name="collection"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfFirst<TElement>([AllowNull] this IIndexRefReadOnly<TElement> collection, [AllowNull] TElement element) {
			if (collection is null) {
				return -1;
			} else if (element is null) {
				return IndexOfFirstNull(collection);
			}
			for (nint i = 0; i < collection.Count; i++) {
				if (element.Equals(collection[i])) {
					return i;
				}
			}
			return -1;
		}

		/// <summary>
		/// Searches for the specified <paramref name="element"/> and returns the index of its first occurrence.
		/// </summary>
		/// <param name="collection">The collection to search.</param>
		/// <param name="element">The item to locate in the collection.</param>
		/// <returns>The index of the first occurrence of <paramref name="element"/> in <paramref name="collection"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfFirst([AllowNull] this String collection, Char element) => collection is not null ? IndexOfFirst(collection.AsSpan(), element) : -1;

		/// <summary>
		/// Searches for the specified <paramref name="element"/> and returns the index of its first occurrence.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements of the collection.</typeparam>
		/// <param name="collection">The collection to search.</param>
		/// <param name="element">The item to locate in the collection.</param>
		/// <returns>The index of the first occurrence of <paramref name="element"/> in <paramref name="collection"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfFirst<TElement>([AllowNull] this TElement[] collection, [AllowNull] TElement element) => collection is not null ? IndexOfFirst(collection.AsSpan(), element) : -1;

		/// <summary>
		/// Searches for the specified <paramref name="element"/> and returns the index of its first occurrence.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements of the collection.</typeparam>
		/// <param name="collection">The collection to search.</param>
		/// <param name="element">The item to locate in the collection.</param>
		/// <returns>The index of the first occurrence of <paramref name="element"/> in <paramref name="collection"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfFirst<TElement>(this Memory<TElement> collection, [AllowNull] TElement element) => IndexOfFirst(collection.Span, element);

		/// <summary>
		/// Searches for the specified <paramref name="element"/> and returns the index of its first occurrence.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements of the collection.</typeparam>
		/// <param name="collection">The collection to search.</param>
		/// <param name="element">The item to locate in the collection.</param>
		/// <returns>The index of the first occurrence of <paramref name="element"/> in <paramref name="collection"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfFirst<TElement>(this ReadOnlyMemory<TElement> collection, [AllowNull] TElement element) => IndexOfFirst(collection.Span, element);

		/// <summary>
		/// Searches for the specified <paramref name="element"/> and returns the index of its first occurrence.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements of the collection.</typeparam>
		/// <param name="collection">The collection to search.</param>
		/// <param name="element">The item to locate in the collection.</param>
		/// <returns>The index of the first occurrence of <paramref name="element"/> in <paramref name="collection"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfFirst<TElement>(this Span<TElement> collection, [AllowNull] TElement element) => IndexOfFirst((ReadOnlySpan<TElement>)collection, element);

		/// <summary>
		/// Searches for the specified <paramref name="element"/> and returns the index of its first occurrence.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements of the collection.</typeparam>
		/// <param name="collection">The collection to search.</param>
		/// <param name="element">The item to locate in the collection.</param>
		/// <returns>The index of the first occurrence of <paramref name="element"/> in <paramref name="collection"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfFirst<TElement>(this ReadOnlySpan<TElement> collection, [AllowNull] TElement element) {
			if (element is null) {
				return IndexOfFirstNull(collection);
			}
			for (Int32 i = 0; i < collection.Length; i++) {
				if (element.Equals(collection[i])) {
					return i;
				}
			}
			return -1;
		}
		#endregion

		#region IndexOfFirst(Collection, IEquatable<TElement>)
		/// <summary>
		/// Searches for the specified <paramref name="element"/> and returns the index of its first occurrence.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements of the collection.</typeparam>
		/// <param name="collection">The collection to search.</param>
		/// <param name="element">The item to locate in the collection.</param>
		/// <returns>The index of the first occurrence of <paramref name="element"/> in <paramref name="collection"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfFirst<TElement>([AllowNull] this IIndexReadOnly<TElement> collection, [AllowNull] IEquatable<TElement> element) {
			if (collection is null) {
				return -1;
			} else if (element is null) {
				return IndexOfFirstNull(collection);
			}
			for (nint i = 0; i < collection.Count; i++) {
				if (element.Equals(collection[i])) {
					return i;
				}
			}
			return -1;
		}

		/// <summary>
		/// Searches for the specified <paramref name="element"/> and returns the index of its first occurrence.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements of the collection.</typeparam>
		/// <param name="collection">The collection to search.</param>
		/// <param name="element">The item to locate in the collection.</param>
		/// <returns>The index of the first occurrence of <paramref name="element"/> in <paramref name="collection"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfFirst<TElement>([AllowNull] this IIndexRefReadOnly<TElement> collection, [AllowNull] IEquatable<TElement> element) {
			if (collection is null) {
				return -1;
			} else if (element is null) {
				return IndexOfFirstNull(collection);
			}
			for (nint i = 0; i < collection.Count; i++) {
				if (element.Equals(collection[i])) {
					return i;
				}
			}
			return -1;
		}

		/// <summary>
		/// Searches for the specified <paramref name="element"/> and returns the index of its first occurrence.
		/// </summary>
		/// <param name="collection">The collection to search.</param>
		/// <param name="element">The item to locate in the collection.</param>
		/// <returns>The index of the first occurrence of <paramref name="element"/> in <paramref name="collection"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfFirst([AllowNull] this String collection, [AllowNull] IEquatable<Char> element) => collection is not null ? IndexOfFirst(collection.AsSpan(), element) : -1;

		/// <summary>
		/// Searches for the specified <paramref name="element"/> and returns the index of its first occurrence.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements of the collection.</typeparam>
		/// <param name="collection">The collection to search.</param>
		/// <param name="element">The item to locate in the collection.</param>
		/// <returns>The index of the first occurrence of <paramref name="element"/> in <paramref name="collection"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfFirst<TElement>([AllowNull] this TElement[] collection, [AllowNull] IEquatable<TElement> element) => collection is not null ? IndexOfFirst(collection.AsSpan(), element) : -1;

		/// <summary>
		/// Searches for the specified <paramref name="element"/> and returns the index of its first occurrence.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements of the collection.</typeparam>
		/// <param name="collection">The collection to search.</param>
		/// <param name="element">The item to locate in the collection.</param>
		/// <returns>The index of the first occurrence of <paramref name="element"/> in <paramref name="collection"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfFirst<TElement>(this Memory<TElement> collection, [AllowNull] IEquatable<TElement> element) => IndexOfFirst(collection.Span, element);

		/// <summary>
		/// Searches for the specified <paramref name="element"/> and returns the index of its first occurrence.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements of the collection.</typeparam>
		/// <param name="collection">The collection to search.</param>
		/// <param name="element">The item to locate in the collection.</param>
		/// <returns>The index of the first occurrence of <paramref name="element"/> in <paramref name="collection"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfFirst<TElement>(this ReadOnlyMemory<TElement> collection, [AllowNull] IEquatable<TElement> element) => IndexOfFirst(collection.Span, element);

		/// <summary>
		/// Searches for the specified <paramref name="element"/> and returns the index of its first occurrence.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements of the collection.</typeparam>
		/// <param name="collection">The collection to search.</param>
		/// <param name="element">The item to locate in the collection.</param>
		/// <returns>The index of the first occurrence of <paramref name="element"/> in <paramref name="collection"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfFirst<TElement>(this Span<TElement> collection, [AllowNull] IEquatable<TElement> element) => IndexOfFirst((ReadOnlySpan<TElement>)collection, element);

		/// <summary>
		/// Searches for the specified <paramref name="element"/> and returns the index of its first occurrence.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements of the collection.</typeparam>
		/// <param name="collection">The collection to search.</param>
		/// <param name="element">The item to locate in the collection.</param>
		/// <returns>The index of the first occurrence of <paramref name="element"/> in <paramref name="collection"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfFirst<TElement>(this ReadOnlySpan<TElement> collection, [AllowNull] IEquatable<TElement> element) {
			if (element is null) {
				return IndexOfFirstNull(collection);
			}
			for (Int32 i = 0; i < collection.Length; i++) {
				if (element.Equals(collection[i])) {
					return i;
				}
			}
			return -1;
		}
		#endregion

		#region IndexOfFirst(Collection, Predicate<TElement>)
		/// <summary>
		/// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence in the entire collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="predicate">The <see cref="Predicate{T}"/> delegate the defines the conditions of the element to search for.</param>
		/// <returns>The zero-based index of the first occurrence of an element that matches the conditions defined by <paramref name="predicate"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfFirst<TElement>([AllowNull] this IIndexReadOnly<TElement> collection, [AllowNull] Predicate<TElement> predicate) {
			if (collection is null) {
				return -1;
			} else if (predicate is null) {
				return IndexOfFirstNull(collection);
			}
			for (nint i = 0; i < collection.Count; i++) {
				if (predicate(collection[i])) {
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
		/// <param name="predicate">The <see cref="Predicate{T}"/> delegate the defines the conditions of the element to search for.</param>
		/// <returns>The zero-based index of the first occurrence of an element that matches the conditions defined by <paramref name="predicate"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfFirst<TElement>([AllowNull] this IIndexRefReadOnly<TElement> collection, [AllowNull] Predicate<TElement> predicate) {
			if (collection is null) {
				return -1;
			} else if (predicate is null) {
				return IndexOfFirstNull(collection);
			}
			for (nint i = 0; i < collection.Count; i++) {
				if (predicate(collection[i])) {
					return i;
				}
			}
			return -1;
		}

		/// <summary>
		/// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence in the entire collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="predicate">The <see cref="Predicate{T}"/> delegate the defines the conditions of the element to search for.</param>
		/// <returns>The zero-based index of the first occurrence of an element that matches the conditions defined by <paramref name="predicate"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfFirst([AllowNull] this String collection, [AllowNull] Predicate<Char> predicate) => collection is not null ? IndexOfFirst(collection.AsSpan(), predicate) : -1;

		/// <summary>
		/// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence in the entire collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="predicate">The <see cref="Predicate{T}"/> delegate the defines the conditions of the element to search for.</param>
		/// <returns>The zero-based index of the first occurrence of an element that matches the conditions defined by <paramref name="predicate"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfFirst<TElement>([AllowNull] this TElement[] collection, [AllowNull] Predicate<TElement> predicate) => collection is not null ? IndexOfFirst(collection.AsSpan(), predicate) : -1;

		/// <summary>
		/// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence in the entire collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="predicate">The <see cref="Predicate{T}"/> delegate the defines the conditions of the element to search for.</param>
		/// <returns>The zero-based index of the first occurrence of an element that matches the conditions defined by <paramref name="predicate"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfFirst<TElement>(this Memory<TElement> collection, [AllowNull] Predicate<TElement> predicate) => IndexOfFirst(collection.Span, predicate);

		/// <summary>
		/// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence in the entire collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="predicate">The <see cref="Predicate{T}"/> delegate the defines the conditions of the element to search for.</param>
		/// <returns>The zero-based index of the first occurrence of an element that matches the conditions defined by <paramref name="predicate"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfFirst<TElement>(this ReadOnlyMemory<TElement> collection, [AllowNull] Predicate<TElement> predicate) => IndexOfFirst(collection.Span, predicate);

		/// <summary>
		/// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence in the entire collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="predicate">The <see cref="Predicate{T}"/> delegate the defines the conditions of the element to search for.</param>
		/// <returns>The zero-based index of the first occurrence of an element that matches the conditions defined by <paramref name="predicate"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfFirst<TElement>(this Span<TElement> collection, [AllowNull] Predicate<TElement> predicate) => IndexOfFirst((ReadOnlySpan<TElement>)collection, predicate);

		/// <summary>
		/// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence in the entire collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="predicate">The <see cref="Predicate{T}"/> delegate the defines the conditions of the element to search for.</param>
		/// <returns>The zero-based index of the first occurrence of an element that matches the conditions defined by <paramref name="predicate"/>, if found; otherwise, <c>-1</c>.</returns>
		public static nint IndexOfFirst<TElement>(this ReadOnlySpan<TElement> collection, [AllowNull] Predicate<TElement> predicate) {
			if (predicate is null) {
				return IndexOfFirstNull(collection);
			}
			for (Int32 i = 0; i < collection.Length; i++) {
				if (predicate(collection[i])) {
					return i;
				}
			}
			return -1;
		}
		#endregion

		private static nint IndexOfFirstNull<TElement>([DisallowNull] IIndexReadOnly<TElement> collection) {
			for (nint i = 0; i < collection.Count; i++) {
				if (collection[i] is null) {
					return i;
				}
			}
			return -1;
		}

		private static nint IndexOfFirstNull<TElement>([DisallowNull] IIndexRefReadOnly<TElement> collection) {
			for (nint i = 0; i < collection.Count; i++) {
				if (collection[i] is null) {
					return i;
				}
			}
			return -1;
		}

		private static nint IndexOfFirstNull<TElement>(ReadOnlySpan<TElement> collection) {
			for (Int32 i = 0; i < collection.Length; i++) {
				if (collection[i] is null) {
					return i;
				}
			}
			return -1;
		}
	}
}
