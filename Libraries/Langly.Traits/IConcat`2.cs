namespace Langly {
	/// <summary>
	/// Indicates the type can have other elements concated onto it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	/// <remarks>
	/// This is nothing more than a convenience around <see cref="IPostpend{TElement, TResult}"/> and <see cref="IPrepend{TElement, TResult}"/> which will often be used together.
	/// </remarks>
	public interface IConcat<TElement, out TResult> : IPostpend<TElement, TResult>, IPrepend<TElement, TResult> { }
}
