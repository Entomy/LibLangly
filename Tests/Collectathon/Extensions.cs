using System;
using System.Diagnostics.CodeAnalysis;

namespace Collectathon {
	public static class Extensions {
		/// <summary>
		/// Zips the two arrays together, forming a single array.
		/// </summary>
		/// <typeparam name="TLeft">The lefthand array element type.</typeparam>
		/// <typeparam name="TRight">The righthand array element type.</typeparam>
		/// <param name="left">The lefthand array.</param>
		/// <param name="right">The righthand array.</param>
		/// <returns>A new array whos elements are tuples of the respect <paramref name="left"/> and <paramref name="right"/> elements, or <see langword="null"/> if both parameters are also <see langword="null"/>.</returns>
		/// <exception cref="ArgumentException">Thrown if the arrays are not the same length.</exception>
		/// <exception cref="ArgumentNullException">Thrown if one but not both of the arrays is <see langword="null"/>.</exception>
		[SuppressMessage("Major Code Smell", "S1168:Empty arrays and collections should be returned instead of null", Justification = "Combining two nothings doesn't result in a something; this would violate semantics. Null is the right thing to return in this case.")]
		public static (TLeft, TRight)[] Zip<TLeft, TRight>(this TLeft[] left, TRight[] right) {
			if (left is null && right is null) {
				return null;
			} else if (left is null || right is null) {
				throw new ArgumentNullException(left is null ? nameof(left) : nameof(right), "One of the parameters was null");
			} else if (left.Length != right.Length) {
				throw new ArgumentException("The arrays are not the same length");
			} else {
				(TLeft, TRight)[] result = new (TLeft, TRight)[left.Length];
				for (Int32 i = 0; i < result.Length; i++) {
					result[i] = (left[i], right[i]);
				}
				return result;
			}
		}

	}
}
