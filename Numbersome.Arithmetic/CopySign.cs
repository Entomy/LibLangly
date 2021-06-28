#if NETCOREAPP3_0_OR_GREATER
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Traits.Concepts;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns a value with the magnitude of <paramref name="x"/> and the sign of <paramref name="y"/>.
		/// </summary>
		/// <param name="x">A number whos magnitude is used in the result.</param>
		/// <param name="y">A number whos sign is used in the result.</param>
		/// <returns>A value with the magnitude of <paramref name="x"/> and the sign of <paramref name="y"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.copysign"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double CopySign(this Double x, Double y) => Math.CopySign(x, y);

		/// <summary>
		/// Takes the sign top element and the magnitude of the next element of the <paramref name="stack"/>, combining them, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void CopySign([DisallowNull] this IStack<Double> stack) {
			Double y = stack.Pop();
			Double x = stack.Pop();
			stack.Push(Math.CopySign(x, y));
		}
	}
}
#endif
