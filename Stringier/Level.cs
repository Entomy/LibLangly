namespace Langly {
	/// <summary>
	/// The level to use for operations supporting multiple levels.
	/// </summary>
	/// <remarks>
	/// In some cases, an operation like a search, can work at various levels, corresponding to various text element types. For example, working at the <see cref="Char"/> level is operating UTF-16 code unit wise, while working at the <see cref="Glyph"/> level is operating UNICODE grapheme cluster wise. The results of these operations at different levels are likely to be different. Operations which have the same result regardless should not have a <see cref="Level"/> parameter.
	/// </remarks>
	public enum Level {
		/// <summary>
		/// UTF-16 code unit wise
		/// </summary>
		Char,

		/// <summary>
		/// UNICODE scalar value wise
		/// </summary>
		Rune,

		/// <summary>
		/// UNICODE grapheme cluster wise
		/// </summary>
		Glyph,
	}
}
