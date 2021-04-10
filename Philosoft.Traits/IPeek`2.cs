using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type can have its first element peeked at.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IPeek<TElement, out TResult> : IRead<TElement, TResult> where TResult : IPeek<TElement, TResult> {
		/// <summary>
		/// Peeks at the first element.
		/// </summary>
		/// <param name="element">The <typeparamref name="TElement"/> value that was peeked.</param>
		[return: MaybeNull]
		TResult Peek([MaybeNull] out TElement element);
	}
}
