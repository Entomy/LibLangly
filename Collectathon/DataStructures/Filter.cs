namespace Langly.DataStructures {
	/// <summary>
	/// Declares the type of filter, if any, a collection should use.
	/// </summary>
	public enum Filter {
		/// <summary>
		/// No filtration; operate as-is.
		/// </summary>
		None,

		/// <summary>
		/// Unique filtration; only one of each value allowed.
		/// </summary>
		Unique,
	}
}
