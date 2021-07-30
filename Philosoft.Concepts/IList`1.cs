namespace System.Traits.Concepts {
	/// <summary>
	/// Indicates the type can be used as a list.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IList<TElement> : IList<Index, TElement>, IReadOnlyList<TElement> { }
}
