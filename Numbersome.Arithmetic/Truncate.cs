using System.Runtime.CompilerServices;
using System.Traits.Concepts;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Calculates the integral part of a specified decimal number.
		/// </summary>
		/// <param name="d">A number to truncate.</param>
		/// <returns>The integral part of <paramref name="d"/>; that is, the number that remains after any fractional digits have been discarded.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.truncate"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T Truncate<T>(this T d) where T : IFloatingPoint<T> => T.Truncate(d);

		/// <summary>
		/// Takes the integral part of the top element of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Truncate<T>(this IStack<T> stack) where T : IFloatingPoint<T> => stack.Push(stack.Pop().Truncate());
	}
}
