using System;
using System.Diagnostics.CodeAnalysis;
using Langly.Traits;

namespace Langly.Traits {
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

namespace Langly {
	public static partial class TraitExtensions {
		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <param name="length">The length of the <paramref name="collection"/>.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[CLSCompliant(false)]
		[return: MaybeNull]
		public static unsafe TResult Insert<TElement, TResult>([AllowNull] this IInsertUnsafe<TElement, TResult> collection, nint index, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged where TResult : IInsertUnsafe<TElement, TResult> => collection is not null ? collection.Insert(index, elements, length) : (TResult)collection;
	}
}
