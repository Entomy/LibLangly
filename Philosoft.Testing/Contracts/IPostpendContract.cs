using System.Collections.Generic;

namespace System.Traits.Testing.Contracts {
	/// <summary>
	/// Contract for testing <see cref="IPostpend{TElement}"/>, <see cref="IPostpendMemory{TElement}"/>, and <see cref="IPostpendSpan{TElement}"/>.
	/// </summary>
	public interface IPostpendContract {
		/// <summary>
		/// Tests behavior of <see cref="IPostpend{TElement}.Postpend(TElement)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements to postpend.</typeparam>
		/// <param name="initial">The initial elements of the collection.</param>
		/// <param name="element">The element to postpend.</param>
		/// <param name="expected">The expected values in the collection.</param>
		void Postpend_Element<TElement>(TElement[] initial, TElement element, TElement[] expected);

		/// <summary>
		/// Tests behavior of <see cref="IPostpendMemory{TElement}.Postpend(TElement[])"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements to postpend.</typeparam>
		/// <param name="initial">The initial elements of the collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <param name="expected">The expected values in the collection.</param>
		void Postpend_Array<TElement>(TElement[] initial, TElement[] elements, TElement[] expected);

		/// <summary>
		/// Tests behavior of <see cref="IPostpendMemory{TElement}.Postpend(ArraySegment{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements to postpend.</typeparam>
		/// <param name="initial">The initial elements of the collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <param name="expected">The expected values in the collection.</param>
		void Postpend_Segment<TElement>(TElement[] initial, TElement[] elements, TElement[] expected);

		/// <summary>
		/// Tests behavior of <see cref="IPostpendMemory{TElement}.Postpend(Memory{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements to postpend.</typeparam>
		/// <param name="initial">The initial elements of the collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <param name="expected">The expected values in the collection.</param>
		void Postpend_Memory<TElement>(TElement[] initial, TElement[] elements, TElement[] expected);

		/// <summary>
		/// Tests behavior of <see cref="IPostpendMemory{TElement}.Postpend(ReadOnlyMemory{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements to postpend.</typeparam>
		/// <param name="initial">The initial elements of the collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <param name="expected">The expected values in the collection.</param>
		void Postpend_ReadOnlyMemory<TElement>(TElement[] initial, TElement[] elements, TElement[] expected);

		/// <summary>
		/// Tests behavior of <see cref="IPostpendSpan{TElement}.Postpend(Span{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements to postpend.</typeparam>
		/// <param name="initial">The initial elements of the collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <param name="expected">The expected values in the collection.</param>
		void Postpend_Span<TElement>(TElement[] initial, TElement[] elements, TElement[] expected);

		/// <summary>
		/// Tests behavior of <see cref="IPostpendSpan{TElement}.Postpend(ReadOnlySpan{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements to postpend.</typeparam>
		/// <param name="initial">The initial elements of the collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <param name="expected">The expected values in the collection.</param>
		void Postpend_ReadOnlySpan<TElement>(TElement[] initial, TElement[] elements, TElement[] expected);
	}

	/// <summary>
	/// Represents data used with <see cref="IPostpendContract"/>.
	/// </summary>
	public sealed class PostpendContractData {
		/// <summary>
		/// Test data for <see cref="IPostpendContract.Postpend_Element{TElement}(TElement[], TElement, TElement[])"/>.
		/// </summary>
		public static IEnumerable<Object?[]> Postpend_Element() {
			yield return new Object?[] { new Int32[] { }, 1, new Int32[] { 1 } };
			yield return new Object?[] { new Int32[] { 1, 2, 3 }, 4, new Int32[] { 1, 2, 3, 4 } };
			yield return new Object?[] { new String[] { }, "alpha", new String[] { "alpha" } };
			yield return new Object?[] { new String[] { "alpha", "bravo", "charlie" }, "delta", new String[] { "alpha", "bravo", "charlie", "delta" } };
		}

		/// <summary>
		/// Test data for <see cref="IAddContract.Add_Array{TElement}(TElement[], TElement[], TElement[])"/> and others.
		/// </summary>
		public static IEnumerable<Object?[]> Postpend_Elements() {
			yield return new Object?[] { new Int32[] { 1, 2 }, new Int32[] { }, new Int32[] { 1, 2 } };
			yield return new Object?[] { new String[] { "alpha", "bravo" }, new String[] { "charlie", "delta" }, new String[] { "alpha", "bravo", "charlie", "delta" } };
		}
	}
}
