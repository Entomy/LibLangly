using System;
using System.Diagnostics.CodeAnalysis;

namespace Collectathon.Stacks {
	public static partial class StackExtensions {
		/// <summary>
		/// Rounds the top element, by truncation, and pushes the result back onto the stack.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		public static void Truncate([DisallowNull] this Stack<Double> stack) {
			stack.Truncate(out Double result);
			stack.Write(result);
		}

		/// <summary>
		/// Rounds the top element, by truncation, and returns the <paramref name="result"/>.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <param name="result">The result of rounding.</param>
		public static void Truncate([DisallowNull] this Stack<Double> stack, out Double result) {
			stack.Read(out Double value);
			result = Math.Truncate(value);
		}
	}
}
