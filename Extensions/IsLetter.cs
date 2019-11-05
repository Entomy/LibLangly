namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether a Unicode character is categorized as a Unicode letter.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="char"/> is a letter; otherwise, false.</returns>
		public static Boolean IsLetter(this Char @char) => Char.IsLetter(@char);
	}
}
