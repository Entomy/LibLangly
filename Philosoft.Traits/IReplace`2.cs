using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type can have its elements replaced.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IReplace<in TElement, out TResult> : IReplace<TElement, TElement, TResult> where TResult : IReplace<TElement, TResult> { }
}
