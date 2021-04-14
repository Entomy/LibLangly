using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits.Contracts {
	/// <summary>
	/// Contract for validating <see cref="IShift{TResult}"/>.
	/// </summary>
	/// <typeparam name="TAssert">The type of the test asserter to use.</typeparam>
	public interface IShiftContract<out TAssert> : IContract<TAssert> where TAssert : IAssert, new() {
		/// <summary>
		/// Standard test cases for <see cref="ShiftLeft{TElement}(TElement[], TElement[])"/>.
		/// </summary>
		/// <returns>The test cases.</returns>
		public static IEnumerable<Object[]> ShiftLeft_Data() {
			yield return new Object[] { null, null };
			yield return new Object[] { Array.Empty<Int32>(), Array.Empty<Int32>() };
			yield return new Object[] { new Int32[] { 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 } };
		}

		/// <summary>
		/// Standard test cases for <see cref="ShiftLeftBy{TElement}(TElement[], TElement[], Int32)"/>.
		/// </summary>
		/// <returns>The test cases.</returns>
		public static IEnumerable<Object[]> ShiftLeftBy_Data() {
			yield return new Object[] { null, null, 1 };
			yield return new Object[] { Array.Empty<Int32>(), Array.Empty<Int32>(), 1 };
			yield return new Object[] { new Int32[] { 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 1 };
			yield return new Object[] { new Int32[] { 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 2 };
		}

		/// <summary>
		/// Standard test cases for <see cref="ShiftRight{TElement}(TElement[], TElement[])"/>.
		/// </summary>
		/// <returns>The test cases.</returns>
		public static IEnumerable<Object[]> ShiftRight_Data() {
			yield return new Object[] { null, null };
			yield return new Object[] { Array.Empty<Int32>(), Array.Empty<Int32>() };
			yield return new Object[] { new Int32[] { 0, 1, 2, 3, 4 }, new Int32[] { 1, 2, 3, 4, 5 } };
		}

		/// <summary>
		/// Standard test cases for <see cref="ShiftRightBy{TElement}(TElement[], TElement[], Int32)"/>.
		/// </summary>
		/// <returns>The test cases.</returns>
		public static IEnumerable<Object[]> ShiftRightBy_Data() {
			yield return new Object[] { null, null, 1 };
			yield return new Object[] { Array.Empty<Int32>(), Array.Empty<Int32>(), 1 };
			yield return new Object[] { new Int32[] { 0, 1, 2, 3, 4 }, new Int32[] { 1, 2, 3, 4, 5 }, 1 };
			yield return new Object[] { new Int32[] { 0, 0, 1, 2, 3 }, new Int32[] { 1, 2, 3, 4, 5 }, 2 };
		}

		/// <summary>
		/// Tests <see cref="IShift{TResult}.ShiftLeft()"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		public static void Test_Left<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject) where TSubject : IShift<TSubject>, IEnumerable<TElement> {
			subject = PhilosoftExtensions.ShiftLeft(subject);
			Validate(expected, subject);
		}

		/// <summary>
		/// Tests <see cref="IShift{TResult}.ShiftLeft(nint)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		public static void Test_Left<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, Int32 amount) where TSubject : IShift<TSubject>, IEnumerable<TElement> {
			subject = PhilosoftExtensions.ShiftLeft(subject, amount);
			Validate(expected, subject);
		}

		/// <summary>
		/// Tests <see cref="IShift{TResult}.ShiftRight()"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		public static void Test_Right<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject) where TSubject : IShift<TSubject>, IEnumerable<TElement> {
			subject = PhilosoftExtensions.ShiftRight(subject);
			Validate(expected, subject);
		}

		/// <summary>
		/// Tests <see cref="IShift{TResult}.ShiftRight(nint)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		public static void Test_Right<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, Int32 amount) where TSubject : IShift<TSubject>, IEnumerable<TElement> {
			subject = PhilosoftExtensions.ShiftRight(subject, amount);
			Validate(expected, subject);
		}

		/// <summary>
		/// Validates <see cref="IShift{TResult}.ShiftLeft()"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		void ShiftLeft<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial);

		/// <summary>
		/// Validates <see cref="IShift{TResult}.ShiftLeft(nint)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		void ShiftLeftBy<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, Int32 amount);

		/// <summary>
		/// Validates left-shift operator.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		void ShiftLeftOp<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, Int32 amount);

		/// <summary>
		/// Validates <see cref="IShift{TResult}.ShiftRight()"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		void ShiftRight<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial);

		/// <summary>
		/// Validates <see cref="IShift{TResult}.ShiftRight(nint)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		void ShiftRightBy<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, Int32 amount);

		/// <summary>
		/// Validates right-shift operator.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		void ShiftRightOp<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, Int32 amount);

		/// <summary>
		/// Validates that the <paramref name="subject"/> has been shifted, matching the <paramref name="expected"/> elements.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		protected static void Validate<TElement>([AllowNull] TElement[] expected, [AllowNull] IEnumerable<TElement> subject) {
			if (expected is not null) {
				Assert.Equals(expected, subject);
			} else {
				Assert.IsNull(subject);
			}
		}
	}
}
