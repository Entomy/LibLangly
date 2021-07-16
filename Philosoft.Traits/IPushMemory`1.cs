namespace System.Traits {
	/// <summary>
	/// Indicates the type can have other elements pushed onto it, with additional array and memory operations.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IPushMemory<TElement> : IPush<TElement> {
		/// <summary>
		/// Pushes the elements onto this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to push.</param>
		void Push(params TElement[]? elements);

		/// <summary>
		/// Pushes the elements onto this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to push.</param>
		void Push(ArraySegment<TElement> elements);

		/// <summary>
		/// Pushes the elements onto this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to push.</param>
		void Push(Memory<TElement> elements);

		/// <summary>
		/// Pushes the elements onto this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to push.</param>
		void Push(ReadOnlyMemory<TElement> elements);
	}
}
