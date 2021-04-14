using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits.Contracts {
	/// <summary>
	/// Contract for validating <see cref="IReplace{TElement, TResult}"/>.
	/// </summary>
	/// <typeparam name="TAssert">The type of the test asserter to use.</typeparam>
	public interface IReplaceContract<out TAssert> : IContract<TAssert> where TAssert : IAssert, new() {
		/// <summary>
		/// Standard test cases for <see cref="Replace{TSearch, TReplace}(TSearch[], TSearch[], TSearch, TReplace)"/>.
		/// </summary>
		/// <returns>The test cases.</returns>
		public static IEnumerable<Object[]> Replace_Data() {
			yield return new Object[] { new Int32[] { }, new Int32[] { }, 0, 0 };
			yield return new Object[] { new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0, 0 };
			yield return new Object[] { new Int32[] { 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 0 };
			yield return new Object[] { new Int32[] { 1, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, 0 };
			yield return new Object[] { new Int32[] { 1, 2, 0, 4, 5, }, new Int32[] { 1, 2, 3, 4, 5 }, 3, 0 };
			yield return new Object[] { new Int32[] { 1, 2, 3, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 4, 0 };
			yield return new Object[] { new Int32[] { 1, 2, 3, 4, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 5, 0 };
			yield return new Object[] { new Int32[] { 0, 2, 0, 2, 0 }, new Int32[] { 1, 2, 1, 2, 1 }, 1, 0 };
			yield return new Object[] { new Int32[] { 0, 0, 0, 0, 0 }, new Int32[] { 1, 1, 1, 1, 1 }, 1, 0 };
		}

		/// <summary>
		/// Tests <see cref="IReplace{TSearch, TReplace, TResult}.Replace(TSearch, TReplace)"/>.
		/// </summary>
		/// <typeparam name="TSearch">The type of the <paramref name="search"/> object.</typeparam>
		/// <typeparam name="TReplace">The type of the <paramref name="replace"/> object.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="search">The element to replace.</param>
		/// <param name="replace">The element to use instead.</param>
		public static void Test<TSearch, TReplace, TSubject>([AllowNull] TSearch[] expected, [AllowNull] IReplace<TSearch, TReplace, TSubject> subject, [AllowNull] TSearch search, [AllowNull] TReplace replace) where TSubject : IReplace<TSearch, TReplace, TSubject>, IEnumerable<TSearch> {
			subject = PhilosoftExtensions.Replace(subject, search, replace);
			Validate(expected, (TSubject)subject);
		}

		/// <summary>
		/// Tests <see cref="IReplace{TSearch, TReplace, TResult}.Replace(TSearch, TReplace)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="search">The element to replace.</param>
		/// <param name="replace">The element to use instead.</param>
		public static void Test<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] IReplace<TElement, TSubject> subject, [AllowNull] TElement search, [AllowNull] TElement replace) where TSubject : IReplace<TElement, TSubject>, IEnumerable<TElement> {
			subject = PhilosoftExtensions.Replace(subject, search, replace);
			Validate(expected, (TSubject)subject);
		}

		/// <summary>
		/// Validates <see cref="IReplace{TSearch, TReplace, TResult}.Replace(TSearch, TReplace)"/>.
		/// </summary>
		/// <typeparam name="TSearch">The type of the <paramref name="search"/> object.</typeparam>
		/// <typeparam name="TReplace">The type of the <paramref name="replace"/> object.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="search">The element to replace.</param>
		/// <param name="replace">The element to use instead.</param>
		void Replace_Complex<TSearch, TReplace>([AllowNull] TSearch[] expected, [AllowNull] TSearch[] initial, [AllowNull] TSearch search, [AllowNull] TReplace replace);

		/// <summary>
		/// Validates <see cref="IReplace{TSearch, TReplace, TResult}.Replace(TSearch, TReplace)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="search">The element to replace.</param>
		/// <param name="replace">The element to use instead.</param>
		void Replace_Simple<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement search, [AllowNull] TElement replace);

		/// <summary>
		/// Validates that the <paramref name="subject"/> has had the necessary objects replaced.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="expected">The expected values type <paramref name="subject"/> contains.</param>
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
