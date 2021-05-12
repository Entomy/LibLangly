using System;
using System.Diagnostics.CodeAnalysis;

namespace Collectathon.Stacks {
	public static partial class StackExtensions {
		/// <summary>
		/// Rounds the top element, by flooring, and pushes the result back onto the stack.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		public static void Floor([DisallowNull] this Stack<Double> stack) {
			stack.Floor(out Double result);
			stack.Write(result);
		}

		/// <summary>
		/// Rounds the top element, by flooring, and returns the <paramref name="result"/>.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <param name="result">The result of rounding.</param>
		public static void Floor([DisallowNull] this Stack<Double> stack, out Double result) {
			stack.Read(out Double value);
			result = Math.Floor(value);
		}
	}
}
