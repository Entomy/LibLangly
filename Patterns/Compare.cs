namespace Stringier.Patterns {
	/// <summary>
	/// The comparison mode to use when parsing.
	/// </summary>
	public enum Compare {
		/// <summary>
		/// No comparison preference (default behavior is <see cref="CaseSensitive"/>).
		/// </summary>
		/// <remarks>
		/// This is intended to specify "I don't care", or default behavior, for <see cref="Source"/>.
		/// </remarks>
		NoPreference = 0x0000_0000,

		/// <summary>
		/// Comparisons should be done with regards to letter casing.
		/// </summary>
		CaseSensitive = 0x2AAA_AAAA,

		/// <summary>
		/// Comparisons should be done without regards to letter casing.
		/// </summary>
		CaseInsensitive = 0x7FFF_FFFF,
	}
}
