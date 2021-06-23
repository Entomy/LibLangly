#if NETCOREAPP3_0_OR_GREATER
using System;
using System.Runtime.CompilerServices;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns the next smallest value that compares less than <paramref name="x"/>.
		/// </summary>
		/// <param name="x">The value to decrement.</param>
		/// <returns>The next smallest value that compares less than <paramref name="x"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.bitdecrement"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double BitDecrement(this Double x) => Math.BitDecrement(x);
	}
}
#endif
