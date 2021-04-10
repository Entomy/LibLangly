namespace System.Traits {
	/// <summary>
	/// Indicates the type is indexable by reference, read only.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
	/// <remarks>
	/// This is just a convenience for the most common case of <see cref="IIndexRefReadOnly{TIndex, TElement}"/>: indexed by integer.
	/// </remarks>
	public interface IIndexRefReadOnly<TElement> : IIndexRefReadOnly<nint, TElement> { }
}
