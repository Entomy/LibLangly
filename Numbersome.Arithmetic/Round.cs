using System.Runtime.CompilerServices;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Rounds a double-precision floating-point value to the nearest integral value, and rounds midpoint values to the nearest even number.
		/// </summary>
		/// <param name="a">A double-precision floating-point number to be rounded.</param>
		/// <returns>The integer nearest <paramref name="a"/>. If the fractional component of <paramref name="a"/> is halfway between two integers, one of which is even and the other odd, then the even number is returned. Note that this method returns a <see cref="Double"/> instead of an integral type.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.round"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T Round<T>(this T a) where T : IFloatingPoint<T> => T.Round(a);

		/// <summary>
		/// Rounds a decimal value an integer using the specified rounding convention.
		/// </summary>
		/// <param name="d">A decimal number to be rounded.</param>
		/// <param name="mode">One of the enumeration values that specifies which rounding strategy to use.</param>
		/// <returns>The integer that <paramref name="d"/> is rounded to. This method returns a <see cref="Decimal"/> instead of an integral type.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.round"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T Round<T>(this T d, MidpointRounding mode) where T : IFloatingPoint<T> => T.Round(d, mode);

		/// <summary>
		/// Rounds a double-precision floating-point value to a specified number of fractional digits, and rounds midpoint values to the nearest even number.
		/// </summary>
		/// <param name="value">A double-precision floating-point number to be rounded.</param>
		/// <param name="digits">The number of fractional digits in the return value.</param>
		/// <returns>The number nearest to <paramref name="value"/> that contains a number of fractional digits equal to <paramref name="digits"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.round"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T Round<T, TInteger>(this T value, TInteger digits) where T : IFloatingPoint<T> where TInteger : IBinaryInteger<TInteger> => T.Round(value, digits);

		/// <summary>
		/// Rounds a double-precision floating-point value to a specified number of fractional digits using the specified rounding convention.
		/// </summary>
		/// <param name="value">A double-precision floating-point number to be rounded.</param>
		/// <param name="digits">The number of fractional digits in the return value.</param>
		/// <param name="mode">One of the enumeration values that specifies which rounding strategy to use.</param>
		/// <returns>The number that has <paramref name="digits"/> fractional digits that <paramref name="value"/> is rounded to. If <paramref name="value"/> has fewer fractional digits than <paramref name="digits"/>, <paramref name="value"/> is returned unchanged.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.round"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T Round<T, TInteger>(this T value, TInteger digits, MidpointRounding mode) where T : IFloatingPoint<T> where TInteger : IBinaryInteger<TInteger> => T.Round(value, digits, mode);
	}
}
