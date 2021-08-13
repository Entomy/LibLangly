﻿using System.Runtime.CompilerServices;
using System.Traits.Concepts;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns the base 2 logarithm of a specified number.
		/// </summary>
		/// <param name="x">A number whos logarithm is to be found.</param>
		/// <returns></returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.log2"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T Log2<T>(this T x) where T : IFloatingPoint<T> => T.Log2(x);

		/// <summary>
		/// Takes the base 2 logarithm of the top element of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Log2<T>(this IStack<T> stack) where T : IFloatingPoint<T> => stack.Push(stack.Pop().Log2());
	}
}
