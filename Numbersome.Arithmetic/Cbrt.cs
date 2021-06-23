#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
using System;
using System.Runtime.CompilerServices;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns the cube root of a specified number.
		/// </summary>
		/// <param name="d">The number whos cube root is to be found.</param>
		/// <returns>The cube root of <paramref name="d"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.cbrt"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double Cbrt(this Double d) => Math.Cbrt(d);
	}
}
#endif
