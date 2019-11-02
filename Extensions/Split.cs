namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Splits a string into substrings based on the strings in an array.
		/// </summary>
		/// <param name="String">The string to split.</param>
		/// <param name="Separator">A string array that delimits the substrings in this string, an empty array that contains no delimiters, or null.</param>
		/// <returns>A string array that delimits the substrings in this string, an empty array that contains no delimiters, or null.</returns>
		public static String[] Split(this String String, params String[] Separator) => String.Split(Separator, StringSplitOptions.None);
	}
}
