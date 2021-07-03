namespace System.Traits {
	/// <summary>
	/// Indicates the type can be moved to a next element.
	/// </summary>
	/// <remarks>
	/// This implies the type has state.
	/// </remarks>
	public interface IMoveNext {
		/// <summary>
		/// Advances the enumerator to the next element of the collection.
		/// </summary>
		/// <returns><see langword="true"/> if the enumerator was successfully advanced to the next element; <see langword="false"/> if the enumerator has passed the end of the collection.</returns>
		Boolean MoveNext();
	}
}
