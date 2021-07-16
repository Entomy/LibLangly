namespace System.Traits {
	/// <summary>
	/// Indicates the type can have other elements prepended onto it, with additional span operations.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IPrependSpan<TElement> : IPrependMemory<TElement> {
		/// <summary>
		/// Prepends the elements onto this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to prepend.</param>
		void Prepend(Span<TElement> elements);

		/// <summary>
		/// Prepends the elements onto this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to prepend.</param>
		void Prepend(ReadOnlySpan<TElement> elements);
	}
}
