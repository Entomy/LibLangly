namespace System.Traits {
	/// <summary>
	/// Indicates the type can have its elements replaced.
	/// </summary>
	/// <typeparam name="TSearch">The type of the elements to replace.</typeparam>
	/// <typeparam name="TReplace">The type of the elements to use instead.</typeparam>
	public interface IReplace<in TSearch, in TReplace> {
		/// <summary>
		/// Replaces all instances of <paramref name="search"/> with <paramref name="replace"/>.
		/// </summary>
		/// <param name="search">The element to replace.</param>
		/// <param name="replace">The element to use instead.</param>
		void Replace(TSearch search, TReplace replace);
	}
}
