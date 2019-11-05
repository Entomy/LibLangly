namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether the specified Char object is a high surrogate.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns>true if the numeric value of the <paramref name="char"/> parameter ranges from U+D800 through U+DBFF; otherwise, false.</returns>
		public static Boolean IsHighSurrogate(this Char @char) => Char.IsHighSurrogate(@char);
	}
}
