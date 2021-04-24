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
		/// Tests <see cref="ISequence{TElement, TEnumerator}.Fold(Func{TElement, TElement, TElement}, TElement)"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator.</typeparam>
		/// <param name="expected">The expected value of the fold.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="func">The <see cref="Func{T1, T2, TResult}"/> to use for the fold.</param>
		/// <param name="identity">The identity of the fold.</param>
		public static void Test_Fold<TEnumerator>(Int32 expected, [AllowNull] ISequence<Int32, TEnumerator> subject, [AllowNull] Func<Int32, Int32, Int32> func, Int32 identity) where TEnumerator : IEnumerator<Int32> => Assert.Equals(expected, PhilosoftExtensions.Fold(subject, func, identity));

		/// <summary>
		/// Tests <see cref="ISequence{TElement, TEnumerator}.ToArray()"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator.</typeparam>
		/// <param name="expected">The expected array.</param>
		/// <param name="subject">The object being tested.</param>
		public static void Test_ToArray<TElement, TEnumerator>([AllowNull] TElement[] expected, [AllowNull] ISequence<TElement, TEnumerator> subject) where TEnumerator : IEnumerator<TElement> => Assert.Equals(expected, PhilosoftExtensions.ToArray(subject));

		/// <summary>
		/// Tests <see cref="ISequence{TElement, TEnumerator}.ToString(nint)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator.</typeparam>
		/// <param name="expected">The expected string.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="amount">The maximum amount of elements to render.</param>
		public static void Test_ToString<TElement, TEnumerator>([DisallowNull] String expected, [DisallowNull] ISequence<TElement, TEnumerator> subject, Int32 amount) where TEnumerator : IEnumerator<TElement> => Assert.Equals(expected, subject.ToString(amount));

		/// <summary>
		/// Standard test cases for <see cref="ToArray{TElement}(TElement[])"/>.
		/// </summary>
		/// <returns>The test cases.</returns>
		public static IEnumerable<Object[]> ToArray_Data() {
			yield return new Object[] { new Int32[] { } };
			yield return new Object[] { new Int32[] { 1, 2, 3, 4, 5 } };
		}

		/// <summary>
		/// Standard test cases for <see cref="ToString{TElement}(String, TElement[], Int32)"/>.
		/// </summary>
		/// <returns>The test cases.</returns>
		public static IEnumerable<Object[]> ToString_Data() {
			foreach (Object[] entry in ToString_Data(String.Empty)) {
				yield return entry;
			}
		}

		/// <summary>
		/// Standard test cases for <see cref="ToString{TElement}(String, TElement[], Int32)"/>, with a specified <paramref name="prefix"/>.
		/// </summary>
		/// <param name="prefix"></param>
		/// <returns>The test cases.</returns>
		public static IEnumerable<Object[]> ToString_Data([AllowNull] String prefix) {
			yield return new Object[] { $"{prefix}[]", new Int32[] { }, 5 };
			yield return new Object[] { $"{prefix}[1, 2, 3, 4, 5]", new Int32[] { 1, 2, 3, 4, 5 }, 5 };
			yield return new Object[] { $"{prefix}[1, 2, 3...]", new Int32[] { 1, 2, 3, 4, 5 }, 3 };
		}

		/// <summary>
		/// Validates <see cref="ISequence{TElement, TEnumerator}.GetEnumerator()"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in this collection.</typeparam>
		/// <param name="values">The values of the subject.</param>
		void Enumerator<TElement>([DisallowNull] TElement[] values);

		/// <summary>
		/// Validates <see cref="ISequence{TElement, TEnumerator}.Fold(Func{TElement, TElement, TElement}, TElement)"/>.
		/// </summary>
		/// <param name="expected">The expected value of the fold.</param>
		/// <param name="values">The values of the subject.</param>
		void Fold(Int32 expected, [AllowNull] Int32[] values);

		/// <summary>
		/// Validates <see cref="ISequence{TElement, TEnumerator}.ToArray()"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in this collection.</typeparam>
		/// <param name="values">The values of the subject.</param>
		void ToArray<TElement>([AllowNull] TElement[] values);

		/// <summary>
		/// Validates <see cref="ISequence{TElement, TEnumerator}.ToString(nint)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in this collection.</typeparam>
		/// <param name="expected">The expected text.</param>
		/// <param name="values">The values of the subject.</param>
		/// <param name="amount">The maximum amount of elements to render.</param>
		void ToString<TElement>([DisallowNull] String expected, [DisallowNull] TElement[] values, Int32 amount);
	}
}
