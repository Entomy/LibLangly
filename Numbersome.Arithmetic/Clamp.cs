using System.Runtime.CompilerServices;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns <paramref name="value"/> clamped to the inclusive range of <paramref name="min"/> and <paramref name="max"/>.
		/// </summary>
		/// <param name="value">The value to be clamped.</param>
		/// <param name="min">The lower bound of the result.</param>
		/// <param name="max">The upper bound of the result.</param>
		/// <returns>
		/// <paramref name="value"/> if <paramref name="min"/> ≤ <paramref name="value"/> ≤ <paramref name="max"/>.
		/// -or-
		/// <paramref name="min"/> if <paramref name="value"/> &lt; <paramref name="min"/>.
		/// -or-
		/// <paramref name="max"/> if <paramref name="max"/> &lt; <paramref name="value"/>.
		/// </returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.clamp"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T Clamp<T>(this T value, T min, T max) where T : INumber<T> => T.Clamp(value, min, max);
	}
}
