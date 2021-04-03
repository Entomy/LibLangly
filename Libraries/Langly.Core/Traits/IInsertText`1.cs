using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the collection can have elements inserted into it, with additional textual operations.
	/// </summary>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IInsertText<out TResult> : IInsert<Char, TResult> where TResult : IInsertText<TResult> {
		/// <summary>
		/// Inserts the elements into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Insert(nint index, [AllowNull] String elements) => elements is not null ? Insert(index, elements.AsMemory()) : (TResult)this;
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Insert<TResult>([AllowNull] this IInsertText<TResult> collection, nint index, [AllowNull] String elements) where TResult : IInsertText<TResult> => collection is not null ? collection.Insert(index, elements) : (TResult)collection;
	}
}
