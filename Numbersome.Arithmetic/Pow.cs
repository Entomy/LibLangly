using System.Runtime.CompilerServices;
using System.Traits.Concepts;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns a specified number raised to the specified power.
		/// </summary>
		/// <param name="x">A floating-point number to be raised to a power.</param>
		/// <param name="y">A floating-point number that specifies a power.</param>
		/// <returns>The number <paramref name="x"/> raised to the power <paramref name="y"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.pow"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T Pow<T>(this T x, T y) where T : IFloatingPoint<T> => T.Pow(x, y);

		/// <summary>
		/// Takes the top element of the <paramref name="stack"/>, raises the next element to the power of the first, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Pow<T>(this IStack<T> stack) where T : IFloatingPoint<T> {
			T y = stack.Pop();
			T x = stack.Pop();
			stack.Push(T.Pow(x, y));
		}
	}
}
