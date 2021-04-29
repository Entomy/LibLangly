using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits.Contracts {
	/// <summary>
	/// Contract for validating <see cref="IAdd{TElement, TResult}"/>.
	/// </summary>
	/// <typeparam name="TAssert">The type of the test asserter to use.</typeparam>
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
		/// Tests <see cref="IAdd{TElement, TResult}.Add(TElement[])"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="values">The values to add to the <paramref name="subject"/>.</param>
		public static void Test_Array<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, [AllowNull] TElement[][] values) where TSubject : IAdd<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			if (values is not null) {
				foreach (TElement[] item in values) {
					subject = TraitExtensions.Add(subject, item);
					opFailed = subject is null;
				}
			}
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Tests <see cref="IAdd{TElement, TResult}.Add(TElement)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="values">The values to add to the <paramref name="subject"/>.</param>
		public static void Test_Element<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, [AllowNull] TElement[] values) where TSubject : IAdd<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			if (values is not null) {
				foreach (TElement item in values) {
					subject = TraitExtensions.Add(subject, item);
					opFailed = subject is null;
				}
			}
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Tests <see cref="IAdd{TElement, TResult}.Add(Memory{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="values">The values to add to the <paramref name="subject"/>.</param>
		public static void Test_Memory<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, [AllowNull] TElement[][] values) where TSubject : IAdd<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			if (values is not null) {
				foreach (TElement[] item in values) {
					subject = TraitExtensions.Add(subject, item.AsMemory());
					opFailed = subject is null;
				}
			}
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Tests <see cref="IAddUnsafe{TElement, TResult}.Add(TElement*, Int32)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="values">The values to add to the <paramref name="subject"/>.</param>
		public static unsafe void Test_Pointer<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, [AllowNull] TElement[][] values) where TElement : unmanaged where TSubject : IAddUnsafe<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			if (values is not null) {
				foreach (TElement[] item in values) {
					fixed (TElement* itm = item) {
						subject = TraitExtensions.Add(subject, itm, item.Length);
						opFailed = subject is null;
					}
				}
			}
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Tests <see cref="IAdd{TElement, TResult}.Add(ReadOnlyMemory{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="values">The values to add to the <paramref name="subject"/>.</param>
		public static void Test_ReadOnlyMemory<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, [AllowNull] TElement[][] values) where TSubject : IAdd<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			if (values is not null) {
				foreach (TElement[] item in values) {
					subject = TraitExtensions.Add(subject, (ReadOnlyMemory<TElement>)item.AsMemory());
					opFailed = subject is null;
				}
			}
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Tests <see cref="IAddSpan{TElement, TResult}.Add(ReadOnlySpan{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="values">The values to add to the <paramref name="subject"/>.</param>
		public static void Test_ReadOnlySpan<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, [AllowNull] TElement[][] values) where TSubject : IAddSpan<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			if (values is not null) {
				foreach (TElement[] item in values) {
					subject = TraitExtensions.Add(subject, (ReadOnlySpan<TElement>)item.AsSpan());
					opFailed = subject is null;
				}
			}
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Tests <see cref="IAddSpan{TElement, TResult}.Add(Span{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="values">The values to add to the <paramref name="subject"/>.</param>
		public static void Test_Span<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, [AllowNull] TElement[][] values) where TSubject : IAddSpan<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			if (values is not null) {
				foreach (TElement[] item in values) {
					subject = TraitExtensions.Add(subject, item.AsSpan());
					opFailed = subject is null;
				}
			}
			Validate(expected, subject, opFailed);
		}

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

		/// <summary>
		/// Validates <see cref="IAdd{TElement, TResult}.Add(Memory{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="values">The values to add to the subject.</param>
		void Add_Memory<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values);

		/// <summary>
		/// Validates <see cref="IAddUnsafe{TElement, TResult}.Add(TElement*, Int32)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="values">The values to add to the subject.</param>
		void Add_Pointer<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values) where TElement : unmanaged;

		/// <summary>
		/// Validates <see cref="IAdd{TElement, TResult}.Add(ReadOnlyMemory{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="values">The values to add to the subject.</param>
		void Add_ReadOnlyMemory<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values);

		/// <summary>
		/// Validates <see cref="IAddSpan{TElement, TResult}.Add(ReadOnlySpan{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="values">The values to add to the subject.</param>
		void Add_ReadOnlySpan<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values);

		/// <summary>
		/// Validates <see cref="IAddSpan{TElement, TResult}.Add(Span{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="values">The values to add to the subject.</param>
		void Add_Span<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values);

		/// <summary>
		/// Validates that the <paramref name="subject"/> contains the <paramref name="expected"/> elements.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		protected static void Validate<TElement>([AllowNull] TElement[] expected, [AllowNull] IEnumerable<TElement> subject) => Validate(expected, subject, false);

		/// <summary>
		/// Validates that the <paramref name="subject"/> contains the <paramref name="expected"/> elements.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="opFailed">Whether the test operations failed.</param>
		protected static void Validate<TElement>([AllowNull] TElement[] expected, [AllowNull] IEnumerable<TElement> subject, Boolean opFailed) {
			if (opFailed) {
				Assert.IsNull(subject);
			} else if (expected is not null) {
				foreach (TElement exp in expected) {
					Assert.Contains(exp, subject);
				}
			} else {
				Assert.IsNull(subject);
			}
		}
	}
}
