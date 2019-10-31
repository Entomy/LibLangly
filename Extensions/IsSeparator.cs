namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether a Unicode character is categorized as a separator character.
		/// </summary>
		/// <param name="Char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="Char"/> is a separator character; otherwise, false.</returns>
		public static Boolean IsSeparator(this Char Char) => Char.IsSeparator(Char);
	}
}
