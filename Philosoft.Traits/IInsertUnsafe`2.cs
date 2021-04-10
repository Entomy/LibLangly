using System;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the collection can have elements inserted into it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	[CLSCompliant(false)]
	public interface IInsertUnsafe<TElement, out TResult> : IInsert<TElement, TResult> where TElement : unmanaged where TResult : IInsertUnsafe<TElement, TResult> {
		/// <summary>
		/// Inserts the elements into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		unsafe TResult Insert(nint index, [AllowNull] TElement* elements, Int32 length) {
			TResult result = (TResult)this;
			for (Int32 i = 0; i < length; i++) {
				result = ((IInsert<nint, TElement, TResult>)result).Insert(index++, elements[i]);
				if (result is null) {
					goto Result;
				}
			}
		Result:
			return result;
		}
	}
}
