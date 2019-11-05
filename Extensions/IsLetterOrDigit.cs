namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether a Unicode character is categorized as a letter or a decimal digit.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="char"/> is a letter or a decimal digit; otherwise, false.</returns>
		public static Boolean IsLetterOrDigit(this Char @char) => Char.IsLetterOrDigit(@char);
	}
}
