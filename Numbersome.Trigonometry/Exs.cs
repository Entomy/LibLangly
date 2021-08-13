using System.Traits.Concepts;

namespace Numbersome {
	public static partial class TrigonometryExtensions {
		/// <summary>
		/// Computes the exterior secant of a value.
		/// </summary>
		/// <typeparam name="T">The floating-point numeric type.</typeparam>
		/// <param name="value">The value, in radians, whos exterior secant is to be computed.</param>
		/// <returns>The exterior secant of <paramref name="value"/>.</returns>
		public static T Exs<T>(this T value) where T : IFloatingPoint<T> => value.Sec() - T.One;

		/// <summary>
		/// Takes the exterior secant of the top element, in radians, of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <typeparam name="T">The floating-point numeric type.</typeparam>
		/// <param name="stack">This stack.</param>
		public static void Exs<T>(this IStack<T> stack) where T : IFloatingPoint<T> => stack.Push(stack.Pop().Exs());
	}
}
