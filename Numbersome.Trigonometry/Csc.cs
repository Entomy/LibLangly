using System.Traits.Concepts;

namespace Numbersome {
	public static partial class TrigonometryExtensions {
		/// <summary>
		/// Computes the secant compliment of a value.
		/// </summary>
		/// <typeparam name="T">The floating-point numeric type.</typeparam>
		/// <param name="value">The value, in radians, whos secant compliment is to be computed.</param>
		/// <returns>The secant compliment of <paramref name="value"/>.</returns>
		public static T Csc<T>(this T value) where T : IFloatingPoint<T> => T.One / T.Sin(value);

		/// <summary>
		/// Takes the secant compliment of the top element, in radians, of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <typeparam name="T">The floating-point numeric type.</typeparam>
		/// <param name="stack">This stack.</param>
		public static void Csc<T>(this IStack<T> stack) where T : IFloatingPoint<T> => stack.Push(stack.Pop().Csc());
	}
}
