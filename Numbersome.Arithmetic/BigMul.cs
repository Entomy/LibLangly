using System.Runtime.CompilerServices;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Produces the full product of two 32-bit numbers.
		/// </summary>
		/// <param name="a">The first number to multiply.</param>
		/// <param name="b">The second number to multiply.</param>
		/// <returns>The number containing the product of the specified numbers.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.bigmul"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int64 BigMul(this Int32 a, Int32 b) => Math.BigMul(a, b);

		/// <summary>
		/// Produces the full product of two 64-bit numbers.
		/// </summary>
		/// <param name="a">The first number to multiply.</param>
		/// <param name="b">The second number to multiply.</param>
		/// <param name="low">The low 64-bit of the product of the specified numbers.</param>
		/// <returns>The high 64-bit of the product of the specified numbers.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.bigmul"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int64 BigMul(this Int64 a, Int64 b, out Int64 low) => Math.BigMul(a, b, out low);

		/// <summary>
		/// Produces the full product of two 64-bit numbers.
		/// </summary>
		/// <param name="a">The first number to multiply.</param>
		/// <param name="b">The second number to multiply.</param>
		/// <param name="low">The low 64-bit of the product of the specified numbers.</param>
		/// <returns>The high 64-bit of the product of the specified numbers.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.bigmul"/>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static UInt64 BigMul(this UInt64 a, UInt64 b, out UInt64 low) => Math.BigMul(a, b, out low);
	}
}
