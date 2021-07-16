namespace System.Traits {
	/// <summary>
	/// Indicates the type can move to a next instance.
	/// </summary>
	/// <remarks>
	/// This would be like the next node in a list.
	/// </remarks>
	public interface INext<out TSelf> {
		/// <summary>
		/// The next node in the collection.
		/// </summary>
		TSelf Next { get; }
	}
}
