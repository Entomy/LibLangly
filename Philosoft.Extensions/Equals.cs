using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class PhilosoftExtensions {
		/// <summary>
		/// Determines if the two sequences are equal.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the sequence.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for this sequence.</typeparam>
		/// <param name="sequence">The primary sequence.</param>
		/// <param name="other">The other sequence.</param>
		/// <returns><see langword="true"/> if the two sequences are equal; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals<TElement, TEnumerator>([AllowNull] ISequence<TElement, TEnumerator> sequence, [AllowNull] System.Collections.Generic.IEnumerable<TElement> other) where TEnumerator : IEnumerator<TElement> {
			if (sequence is null && other is null) {
				return true;
			} else if (sequence is null || other is null) {
				return false;
			}
			// Get enumerators for each
			using TEnumerator seq = sequence.GetEnumerator();
			using System.Collections.Generic.IEnumerator<TElement> oth = other.GetEnumerator();
			// Now iterate through both
			while (seq.MoveNext() && oth.MoveNext()) {
				// If the current elements are not equal to each other
				if (!(oth.Current?.Equals(seq.Current) ?? false)) {
					// The sequences aren't equal
					return false;
				}
			}
			// If any enumerator can still advance
			if (seq.MoveNext() || oth.MoveNext()) {
				// They aren't the same length and therefore aren't equal
				return false;
			}
			// We've validated that the sequences are the same length, and contain the same elements in the same order, so are therefore equal.
			return true;
		}

		/// <summary>
		/// Determines if the two sequences are equal.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the sequence.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for this sequence.</typeparam>
		/// <typeparam name="TOtherEnumerator">The type of the enumerator for the <paramref name="other"/> sequence.</typeparam>
		/// <param name="sequence">The primary sequence.</param>
		/// <param name="other">The other sequence.</param>
		/// <returns><see langword="true"/> if the two sequences are equal; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals<TElement, TEnumerator, TOtherEnumerator>([AllowNull] ISequence<TElement, TEnumerator> sequence, [AllowNull] ISequence<TElement, TOtherEnumerator> other) where TEnumerator : IEnumerator<TElement> where TOtherEnumerator : IEnumerator<TElement> {
			// We're calling this off an instance, so if the other is null
			if (other is null) {
				// They aren't equal
				return false;
			}
			// Get enumerators for each
			using TEnumerator seq = sequence.GetEnumerator();
			using TOtherEnumerator oth = other.GetEnumerator();
			// Now iterate through both
			while (seq.MoveNext() && oth.MoveNext()) {
				// If the current elements are not equal to each other
				if (!(oth.Current?.Equals(seq.Current) ?? false)) {
					// The sequences aren't equal
					return false;
				}
			}
			// If any enumerator can still advance
			if (seq.MoveNext() || oth.MoveNext()) {
				// They aren't the same length and therefore aren't equal
				return false;
			}
			// We've validated that the sequences are the same length, and contain the same elements in the same order, so are therefore equal.
			return true;
		}
	}
}
