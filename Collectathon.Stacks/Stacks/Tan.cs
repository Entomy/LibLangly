using System;
using System.Diagnostics.CodeAnalysis;

namespace Collectathon.Stacks {
	public static partial class StackExtensions {
		/// <summary>
		/// Takes the tangent of the top element, and pushes the result back onto the stack.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		public static void Tan([DisallowNull] this Stack<Double> stack) {
			stack.Tan(out Double result);
			stack.Write(result);
		}

		/// <summary>
		/// Takes the tangent of the top element, and returns the <paramref name="result"/>.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <param name="result">The result of the tangent.</param>
		public static void Tan([DisallowNull] this Stack<Double> stack, out Double result) {
			stack.Read(out Double value);
			result = Math.Tan(value);
		}
	}
}
