namespace Philosoft {
	/// <summary>
	/// Indicates the collection can have elements removed from it by index.
	/// </summary>
	/// <typeparam name="TIndex">The type of the index.</typeparam>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IRemovable<in TIndex, TElement> : IRemovable<TElement> {
		/// <summary>
		/// Removes the entry at the specified <paramref name="index"/>.
		/// </summary>
		/// <param name="index">The index at which to remove the entry from the collection.</param>
		void RemoveAt(TIndex index);

		/// <summary>
		/// Removes the entries at the specified <paramref name="indices"/>.
		/// </summary>
		/// <param name="indices">The indices at which to remove the entry from the collection.</param>
		void RemoveAt(params TIndex[] indices) {
			if (indices is null) {
				return;
			}
			foreach (TIndex index in indices) {
				RemoveAt(index);
			}
		}
	}

	public static partial class Extensions {
		/// <summary>
		/// Removes the entry at the specified <paramref name="index"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which to remove the entry from the collection.</param>
		/// <typeparam name="TIndex">The type of the indices of the collection.</typeparam>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		public static void RemoveAt<TIndex, TElement>(this IRemovable<TIndex, TElement> collection, TIndex index) {
			if (collection is null) {
				return;
			}
			collection.RemoveAt(index);
		}

		/// <summary>
		/// Removes the entries at the specified <paramref name="indices"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="indices">The indices at which to remove the entry from the collection.</param>
		/// <typeparam name="TIndex">The type of the indices of the collection.</typeparam>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		public static void RemoveAt<TIndex, TElement>(this IRemovable<TIndex, TElement> collection, params TIndex[] indices) {
			if (collection is null) {
				return;
			}
			collection.RemoveAt(indices);
		}
	}
}
