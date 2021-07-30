namespace System.Traits.Concepts {
	/// <summary>
	/// Indicates the type can be used as a read-only list.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IReadOnlyList<TElement> : IReadOnlyList<Index, TElement> { }
}
