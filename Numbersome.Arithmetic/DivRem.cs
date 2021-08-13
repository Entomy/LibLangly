using System.Runtime.CompilerServices;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Calculates the quotient of two 64-bit signed integers and also returns the remainder in an output parameter.
		/// </summary>
		/// <param name="a">The dividend.</param>
		/// <param name="b">The divisor.</param>
		/// <returns>The quotient and remainder of the specified numbers.</returns>
		/// <exception cref="DivideByZeroException"><paramref name="b"/> is zero.</exception>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.divrem"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static (T Quotient, T Remainder) DivRem<T>(this T a, T b) where T : INumber<T> => T.DivRem(a, b);
	}
}
