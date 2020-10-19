namespace Philosoft {
	/// <summary>
	/// Indicates the type can be moved through with a cursor.
	/// </summary>
	/// <remarks>
	/// This is similar to <see cref="IIndexable{TIndex, TElement}"/>, but instead of returning the element at the position, returns a cursor pointing at that position, which can then be arbitrarily moved around.
	/// </remarks>
	public interface ICursable<in TIndex, out TCursor> {
		/// <summary>
		/// Gets a <typeparamref name="TCursor"/> pointing at the specified <paramref name="index"/>.
		/// </summary>
		/// <param name="index">The zero-based index of the element to point to.</param>
		/// <returns>A <typeparamref name="TCursor"/> pointing at the specified <paramref name="index"/>.</returns>
		public TCursor GetCursor(TIndex index);
	}
}
