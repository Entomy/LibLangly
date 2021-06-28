using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Traits.Concepts;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns the logarithm of a specified number in a specified base.
		/// </summary>
		/// <param name="a">The number whos logarithm is to be found.</param>
		/// <param name="newBase">The base of the logarithm.</param>
		/// <returns></returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.log"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double Log(this Double a, Double newBase) => Math.Log(a, newBase);

		/// <summary>
		/// Returns the natural (base <see cref="Math.E"/>) logarithm of a specified number.
		/// </summary>
		/// <param name="d">The number whos logarithm is to be found.</param>
		/// <returns></returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.log"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double Log(this Double d) => Math.Log(d);

		/// <summary>
		/// Takes the natural (base <see cref="Math.E"/>) logarithm of the top element of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Log([DisallowNull] this IStack<Double> stack) => stack.Push(stack.Pop().Log());
	}
}
