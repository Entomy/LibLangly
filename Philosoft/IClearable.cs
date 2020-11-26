namespace Langly {
	/// <summary>
	/// Indicates the collection is clearable.
	/// </summary>
	public interface IClearable {
		/// <summary>
		/// Clears all items from the collection.
		/// </summary>
		void Clear();
	}

	public static partial class Extensions {
		/// <summary>
		/// Clears all items from the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		public static void Clear(this IClearable collection) {
			if (collection is null) {
				return;
			}
			collection.Clear();
		}
	}
}
