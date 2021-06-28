using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits.Concepts;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Divides the top two elements on the <paramref name="stack"/> together, and pushes the modulus back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Modulus([DisallowNull] this IStack<nint> stack) {
			nint right = stack.Pop();
			nint left = stack.Pop();
			stack.Push(left % right);
		}

		/// <summary>
		/// Divides the top two elements on the <paramref name="stack"/> together, and pushes the modulus back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		[CLSCompliant(false)]
		public static void Modulus([DisallowNull] this IStack<nuint> stack) {
			nuint right = stack.Pop();
			nuint left = stack.Pop();
			stack.Push(left % right);
		}

		/// <summary>
		/// Divides the top two elements on the <paramref name="stack"/> together, and pushes the modulus back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Modulus([DisallowNull] this IStack<Int32> stack) {
			Int32 right = stack.Pop();
			Int32 left = stack.Pop();
			stack.Push(left % right);
		}

		/// <summary>
		/// Divides the top two elements on the <paramref name="stack"/> together, and pushes the modulus back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		[CLSCompliant(false)]
		public static void Modulus([DisallowNull] this IStack<UInt32> stack) {
			UInt32 right = stack.Pop();
			UInt32 left = stack.Pop();
			stack.Push(left % right);
		}

		/// <summary>
		/// Divides the top two elements on the <paramref name="stack"/> together, and pushes the modulus back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Modulus([DisallowNull] this IStack<Int64> stack) {
			Int64 right = stack.Pop();
			Int64 left = stack.Pop();
			stack.Push(left % right);
		}

		/// <summary>
		/// Divides the top two elements on the <paramref name="stack"/> together, and pushes the modulus back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		[CLSCompliant(false)]
		public static void Modulus([DisallowNull] this IStack<UInt64> stack) {
			UInt64 right = stack.Pop();
			UInt64 left = stack.Pop();
			stack.Push(left % right);
		}

		/// <summary>
		/// Divides the top two elements on the <paramref name="stack"/> together, and pushes the modulus back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Modulus([DisallowNull] this IStack<Single> stack) {
			Single right = stack.Pop();
			Single left = stack.Pop();
			stack.Push(left % right);
		}

		/// <summary>
		/// Divides the top two elements on the <paramref name="stack"/> together, and pushes the modulus back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Modulus([DisallowNull] this IStack<Double> stack) {
			Double right = stack.Pop();
			Double left = stack.Pop();
			stack.Push(left % right);
		}

		/// <summary>
		/// Divides the top two elements on the <paramref name="stack"/> together, and pushes the modulus back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Modulus([DisallowNull] this IStack<Decimal> stack) {
			Decimal right = stack.Pop();
			Decimal left = stack.Pop();
			stack.Push(left % right);
		}
	}
}
