using System.Runtime.CompilerServices;
using System.Traits.Concepts;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns the cube root of a specified number.
		/// </summary>
		/// <param name="d">The number whos cube root is to be found.</param>
		/// <returns>The cube root of <paramref name="d"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.cbrt"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T Cbrt<T>(this T d) where T : IFloatingPoint<T> => T.Cbrt(d);

		/// <summary>
		/// Takes the cube root of the top element of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Cbrt<T>(this IStack<T> stack) where T : IFloatingPoint<T> => stack.Push(stack.Pop().Cbrt());
	}
}
