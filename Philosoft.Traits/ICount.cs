namespace System.Traits {
	/// <summary>
	/// Indicates the type is countable.
	/// </summary>
	public interface ICount {
		/// <summary>
		/// Gets the number of elements contained in the collection.
		/// </summary>
		Int32 Count { get; }
	}
}
