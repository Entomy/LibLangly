using System;
using System.Diagnostics.CodeAnalysis;

namespace Collectathon.Stacks {
	public static partial class StackExtensions {
		/// <summary>
		/// Takes the top two elements, raising the second to the power of the first, and pushes the result back onto the stack.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		public static void Pow([DisallowNull] this Stack<Double> stack) {
			stack.Pow(out Double result);
			stack.Write(result);
		}

		/// <summary>
		/// Takes the top two elements, raising the second to the power of the first, and returns the <paramref name="result"/>.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <param name="result">The result of the exponentiation.</param>
		public static void Pow([DisallowNull] this Stack<Double> stack, out Double result) {
			stack.Read(out Double right);
			stack.Read(out Double left);
			result = Math.Pow(left, right);
		}
	}
}
