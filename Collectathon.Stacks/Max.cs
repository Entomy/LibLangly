using System;
using System.Diagnostics.CodeAnalysis;

namespace Collectathon.Stacks {
	public static partial class StackExtensions {
		#region Int32
		/// <summary>
		/// Takes the maximum of the top two elements, and pushes the result back onto the stack.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		public static void Max([DisallowNull] this Stack<Int32> stack) {
			stack.Max(out Int32 result);
			stack.Write(result);
		}

		/// <summary>
		/// Takes the maximum of the top two elements, and returns the <paramref name="result"/>.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <param name="result">The maximum.</param>
		public static void Max([DisallowNull] this Stack<Int32> stack, out Int32 result) {
			stack.Read(out Int32 right);
			stack.Read(out Int32 left);
			result = Math.Max(left, right);
		}
		#endregion

		#region Int64
		/// <summary>
		/// Takes the maximum of the top two elements, and pushes the result back onto the stack.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		public static void Max([DisallowNull] this Stack<Int64> stack) {
			stack.Max(out Int64 result);
			stack.Write(result);
		}

		/// <summary>
		/// Takes the maximum of the top two elements, and returns the <paramref name="result"/>.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <param name="result">The maximum.</param>
		public static void Max([DisallowNull] this Stack<Int64> stack, out Int64 result) {
			stack.Read(out Int64 right);
			stack.Read(out Int64 left);
			result = Math.Max(left, right);
		}
		#endregion

		#region Single
		/// <summary>
		/// Takes the maximum of the top two elements, and pushes the result back onto the stack.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		public static void Max([DisallowNull] this Stack<Single> stack) {
			stack.Max(out Single result);
			stack.Write(result);
		}

		/// <summary>
		/// Takes the maximum of the top two elements, and returns the <paramref name="result"/>.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <param name="result">The maximum.</param>
		public static void Max([DisallowNull] this Stack<Single> stack, out Single result) {
			stack.Read(out Single right);
			stack.Read(out Single left);
			result = Math.Max(left, right);
		}
		#endregion

		#region Double
		/// <summary>
		/// Takes the maximum of the top two elements, and pushes the result back onto the stack.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		public static void Max([DisallowNull] this Stack<Double> stack) {
			stack.Max(out Double result);
			stack.Write(result);
		}

		/// <summary>
		/// Takes the maximum of the top two elements, and returns the <paramref name="result"/>.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <param name="result">The maximum.</param>
		public static void Max([DisallowNull] this Stack<Double> stack, out Double result) {
			stack.Read(out Double right);
			stack.Read(out Double left);
			result = Math.Max(left, right);
		}
		#endregion
	}
}
