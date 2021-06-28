using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Traits.Concepts;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns the square root of a specified number.
		/// </summary>
		/// <param name="d">A number whos square root is to be found.</param>
		/// <returns></returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.sqrt"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double Sqrt(this Double d) => Math.Sqrt(d);

		/// <summary>
		/// Takes the square root of the top element of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Sqrt([DisallowNull] this IStack<Double> stack) => stack.Push(stack.Pop().Sqrt());
	}
}
