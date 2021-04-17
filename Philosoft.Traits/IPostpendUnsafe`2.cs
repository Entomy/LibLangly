using System;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type can have other elements postpended onto it, with additional unsafe operations.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IPostpendUnsafe<TElement, out TResult> : IPostpend<TElement, TResult> where TElement : unmanaged where TResult : IPostpendUnsafe<TElement, TResult> {
		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to postpend.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		unsafe TResult Postpend([AllowNull] TElement* elements, Int32 length) {
			TResult? result = (TResult)this;
			for (Int32 i = length - 1; i >= 0; i--) {
				if ((result = result!.Postpend(elements[i])) is null) { return default; }
			}
			return result;
		}
	}
}
