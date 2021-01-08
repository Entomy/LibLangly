using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can have elements inserted into it.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies.</typeparam>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IInsert<in TIndex, in TElement, out TResult> {
		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		TResult Insert([DisallowNull] TIndex index, [AllowNull] TElement element);
	}

	public static partial class CoreExtensions {
		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TIndex">The type of the indicies.</typeparam>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		public static TResult Insert<TIndex, TElement, TResult>([AllowNull] this IInsert<TIndex, TElement, TResult> collection, [DisallowNull] TIndex index, [AllowNull] TElement element) {
			if (index is null) {
				throw new IndexOutOfRangeException();
			}
			return collection is not null ? collection.Insert(index, element) : (TResult)collection;
		}
	}
}
