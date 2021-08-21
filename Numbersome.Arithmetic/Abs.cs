using System.Traits.Concepts;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns the absolute value of a <typeparamref name="T"/> number.
		/// </summary>
		/// <typeparam name="T">The type of the number.</typeparam>
		/// <param name="value">A number that is greater than or equal to <see cref="INumber{TSelf}"/></param>
		/// <returns>The absolute value of <paramref name="value"/>.</returns>
		public static T Abs<T>(this T value) where T : INumber<T> => T.Abs(value);

		/// <summary>
		/// Takes the absolute value of the top element of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Abs<T>(this IStack<T> stack) where T : INumber<T> => stack.Push(stack.Pop().Abs());
	}
}
