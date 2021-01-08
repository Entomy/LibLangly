using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can have elements inserted into it.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies.</typeparam>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IInsert<in TIndex, in TElement> {
		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		void Insert([DisallowNull] TIndex index, [AllowNull] TElement element);
	}

	public static partial class CoreExtensions {
		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TIndex">The type of the indicies.</typeparam>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		public static void Insert<TIndex, TElement>([AllowNull] this IInsert<TIndex, TElement> collection, [DisallowNull] TIndex index, [AllowNull] TElement element) {
			if (index is null) {
				throw new IndexOutOfRangeException();
			}
			collection?.Insert(index, element);
		}
	}
}
