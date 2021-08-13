using System.Traits.Concepts;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Multiplies the top two elements on the <paramref name="stack"/> together, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Multiply<T>(this IStack<T> stack) where T : IMultiplyOperators<T, T, T> {
			T right = stack.Pop();
			T left = stack.Pop();
			stack.Push(left * right);
		}
	}
}
