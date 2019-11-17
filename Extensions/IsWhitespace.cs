namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as white space.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="char"/> is white space; otherwise, false.</returns>
		public static Boolean IsWhiteSpace(this Char @char) => Char.IsWhiteSpace(@char);
	}
}
