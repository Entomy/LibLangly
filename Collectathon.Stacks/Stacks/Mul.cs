using System;
using System.Diagnostics.CodeAnalysis;

namespace Collectathon.Stacks {
	public static partial class StackExtensions {
		#region Int32
		/// <summary>
		/// Multiplies the top two elements together, and pushes the result back onto the stack.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		public static void Mul([DisallowNull] this Stack<Int32> stack) {
			stack.Mul(out Int32 result);
			stack.Write(result);
		}

		/// <summary>
		/// Multiplies the top two elements together, and returns the <paramref name="result"/>.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <param name="result">The result of the multiplication.</param>
		public static void Mul([DisallowNull] this Stack<Int32> stack, out Int32 result) {
			stack.Read(out Int32 right);
			stack.Read(out Int32 left);
			result = left * right;
		}
		#endregion

		#region Int64
		/// <summary>
		/// Multiplies the top two elements together, and pushes the result back onto the stack.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		public static void Mul([DisallowNull] this Stack<Int64> stack) {
			stack.Mul(out Int64 result);
			stack.Write(result);
		}

		/// <summary>
		/// Multiplies the top two elements together, and returns the <paramref name="result"/>.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <param name="result">The result of the multiplication.</param>
		public static void Mul([DisallowNull] this Stack<Int64> stack, out Int64 result) {
			stack.Read(out Int64 right);
			stack.Read(out Int64 left);
			result = left * right;
		}
		#endregion

		#region Single
		/// <summary>
		/// Multiplies the top two elements together, and pushes the result back onto the stack.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		public static void Mul([DisallowNull] this Stack<Single> stack) {
			stack.Mul(out Single result);
			stack.Write(result);
		}

		/// <summary>
		/// Multiplies the top two elements together, and returns the <paramref name="result"/>.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <param name="result">The result of the multiplication.</param>
		public static void Mul([DisallowNull] this Stack<Single> stack, out Single result) {
			stack.Read(out Single right);
			stack.Read(out Single left);
			result = left * right;
		}
		#endregion

		#region Double
		/// <summary>
		/// Multiplies the top two elements together, and pushes the result back onto the stack.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		public static void Mul([DisallowNull] this Stack<Double> stack) {
			stack.Mul(out Double result);
			stack.Write(result);
		}

		/// <summary>
		/// Multiplies the top two elements together, and returns the <paramref name="result"/>.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <param name="result">The result of the multiplication.</param>
		/// <returns>A <see	cref="Stack{TElement}"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static void Mul([DisallowNull] this Stack<Double> stack, out Double result) {
			stack.Read(out Double right);
			stack.Read(out Double left);
			result = left * right;
		}
		#endregion
	}
}
