namespace Langly {
	/// <summary>
	/// Indicates the type can have other elements concatenated onto it, with additional textual operations.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IConcatSpan<TElement, out TResult> : IConcat<TElement, TResult>, IPostpendSpan<TElement, TResult>, IPrependSpan<TElement, TResult> where TResult : IConcatSpan<TElement, TResult> { }
}
