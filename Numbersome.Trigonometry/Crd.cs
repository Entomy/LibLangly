using System.Traits.Concepts;

namespace Numbersome {
	public static partial class TrigonometryExtensions {
		/// <summary>
		/// Computes the chord of a value.
		/// </summary>
		/// <typeparam name="T">The floating-point numeric type.</typeparam>
		/// <param name="value">The value, in radians, whos chord is to be computed.</param>
		/// <returns>The chord of <paramref name="value"/>.</returns>
		public static T Crd<T>(this T value) where T : IFloatingPoint<T> {
			T two = T.One + T.One;
			return two * T.Sin(value / two);
		}

		/// <summary>
		/// Takes the chord of the top element, in radians, of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <typeparam name="T">The floating-point numeric type.</typeparam>
		/// <param name="stack">This stack.</param>
		public static void Crd<T>(this IStack<T> stack) where T : IFloatingPoint<T> => stack.Push(stack.Pop().Crd());
	}
}
