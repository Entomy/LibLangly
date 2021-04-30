using System;
using System.Diagnostics.CodeAnalysis;

namespace Collectathon.Stacks {
	public static partial class StackExtensions {
		/// <summary>
		/// Takes the sine of the top element, and pushes the result back onto the stack.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <returns>A <see	cref="Stack{TElement}"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static Stack<Double> Sin([AllowNull] this Stack<Double> stack) => stack.Sin(out Double result).Write(result);

		/// <summary>
		/// Takes the sine of the top element, and returns the <paramref name="result"/>.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <param name="result">The result of the sine.</param>
		/// <returns>A <see	cref="Stack{TElement}"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static Stack<Double> Sin([AllowNull] this Stack<Double> stack, out Double result) {
			stack.Read(out Double value);
			result = Math.Sin(value);
			return stack;
		}
	}
}
