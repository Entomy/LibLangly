using System;

namespace Philosoft {
	/// <summary>
	/// Indicates the type is an enumerator, which supports a simple iteration over a collection of a specified type.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements to enumerate.</typeparam>
	/// <typeparam name="TEnumerator">The type of the enumerator.</typeparam>
	/// <remarks>
	/// This is an improvement that degeneralizes the enumerator, so that heap allocations can potentially be avoided by using a struct.
	/// </remarks>
	public interface IEnumerable<TElement, TEnumerator> : System.Collections.Generic.IEnumerable<TElement> where TEnumerator : IEnumerator<TElement> {
		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>An enumerator that can be used to iterate through the collection.</returns>
		new TEnumerator GetEnumerator();

		/// <inheritdoc/>
		System.Collections.Generic.IEnumerator<TElement> System.Collections.Generic.IEnumerable<TElement>.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

		/// <summary>
		/// Folds the collection into a single element as described by the <paramref name="func"/>.
		/// </summary>
		/// <param name="func">The function describing the folding operation. This is a magma.</param>
		/// <param name="identity">The identity value for <paramref name="func"/>.</param>
		/// <returns>A single element after folding the entire collection.</returns>
		/// <remarks>
		/// <para><paramref name="func"/> is a magma, so associativity like left-fold and right-fold are completely irrelevant.</para>
		/// <para><paramref name="identity"/> is required as a start point for the fold. It needs to be the identity of the <paramref name="func"/> to function properly. For example, the identity of addition is <c>0</c>, and the identity of multiplication is <c>1</c>. Without an appropriate identity, the results will be wrong.</para>
		/// </remarks>
		TElement Fold(Func<TElement, TElement, TElement> func, TElement identity) {
			if (func is null) {
				// There's no operation to perform, so return immediately.
				return identity;
			}
			TElement result = identity;
			foreach (TElement item in this) {
				result = func(result, item);
			}
			return result;
		}

		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the collection.
		/// </summary>
		/// <param name="element">The element to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		nint Occurrences(TElement element) {
			nint count = 0;
			foreach (TElement item in this) {
				if (Equals(item, element)) {
					count++;
				}
			}
			return count;
		}

		/// <summary>
		/// Count all occurrences of elements that match the provided predicate in the collection.
		/// </summary>
		/// <param name="match">The <see cref="Predicate{T}"/> describing a match of the elements to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		nint Occurrences(Predicate<TElement> match) {
			nint count = 0;
			if (match is null) {
				foreach (TElement item in this) {
					if (item is null) {
						count++;
					}
				}
			} else {
				foreach (TElement item in this) {
					if (match(item)) {
						count++;
					}
				}
			}
			return count;
		}
	}

	public static partial class Extensions {
		/// <summary>
		/// Folds the collection into a single element as described by the <paramref name="func"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="func">The function describing the folding operation. This is a magma.</param>
		/// <param name="identity">The identity value for <paramref name="func"/>.</param>
		/// <returns>A single element after folding the entire <paramref name="collection"/>.</returns>
		/// <remarks>
		/// <para><paramref name="func"/> is a magma, so associativity like left-fold and right-fold are completely irrelevant.</para>
		/// <para><paramref name="identity"/> is required as a start point for the fold. It needs to be the identity of the <paramref name="func"/> to function properly. For example, the identity of addition is <c>0</c>, and the identity of multiplication is <c>1</c>. Without an appropriate identity, the results will be wrong.</para>
		/// </remarks>
		public static TElement Fold<TElement, TEnumerator>(this IEnumerable<TElement, TEnumerator> collection, Func<TElement, TElement, TElement> func, TElement identity) where TEnumerator : IEnumerator<TElement> {
			if (collection is null) {
				return identity;
			}
			return collection.Fold(func, identity);
		}

		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the collection.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences<TElement, TEnumerator>(this IEnumerable<TElement, TEnumerator> collection, TElement element) where TEnumerator : IEnumerator<TElement> {
			if (collection is null) {
				return 0;
			}
			return collection.Occurrences(element);
		}

		/// <summary>
		/// Count all occurrences of elements that match the provided predicate in the collection.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="match">The <see cref="Predicate{T}"/> describing a match of the elements to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences<TElement, TEnumerator>(this IEnumerable<TElement, TEnumerator> collection, Predicate<TElement> match) where TEnumerator : IEnumerator<TElement> {
			if (collection is null) {
				return 0;
			}
			return collection.Occurrences(match);
		}
	}
}
