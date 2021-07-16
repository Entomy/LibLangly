namespace System.Traits {
	/// <summary>
	/// Indicates the type can contain elements, and test against those.
	/// </summary>
	/// <typeparam name="TElement">The type of element contained in the collection.</typeparam>
	public interface IContainsOnly<TElement> : IContains<TElement> {
		/// <summary>
		/// Determines whether this collection contains only the specified <paramref name="element"/>.
		/// </summary>
		/// <param name="element">The element to attempt to find.</param>
		/// <returns><see langword="true"/> if the <paramref name="element"/> is the only thing contained in this collection; otherwise <see langword="false"/>.</returns>
		Boolean ContainsOnly(TElement element);

		/// <summary>
		/// Determines whether this collection contains only the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if the <paramref name="elements"/> are the only things contained in this collection; otherwise <see langword="false"/>.</returns>
		Boolean ContainsOnly(params TElement[]? elements);

		/// <summary>
		/// Determines whether this collection contains only elements described by the specified <paramref name="predicate"/>.
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns><see langword="true"/> if elements described by the <paramref name="predicate"/> are the only things contained in this collection; otherwise <see langword="false"/>.</returns>
		Boolean ContainsOnly(Predicate<TElement>? predicate);
	}
}
