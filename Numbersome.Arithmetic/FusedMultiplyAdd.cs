#if NETCOREAPP3_0_OR_GREATER
using System;
using System.Runtime.CompilerServices;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns (<paramref name="x"/> * <paramref name="y"/>) + <paramref name="z"/>, rounded as one ternary operation.
		/// </summary>
		/// <param name="x">The number to be multiplied with <paramref name="y"/>.</param>
		/// <param name="y">The number to be multipled with <paramref name="x"/>.</param>
		/// <param name="z">The number to be added to the result of <paramref name="x"/> multiplied by <paramref name="y"/>.</param>
		/// <returns>(<paramref name="x"/> * <paramref name="y"/>) + <paramref name="z"/>, rounded as one ternary operation.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.fusedmultiplyadd"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double FusedMultiplyAdd(this Double x, Double y, Double z) => Math.FusedMultiplyAdd(x, y, z);
	}
}
#endif
