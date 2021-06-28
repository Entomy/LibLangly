using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Traits.Concepts;

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

		/// <summary>
		/// Takes the top element of the <paramref name="stack"/>, raises the next element to the power of the first, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Pow([DisallowNull] this IStack<Double> stack) {
			Double y = stack.Pop();
			Double x = stack.Pop();
			stack.Push(Math.Pow(x, y));
		}
	}
}
