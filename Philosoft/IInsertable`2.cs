using System;

namespace Langly {
	/// <summary>
	/// Indicates the collection can have elements inserted into it.
	/// </summary>
	public interface IInsertable<in TIndex, in TElement> {
		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The object to insert.</param>
		void Insert(TIndex index, TElement element);
	}

	public static partial class Extensions {
		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The object to insert.</param>
		/// <typeparam name="TIndex">The type of the <paramref name="index"/>.</typeparam>
		/// <typeparam name="TElement">The type of the <paramref name="element"/>.</typeparam>
		public static void Insert<TIndex, TElement>(this IInsertable<TIndex, TElement> collection, TIndex index, TElement element) where TIndex : IEquatable<TIndex> {
			if (collection is null) {
				return;
			}
			collection.Insert(index, element);
		}
	}
}
