using System.Collections.Generic;

namespace System.Traits.Testing.Contracts {
	/// <summary>
	/// Contract for testing <see cref="ISlice{TResult}"/>.
	/// </summary>
	public interface ISliceContract {
		/// <summary>
		/// Tests behavior of <see cref="ISlice{TResult}.Slice()"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in this collection.</typeparam>
		/// <param name="initial">The initial elements of the collection.</param>
		/// <param name="expected">The expected values after the operation.</param>
		void Slice<TElement>(TElement[] initial, TElement[] expected);

		/// <summary>
		/// Tests behavior of <see cref="ISlice{TResult}.Slice(Index)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in this collection.</typeparam>
		/// <param name="initial">The initial elements of the collection.</param>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <param name="expected">The expected values after the operation.</param>
		void Slice_Start<TElement>(TElement[] initial, Index start, TElement[] expected);

		/// <summary>
		/// Tests behavior of <see cref="ISlice{TResult}.Slice(Index, Int32)"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in this collection.</typeparam>
		/// <param name="initial">The initial elements of the collection.</param>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <param name="length">The desired length for the slice.</param>
		/// <param name="expected">The expected values after the operation.</param>
		void Slice_Start_Length<TElement>(TElement[] initial, Index start, Int32 length, TElement[] expected);

		/// <summary>
		/// Tests behavior of <see cref="ISlice{TResult}.this[Range]"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in this collection.</typeparam>
		/// <param name="initial">The initial elements of the collection.</param>
		/// <param name="range">The zero-based range of the elements.</param>
		/// <param name="expected">The expected values after the operation.</param>
		void Slice_Range<TElement>(TElement[] initial, Range range, TElement[] expected);
	}

	/// <summary>
	/// Represents data used with <see cref="ISliceContract"/>.
	/// </summary>
	public static class SliceContractData {
		/// <summary>
		/// Test data for <see cref="ISlice{TResult}.Slice()"/>.
		/// </summary>
		public static IEnumerable<Object?[]> Slice() {
			yield return new Object?[] { new Int32[] { }, new Int32[] { } };
			yield return new Object?[] { new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 1, 2, 3, 4, 5 } };
		}

		/// <summary>
		/// Test data for <see cref="ISlice{TResult}.Slice(Index)"/>.
		/// </summary>
		public static IEnumerable<Object?[]> Slice_Start() {
			yield return new Object?[] { new Int32[] { 1, 2, 3, 4, 5 }, 1, new Int32[] { 2, 3, 4, 5 } };
			yield return new Object?[] { new Int32[] { 1, 2, 3, 4, 5 }, 2, new Int32[] { 3, 4, 5 } };
		}

		/// <summary>
		/// Test data for <see cref="ISlice{TResult}.Slice(Index, Int32)"/>.
		/// </summary>
		public static IEnumerable<Object?[]> Slice_Start_Length() {
			yield return new Object?[] { new Int32[] { 1, 2, 3, 4, 5 }, 1, 2, new Int32[] { 2, 3 } };
			yield return new Object?[] { new Int32[] { 1, 2, 3, 4, 5 }, 2, 2, new Int32[] { 3, 4 } };
			yield return new Object?[] { new Int32[] { 1, 2, 3, 4, 5 }, 1, 4, new Int32[] { 2, 3, 4, 5 } };
		}

		/// <summary>
		/// Test data for <see cref="ISlice{TResult}.this[Range]"/>.
		/// </summary>
		public static IEnumerable<Object?[]> Slice_Range() {
			yield return new Object?[] { new Int32[] { }, 0..0, new Int32[] { } };
			yield return new Object?[] { new Int32[] { 1, 2, 3, 4, 5 }, 0..0, new Int32[] { } };
			yield return new Object?[] { new Int32[] { 1, 2, 3, 4, 5 }, 1..3, new Int32[] { 2, 3 } };
			yield return new Object?[] { new Int32[] { 1, 2, 3, 4, 5 }, 2..4, new Int32[] { 3, 4 } };
			yield return new Object?[] { new Int32[] { 1, 2, 3, 4, 5 }, 1..5, new Int32[] { 2, 3, 4, 5 } };
		}
	}
}
