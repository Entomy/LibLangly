using System.Traits.Concepts;

namespace Numbersome {
	public static partial class TrigonometryExtensions {
		/// <summary>
		/// Computes the exterior secant compliment of a value.
		/// </summary>
		/// <typeparam name="T">The floating-point numeric type.</typeparam>
		/// <param name="value">The value, in radians, whos exterior secant compliment is to be computed.</param>
		/// <returns>The exterior secant compliment of <paramref name="value"/>.</returns>
		public static T Exc<T>(this T value) where T : IFloatingPoint<T> => value.Csc() - T.One;

		/// <summary>
		/// Takes the exterior secant compliment of the top element, in radians, of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <typeparam name="T">The floating-point numeric type.</typeparam>
		/// <param name="stack">This stack.</param>
		public static void Exc<T>(this IStack<T> stack) where T : IFloatingPoint<T> => stack.Push(stack.Pop().Exc());
	}
}
