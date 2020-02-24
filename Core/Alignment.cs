namespace Stringier {
	/// <summary>
	/// Alignment to use when a <see cref="FormatTable"/> field content is smaller than the field.
	/// </summary>
	public enum Alignment {
		/// <summary>
		/// Use the alignment of the current culture.
		/// </summary>
		Default = 0,

		/// <summary>
		/// Align to the left.
		/// </summary>
		Left,

		/// <summary>
		/// Align to the right.
		/// </summary>
		Right,

		/// <summary>
		/// Align to the center.
		/// </summary>
		Center,
	}
}
