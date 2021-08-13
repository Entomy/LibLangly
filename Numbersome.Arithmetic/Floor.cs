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
		public static T Floor<T>(this T d) where T : IFloatingPoint<T> => T.Floor(d);

		/// <summary>
		/// Takes the largest integral value that is less than or equal to the top element of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Floor<T>(this IStack<T> stack) where T : IFloatingPoint<T> => stack.Push(stack.Pop().Floor());
	}
}
