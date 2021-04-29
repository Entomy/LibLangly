using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits.Contracts {
	/// <summary>
	/// Contract for validating <see cref="IInsert{TElement, TResult}"/>.
	/// </summary>
	/// <typeparam name="TAssert">The type of the test asserter to use.</typeparam>
	public interface IInsertContract<out TAssert> : IContract<TAssert> where TAssert : IAssert, new() {
		/// <summary>
		/// Standard test cases for <see cref="Insert_Array{TElement}(TElement[], TElement[], Int32, TElement[])"/>.
		/// </summary>
		/// <returns>The test cases.</returns>
		public static IEnumerable<Object[]> Insert_Array_Data() {
			yield return new Object[] { new Int32[] { 0, 0 }, null, 0, new Int32[] { 0, 0 } };
			yield return new Object[] { new Int32[] { 0, 0 }, Array.Empty<Int32>(), 0, new Int32[] { 0, 0 } };
			yield return new Object[] { new Int32[] { 0, 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0, new Int32[] { 0, 0 } };
			yield return new Object[] { new Int32[] { 1, 0, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, new Int32[] { 0, 0 } };
			yield return new Object[] { new Int32[] { 1, 2, 0, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, new Int32[] { 0, 0 } };
			yield return new Object[] { new Int32[] { 1, 2, 3, 0, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 3, new Int32[] { 0, 0 } };
			yield return new Object[] { new Int32[] { 1, 2, 3, 4, 0, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 4, new Int32[] { 0, 0 } };
			yield return new Object[] { new Int32[] { 1, 2, 3, 4, 5, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 5, new Int32[] { 0, 0 } };
		}

		/// <summary>
		/// Standard test cases for <see cref="Insert_Element_Complex{TIndex, TElement}(TElement[], TElement[], TIndex, TElement)"/>.
		/// </summary>
		/// <returns>The test cases.</returns>
		public static IEnumerable<Object[]> Insert_Element_Complex_Data() {
			foreach (Object[] entry in Insert_Element_Simple_Data()) {
				yield return entry;
			}
		}

		/// <summary>
		/// Standard test cases for <see cref="Insert_Element_Simple{TElement}(TElement[], TElement[], Int32, TElement)"/>.
		/// </summary>
		/// <returns>The test cases.</returns>
		public static IEnumerable<Object[]> Insert_Element_Simple_Data() {
			yield return new Object[] { new Int32[] { 0 }, null, 0, 0 };
			yield return new Object[] { new Int32[] { 0 }, Array.Empty<Int32>(), 0, 0 };
			yield return new Object[] { new Int32[] { 0, 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 0, 0 };
			yield return new Object[] { new Int32[] { 1, 0, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 1, 0 };
			yield return new Object[] { new Int32[] { 1, 2, 0, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 2, 0 };
			yield return new Object[] { new Int32[] { 1, 2, 3, 0, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 3, 0 };
			yield return new Object[] { new Int32[] { 1, 2, 3, 4, 0, 5 }, new Int32[] { 1, 2, 3, 4, 5 }, 4, 0 };
			yield return new Object[] { new Int32[] { 1, 2, 3, 4, 5, 0 }, new Int32[] { 1, 2, 3, 4, 5 }, 5, 0 };
		}

		/// <summary>
		/// Tests <see cref="IInsert{TElement, TResult}.Insert(nint, TElement[])"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="index">The index at which to insert the <paramref name="values"/>.</param>
		/// <param name="values">The values to insert into the <paramref name="subject"/>.</param>
		public static void Test_Array<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, Int32 index, [AllowNull] TElement[] values) where TSubject : IInsert<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			subject = TraitExtensions.Insert(subject, index, values);
			opFailed = subject is null;
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Tests <see cref="IInsert{TIndex, TElement, TResult}.Insert(TIndex, TElement)"/>.
		/// </summary>
		/// <typeparam name="TIndex">The type of the indicies of the collection.</typeparam>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="index">The index at which to insert the <paramref name="value"/>.</param>
		/// <param name="value">The value to insert into the <paramref name="subject"/>.</param>
		public static void Test_Element<TIndex, TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, [DisallowNull] TIndex index, [AllowNull] TElement value) where TSubject : IInsert<TIndex, TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			subject = TraitExtensions.Insert(subject, index, value);
			opFailed = subject is null;
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Tests <see cref="IInsert{TIndex, TElement, TResult}.Insert(TIndex, TElement)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="index">The index at which to insert the <paramref name="value"/>.</param>
		/// <param name="value">The value to insert into the <paramref name="subject"/>.</param>
		public static void Test_Element<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, Int32 index, [AllowNull] TElement value) where TSubject : IInsert<nint, TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			subject = TraitExtensions.Insert(subject, index, value);
			opFailed = subject is null;
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Tests <see cref="IInsertUnsafe{TElement, TResult}.Insert(nint, TElement*, Int32)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="index">The index at which to insert the <paramref name="values"/>.</param>
		/// <param name="values">The values to insert into the <paramref name="subject"/>.</param>
		public static unsafe void Test_Pointer<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, Int32 index, [AllowNull] TElement[] values) where TElement : unmanaged where TSubject : IInsertUnsafe<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			fixed (TElement* vals = values) {
				subject = TraitExtensions.Insert(subject, index, vals, values.Length);
			}
			opFailed = subject is null;
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Tests <see cref="IInsert{TElement, TResult}.Insert(nint, Memory{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="index">The index at which to insert the <paramref name="values"/>.</param>
		/// <param name="values">The values to insert into the <paramref name="subject"/>.</param>
		public static void Test_Memory<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, Int32 index, [AllowNull] TElement[] values) where TSubject : IInsert<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			subject = TraitExtensions.Insert(subject, index, values.AsMemory());
			opFailed = subject is null;
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Tests <see cref="IInsert{TElement, TResult}.Insert(nint, ReadOnlyMemory{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="index">The index at which to insert the <paramref name="values"/>.</param>
		/// <param name="values">The values to insert into the <paramref name="subject"/>.</param>
		public static void Test_ReadOnlyMemory<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, Int32 index, [AllowNull] TElement[] values) where TSubject : IInsert<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			subject = TraitExtensions.Insert(subject, index, (ReadOnlyMemory<TElement>)values.AsMemory());
			opFailed = subject is null;
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Tests <see cref="IInsertSpan{TElement, TResult}.Insert(nint, Span{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="index">The index at which to insert the <paramref name="values"/>.</param>
		/// <param name="values">The values to insert into the <paramref name="subject"/>.</param>
		public static void Test_Span<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, Int32 index, [AllowNull] TElement[] values) where TSubject : IInsertSpan<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			subject = TraitExtensions.Insert(subject, index, values.AsSpan());
			opFailed = subject is null;
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Tests <see cref="IInsertSpan{TElement, TResult}.Insert(nint, ReadOnlySpan{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSubject">The type of the <paramref name="subject"/>.</typeparam>
		/// <param name="expected">The expected values the <paramref name="subject"/> contains.</param>
		/// <param name="subject">The object being tested.</param>
		/// <param name="index">The index at which to insert the <paramref name="values"/>.</param>
		/// <param name="values">The values to insert into the <paramref name="subject"/>.</param>
		public static void Test_ReadOnlySpan<TElement, TSubject>([AllowNull] TElement[] expected, [AllowNull] TSubject subject, Int32 index, [AllowNull] TElement[] values) where TSubject : IInsertSpan<TElement, TSubject>, IEnumerable<TElement> {
			Boolean opFailed = false;
			subject = TraitExtensions.Insert(subject, index, (ReadOnlySpan<TElement>)values.AsSpan());
			opFailed = subject is null;
			Validate(expected, subject, opFailed);
		}

		/// <summary>
		/// Validates <see cref="IInsert{TElement, TResult}.Insert(nint, TElement[])"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="index">The index at which to insert the <paramref name="values"/>.</param>
		/// <param name="values">The values to insert into the subject.</param>
		void Insert_Array<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, Int32 index, [AllowNull] TElement[] values);

		/// <summary>
		/// Validates <see cref="IInsert{TIndex, TElement, TResult}.Insert(TIndex, TElement)"/>.
		/// </summary>
		/// <typeparam name="TIndex">The type of the indices of the collection.</typeparam>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="index">The index at which to insert the <paramref name="value"/>.</param>
		/// <param name="value">The value to insert into the subject.</param>
		void Insert_Element_Complex<TIndex, TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [DisallowNull] TIndex index, [AllowNull] TElement value);

		/// <summary>
		/// Validates <see cref="IInsert{TIndex, TElement, TResult}.Insert(TIndex, TElement)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="index">The index at which to insert the <paramref name="value"/>.</param>
		/// <param name="value">The value to insert into the subject.</param>
		void Insert_Element_Simple<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, Int32 index, [AllowNull] TElement value);

		/// <summary>
		/// Validates <see cref="IInsertUnsafe{TElement, TResult}.Insert(nint, TElement*, Int32)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="index">The index at which to insert the <paramref name="values"/>.</param>
		/// <param name="values">The values to insert into the subject.</param>
		void Insert_Pointer<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, Int32 index, [AllowNull] TElement[] values) where TElement : unmanaged;

		/// <summary>
		/// Validates <see cref="IInsert{TElement, TResult}.Insert(nint, Memory{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="index">The index at which to insert the <paramref name="values"/>.</param>
		/// <param name="values">The values to insert into the subject.</param>
		void Insert_Memory<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, Int32 index, [AllowNull] TElement[] values);

		/// <summary>
		/// Validates <see cref="IInsert{TElement, TResult}.Insert(nint, ReadOnlyMemory{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="index">The index at which to insert the <paramref name="values"/>.</param>
		/// <param name="values">The values to insert into the subject.</param>
		void Insert_ReadOnlyMemory<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, Int32 index, [AllowNull] TElement[] values);

		/// <summary>
		/// Validates <see cref="IInsertSpan{TElement, TResult}.Insert(nint, Span{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="index">The index at which to insert the <paramref name="values"/>.</param>
		/// <param name="values">The values to insert into the subject.</param>
		void Insert_Span<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, Int32 index, [AllowNull] TElement[] values);

		/// <summary>
		/// Validates <see cref="IInsertSpan{TElement, TResult}.Insert(nint, ReadOnlySpan{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="expected">The expected values the subject contains.</param>
		/// <param name="initial">The initial values of the subject.</param>
		/// <param name="index">The index at which to insert the <paramref name="values"/>.</param>
		/// <param name="values">The values to insert into the subject.</param>
		void Insert_ReadOnlySpan<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, Int32 index, [AllowNull] TElement[] values);

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
