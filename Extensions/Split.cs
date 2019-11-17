namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Splits a string into substrings based on the strings in an array.
		/// </summary>
		/// <param name="string">The string to split.</param>
		/// <param name="separator">A string array that delimits the substrings in this string, an empty array that contains no delimiters, or null.</param>
		/// <returns>A string array that delimits the substrings in this string, an empty array that contains no delimiters, or null.</returns>
		public static String[] Split(this String @string, params String[] separator) {
			if (@string is null || separator is null) {
				throw new ArgumentNullException(@string is null ? nameof(@string) : nameof(separator));
			}
			return @string.Split(separator, StringSplitOptions.None);
		}
	}
}
