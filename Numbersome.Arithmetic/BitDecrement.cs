#if NETCOREAPP3_0_OR_GREATER
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Traits.Concepts;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns the next smallest value that compares less than <paramref name="x"/>.
		/// </summary>
		/// <param name="x">The value to decrement.</param>
		/// <returns>The next smallest value that compares less than <paramref name="x"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.bitdecrement"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double BitDecrement(this Double x) => Math.BitDecrement(x);

		/// <summary>
		/// Takes the top element of the <paramref name="stack"/>, and pushes the next smallest value that compares less than it back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void BitDecrement([DisallowNull] this IStack<Double> stack) => stack.Push(stack.Pop().BitDecrement());
	}
}
#endif
