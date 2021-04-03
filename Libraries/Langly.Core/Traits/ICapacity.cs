namespace Langly.Traits {
	/// <summary>
	/// Indicates the type has a maximum capacity.
	/// </summary>
	public interface ICapacity {
		/// <summary>
		/// The maximum capacity of the collection.
		/// </summary>
		nint Capacity { get; }
	}
}
