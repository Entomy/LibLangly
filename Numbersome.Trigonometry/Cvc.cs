using System.Traits.Concepts;

namespace Numbersome {
	public static partial class TrigonometryExtensions {
		/// <summary>
		/// Computes the versed compliment sine compliment of a value.
		/// </summary>
		/// <typeparam name="T">The floating-point numeric type.</typeparam>
		/// <param name="value">The value, in radians, whos versed sine compliment is to be computed.</param>
		/// <returns>The versed compliment sine compliment of <paramref name="value"/>.</returns>
		public static T Cvc<T>(this T value) where T : IFloatingPoint<T> => T.One + T.Sin(value);

		/// <summary>
		/// Takes the versed compliment sine compliment of the top element, in radians, of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <typeparam name="T">The floating-point numeric type.</typeparam>
		/// <param name="stack">This stack.</param>
		public static void Cvc<T>(this IStack<T> stack) where T : IFloatingPoint<T> => stack.Push(stack.Pop().Cvc());
	}
}
