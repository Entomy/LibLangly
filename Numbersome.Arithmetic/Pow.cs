using System;
using System.Runtime.CompilerServices;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns a specified number raised to the specified power.
		/// </summary>
		/// <param name="x">A double-precision floating-point number to be raised to a power.</param>
		/// <param name="y">A double-precision floating-point number that specifies a power.</param>
		/// <returns>The number <paramref name="x"/> raised to the power <paramref name="y"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.pow"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double Pow(this Double x, Double y) => Math.Pow(x, y);
	}
}
