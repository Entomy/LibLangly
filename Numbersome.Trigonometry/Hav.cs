using System.Traits.Concepts;

namespace Numbersome {
	public static partial class TrigonometryExtensions {
		/// <summary>
		/// Computes the halved versed sine of a value.
		/// </summary>
		/// <typeparam name="T">The floating-point numeric type.</typeparam>
		/// <param name="value">The value, in radians, whos halved versed sine is to be computed.</param>
		/// <returns>The halved versed sine of <paramref name="value"/>.</returns>
		public static T Hav<T>(this T value) where T : IFloatingPoint<T> => value.Ver() / (T.One + T.One);

		/// <summary>
		/// Takes the halved versed sine of the top element, in radians, of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <typeparam name="T">The floating-point numeric type.</typeparam>
		/// <param name="stack">This stack.</param>
		public static void Hav<T>(this IStack<T> stack) where T : IFloatingPoint<T> => stack.Push(stack.Pop().Hav());
	}
}
