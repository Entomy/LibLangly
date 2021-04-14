using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits.Contracts {
	/// <summary>
	/// Contract for validating <see cref="IClear{TResult}"/>.
	/// </summary>
	/// <typeparam name="TAssert">The type of the test asserter to use.</typeparam>
	public interface IClearContract<out TAssert> : IContract<TAssert> where TAssert : IAssert, new() {
		/// <summary>
		/// Standard test cases for <see cref="Clear{TElement}(TElement[])"/>.
		/// </summary>
		/// <returns>The test cases.</returns>
		public static IEnumerable<Object[]> Clear_Data() {
			yield return new Object[] { null };
			yield return new Object[] { Array.Empty<Int32>() };
			yield return new Object[] { new Int32[] { 1, 2, 3, 4, 5 } };
		}

		/// <summary>
		/// Tests <see cref="IClear{TResult}.Clear()"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="subject">The object being tested.</param>
		public static void Test<TElement, TSubject>([AllowNull] TSubject subject) where TSubject : IClear<TSubject>, IEnumerable<TElement> {
			PhilosoftExtensions.Clear(subject);
			Validate<TElement, TSubject>(subject);
		}

		/// <summary>
		/// Validates <see cref="IClear{TResult}.Clear()"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="initial">The initial values of the subject.</param>
		void Clear<TElement>([AllowNull] TElement[] initial);

		/// <summary>
		/// Validates that the <paramref name="subject"/> has been cleared.
		/// </summary>
		/// <param name="subject">The object being tested.</param>
		protected static void Validate<TElement, TSubject>([DisallowNull] TSubject subject) where TSubject : IClear<TSubject>, IEnumerable<TElement> {
			if (subject is not null) {
				Assert.Empty(subject);
			} else {
				Assert.IsNull(subject);
			}
		}
	}
}
