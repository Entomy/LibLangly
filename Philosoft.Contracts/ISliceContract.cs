using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits.Contracts {
	/// <summary>
	/// Contract for validating <see cref="ISlice{TResult}"/>.
	/// </summary>
	/// <typeparam name="TAssert">The type of the test asserter to use.</typeparam>
	public interface ISliceContract<out TAssert> : IContract<TAssert> where TAssert : IAssert, new() {
		/// <summary>
		/// Standard test cases for <see cref="Slice{TElement}(TElement[], TElement[])"/>.
		/// </summary>
		/// <returns>The test cases.</returns>
		public static IEnumerable<Object[]> Slice_Data() {
			yield return new object[] { new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 } };
		}

		/// <summary>
		/// Standard test cases for <see cref="Slice_Range{TElement}(TElement[], TElement[], Int32, Int32)"/>.
		/// </summary>
		/// <returns>The test cases.</returns>
		public static IEnumerable<Object[]> Slice_Range_Data() {
			yield return new Object[] { new Int32[] { 2, 3 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 3 };
			yield return new Object[] { new Int32[] { 3, 4 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, 4 };
			yield return new Object[] { new Int32[] { 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 5 };
		}

		/// <summary>
		/// Standard test cases for <see cref="Slice_Start{TElement}(TElement[], TElement[], Int32)"/>.
		/// </summary>
		/// <returns>The test cases.</returns>
		public static IEnumerable<Object[]> Slice_Start_Data() {
			yield return new Object[] { new Int32[] { 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1 };
			yield return new Object[] { new Int32[] { 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 2 };
		}

		/// <summary>
		/// Standard test cases for <see cref="Slice_Start_Length{TElement}(TElement[], TElement[], Int32, Int32)"/>.
		/// </summary>
		/// <returns>The test cases.</returns>
		public static IEnumerable<Object[]> Slice_Start_Length_Data() {
			yield return new Object[] { new Int32[] { 2, 3 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 2 };
			yield return new Object[] { new Int32[] { 3, 4 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, 2 };
			yield return new Object[] { new Int32[] { 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 4 };
		}

		/// <summary>
		/// Tests <see cref="ISlice{TResult}.Slice()"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSlice">The type of the slice taken from the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		public static void Test<TElement, TSlice>([AllowNull] TElement[] expected, [AllowNull] ISlice<TSlice> subject) where TSlice : IEnumerable<TElement> {
			TSlice slice = PhilosoftExtensions.Slice(subject);
			Validate(expected, slice);
		}

		/// <summary>
		/// Tests <see cref="ISlice{TResult}.Slice()"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		public static void Test<TElement>([AllowNull] TElement[] expected, [AllowNull] ISlice<Memory<TElement>> subject) {
			Memory<TElement> slice = PhilosoftExtensions.Slice(subject);
			Validate(expected, slice);
		}

		/// <summary>
		/// Tests <see cref="ISlice{TResult}.Slice()"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		public static void Test<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] ISlice<ReadOnlyMemory<TElement>> subject) {
			ReadOnlyMemory<TElement> slice = PhilosoftExtensions.Slice(subject);
			Validate(expected, slice);
		}

		/// <summary>
		/// Tests <see cref="ISlice{TResult}.Slice(nint)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSlice">The type of the slice taken from the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="start">The starting index of the slice.</param>
		public static void Test<TElement, TSlice>([AllowNull] TElement[] expected, [AllowNull] ISlice<TSlice> subject, Int32 start) where TSlice : IEnumerable<TElement> {
			TSlice slice = PhilosoftExtensions.Slice(subject, start);
			Validate(expected, slice);
		}

		/// <summary>
		/// Tests <see cref="ISlice{TResult}.Slice(nint)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="start">The starting index of the slice.</param>
		public static void Test<TElement>([AllowNull] TElement[] expected, [AllowNull] ISlice<Memory<TElement>> subject, Int32 start) {
			Memory<TElement> slice = PhilosoftExtensions.Slice(subject, start);
			Validate(expected, slice);
		}

		/// <summary>
		/// Tests <see cref="ISlice{TResult}.Slice(nint)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="start">The starting index of the slice.</param>
		public static void Test<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] ISlice<ReadOnlyMemory<TElement>> subject, Int32 start) {
			ReadOnlyMemory<TElement> slice = PhilosoftExtensions.Slice(subject, start);
			Validate(expected, slice);
		}

		/// <summary>
		/// Tests <see cref="ISlice{TResult}.Slice(nint, nint)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSlice">The type of the slice taken from the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="start">The starting index of the slice.</param>
		/// <param name="length">The length of the slice.</param>
		public static void Test<TElement, TSlice>([AllowNull] TElement[] expected, [AllowNull] ISlice<TSlice> subject, Int32 start, Int32 length) where TSlice : IEnumerable<TElement> {
			TSlice slice = PhilosoftExtensions.Slice(subject, start, length);
			Validate(expected, slice);
		}

		/// <summary>
		/// Tests <see cref="ISlice{TResult}.Slice(nint, nint)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="start">The starting index of the slice.</param>
		/// <param name="length">The length of the slice.</param>
		public static void Test<TElement>([AllowNull] TElement[] expected, [AllowNull] ISlice<Memory<TElement>> subject, Int32 start, Int32 length) {
			Memory<TElement> slice = PhilosoftExtensions.Slice(subject, start, length);
			Validate(expected, slice);
		}

		/// <summary>
		/// Tests <see cref="ISlice{TResult}.Slice(nint, nint)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="start">The starting index of the slice.</param>
		/// <param name="length">The length of the slice.</param>
		public static void Test<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] ISlice<ReadOnlyMemory<TElement>> subject, Int32 start, Int32 length) {
			ReadOnlyMemory<TElement> slice = PhilosoftExtensions.Slice(subject, start, length);
			Validate(expected, slice);
		}

		/// <summary>
		/// Validates <see cref="ISlice{TResult}.Slice()"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the slice.</param>
		/// <param name="initial">The initial values of the subject.</param>
		void Slice<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial);

		/// <summary>
		/// Valides range-index slicing.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the slice.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="start">The starting index of the slice.</param>
		/// <param name="end">The ending index of the slice.</param>
		void Slice_Range<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, Int32 start, Int32 end);

		/// <summary>
		/// Validates <see cref="ISlice{TResult}.Slice(nint)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the slice.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="start">The starting index of the slice.</param>
		void Slice_Start<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, Int32 start);

		/// <summary>
		/// Validates <see cref="ISlice{TResult}.Slice(nint, nint)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the slice.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="start">The starting index of the slice.</param>
		/// <param name="length">The length of the slice.</param>
		void Slice_Start_Length<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, Int32 start, Int32 length);
		/// <summary>
		/// Validates that the <paramref name="slice"/> contains the <paramref name="expected"/> elements.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="expected">The expected values the <paramref name="slice"/> contains.</param>
		/// <param name="slice">The object being tested.</param>
		protected static void Validate<TElement>([AllowNull] TElement[] expected, [AllowNull] IEnumerable<TElement> slice) {
			if (expected is not null) {
				Assert.Equals(expected, slice);
			} else {
				Assert.IsNull(slice);
			}
		}

		/// <summary>
		/// Validates that the <paramref name="slice"/> contains the <paramref name="expected"/> elements.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="expected">The expected values the <paramref name="slice"/> contains.</param>
		/// <param name="slice">The object being tested.</param>
		protected static void Validate<TElement>([AllowNull] TElement[] expected, Memory<TElement> slice) {
			if (expected is not null) {
				Assert.Equals(expected, slice.ToArray());
			} else {
				Assert.IsNull(slice);
			}
		}

		/// <summary>
		/// Validates that the <paramref name="slice"/> contains the <paramref name="expected"/> elements.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="expected">The expected values the <paramref name="slice"/> contains.</param>
		/// <param name="slice">The object being tested.</param>
		protected static void Validate<TElement>([AllowNull] TElement[] expected, ReadOnlyMemory<TElement> slice) {
			if (expected is not null) {
				Assert.Equals(expected, slice.ToArray());
			} else {
				Assert.IsNull(slice);
			}
		}
	}
}
