namespace System.Traits {
	/// <summary>
	/// Indicates the type is indexable, read only.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
	/// <remarks>
	/// This is just a convenience for the most common case of <see cref="IIndexReadOnly{TIndex, TElement}"/>: indexed by integer.
	/// </remarks>
	public interface IIndexReadOnly<out TElement> : IIndexReadOnly<nint, TElement> { }
}
