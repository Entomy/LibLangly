namespace Langly {
	/// <summary>
	/// Indicates the collection can have elements replaced with other elements.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
	public interface IReplaceable<TElement> : IReplaceable<TElement, TElement> {
	}
}
