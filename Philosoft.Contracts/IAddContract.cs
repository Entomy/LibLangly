using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits.Contracts {
	/// <summary>
	/// Contract for validating <see cref="IAdd{TElement, TResult}"/>.
	/// </summary>
	public interface IAddContract<out TAssert> : IContract<TAssert> where TAssert : IAssert, new() {
		/// <summary>
		/// Standard test cases for <see cref="Add_Array{TElement}(TElement[], TElement[], TElement[][])"/>.
		/// </summary>
		/// <returns>The test cases.</returns>
		public static IEnumerable<Object[]> Add_Array_Data() {
			yield return new Object[] { null, null, null };
			yield return new Object[] { Array.Empty<Int32>(), Array.Empty<Int32>(), Array.Empty<Int32[]>() };
			yield return new Object[] { new Int32[] { 1, 2, 3, 4, 5 }, Array.Empty<Int32>(), new Int32[][] { new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 } } };
		}

		/// <summary>
		/// Standard test cases for <see cref="Add_Element{TElement}(TElement[], TElement[], TElement[])"/>.
		/// </summary>
		/// <returns>The test cases.</returns>
		public static IEnumerable<Object[]> Add_Element_Data() {
			yield return new Object[] { null, null, null };
			yield return new Object[] { Array.Empty<Int32>(), Array.Empty<Int32>(), Array.Empty<Int32>() };
			yield return new Object[] { new Int32[] { 1, 2, 3, 4, 5 }, Array.Empty<Int32>(), new Int32[] { 1, 2, 3, 4, 5 } };
		}

		/// <summary>
		/// Validates <see cref="IAdd{TElement, TResult}.Add(Memory{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="values">The values to add to the <paramref name="subject"/>.</param>
		public static void Validate<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, [AllowNull] Memory<TElement>[] values) where TSubject : IAdd<TElement, TSubject>, IEnumerable<TElement> {
			if (values is not null) {
				foreach (Memory<TElement> item in values) {
					subject = PhilosoftExtensions.Add(subject, item);
				}
			}
			if (expected is not null) {
				foreach (TElement exp in expected) {
					Assert.Contains(exp, subject);
				}
			} else {
				Assert.IsNull(subject);
			}
		}

		/// <summary>
		/// Validates <see cref="IAdd{TElement, TResult}.Add(ReadOnlyMemory{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="values">The values to add to the <paramref name="subject"/>.</param>
		public static void Validate<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, [AllowNull] ReadOnlyMemory<TElement>[] values) where TSubject : IAdd<TElement, TSubject>, IEnumerable<TElement> {
			if (values is not null) {
				foreach (ReadOnlyMemory<TElement> item in values) {
					subject = PhilosoftExtensions.Add(subject, item);
				}
			}
			if (expected is not null) {
				foreach (TElement exp in expected) {
					Assert.Contains(exp, subject);
				}
			} else {
				Assert.IsNull(subject);
			}
		}

		/// <summary>
		/// Validates <see cref="IAdd{TElement, TResult}.Add(TElement[])"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="values">The values to add to the <paramref name="subject"/>.</param>
		public static void Validate<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, [AllowNull] TElement[][] values) where TSubject : IAdd<TElement, TSubject>, IEnumerable<TElement> {
			if (values is not null) {
				foreach (TElement[] item in values) {
					subject = PhilosoftExtensions.Add(subject, item);
				}
			}
			if (expected is not null) {
				foreach (TElement exp in expected) {
					Assert.Contains(exp, subject);
				}
			} else {
				Assert.IsNull(subject);
			}
		}

		/// <summary>
		/// Validates <see cref="IAdd{TElement, TResult}.Add(TElement)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="values">The values to add to the <paramref name="subject"/>.</param>
		public static void Validate<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, [AllowNull] TElement[] values) where TSubject : IAdd<TElement, TSubject>, IEnumerable<TElement> {
			if (values is not null) {
				foreach (TElement item in values) {
					subject = PhilosoftExtensions.Add(subject, item);
				}
			}
			if (expected is not null) {
				foreach (TElement exp in expected) {
					Assert.Contains(exp, subject);
				}
			} else {
				Assert.IsNull(subject);
			}
		}

		/// <summary>
		/// Validates <see cref="IAdd{TElement, TResult}.Add(Memory{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="values">The values to add to the subject.</param>
		void Add_Memory<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values);

		/// <summary>
		/// Validates <see cref="IAdd{TElement, TResult}.Add(ReadOnlyMemory{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="values">The values to add to the subject.</param>
		void Add_ReadOnlyMemory<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values);

		/// <summary>
		/// Validates <see cref="IAdd{TElement, TResult}.Add(TElement[])"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="values">The values to add to the subject.</param>
		void Add_Array<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values);

		/// <summary>
		/// Validates <see cref="IAdd{TElement, TResult}.Add(TElement)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="values">The values to add to the subject.</param>
		void Add_Element<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[] values);
	}
}
