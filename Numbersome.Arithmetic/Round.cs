using System;
using System.Runtime.CompilerServices;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Rounds a double-precision floating-point value to a specified number of fractional digits using the specified rounding convention.
		/// </summary>
		/// <param name="value">A double-precision floating-point number to be rounded.</param>
		/// <param name="digits">The number of fractional digits in the return value.</param>
		/// <param name="mode">One of the enumeration values that specifies which rounding strategy to use.</param>
		/// <returns>The number that has <paramref name="digits"/> fractional digits that <paramref name="value"/> is rounded to. If <paramref name="value"/> has fewer fractional digits than <paramref name="digits"/>, <paramref name="value"/> is returned unchanged.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.round"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double Round(this Double value, Int32 digits, MidpointRounding mode) => Math.Round(value, digits, mode);

		/// <summary>
		/// Rounds a decimal value to a specified number of fractional digits using the specified rounding convention.
		/// </summary>
		/// <param name="d">A decimal number to be rounded.</param>
		/// <param name="decimals">The number of decimal places in the return value.</param>
		/// <param name="mode">One of the enumeration values that specifies which rounding strategy to use.</param>
		/// <returns>The number with <paramref name="decimals"/> fractional digits that <paramref name="d"/> is rounded to. If <paramref name="d"/> has fewer fractional digits than <paramref name="decimals"/>, <paramref name="d"/> is returned unchanged.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.round"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Decimal Round(this Decimal d, Int32 decimals, MidpointRounding mode) => Math.Round(d, decimals, mode);

		/// <summary>
		/// Rounds a double-precision floating-point value to an integer using the specified rounding conversion.
		/// </summary>
		/// <param name="value">A double-precision floating-point number to be rounded.</param>
		/// <param name="mode">One of the enumeration values that specifies which rounding strategy to use.</param>
		/// <returns>The integer that <paramref name="value"/> is rounded to. This method returns a <see cref="Double"/> instead of an integral type.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.round"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double Round(this Double value, MidpointRounding mode) => Math.Round(value, mode);

		/// <summary>
		/// Rounds a double-precision floating-point value to a specified number of fractional digits, and rounds midpoint values to the nearest even number.
		/// </summary>
		/// <param name="value">A double-precision floating-point number to be rounded.</param>
		/// <param name="digits">The number of fractional digits in the return value.</param>
		/// <returns>The number nearest to <paramref name="value"/> that contains a number of fractional digits equal to <paramref name="digits"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.round"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double Round(this Double value, Int32 digits) => Math.Round(value, digits);

		/// <summary>
		/// Rounds a decimal value to a specified number of fractional digits, and rounds midpoint values to the nearest even number.
		/// </summary>
		/// <param name="d">A decimal number to be rounded.</param>
		/// <param name="decimals">The number of decimal places in the return value.</param>
		/// <returns>The number nearest to <paramref name="d"/> that contains a number of fractional digits equal to <paramref name="decimals"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.round"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Decimal Round(this Decimal d, Int32 decimals) => Math.Round(d, decimals);

		/// <summary>
		/// Rounds a double-precision floating-point value to the nearest integral value, and rounds midpoint values to the nearest even number.
		/// </summary>
		/// <param name="a">A double-precision floating-point number to be rounded.</param>
		/// <returns>The integer nearest <paramref name="a"/>. If the fractional component of <paramref name="a"/> is halfway between two integers, one of which is even and the other odd, then the even number is returned. Note that this method returns a <see cref="Double"/> instead of an integral type.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.round"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double Round(this Double a) => Math.Round(a);

		/// <summary>
		/// Rounds a decimal value to the nearest integral value, and rounds midpont values to the nearest even number.
		/// </summary>
		/// <param name="d">A decimal number to be rounded.</param>
		/// <returns>The integer nearest the <paramref name="d"/> parameter. If the fractional component of <paramref name="d"/> is halfway between two integers, one of which is even and the other odd, the even number is returned. Note that this method returns a <see cref="Decimal"/> instead of an integral type.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.round"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Decimal Round(this Decimal d) => Math.Round(d);

		/// <summary>
		/// Rounds a decimal value an integer using the specified rounding convention.
		/// </summary>
		/// <param name="d">A decimal number to be rounded.</param>
		/// <param name="mode">One of the enumeration values that specifies which rounding strategy to use.</param>
		/// <returns>The integer that <paramref name="d"/> is rounded to. This method returns a <see cref="Decimal"/> instead of an integral type.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.round"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Decimal Round(this Decimal d, MidpointRounding mode) => Math.Round(d, mode);
	}
}
