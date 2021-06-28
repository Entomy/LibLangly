using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Traits.Concepts;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns the largest integral value less than or equal to the specified double-precision floating-point number.
		/// </summary>
		/// <param name="d">A double-precision floating-point number.</param>
		/// <returns>The largest integral value less than or equal to <paramref name="d"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.floor"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double Floor(this Double d) => Math.Floor(d);

		/// <summary>
		/// Takes the largest integral value that is less than or equal to the top element of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Floor([DisallowNull] this IStack<Double> stack) => stack.Push(stack.Pop().Floor());

		/// <summary>
		/// Returns the largest integral value less than or equal to the specified decimal number.
		/// </summary>
		/// <param name="d">A decimal number.</param>
		/// <returns>The largest integral value less than or equal to <paramref name="d"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Decimal Floor(this Decimal d) => Math.Floor(d);

		/// <summary>
		/// Takes the largest integral value that is less than or equal to the top element of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Floor([DisallowNull] this IStack<Decimal> stack) => stack.Push(stack.Pop().Floor());
	}
}
