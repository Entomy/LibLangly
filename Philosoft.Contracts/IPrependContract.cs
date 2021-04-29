using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits.Contracts {
	/// <summary>
	/// Contract for validating <see cref="IPrepend{TElement, TResult}"/>.
	/// </summary>
	/// <typeparam name="TAssert">The type of the test asserter to use.</typeparam>
	public interface IPrependContract<out TAssert> : IContract<TAssert> where TAssert : IAssert, new() {
		/// <summary>
		/// Standard test cases for <see cref="Prepend_Array{TElement}(TElement[], TElement[], TElement[][])"/>.
		/// </summary>
		/// <returns>The test cases.</returns>
		public static IEnumerable<Object[]> Prepend_Array_Data() {
			yield return new Object[] { null, null, null };
			yield return new Object[] { Array.Empty<Int32>(), Array.Empty<Int32>(), Array.Empty<Int32[]>() };
			yield return new Object[] { new Int32[] { 3, 4, 5, 1, 2 }, Array.Empty<Int32>(), new Int32[][] { new Int32[] { 1, 2 }, new Int32[] { 3, 4, 5 } } };
		}

		/// <summary>
		/// Standard test cases for <see cref="Prepend_Element{TElement}(TElement[], TElement[], TElement[])"/>.
		/// </summary>
		/// <returns>The test cases.</returns>
		public static IEnumerable<Object[]> Prepend_Element_Data() {
			yield return new Object[] { null, null, null };
			yield return new Object[] { Array.Empty<Int32>(), Array.Empty<Int32>(), Array.Empty<Int32>() };
			yield return new Object[] { new Int32[] { 5, 4, 3, 2, 1 }, Array.Empty<Int32>(), new Int32[] { 1, 2, 3, 4, 5 } };
		}

		/// <summary>
		/// Tests <see cref="IPrepend{TElement, TResult}.Prepend(TElement[])"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="values">The values to add to the <paramref name="subject"/>.</param>
		public static void Test_Array<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, [AllowNull] TElement[][] values) where TSubject : IPrepend<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			if (values is not null) {
				foreach (TElement[] item in values) {
					subject = TraitExtensions.Prepend(subject, item);
					opFailed = subject is null;
				}
			}
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Tests <see cref="IPrepend{TElement, TResult}.Prepend(TElement)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="values">The values to add to the <paramref name="subject"/>.</param>
		public static void Test_Element<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, [AllowNull] TElement[] values) where TSubject : IPrepend<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			if (values is not null) {
				foreach (TElement item in values) {
					subject = TraitExtensions.Prepend(subject, item);
					opFailed = subject is null;
				}
			}
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Tests <see cref="IPrepend{TElement, TResult}.Prepend(Memory{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="values">The values to add to the <paramref name="subject"/>.</param>
		public static void Test_Memory<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, [AllowNull] TElement[][] values) where TSubject : IPrepend<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			if (values is not null) {
				foreach (TElement[] item in values) {
					subject = TraitExtensions.Prepend(subject, item.AsMemory());
					opFailed = subject is null;
				}
			}
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Tests <see cref="IPrependUnsafe{TElement, TResult}.Prepend(TElement*, Int32)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="values">The values to add to the <paramref name="subject"/>.</param>
		public static unsafe void Test_Pointer<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, [AllowNull] TElement[][] values) where TElement : unmanaged where TSubject : IPrependUnsafe<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			if (values is not null) {
				foreach (TElement[] item in values) {
					fixed (TElement* itm = item) {
						subject = TraitExtensions.Prepend(subject, itm, item.Length);
						opFailed = subject is null;
					}
				}
			}
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Tests <see cref="IPrepend{TElement, TResult}.Prepend(ReadOnlyMemory{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="values">The values to add to the <paramref name="subject"/>.</param>
		public static void Test_ReadOnlyMemory<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, [AllowNull] TElement[][] values) where TSubject : IPrepend<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			if (values is not null) {
				foreach (TElement[] item in values) {
					subject = TraitExtensions.Prepend(subject, (ReadOnlyMemory<TElement>)item.AsMemory());
					opFailed = subject is null;
				}
			}
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Tests <see cref="IPrependSpan{TElement, TResult}.Prepend(ReadOnlySpan{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="values">The values to add to the <paramref name="subject"/>.</param>
		public static void Test_ReadOnlySpan<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, [AllowNull] TElement[][] values) where TSubject : IPrependSpan<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			if (values is not null) {
				foreach (TElement[] item in values) {
					subject = TraitExtensions.Prepend(subject, (ReadOnlySpan<TElement>)item.AsSpan());
					opFailed = subject is null;
				}
			}
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Tests <see cref="IPrependSpan{TElement, TResult}.Prepend(Span{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="values">The values to add to the <paramref name="subject"/>.</param>
		public static void Test_Span<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, [AllowNull] TElement[][] values) where TSubject : IPrependSpan<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			if (values is not null) {
				foreach (TElement[] item in values) {
					subject = TraitExtensions.Prepend(subject, item.AsSpan());
					opFailed = subject is null;
				}
			}
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Validates <see cref="IPrepend{TElement, TResult}.Prepend(TElement[])"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="values">The values to add to the subject.</param>
		void Prepend_Array<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values);

		/// <summary>
		/// Validates <see cref="IPrepend{TElement, TResult}.Prepend(TElement)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="values">The values to add to the subject.</param>
		void Prepend_Element<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[] values);

		/// <summary>
		/// Validates <see cref="IPrepend{TElement, TResult}.Prepend(Memory{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="values">The values to add to the subject.</param>
		void Prepend_Memory<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values);

		/// <summary>
		/// Validates <see cref="IPrependUnsafe{TElement, TResult}.Prepend(TElement*, Int32)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="values">The values to add to the subject.</param>
		unsafe void Prepend_Pointer<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values);

		/// <summary>
		/// Validates <see cref="IPrepend{TElement, TResult}.Prepend(ReadOnlyMemory{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="values">The values to add to the subject.</param>
		void Prepend_ReadOnlyMemory<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values);

		/// <summary>
		/// Validates <see cref="IPrependSpan{TElement, TResult}.Prepend(ReadOnlySpan{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="values">The values to add to the subject.</param>
		void Prepend_ReadOnlySpan<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values);

		/// <summary>
		/// Validates <see cref="IPrependSpan{TElement, TResult}.Prepend(Span{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="values">The values to add to the subject.</param>
		void Prepend_Span<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values);

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
