using System;
using System.Runtime.CompilerServices;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns the smallest integral value that is greater than or equal to the specified decimal number.
		/// </summary>
		/// <param name="d">A decimal number.</param>
		/// <returns>The smallest integral value that is greater than or equal to <paramref name="d"/>. Note that this method returns a <see cref="Decimal"/> instead of an integral type.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.ceiling"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Decimal Ceiling(this Decimal d) => Math.Ceiling(d);

		/// <summary>
		/// Returns the smallest integral value that is greater than or equal to the specified double-precision floating-point number.
		/// </summary>
		/// <param name="a">A double-precision floating-point number.</param>
		/// <returns>The smallest integral value that is greater than or equal to <paramref name="a"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.ceiling"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double Ceiling(this Double a) => Math.Ceiling(a);
	}
}

