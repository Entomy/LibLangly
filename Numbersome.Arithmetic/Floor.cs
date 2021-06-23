using System;
using System.Runtime.CompilerServices;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns the largest integral value less than or equal to the specified double-precision floating-point number.
		/// </summary>
		/// <param name="d">A double-precision floating-point number.</param>
		/// <returns>The largest integral value less than or equal to <paramref name="d"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.floor"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double Floor(this Double d) => Math.Floor(d);

		/// <summary>
		/// Returns the largest integral value less than or equal to the specified decimal number.
		/// </summary>
		/// <param name="d">A decimal number.</param>
		/// <returns>The largest integral value less than or equal to <paramref name="d"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Decimal Floor(this Decimal d) => Math.Floor(d);
	}
}
