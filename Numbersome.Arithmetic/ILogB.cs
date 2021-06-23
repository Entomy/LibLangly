#if NETCOREAPP3_0_OR_GREATER
using System;
using System.Runtime.CompilerServices;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns the base 2 integer logarithm of a specified number.
		/// </summary>
		/// <param name="x">The number whos logarithm is to be found.</param>
		/// <returns></returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.ilogb"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int32 ILogB(this Double x) => Math.ILogB(x);
	}
}
#endif
