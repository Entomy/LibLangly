#if NETCOREAPP3_0_OR_GREATER
using System;
using System.Runtime.CompilerServices;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns a value with the magnitude of <paramref name="x"/> and the sign of <paramref name="y"/>.
		/// </summary>
		/// <param name="x">A number whos magnitude is used in the result.</param>
		/// <param name="y">A number whos sign is used in the result.</param>
		/// <returns>A value with the magnitude of <paramref name="x"/> and the sign of <paramref name="y"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.copysign"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double CopySign(this Double x, Double y) => Math.CopySign(x, y);
	}
}
#endif
