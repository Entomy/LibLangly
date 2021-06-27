namespace System.Traits.Concepts {
	/// <summary>
	/// Indicates the type can be used as a read-only array.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies.</typeparam>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IReadOnlyArray<TIndex, TElement> : ICapacity, IContains<TElement>, ICount, IIndexReadOnly<TIndex, TElement> { }
}
