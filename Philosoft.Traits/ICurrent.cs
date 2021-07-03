namespace System.Traits {
	/// <summary>
	/// Indicates the type has a current element.
	/// </summary>
	/// <typeparam name="TElement">The type of the element.</typeparam>
	/// <remarks>
	/// This implies the type has state.
	/// </remarks>
	public interface ICurrent<out TElement> {
		/// <summary>
		/// Gets the element in the collection at the current position of the enumerator.
		/// </summary>
		/// <value>The element in the collection at the current position of the enumerator.</value>
		TElement Current { get; }
	}
}
