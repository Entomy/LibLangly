namespace System.Traits {
	/// <summary>
	/// Indicates the type can have its elements replaced.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
	public interface IReplace<in TElement> : IReplace<TElement, TElement> { }
}
