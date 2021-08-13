using System.Runtime.CompilerServices;
using System.Traits.Concepts;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns the remainder resulting from the division of a specified number by another specified number.
		/// </summary>
		/// <param name="x">A dividend.</param>
		/// <param name="y">A divisor.</param>
		/// <returns>
		/// <para>A number equal to <paramref name="x"/> - (<paramref name="y"/> Q), where Q is the equotient of <paramref name="x"/> / <paramref name="y"/> rounded to the nearest integer (if <paramref name="x"/> / <paramref name="y"/> falls halfway between two integers, the even integer is returned).</para>
		/// <para>If <paramref name="x"/> - (<paramref name="y"/> Q) is zero, the value +0 is returned if <paramref name="x"/> is positive, or -0 if <paramref name="x"/> is negative.</para>
		/// <para>IF <paramref name="y"/> = 0, <see cref="Double.NaN"/> is returned.</para>
		/// </returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.ieeeremainder"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T IEEERemainder<T>(this T x, T y) where T : IFloatingPoint<T> => T.IEEERemainder(x, y);

		/// <summary>
		/// Takes the top two element of the <paramref name="stack"/>, divides them, and pushes the remainder back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void IEEERemainder<T>(this IStack<T> stack) where T : IFloatingPoint<T> {
			T y = stack.Pop();
			T x = stack.Pop();
			stack.Push(T.IEEERemainder(x, y));
		}
	}
}
