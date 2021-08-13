using System.Runtime.CompilerServices;

namespace Numbersome {
	/// <summary>
	/// Returns an integer that indicates the sign of a single-precision floating-point number.
	/// </summary>
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns an integer that indicates the sign of a single-precision floating-point number.
		/// </summary>
		/// <param name="value">A signed number.</param>
		/// <returns>A number that indicates the sign of <paramref name="value"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.sign"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T Sign<T>(this T value) where T : IFloatingPoint<T> => T.Sign(value);
	}
}
