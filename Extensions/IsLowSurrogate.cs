namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether the specified Char object is a low surrogate.
		/// </summary>
		/// <param name="Char">The character to evaluate.</param>
		/// <returns>true if the numeric value of the <paramref name="Char"/> parameter ranges from U+DC00 through U+DFFF; otherwise, false.</returns>
		public static Boolean IsLowSurrogate(this Char Char) => Char.IsLowSurrogate(Char);
	}
}
