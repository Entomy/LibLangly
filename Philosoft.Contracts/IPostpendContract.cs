using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits.Contracts {
	/// <summary>
	/// Contract for validating <see cref="IPostpend{TElement, TResult}"/>.
	/// </summary>
	/// <typeparam name="TAssert">The type of the test asserter to use.</typeparam>
	public interface IPostpendContract<out TAssert> : IContract<TAssert> where TAssert : IAssert, new() {
		/// <summary>
		/// Standard test cases for <see cref="Postpend_Array{TElement}(TElement[], TElement[], TElement[][])"/>.
		/// </summary>
		/// <returns>The test cases.</returns>
		public static IEnumerable<Object[]> Postpend_Array_Data() {
			yield return new Object[] { null, null, null };
			yield return new Object[] { Array.Empty<Int32>(), Array.Empty<Int32>(), Array.Empty<Int32[]>() };
			yield return new Object[] { new Int32[] { 1, 2, 3, 4, 5 }, Array.Empty<Int32>(), new Int32[][] { new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 } } };
		}

		/// <summary>
		/// Standard test cases for <see cref="Postpend_Element{TElement}(TElement[], TElement[], TElement[])"/>.
		/// </summary>
		/// <returns>The test cases.</returns>
		public static IEnumerable<Object[]> Postpend_Element_Data() {
			yield return new Object[] { null, null, null };
			yield return new Object[] { Array.Empty<Int32>(), Array.Empty<Int32>(), Array.Empty<Int32>() };
			yield return new Object[] { new Int32[] { 1, 2, 3, 4, 5 }, Array.Empty<Int32>(), new Int32[] { 1, 2, 3, 4, 5 } };
		}

		/// <summary>
		/// Tests <see cref="IPostpend{TElement, TResult}.Postpend(TElement[])"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="values">The values to add to the <paramref name="subject"/>.</param>
		public static void Test_Array<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, [AllowNull] TElement[][] values) where TSubject : IPostpend<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			if (values is not null) {
				foreach (TElement[] item in values) {
					subject = TraitExtensions.Postpend(subject, item);
					opFailed = subject is null;
				}
			}
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Tests <see cref="IPostpend{TElement, TResult}.Postpend(TElement)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="values">The values to add to the <paramref name="subject"/>.</param>
		public static void Test_Element<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, [AllowNull] TElement[] values) where TSubject : IPostpend<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			if (values is not null) {
				foreach (TElement item in values) {
					subject = TraitExtensions.Postpend(subject, item);
					opFailed = subject is null;
				}
			}
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Tests <see cref="IPostpend{TElement, TResult}.Postpend(Memory{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="values">The values to add to the <paramref name="subject"/>.</param>
		public static void Test_Memory<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, [AllowNull] TElement[][] values) where TSubject : IPostpend<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			if (values is not null) {
				foreach (TElement[] item in values) {
					subject = TraitExtensions.Postpend(subject, item.AsMemory());
					opFailed = subject is null;
				}
			}
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Tests <see cref="IPostpendUnsafe{TElement, TResult}.Postpend(TElement*, Int32)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="values">The values to add to the <paramref name="subject"/>.</param>
		public static unsafe void Test_Pointer<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, [AllowNull] TElement[][] values) where TElement : unmanaged where TSubject : IPostpendUnsafe<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			if (values is not null) {
				foreach (TElement[] item in values) {
					fixed (TElement* itm = item) {
						subject = TraitExtensions.Postpend(subject, itm, item.Length);
						opFailed = subject is null;
					}
				}
			}
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Tests <see cref="IPostpend{TElement, TResult}.Postpend(ReadOnlyMemory{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="values">The values to add to the <paramref name="subject"/>.</param>
		public static void Test_ReadOnlyMemory<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, [AllowNull] TElement[][] values) where TSubject : IPostpend<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			if (values is not null) {
				foreach (TElement[] item in values) {
					subject = TraitExtensions.Postpend(subject, (ReadOnlyMemory<TElement>)item.AsMemory());
					opFailed = subject is null;
				}
			}
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Tests <see cref="IPostpendSpan{TElement, TResult}.Postpend(ReadOnlySpan{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="values">The values to add to the <paramref name="subject"/>.</param>
		public static void Test_ReadOnlySpan<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, [AllowNull] TElement[][] values) where TSubject : IPostpendSpan<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			if (values is not null) {
				foreach (TElement[] item in values) {
					subject = TraitExtensions.Postpend(subject, (ReadOnlySpan<TElement>)item.AsSpan());
					opFailed = subject is null;
				}
			}
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Tests <see cref="IPostpendSpan{TElement, TResult}.Postpend(Span{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="values">The values to add to the <paramref name="subject"/>.</param>
		public static void Test_Span<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, [AllowNull] TElement[][] values) where TSubject : IPostpendSpan<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			if (values is not null) {
				foreach (TElement[] item in values) {
					subject = TraitExtensions.Postpend(subject, item.AsSpan());
					opFailed = subject is null;
				}
			}
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Validates <see cref="IPostpend{TElement, TResult}.Postpend(TElement[])"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="values">The values to add to the subject.</param>
		void Postpend_Array<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values);

		/// <summary>
		/// Validates <see cref="IPostpend{TElement, TResult}.Postpend(TElement)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="values">The values to add to the subject.</param>
		void Postpend_Element<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[] values);

		/// <summary>
		/// Validates <see cref="IPostpend{TElement, TResult}.Postpend(Memory{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="values">The values to add to the subject.</param>
		void Postpend_Memory<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values);

		/// <summary>
		/// Validates <see cref="IPostpendUnsafe{TElement, TResult}.Postpend(TElement*, Int32)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="values">The values to add to the subject.</param>
		unsafe void Postpend_Pointer<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values);

		/// <summary>
		/// Validates <see cref="IPostpend{TElement, TResult}.Postpend(ReadOnlyMemory{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="values">The values to add to the subject.</param>
		void Postpend_ReadOnlyMemory<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values);

		/// <summary>
		/// Validates <see cref="IPostpendSpan{TElement, TResult}.Postpend(ReadOnlySpan{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="values">The values to add to the subject.</param>
		void Postpend_ReadOnlySpan<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values);

		/// <summary>
		/// Validates <see cref="IPostpendSpan{TElement, TResult}.Postpend(Span{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="values">The values to add to the subject.</param>
		void Postpend_Span<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values);

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
				Assert.Equals(expected, subject);
			} else {
				Assert.IsNull(subject);
			}
		}
	}
}
