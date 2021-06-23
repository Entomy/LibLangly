using System;
using System.Runtime.CompilerServices;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns <see cref="Math.E"/> raised to the specified power.
		/// </summary>
		/// <param name="d">A number specifying a power.</param>
		/// <returns>The number <see cref="Math.E"/> raised to the power <paramref name="d"/>. If <paramref name="d"/> equals <see cref="Double.NaN"/> or <see cref="Double.PositiveInfinity"/>, that value is returned. If <paramref name="d"/> equals <see cref="Double.NegativeInfinity"/>, 0 is returned.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.exp"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double Exp(this Double d) => Math.Exp(d);
	}
}
