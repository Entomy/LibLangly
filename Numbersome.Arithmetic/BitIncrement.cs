using System.Runtime.CompilerServices;
using System.Traits.Concepts;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns the next largest value that compares greater than <paramref name="x"/>.
		/// </summary>
		/// <param name="x">The value to increment.</param>
		/// <returns>The next largest value that compares greater than <paramref name="x"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.bitincrement"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T BitIncrement<T>(this T x) where T : IFloatingPoint<T> => T.BitIncrement(x);

		/// <summary>
		/// Takes the top element of the <paramref name="stack"/>, and pushes the next largest value that compares greater than it back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void BitIncrement<T>(this IStack<T> stack) where T : IFloatingPoint<T> => stack.Push(stack.Pop().BitIncrement());
	}
}
