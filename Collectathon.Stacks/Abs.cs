using System;
using System.Diagnostics.CodeAnalysis;

namespace Collectathon.Stacks {
	public static partial class StackExtensions {
		#region Int32
		/// <summary>
		/// Takes the absolute value of the top element, and pushes the result back onto the stack.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		public static void Abs([DisallowNull] this Stack<Int32> stack) {
			stack.Abs(out Int32 result);
			stack.Write(result);
		}

		/// <summary>
		/// Takes the absolute value of the top element, and returns the <paramref name="result"/>.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <param name="result">The result of the absolute value.</param>
		public static void Abs([DisallowNull] this Stack<Int32> stack, out Int32 result) {
			stack.Read(out Int32 value);
			result = Math.Abs(value);
		}
		#endregion

		#region Int64
		/// <summary>
		/// Takes the absolute value of the top element, and pushes the result back onto the stack.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		public static void Abs([DisallowNull] this Stack<Int64> stack) {
			stack.Abs(out Int64 result);
			stack.Write(result);
		}

		/// <summary>
		/// Takes the absolute value of the top element, and returns the <paramref name="result"/>.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <param name="result">The result of the absolute value.</param>
		public static void Abs([DisallowNull] this Stack<Int64> stack, out Int64 result) {
			stack.Read(out Int64 value);
			result = Math.Abs(value);
		}
		#endregion

		#region Single
		/// <summary>
		/// Takes the absolute value of the top element, and pushes the result back onto the stack.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		public static void Abs([DisallowNull] this Stack<Single> stack) {
			stack.Abs(out Single result);
			stack.Write(result);
		}

		/// <summary>
		/// Takes the absolute value of the top element, and returns the <paramref name="result"/>.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <param name="result">The result of the absolute value.</param>
		public static void Abs([DisallowNull] this Stack<Single> stack, out Single result) {
			stack.Read(out Single value);
			result = Math.Abs(value);
		}
		#endregion

		#region Double
		/// <summary>
		/// Takes the absolute value of the top element, and pushes the result back onto the stack.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		public static void Abs([DisallowNull] this Stack<Double> stack) {
			stack.Abs(out Double result);
			stack.Write(result);
		}

		/// <summary>
		/// Takes the absolute value of the top element, and returns the <paramref name="result"/>.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <param name="result">The result of the absolute value.</param>
		public static void Abs([DisallowNull] this Stack<Double> stack, out Double result) {
			stack.Read(out Double value);
			result = Math.Abs(value);
		}
		#endregion
	}
}
