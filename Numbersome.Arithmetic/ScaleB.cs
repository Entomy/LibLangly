#if NETCOREAPP3_0_OR_GREATER
using System;
using System.Runtime.CompilerServices;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns <paramref name="x"/> * 2^<paramref name="n"/> computed efficiently.
		/// </summary>
		/// <param name="x">A double-precision floating-point number that specifies the base value.</param>
		/// <param name="n">A 32-bit integer that specifies the power.</param>
		/// <returns><paramref name="x"/> * 2^<paramref name="n"/> computed efficiently.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.scaleb"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double ScaleB(this Double x, Int32 n) => Math.ScaleB(x, n);
	}
}
#endif
