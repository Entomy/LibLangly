using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Traits.Concepts;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns the base 10 logarithm of a specified number.
		/// </summary>
		/// <param name="d">A number whos logarithm is to be found.</param>
		/// <returns></returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.log10"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double Log10(this Double d) => Math.Log10(d);

		/// <summary>
		/// Takes the base 10 logarithm of the top element of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Log10([DisallowNull] this IStack<Double> stack) => stack.Push(stack.Pop().Log10());
	}
}
