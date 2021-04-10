using System;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type can have other elements added to it, with additional unsafe operations.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	[CLSCompliant(false)]
	public interface IAddUnsafe<TElement, out TResult> : IAdd<TElement, TResult> where TElement : unmanaged where TResult : IAddUnsafe<TElement, TResult> {
		/// <summary>
		/// Adds the <paramref name="elements"/> to this object.
		/// </summary>
		/// <param name="elements">The pointer to the <typeparamref name="TElement"/> values to add.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TResult"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull]
		unsafe TResult Add([AllowNull] TElement* elements, Int32 length) {
			TResult? result = (TResult)this;
			if (elements != null) {
				for (Int32 i = 0; i < length; i++) {
					if ((result = result!.Add(elements[i])) is null) { return default; }
				}
			}
			return result;
		}
	}
}
