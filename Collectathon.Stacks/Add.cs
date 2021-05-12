using System;
using System.Diagnostics.CodeAnalysis;

namespace Collectathon.Stacks {
	public static partial class StackExtensions {
		#region Int32
		/// <summary>
		/// Adds the top two elements together, and pushes the result back onto the stack.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		public static void Add([DisallowNull] this Stack<Int32> stack) {
			stack.Add(out Int32 result);
			stack.Write(result);
		}

		/// <summary>
		/// Adds the top two elements together, and returns the <paramref name="result"/>.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <param name="result">The result of the addition.</param>
		public static void Add([DisallowNull] this Stack<Int32> stack, out Int32 result) {
			stack.Read(out Int32 right);
			stack.Read(out Int32 left);
			result = left + right;
		}
		#endregion

		#region Int64
		/// <summary>
		/// Adds the top two elements together, and pushes the result back onto the stack.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		public static void Add([DisallowNull] this Stack<Int64> stack) {
			stack.Add(out Int64 result);
			stack.Write(result);
		}

		/// <summary>
		/// Adds the top two elements together, and returns the <paramref name="result"/>.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <param name="result">The result of the addition.</param>
		public static void Add([DisallowNull] this Stack<Int64> stack, out Int64 result) {
			stack.Read(out Int64 right);
			stack.Read(out Int64 left);
			result = left + right;
		}
		#endregion

		#region Single
		/// <summary>
		/// Adds the top two elements together, and pushes the result back onto the stack.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		public static void Add([DisallowNull] this Stack<Single> stack) {
			stack.Add(out Single result);
			stack.Write(result);
		}

		/// <summary>
		/// Adds the top two elements together, and returns the <paramref name="result"/>.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <param name="result">The result of the addition.</param>
		public static void Add([DisallowNull] this Stack<Single> stack, out Single result) {
			stack.Read(out Single right);
			stack.Read(out Single left);
			result = left + right;
		}
		#endregion

		#region Double
		/// <summary>
		/// Adds the top two elements together, and pushes the result back onto the stack.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		public static void Add([DisallowNull] this Stack<Double> stack) {
			stack.Add(out Double result);
			stack.Write(result);
		}

		/// <summary>
		/// Adds the top two elements together, and returns the <paramref name="result"/>.
		/// </summary>
		/// <param name="stack">This <see cref="Stack{TElement}"/>.</param>
		/// <param name="result">The result of the addition.</param>
		public static void Add([DisallowNull] this Stack<Double> stack, out Double result) {
			stack.Read(out Double right);
			stack.Read(out Double left);
			result = left + right;
		}
		#endregion
	}
}
