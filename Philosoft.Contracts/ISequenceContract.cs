using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits.Contracts {
	/// <summary>
	/// Contract for validating <see cref="ISequence{TElement, TEnumerator}"/>.
	/// </summary>
	/// <typeparam name="TAssert">The type of the test asserter to use.</typeparam>
	public interface ISequenceContract<out TAssert> : IContract<TAssert> where TAssert : IAssert, new() {
		/// <summary>
		/// Standard test cases for <see cref="Enumerator{TElement}(TElement[])"/>.
		/// </summary>
		/// <returns>The test cases.</returns>
		public static IEnumerable<Object[]> Enumerator_Data() {
			yield return new Object[] { new Int32[] { 1 } };
			yield return new Object[] { new Int32[] { 1, 2, 3, 4, 5 } };
		}

		/// <summary>
		/// Tests <see cref="ISequence{TElement, TEnumerator}.GetEnumerator()"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		public static void Test_Enumerator<TElement, TEnumerator>([DisallowNull] TElement[] expected, [DisallowNull] ISequence<TElement, TEnumerator> subject) where TEnumerator : IEnumerator<TElement> {
			if (expected is not null) {
				if (expected is not null) {
					Assert.Equals(expected, subject);
				} else {
					Assert.IsNull(subject);
				}
			}
		}

		/// <summary>
		/// Validates <see cref="ISequence{TElement, TEnumerator}.GetEnumerator()"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in this collection.</typeparam>
		/// <param name="values">The values of the subject.</param>
		void Enumerator<TElement>([DisallowNull] TElement[] values);
	}
}
