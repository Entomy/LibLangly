namespace Philosoft {
	/// <summary>
	/// Indicates the collection can have elements added to it by index.
	/// </summary>
	/// <typeparam name="TIndex">The type of the index.</typeparam>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <seealso cref="IAddable{TElement}"/>
	public interface IAddable<TIndex, TElement> {
		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="index">The index of the <paramref name="element"/>.</param>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add(TIndex index, TElement element);

		/// <summary>
		/// Adds the elements into the collection.
		/// </summary>
		/// <param name="members">The index-element pairs to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add(params (TIndex, TElement)[] members) {
			if (members is null) {
				return;
			}
			foreach ((TIndex index, TElement element) in members) {
				Add(index, element);
			}
		}

		/// <summary>
		/// Adds the elements into the collection.
		/// </summary>
		/// <param name="members">The index-element pairs to add to the collection.</param>
		/// <typeparam name="TEnumerator">The type of the enumerator for the <paramref name="members"/>.</typeparam>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add<TEnumerator>(IEnumerable<(TIndex, TElement), TEnumerator> members) where TEnumerator : IEnumerator<(TIndex, TElement)> {
			if (members is null) {
				return;
			}
			foreach ((TIndex index, TElement element) in members) {
				Add(index, element);
			}
		}
	}
}
