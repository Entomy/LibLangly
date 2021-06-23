#if NETCOREAPP3_0_OR_GREATER
using System;
using System.Runtime.CompilerServices;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns the next largest value that compares greater than <paramref name="x"/>.
		/// </summary>
		/// <param name="x">The value to increment.</param>
		/// <returns>The next largest value that compares greater than <paramref name="x"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.bitincrement"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double BitIncrement(this Double x) => Math.BitIncrement(x);
	}
}
#endif
