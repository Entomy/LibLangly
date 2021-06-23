using System;
using System.Runtime.CompilerServices;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Calculates the integral part of a specified decimal number.
		/// </summary>
		/// <param name="d">A number to truncate.</param>
		/// <returns>The integral part of <paramref name="d"/>; that is, the number that remains after any fractional digits have been discarded.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.truncate"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Decimal Truncate(this Decimal d) => Math.Truncate(d);

		/// <summary>
		/// Calculates the integral part of a specified double-precision floating-point number.
		/// </summary>
		/// <param name="d">A number to truncate.</param>
		/// <returns>The integral part of <paramref name="d"/>; that is, the number that remains after any fractional digits have been discarded.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.truncate"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double Truncate(this Double d) => Math.Truncate(d);
	}
}
