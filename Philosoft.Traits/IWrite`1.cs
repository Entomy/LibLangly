namespace System.Traits {
	/// <summary>
	/// Indicates the type can be written to.
	/// </summary>
	/// <typeparam name="TElement">The type of the element to write.</typeparam>
	public interface IWrite<in TElement> {
		/// <summary>
		/// Writes a <paramref name="element"/>.
		/// </summary>
		/// <param name="element">The <typeparamref name="TElement"/> value to write.</param>
		void Write(TElement element);
	}
}
