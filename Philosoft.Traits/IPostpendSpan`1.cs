namespace System.Traits {
	/// <summary>
	/// Indicates the type can have other elements postpended onto it, with additional span operations.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IPostpendSpan<TElement> : IPostpendMemory<TElement> {
		/// <summary>
		/// Postpends the elements onto this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to postpend.</param>
		void Postpend(Span<TElement> elements);

		/// <summary>
		/// Postpends the elements onto this object, a batch.
		/// </summary>
		/// <param name="elements">The elements to postpend.</param>
		void Postpend(ReadOnlySpan<TElement> elements);
	}
}
