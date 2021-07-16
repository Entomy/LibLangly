namespace System.Traits {
	/// <summary>
	/// Indicates the type can have other elements pushed onto it, with additional span operations.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IPushSpan<TElement> : IPushMemory<TElement> {
		/// <summary>
		/// Pushes the elements onto this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to push.</param>
		void Push(Span<TElement> elements);

		/// <summary>
		/// Pushes the elements onto this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to push.</param>
		void Push(ReadOnlySpan<TElement> elements);
	}
}
