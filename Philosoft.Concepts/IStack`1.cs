namespace System.Traits.Concepts {
	/// <summary>
	/// Indicates the type can be used as a stack.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the stack.</typeparam>
	public interface IStack<TElement> : IPeek<TElement>, IPop<TElement>, IPush<TElement> { }
}
