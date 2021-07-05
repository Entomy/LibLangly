#if NETCOREAPP3_0_OR_GREATER
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Traits.Concepts;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns the base 2 integer logarithm of a specified number.
		/// </summary>
		/// <param name="x">The number whos logarithm is to be found.</param>
		/// <returns></returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.ilogb"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int32 ILogB(this Double x) => Math.ILogB(x);

		/// <summary>
		/// Takes the base 2 integer logarithm of the top element of the <paramref name="stack"/> and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void ILogB([DisallowNull] this IStack<Double> stack) => stack.Push(stack.Pop().ILogB());
	}
}
#endif
