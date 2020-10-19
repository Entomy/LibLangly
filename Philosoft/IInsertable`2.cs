namespace Philosoft {
	/// <summary>
	/// Indicates the collection can have elements inserted into it.
	/// </summary>
	public interface IInsertable<in TIndex, in TElement> {
		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The object to insert.</param>
		void Insert(TIndex index, TElement element);
	}
}
