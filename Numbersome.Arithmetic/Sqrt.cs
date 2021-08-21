﻿using System.Runtime.CompilerServices;
using System.Traits.Concepts;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns the square root of a specified number.
		/// </summary>
		/// <param name="d">A number whos square root is to be found.</param>
		/// <returns>The square root of <paramref name="d"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.sqrt"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T Sqrt<T>(this T d) where T : IFloatingPoint<T> => T.Sqrt(d);

		/// <summary>
		/// Takes the square root of the top element of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Sqrt<T>(this IStack<T> stack) where T : IFloatingPoint<T> => stack.Push(stack.Pop().Sqrt());
	}
}
