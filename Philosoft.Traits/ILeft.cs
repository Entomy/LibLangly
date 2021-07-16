namespace System.Traits {
	/// <summary>
	/// Indicates the type can move to a lefthand instance.
	/// </summary>
	/// <remarks>
	/// This would be like the lefthand child node in a tree.
	/// </remarks>
	public interface ILeft<out TSelf> {
		/// <summary>
		/// The lefthand node in the collection.
		/// </summary>
		TSelf Left { get; }
	}
}
