using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Langly {
	internal static partial class Collection {
		/// <summary>
		/// Determines whether the two collections are considered equal.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the collections.</typeparam>
		/// <param name="first">The first object to compare.</param>
		/// <param name="second">The second object to compare.</param>
		/// <returns><see langword="true"/> if the collections are considered equal; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Equals<T>([AllowNull] IEnumerable<T> first, [AllowNull] IEnumerable<T> second) {
			// If the two references are equal (includes both null)
			if (ReferenceEquals(first, second)) {
				return true;
			} else
			// If at least one of the references is null
			if (first is null || second is null) {
				return false;
			} else {
				// Get enumerators for each
				using IEnumerator<T> fst = first.GetEnumerator();
				using IEnumerator<T> snd = second.GetEnumerator();
				// Now iterate through both
				while (fst.MoveNext() && snd.MoveNext()) {
					// If the current elements are not equal to each other
					if (!Equals(fst.Current, snd.Current)) {
						// The elements in the sequences aren't equal
						return false;
					}
				}
				// If any enumerator can still advance
				if (fst.MoveNext() || snd.MoveNext()) {
					// The sequences aren't of equal length
					return false;
				}
				// We've validated that the sequences are the same length, and contains the same elements in the same order, so are therefore equal
				return true;
			}
		}
	}
}
