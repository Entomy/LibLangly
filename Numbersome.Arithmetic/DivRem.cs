#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
using System;
using System.Runtime.CompilerServices;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Calculates the quotient of two 64-bit signed integers and also returns the remainder in an output parameter.
		/// </summary>
		/// <param name="a">The dividend.</param>
		/// <param name="b">The divisor.</param>
		/// <param name="result">The remainder.</param>
		/// <returns>The quotient of the specified numbers.</returns>
		/// <exception cref="DivideByZeroException"><paramref name="b"/> is zero.</exception>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.divrem"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int64 DivRem(this Int64 a, Int64 b, out Int64 result) => Math.DivRem(a, b, out result);

		/// <summary>
		/// Calculates the quotient of two 64-bit signed integers and also returns the remainder in an output parameter.
		/// </summary>
		/// <param name="a">The dividend.</param>
		/// <param name="b">The divisor.</param>
		/// <param name="result">The remainder.</param>
		/// <returns>The quotient of the specified numbers.</returns>
		/// <exception cref="DivideByZeroException"><paramref name="b"/> is zero.</exception>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.divrem"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int32 DivRem(this Int32 a, Int32 b, out Int32 result) => Math.DivRem(a, b, out result);
	}
}
#endif
