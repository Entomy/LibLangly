namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as a punctuation mark.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="char"/> is a punctuation mark; otherwise, false.</returns>
		public static Boolean IsPunctuation(this Char @char) => Char.IsPunctuation(@char);
	}
}
