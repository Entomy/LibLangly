using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class PhilosoftExtensions {
		/// <summary>
		/// Copies all the elements of the current sequence into an array.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the sequence.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for this sequence.</typeparam>
		/// <param name="sequence">This sequence to copy.</param>
		/// <param name="array">The array to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this sequence.</exception>
		/// <exception cref="ArgumentNullException">The destination is <see langword="null"/>.</exception>
		public static void CopyTo<TElement, TEnumerator>([AllowNull] this ISequence<TElement, TEnumerator> sequence, [AllowNull] TElement[] array) where TEnumerator : IEnumerator<TElement> {
			if (array is null) {
				throw new ArgumentNullException();
			} else if (sequence is not null) {
				sequence.CopyTo(array);
			}
		}

		/// <summary>
		/// Copies all the elements of the current sequence into a memory region.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the sequence.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for this sequence.</typeparam>
		/// <param name="sequence">This sequence to copy.</param>
		/// <param name="memory">The memory to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this sequence.</exception>
		public static void CopyTo<TElement, TEnumerator>([AllowNull] this ISequence<TElement, TEnumerator> sequence, Memory<TElement> memory) where TEnumerator : IEnumerator<TElement> {
			if (sequence is not null) {
				sequence.CopyTo(memory);
			}
		}

		/// <summary>
		/// Copyes all the elements of the current sequence into the span.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the sequence.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for this sequence.</typeparam>
		/// <param name="sequence">This sequence to copy.</param>
		/// <param name="span">The span to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this sequence.</exception>
		public static void CopyTo<TElement, TEnumerator>([AllowNull] this ISequence<TElement, TEnumerator> sequence, Span<TElement> span) where TEnumerator : IEnumerator<TElement> {
			if (sequence is not null) {
				sequence.CopyTo(span);
			}
		}
	}
}
