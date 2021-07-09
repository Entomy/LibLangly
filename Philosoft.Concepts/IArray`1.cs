namespace System.Traits.Concepts {
	/// <summary>
	/// Indicates the type can be used as an array.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IArray<TElement> : IArray<Int32, TElement?>, IReadOnlyArray<TElement?>, IShift, ISlice<Memory<TElement?>> {
		/// <summary>
		/// Forms a slice out of the collection.
		/// </summary>
		/// <returns>A slice that consists of all elements of the current collection.</returns>
		new Span<TElement?> Slice();

		/// <summary>
		/// Forms a slice out of the collection that begins at a specified index.
		/// </summary>
		/// <param name="start">The index at which to begin the slice</param>
		/// <returns>A slice that consists of all elements of the current collection from <paramref name="start"/> to the end of the collection.</returns>
		new Span<TElement?> Slice(Int32 start);

		/// <summary>
		/// Forms a slice out of the current span starting at a specified index for a specified length.
		/// </summary>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <param name="length">The desired length for the slice.</param>
		/// <returns>A slice that consists of <paramref name="length"/> elements from the current collection starting at <paramref name="start"/>.</returns>
		new Span<TElement?> Slice(Int32 start, Int32 length);
	}
}
