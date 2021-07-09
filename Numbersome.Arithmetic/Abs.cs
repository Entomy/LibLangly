using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Traits.Concepts;

namespace Numbersome {
	public static partial class ArithmeticExtensions {
		/// <summary>
		/// Returns the absolute value of a <see cref="Decimal"/> number.
		/// </summary>
		/// <param name="value">A number that is greater than or equal to <see cref="Decimal.MinValue"/>, but less than or equal to <see cref="Decimal.MaxValue"/>.</param>
		/// <returns>A decimal number, x, such that 0 ≤ x ≤ <see cref="Decimal.MaxValue"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.abs"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Decimal Abs(this Decimal value) => Math.Abs(value);

		/// <summary>
		/// Takes the absolute value of the top element of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Abs([DisallowNull] this IStack<Decimal> stack) => stack.Push(stack.Pop().Abs());

		/// <summary>
		/// Returns the absolute value of a <see cref="Double"/> number.
		/// </summary>
		/// <param name="value">A number that is greater than or equal to <see cref="Double.MinValue"/>, but less than or equal to <see cref="Double.MaxValue"/>.</param>
		/// <returns>A decimal number, x, such that 0 ≤ x ≤ <see cref="Double.MaxValue"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.abs"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Double Abs(this Double value) => Math.Abs(value);

		/// <summary>
		/// Takes the absolute value of the top element of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Abs([DisallowNull] this IStack<Double> stack) => stack.Push(stack.Pop().Abs());

		/// <summary>
		/// Returns the absolute value of a <see cref="Int16"/> number.
		/// </summary>
		/// <param name="value">A number that is greater than or equal to <see cref="Int16.MinValue"/>, but less than or equal to <see cref="Int16.MaxValue"/>.</param>
		/// <returns>A decimal number, x, such that 0 ≤ x ≤ <see cref="Int16.MaxValue"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.abs"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int16 Abs(this Int16 value) => Math.Abs(value);

		/// <summary>
		/// Takes the absolute value of the top element of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Abs([DisallowNull] this IStack<Int16> stack) => stack.Push(stack.Pop().Abs());

		/// <summary>
		/// Returns the absolute value of a <see cref="Int32"/> number.
		/// </summary>
		/// <param name="value">A number that is greater than or equal to <see cref="Int32.MinValue"/>, but less than or equal to <see cref="Int32.MaxValue"/>.</param>
		/// <returns>A decimal number, x, such that 0 ≤ x ≤ <see cref="Int32.MaxValue"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.abs"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int32 Abs(this Int32 value) => Math.Abs(value);

		/// <summary>
		/// Takes the absolute value of the top element of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Abs([DisallowNull] this IStack<Int32> stack) => stack.Push(stack.Pop().Abs());

		/// <summary>
		/// Returns the absolute value of a <see cref="Int64"/> number.
		/// </summary>
		/// <param name="value">A number that is greater than or equal to <see cref="Int64.MinValue"/>, but less than or equal to <see cref="Int64.MaxValue"/>.</param>
		/// <returns>A decimal number, x, such that 0 ≤ x ≤ <see cref="Int64.MaxValue"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.abs"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int64 Abs(this Int64 value) => Math.Abs(value);

		/// <summary>
		/// Takes the absolute value of the top element of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Abs([DisallowNull] this IStack<Int64> stack) => stack.Push(stack.Pop().Abs());

		/// <summary>
		/// Returns the absolute value of a <see cref="SByte"/> number.
		/// </summary>
		/// <param name="value">A number that is greater than or equal to <see cref="SByte.MinValue"/>, but less than or equal to <see cref="SByte.MaxValue"/>.</param>
		/// <returns>A decimal number, x, such that 0 ≤ x ≤ <see cref="SByte.MaxValue"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.abs"/>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SByte Abs(this SByte value) => Math.Abs(value);

		/// <summary>
		/// Takes the absolute value of the top element of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		[CLSCompliant(false)]
		public static void Abs([DisallowNull] this IStack<SByte> stack) => stack.Push(stack.Pop().Abs());

		/// <summary>
		/// Returns the absolute value of a <see cref="Single"/> number.
		/// </summary>
		/// <param name="value">A number that is greater than or equal to <see cref="Single.MinValue"/>, but less than or equal to <see cref="Single.MaxValue"/>.</param>
		/// <returns>A decimal number, x, such that 0 ≤ x ≤ <see cref="Single.MaxValue"/>.</returns>
		/// <seealso href="https://docs.microsoft.com/en-us/dotnet/api/system.math.abs"/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Single Abs(this Single value) => Math.Abs(value);

		/// <summary>
		/// Takes the absolute value of the top element of the <paramref name="stack"/>, and pushes the result back onto the <paramref name="stack"/>.
		/// </summary>
		/// <param name="stack">This stack.</param>
		public static void Abs([DisallowNull] this IStack<Single> stack) => stack.Push(stack.Pop().Abs());
	}
}
