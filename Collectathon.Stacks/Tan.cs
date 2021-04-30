using System;
using System.Diagnostics.CodeAnalysis;

namespace Collectathon.Stacks {
	public static partial class StackExtensions {
		/// <summary>
		/// Takes the tangent of the top element, and pushes the result back onto the stack.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <returns>A <see	cref="Stack{TElement}"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static Stack<Double> Tan([AllowNull] this Stack<Double> stack) => stack.Tan(out Double result).Write(result);

		/// <summary>
		/// Takes the tangent of the top element, and returns the <paramref name="result"/>.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <param name="result">The result of the tangent.</param>
		/// <returns>A <see	cref="Stack{TElement}"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static Stack<Double> Tan([AllowNull] this Stack<Double> stack, out Double result) {
			stack.Read(out Double value);
			result = Math.Tan(value);
			return stack;
		}
	}
}
