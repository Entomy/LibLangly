using System;
using System.Collections.Generic;
using System.Traits;

namespace Defender.Contracts {
	/// <summary>
	/// Contract for testing <see cref="IAdd{TElement}"/>, <see cref="IAddMemory{TElement}"/>, and <see cref="IAddSpan{TElement}"/>.
	/// </summary>
	public interface IAddContract {
		/// <summary>
		/// Tests behavior of <see cref="IAdd{TElement}.Add(TElement)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements to add.</typeparam>
		/// <param name="initial">The initial elements of the collection.</param>
		/// <param name="element">The element to add.</param>
		/// <param name="expected">The expected values in the collection.</param>
		void Add_Element<TElement>(TElement[] initial, TElement element, TElement[] expected);

		/// <summary>
		/// Tests behavior of <see cref="IAddMemory{TElement}.Add(TElement[])"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements to add.</typeparam>
		/// <param name="initial">The initial elements of the collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <param name="expected">The expected values in the collection.</param>
		void Add_Array<TElement>(TElement[] initial, TElement[] elements, TElement[] expected);

		/// <summary>
		/// Tests behavior of <see cref="IAddMemory{TElement}.Add(ArraySegment{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements to add.</typeparam>
		/// <param name="initial">The initial elements of the collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <param name="expected">The expected values in the collection.</param>
		void Add_Segment<TElement>(TElement[] initial, TElement[] elements, TElement[] expected);

		/// <summary>
		/// Tests behavior of <see cref="IAddMemory{TElement}.Add(Memory{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements to add.</typeparam>
		/// <param name="initial">The initial elements of the collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <param name="expected">The expected values in the collection.</param>
		void Add_Memory<TElement>(TElement[] initial, TElement[] elements, TElement[] expected);

		/// <summary>
		/// Tests behavior of <see cref="IAddMemory{TElement}.Add(ReadOnlyMemory{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements to add.</typeparam>
		/// <param name="initial">The initial elements of the collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <param name="expected">The expected values in the collection.</param>
		void Add_ReadOnlyMemory<TElement>(TElement[] initial, TElement[] elements, TElement[] expected);

		/// <summary>
		/// Tests behavior of <see cref="IAddSpan{TElement}.Add(Span{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements to add.</typeparam>
		/// <param name="initial">The initial elements of the collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <param name="expected">The expected values in the collection.</param>
		void Add_Span<TElement>(TElement[] initial, TElement[] elements, TElement[] expected);

		/// <summary>
		/// Tests behavior of <see cref="IAddSpan{TElement}.Add(ReadOnlySpan{TElement})"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements to add.</typeparam>
		/// <param name="initial">The initial elements of the collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <param name="expected">The expected values in the collection.</param>
		void Add_ReadOnlySpan<TElement>(TElement[] initial, TElement[] elements, TElement[] expected);
	}

	/// <summary>
	/// Represents data used with <see cref="IAddContract"/>.
	/// </summary>
	public sealed class AddContractData {
		/// <summary>
		/// Test data for <see cref="IAddContract.Add_Element{TElement}(TElement[], TElement, TElement[])"/>.
		/// </summary>
		public static IEnumerable<Object?[]> Add_Element() {
			yield return new Object?[] { new Int32[] { }, 1, new Int32[] { 1 } };
			yield return new Object?[] { new Int32[] { 1, 2, 3 }, 4, new Int32[] { 1, 2, 3, 4 } };
			yield return new Object?[] { new String[] { }, "alpha", new String[] { "alpha" } };
			yield return new Object?[] { new String[] { "alpha", "bravo", "charlie" }, "delta", new String[] { "alpha", "bravo", "charlie", "delta" } };
		}

		/// <summary>
		/// Test data for <see cref="IAddContract.Add_Array{TElement}(TElement[], TElement[], TElement[])"/> and others.
		/// </summary>
		public static IEnumerable<Object?[]> Add_Elements() {
			yield return new Object?[] { new Int32[] { 1, 2 }, new Int32[] { }, new Int32[] { 1, 2 } };
			yield return new Object?[] { new String[] { "alpha", "bravo" }, new String[] { "charlie", "delta" }, new String[] { "alpha", "bravo", "charlie", "delta" } };
		}
	}
}
