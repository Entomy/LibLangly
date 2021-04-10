namespace System.Traits {
	/// <summary>
	/// Indicates the type can have other elements concatenated onto it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IConcat<TElement, out TResult> : IPostpend<TElement, TResult>, IPrepend<TElement, TResult> where TResult : IConcat<TElement, TResult> { }
}
