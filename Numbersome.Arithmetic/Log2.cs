#if NETCOREAPP3_0_OR_GREATER
using System;
using System.Runtime.CompilerServices;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns the base 2 logarithm of a specified number.
		/// </summary>
		/// <param name="x">A number whos logarithm is to be found.</param>
		/// <returns></returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.log2"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double Log2(this Double x) => Math.Log2(x);
	}
}
#endif
