namespace System.Traits {
	/// <summary>
	/// Indicates the type can be read from.
	/// </summary>
	/// <typeparam name="TElement">The type of the element to read.</typeparam>
	public interface IRead<TElement> {
		/// <summary>
		/// Reads a <typeparamref name="TElement"/>.
		/// </summary>
		/// <param name="element">The <typeparamref name="TElement"/> value that was read.</param>
		void Read(out TElement element);
	}
}
