using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	internal static partial class Collection {
		/// <summary>
		/// Zips the two arrays together into an associative array.
		/// </summary>
		/// <typeparam name="TIndex">The type of the index of the association.</typeparam>
		/// <typeparam name="TElement">The type of the elements of the association.</typeparam>
		/// <param name="indicies">The indicies of the resulting association.</param>
		/// <param name="elements">The elements of the resulting association.</param>
		/// <returns>A single <see cref="Array"/> associating the <paramref name="indicies"/> and <paramref name="elements"/>.</returns>
		[return: NotNull]
		public static (TIndex Index, TElement Element)[] Zip<TIndex, TElement>([DisallowNull] TIndex[] indicies, [DisallowNull] TElement[] elements) {
			(TIndex Index, TElement Element)[] result = new (TIndex Index, TElement Element)[indicies.Length];
			for (Int32 i = 0; i < result.Length; i++) {
				result[i] = (indicies[i], elements[i]);
			}
			return result;
		}
	}
}
