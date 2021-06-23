using System;
using System.Runtime.CompilerServices;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns the square root of a specified number.
		/// </summary>
		/// <param name="d">A number whos square root is to be found.</param>
		/// <returns></returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.sqrt"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double Sqrt(this Double d) => Math.Sqrt(d);
	}
}
