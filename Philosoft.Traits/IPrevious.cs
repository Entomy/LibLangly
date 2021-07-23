namespace System.Traits {
	/// <summary>
	/// Indicates the type can move to a previous instance.
	/// </summary>
	/// <remarks>
	/// This would be like the previous node in a list.
	/// </remarks>
	public interface IPrevious<TSelf> {
		/// <summary>
		/// The next node in the collection.
		/// </summary>
		TSelf Previous { get; set; }
	}
}
