using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		#region Occurrences(Collection, TElement)
		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the collection.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences<TElement, TEnumerator>([AllowNull] this ISequence<TElement, TEnumerator> collection, [AllowNull] TElement element) where TEnumerator : IEnumerator<TElement> {
			if (collection is null) {
				return 0;
			} else if (element is null) {
				return NullOccurrences(collection);
			}
			return collection.Occurrences(element);
		}

		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences([AllowNull] this String collection, Char element) => collection is not null ? Occurrences(collection.AsMemory(), element) : 0;

		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the collection.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences<TElement>([AllowNull] this TElement[] collection, [AllowNull] TElement element) => collection is not null ? Occurrences(collection.AsMemory(), element) : 0;

		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the collection.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences<TElement>(this Memory<TElement> collection, [AllowNull] TElement element) => Occurrences(collection.Span, element);

		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the collection.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences<TElement>(this ReadOnlyMemory<TElement> collection, [AllowNull] TElement element) => Occurrences(collection.Span, element);

		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the collection.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences<TElement>(this Span<TElement> collection, [AllowNull] TElement element) => Occurrences((ReadOnlySpan<TElement>)collection, element);

		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the collection.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences<TElement>(this ReadOnlySpan<TElement> collection, [AllowNull] TElement element) {
			if (collection.Length == 0) {
				return 0;
			} else if (element is null) {
				return NullOccurrences(collection);
			}
			nint count = 0;
			foreach (TElement item in collection) {
				if (item is null && element is null) {
					count++;
				} else if (element?.Equals(item) ?? false) {
					count++;
				}
			}
			return count;
		}
		#endregion

		#region Occurrences(Collection, Predicate<TElement>)
		/// <summary>
		/// Count all occurrences of elements that match the provided predicate in the collection.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="predicate">The <see cref="Predicate{T}"/> describing a match of the elements to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences<TElement, TEnumerator>([AllowNull] this ISequence<TElement, TEnumerator> collection, [AllowNull] Predicate<TElement> predicate) where TEnumerator : IEnumerator<TElement> {
			if (collection is null) {
				return 0;
			} else if (predicate is null) {
				return NullOccurrences(collection);
			}
			return collection.Occurrences(predicate);
		}

		/// <summary>
		/// Count all occurrences of elements that match the provided predicate in the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="predicate">The <see cref="Predicate{T}"/> describing a match of the elements to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences([AllowNull] this String collection, [AllowNull] Predicate<Char> predicate) => collection is not null ? Occurrences(collection.AsMemory(), predicate) : 0;

		/// <summary>
		/// Count all occurrences of elements that match the provided predicate in the collection.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="predicate">The <see cref="Predicate{T}"/> describing a match of the elements to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences<TElement>([AllowNull] this TElement[] collection, [AllowNull] Predicate<TElement> predicate) => collection is not null ? Occurrences(collection.AsMemory(), predicate) : 0;

		/// <summary>
		/// Count all occurrences of elements that match the provided predicate in the collection.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="predicate">The <see cref="Predicate{T}"/> describing a match of the elements to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences<TElement>(this Memory<TElement> collection, [AllowNull] Predicate<TElement> predicate) => Occurrences(collection.Span, predicate);

		/// <summary>
		/// Count all occurrences of elements that match the provided predicate in the collection.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="predicate">The <see cref="Predicate{T}"/> describing a match of the elements to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences<TElement>(this ReadOnlyMemory<TElement> collection, [AllowNull] Predicate<TElement> predicate) => Occurrences(collection.Span, predicate);

		/// <summary>
		/// Count all occurrences of elements that match the provided predicate in the collection.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="predicate">The <see cref="Predicate{T}"/> describing a match of the elements to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences<TElement>(this Span<TElement> collection, [AllowNull] Predicate<TElement> predicate) => Occurrences((ReadOnlySpan<TElement>)collection, predicate);

		/// <summary>
		/// Count all occurrences of elements that match the provided predicate in the collection.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="predicate">The <see cref="Predicate{T}"/> describing a match of the elements to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences<TElement>(this ReadOnlySpan<TElement> collection, [AllowNull] Predicate<TElement> predicate) {
			if (collection.Length == 0) {
				return 0;
			} else if (predicate is null) {
				return NullOccurrences(collection);
			}
			nint count = 0;
			foreach (TElement item in collection) {
				if (item is null && predicate is null) {
					count++;
				} else if (predicate(item)) {
					count++;
				}
			}
			return count;
		}
		#endregion

		private static nint NullOccurrences<TElement, TEnumerator>([DisallowNull] ISequence<TElement, TEnumerator> collection) where TEnumerator : IEnumerator<TElement> {
			nint count = 0;
			foreach (TElement item in collection) {
				if (item is null) {
					count++;
				}
			}
			return count;
		}

		private static nint NullOccurrences<TElement>([DisallowNull] ReadOnlySpan<TElement> collection) {
			nint count = 0;
			foreach (TElement item in collection) {
				if (item is null) {
					count++;
				}
			}
			return count;
		}
	}
}
