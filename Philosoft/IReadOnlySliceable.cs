using System;

namespace Philosoft {
	/// <summary>
	/// Indicates the collection is slicable, read-only.
	/// </summary>
	/// <typeparam name="TSlice">The type of the slice to return</typeparam>
	public interface IReadOnlySliceable<out TSlice> : ICountable {
		/// <summary>
		/// Gets the elements of the specified range.
		/// </summary>
		/// <param name="range">The zero-based ranges of the elements.</param>
		/// <returns>A slice that consists of all the elements of the current collection with the <paramref name="range"/>.</returns>
		TSlice this[Range range] { get; }

		/// <summary>
		/// Forms a slice out of the collection.
		/// </summary>
		/// <returns>A slice that consists of all elements of the current collection.</returns>
		TSlice Slice();

		/// <summary>
		/// Forms a slice out of the collection that begins at a specified index.
		/// </summary>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <returns>A slice that consists of all elements of the current collection from <paramref name="start"/> to the end of the collection.</returns>
		TSlice Slice(nint start);

		/// <summary>
		/// Forms a slice out of the current span starting at a specified index for a specified length.
		/// </summary>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <param name="length">The desired length for the slice.</param>
		/// <returns>A slice that consists of <paramref name="length"/> elements from the current collection starting at <paramref name="start"/>.</returns>
		TSlice Slice(nint start, nint length);
	}
}
