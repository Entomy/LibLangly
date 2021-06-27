namespace System.Traits.Concepts {
	/// <summary>
	/// Indicates the type is usable as an array.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies.</typeparam>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IArray<TIndex, TElement> : IReadOnlyArray<TIndex, TElement>, IIndex<TIndex, TElement>, IReplace<TElement> { }
}
