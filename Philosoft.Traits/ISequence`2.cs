using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type is a sequence of <typeparamref name="TElement"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the sequence.</typeparam>
	/// <typeparam name="TEnumerator">The type of the enumerator for this sequence.</typeparam>
	/// <remarks>
	/// This interface devirtualizes the enumerator, and simplifies numerous parts of the interface through well defined defaults.
	/// </remarks>
	public interface ISequence<TElement, TEnumerator> :
		IContains<TElement>,
		ICount,
		IEnumerable<TElement>
		where TEnumerator : IEnumerator<TElement> {
		/// <inheritdoc/>
		Boolean IContains<TElement>.Contains([AllowNull] TElement element) {
			foreach (TElement item in this) {
				if (item is null && element is null) {
					return true;
				} else if (element?.Equals(item) ?? false) {
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Copies all the elements of the current sequence into an array.
		/// </summary>
		/// <param name="array">The array to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this sequence.</exception>
		/// <exception cref="ArgumentNullException">The destination is <see langword="null"/>.</exception>
		void CopyTo([DisallowNull] TElement[] array) => CopyTo(array.AsSpan());

		/// <summary>
		/// Copies all the elements of the current sequence into a memory region.
		/// </summary>
		/// <param name="memory">The memory to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this sequence.</exception>
		void CopyTo(Memory<TElement> memory) => CopyTo(memory.Span);

		/// <summary>
		/// Copyes all the elements of the current sequence into the span.
		/// </summary>
		/// <param name="span">The span to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this sequence.</exception>
		void CopyTo(Span<TElement> span) {
			if (Count > span.Length) {
				throw new ArgumentException();
			}
			Int32 i = 0;
			foreach (TElement item in this) {
				span[i++] = item;
			}
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
		TElement Fold([DisallowNull] Func<TElement, TElement, TElement> func, [AllowNull] TElement identity) {
			TElement result = identity;
			if (func is null) {
				goto Result;
			}
			foreach (TElement item in this) {
				result = func(result, item);
			}
		Result:
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
		System.Collections.Generic.IEnumerator<TElement> IEnumerable<TElement>.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the collection.
		/// </summary>
		/// <param name="element">The element to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		[SuppressMessage("Performance", "HAA0601:Value type to reference type conversion causing boxing allocation", Justification = "There's nothing I can do about this.")]
		nint Occurrences([AllowNull] TElement element) {
			nint count = 0;
			foreach (TElement item in this) {
				if (item is null && element is null) {
					count++;
				} else if (element?.Equals(item) ?? false) {
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
		nint Occurrences([AllowNull] IEquatable<TElement> element) {
			nint count = 0;
			foreach (TElement item in this) {
				if (item is null && element is null) {
					count++;
				} else if (element?.Equals(item) ?? false) {
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
		nint Occurrences([AllowNull] Predicate<TElement> predicate) {
			nint count = 0;
			foreach (TElement item in this) {
				if (item is null && predicate is null) {
					count++;
				} else if (predicate(item)) {
					count++;
				}
			}
			return count;
		}
	}
}
