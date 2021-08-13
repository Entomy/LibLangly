using System.Traits.Concepts;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Divides the top two elements on the <paramref name="stack"/> together, and pushes the modulus back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Modulus<T>(this IStack<T> stack) where T : IModulusOperators<T, T, T> {
			T right = stack.Pop();
			T left = stack.Pop();
			stack.Push(left % right);
		}
	}
}
