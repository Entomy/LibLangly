using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits.Contracts {
	/// <summary>
	/// Contract for validating <see cref="IResize{TResult}"/>.
	/// </summary>
	/// <typeparam name="TAssert">The type of the test asserter to use.</typeparam>
	public interface IResizeContract<out TAssert> : IContract<TAssert> where TAssert : IAssert, new() {
		/// <summary>
		/// Standard test cases for <see cref="Grow{TElement}(TElement[], TElement[])"/>.
		/// </summary>
		/// <returns>The test cases.</returns>
		public static IEnumerable<Object[]> Grow_Data() {
			yield return new Object[] { null, null };
			yield return new Object[] { new Int32[] { }, new Int32[] { } };
			yield return new Object[] { new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 } };
		}

		/// <summary>
		/// Standard test cases for <see cref="Resize{TElement}(TElement[], TElement[], Int32)"/>.
		/// </summary>
		/// <returns>The test cases.</returns>
		public static IEnumerable<Object[]> Resize_Data() {
			yield return new Object[] { null, null, 0 };
			yield return new Object[] { new Int32[] { }, new Int32[] { }, 0 };
			yield return new Object[] { new Int32[] { }, new Int32[] { }, 5 };
			yield return new Object[] { new Int32[] { }, new Int32[] { 1, 2, 3, 4, 5 }, 0 };
			yield return new Object[] { new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 5 };
			yield return new Object[] { new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 8 };
		}

		/// <summary>
		/// Standard test cases for <see cref="Shrink{TElement}(TElement[], TElement[])"/>.
		/// </summary>
		/// <returns>The test cases.</returns>
		public static IEnumerable<Object[]> Shrink_Data() {
			yield return new Object[] { null, null };
			yield return new Object[] { new Int32[] { }, new Int32[] { } };
			yield return new Object[] { new Int32[] { 1, 2, 3 }, new Int32[] { 1, 2, 3, 4, 5 } };
		}

		/// <summary>
		/// Tests <see cref="IResize{TResult}.Grow"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		public static void Test_Grow<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject) where TSubject : IResize<TSubject>, IEnumerable<TElement> => Validate(expected, TraitExtensions.Grow(subject));

		/// <summary>
		/// Tests <see cref="IResize{TResult}.Resize(nint)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="capacity">The new capacity of the subject.</param>
		public static void Test_Resize<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, Int32 capacity) where TSubject : IResize<TSubject>, IEnumerable<TElement> => Validate(expected, TraitExtensions.Resize(subject, capacity));

		/// <summary>
		/// Tests <see cref="IResize{TResult}.Shrink"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		public static void Test_Shrink<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject) where TSubject : IResize<TSubject>, IEnumerable<TElement> => Validate(expected, TraitExtensions.Shrink(subject));

		/// <summary>
		/// Validates <see cref="IResize{TResult}.Grow"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		void Grow<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial);

		/// <summary>
		/// Validates <see cref="IResize{TResult}.Resize(nint)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="capacity">The new capacity of the subject.</param>
		void Resize<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, Int32 capacity);

		/// <summary>
		/// Validates <see cref="IResize{TResult}.Shrink"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		void Shrink<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial);

		/// <summary>
		/// Validates that the <paramref name="subject"/> contains the <paramref name="expected"/> elements.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		protected static void Validate<TElement>([AllowNull] TElement[] expected, [AllowNull] IEnumerable<TElement> subject) {
			if (subject is not null) {
				Assert.Equals(expected, subject);
			} else {
				Assert.IsNull(subject);
			}
		}
	}
}
