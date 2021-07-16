namespace System.Traits {
	/// <summary>
	/// Indicates the type has an associated enumerator.
	/// </summary>
	/// <typeparam name="TElement">The type of element being enumerated.</typeparam>
	/// <typeparam name="TEnumerator">The type of the enumerator.</typeparam>
	public interface IGetEnumerator<out TElement, out TEnumerator> where TEnumerator : notnull, ICurrent<TElement>, IMoveNext {
		/// <summary>
		/// Returns an enumerator that iterates through the sequence.
		/// </summary>
		/// <returns>An enumerator that can be used to iterate through the collection.</returns>
		TEnumerator GetEnumerator();
	}
}
