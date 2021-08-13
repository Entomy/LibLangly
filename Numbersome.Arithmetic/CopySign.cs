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
		public static T CopySign<T>(this T x, T y) where T : IFloatingPoint<T> => T.CopySign(x, y);

		/// <summary>
		/// Takes the sign top element and the magnitude of the next element of the <paramref name="stack"/>, combining them, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void CopySign<T>(this IStack<T> stack) where T : IFloatingPoint<T> {
			T y = stack.Pop();
			T x = stack.Pop();
			stack.Push(T.CopySign(x, y));
		}
	}
}
