namespace System.Traits.Concepts {
	/// <summary>
	/// Indicates the type is usable as a list.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies.</typeparam>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IList<TIndex, TElement> : IReadOnlyList<TIndex, TElement>, IIndex<TIndex, TElement>, IReplace<TElement> { }
}
