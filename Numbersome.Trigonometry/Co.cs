using System.Traits.Concepts;

namespace Numbersome {
	public static partial class TrigonometryExtensions {
		/// <summary>
		/// Computes the compliment of a value.
		/// </summary>
		/// <typeparam name="T">The floating-point numeric type.</typeparam>
		/// <param name="value">The value, in radians, whos compliment is to be computed.</param>
		/// <returns>The compliment of <paramref name="value"/>.</returns>
		public static T Co<T>(this T value) where T : IFloatingPoint<T> => (T.Pi / (T.One + T.One)) - value;

		/// <summary>
		/// Takes the compliment of the top element, in radians, of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <typeparam name="T">The floating-point numeric type.</typeparam>
		/// <param name="stack">This stack.</param>
		public static void Co<T>(this IStack<T> stack) where T : IFloatingPoint<T> => stack.Push(stack.Pop().Co());
	}
}
