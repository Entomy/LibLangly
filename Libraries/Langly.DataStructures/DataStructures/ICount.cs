namespace Langly.DataStructures {
	/// <summary>
	/// Indicates the type is countable.
	/// </summary>
	public interface ICount {
		/// <summary>
		/// Gets the number of elements contained in the collection.
		/// </summary>
		nint Count { get; }
	}
}
