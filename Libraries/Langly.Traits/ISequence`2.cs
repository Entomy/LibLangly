using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type is a sequence of <typeparamref name="TMember"/>.
	/// </summary>
	/// <typeparam name="TMember">The type of elements in the sequence.</typeparam>
	/// <typeparam name="TEnumerator">The type of the enumerator for this sequence.</typeparam>
	/// <remarks>
	/// This interface devirtualizes the enumerator, and simplifies numerous parts of the interface through well defined defaults.
	/// </remarks>
	public interface ISequence<TMember, out TEnumerator> :
		IContains<TMember>,
		ICount,
		System.Collections.Generic.IEnumerable<TMember>
		where TEnumerator : IEnumerator<TMember> {
		/// <inheritdoc/>
		Boolean IContains<TMember>.Contains(TMember element) {
			TEnumerator ths = GetEnumerator();
			while (ths.MoveNext()) {
				if (ths.Current is null && element is null) {
					return true;
				} else if (element?.Equals(ths.Current) ?? false) {
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Folds the collection into a single element as described by <paramref name="func"/>.
		/// </summary>
		/// <param name="func">The function describing the folding operation. This is a magma.</param>
		/// <param name="identity">The identity value for <paramref name="func"/>.</param>
		/// <returns>A single element after folding the entire collection.</returns>
		/// <remarks>
		/// <para><paramref name="func"/> is a magma, so associativity like left-fold and right-fold are completely irrelevant.</para>
		/// <para><paramref name="identity"/> is required as a start point for the fold. It needs to be the identity of the <paramref name="func"/> to function properly. For example, the identity of addition is <c>0</c>, and the identity of multiplication is <c>1</c>. Without an appropriate identity, the results will be wrong.</para>
		/// </remarks>
		TMember Fold([DisallowNull] Func<TMember, TMember, TMember> func, TMember identity) {
			TMember result = identity;
			foreach (TMember item in this) {
				result = func(result, item);
			}
			return result;
		}

		/// <summary>
		/// Returns an enumerator that iterates through the sequence.
		/// </summary>
		/// <returns>An enumerator that can be used to iterate through the collection.</returns>
		[return: NotNull]
		new TEnumerator GetEnumerator();

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.Generic.IEnumerator<TMember> System.Collections.Generic.IEnumerable<TMember>.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the collection.
		/// </summary>
		/// <param name="element">The element to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		[SuppressMessage("Performance", "HAA0601:Value type to reference type conversion causing boxing allocation", Justification = "There's nothing I can do about this.")]
		nint Occurrences([DisallowNull] TMember element) {
			nint count = 0;
			foreach (TMember item in this) {
				if (element.Equals(item)) {
					count++;
				}
			}
			return count;
		}

		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the collection.
		/// </summary>
		/// <param name="element">The element to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		nint Occurrences([DisallowNull] IEquals<TMember> element) {
			nint count = 0;
			foreach (TMember item in this) {
				if (element.Equals(item)) {
					count++;
				}
			}
			return count;
		}

		/// <summary>
		/// Count all occurrences of elements that match the provided predicate in the collection.
		/// </summary>
		/// <param name="predicate">The <see cref="Predicate{T}"/> describing a match of the elements to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		nint Occurrences([DisallowNull] Predicate<TMember> predicate) {
			nint count = 0;
			foreach (TMember item in this) {
				if (predicate(item)) {
					count++;
				}
			}
			return count;
		}
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Folds the collection into a single element as described by the <paramref name="func"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="func">The function describing the folding operation. This is a magma.</param>
		/// <param name="identity">The identity value for <paramref name="func"/>.</param>
		/// <returns>A single element after folding the entire <paramref name="collection"/>. If <paramref name="collection"/> or <paramref name="func"/> are <see langword="null"/> this function returns <paramref name="identity"/>.</returns>
		/// <remarks>
		/// <para><paramref name="func"/> is a magma, so associativity like left-fold and right-fold are completely irrelevant.</para>
		/// <para><paramref name="identity"/> is required as a start point for the fold. It needs to be the identity of the <paramref name="func"/> to function properly. For example, the identity of addition is <c>0</c>, and the identity of multiplication is <c>1</c>. Without an appropriate identity, the results will be wrong.</para>
		/// </remarks>
		public static TElement Fold<TElement, TEnumerator>([AllowNull] this ISequence<TElement, TEnumerator> collection, [AllowNull] Func<TElement, TElement, TElement> func, TElement identity) where TEnumerator : IEnumerator<TElement> {
			if (collection is null || func is null) {
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
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences<TElement, TEnumerator>([AllowNull] this ISequence<TElement, TEnumerator> collection, [AllowNull] IEquals<TElement> element) where TEnumerator : IEnumerator<TElement> {
			if (collection is null) {
				return 0;
			} else if (element is null) {
				return NullOccurrences(collection);
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
		public static nint Occurrences<TElement, TEnumerator>([AllowNull] this ISequence<TElement, TEnumerator> collection, [AllowNull] Predicate<TElement> match) where TEnumerator : IEnumerator<TElement> {
			if (collection is null) {
				return 0;
			} else if (match is null) {
				return NullOccurrences(collection);
			}
			return collection.Occurrences(match);
		}

		private static nint NullOccurrences<TElement, TEnumerator>([DisallowNull] ISequence<TElement, TEnumerator> collection) where TEnumerator : IEnumerator<TElement> {
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
