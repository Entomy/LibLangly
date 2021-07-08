namespace System.Traits {
	/// <summary>
	/// Indicates the type can be reset to an initial state.
	/// </summary>
	/// <remarks>
	/// This implies the type has state.
	/// </remarks>
	public interface IReset {
		/// <summary>
		/// Resets the object to its initial state.
		/// </summary>
		void Reset();
	}
}
