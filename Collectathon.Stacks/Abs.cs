using System;
using System.Diagnostics.CodeAnalysis;

namespace Collectathon.Stacks {
	public static partial class StackExtensions {
		#region Int32
		/// <summary>
		/// Takes the absolute value of the top element, and pushes the result back onto the stack.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <returns>A <see	cref="Stack{TElement}"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static Stack<Int32> Abs([AllowNull] this Stack<Int32> stack) => stack.Abs(out Int32 result).Write(result);

		/// <summary>
		/// Takes the absolute value of the top element, and returns the <paramref name="result"/>.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <param name="result">The result of the absolute value.</param>
		/// <returns>A <see	cref="Stack{TElement}"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static Stack<Int32> Abs([AllowNull] this Stack<Int32> stack, out Int32 result) {
			stack.Read(out Int32 value);
			result = Math.Abs(value);
			return stack;
		}
		#endregion

		#region Int64
		/// <summary>
		/// Takes the absolute value of the top element, and pushes the result back onto the stack.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <returns>A <see	cref="Stack{TElement}"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static Stack<Int64> Abs([AllowNull] this Stack<Int64> stack) => stack.Abs(out Int64 result).Write(result);

		/// <summary>
		/// Takes the absolute value of the top element, and returns the <paramref name="result"/>.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <param name="result">The result of the absolute value.</param>
		/// <returns>A <see	cref="Stack{TElement}"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static Stack<Int64> Abs([AllowNull] this Stack<Int64> stack, out Int64 result) {
			stack.Read(out Int64 value);
			result = Math.Abs(value);
			return stack;
		}
		#endregion

		#region Single
		/// <summary>
		/// Takes the absolute value of the top element, and pushes the result back onto the stack.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <returns>A <see	cref="Stack{TElement}"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static Stack<Single> Abs([AllowNull] this Stack<Single> stack) => stack.Abs(out Single result).Write(result);

		/// <summary>
		/// Takes the absolute value of the top element, and returns the <paramref name="result"/>.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <param name="result">The result of the absolute value.</param>
		/// <returns>A <see	cref="Stack{TElement}"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static Stack<Single> Abs([AllowNull] this Stack<Single> stack, out Single result) {
			stack.Read(out Single value);
			result = Math.Abs(value);
			return stack;
		}
		#endregion

		#region Double
		/// <summary>
		/// Takes the absolute value of the top element, and pushes the result back onto the stack.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <returns>A <see	cref="Stack{TElement}"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static Stack<Double> Abs([AllowNull] this Stack<Double> stack) => stack.Abs(out Double result).Write(result);

		/// <summary>
		/// Takes the absolute value of the top element, and returns the <paramref name="result"/>.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <param name="result">The result of the absolute value.</param>
		/// <returns>A <see	cref="Stack{TElement}"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static Stack<Double> Abs([AllowNull] this Stack<Double> stack, out Double result) {
			stack.Read(out Double value);
			result = Math.Abs(value);
			return stack;
		}
		#endregion
	}
}
