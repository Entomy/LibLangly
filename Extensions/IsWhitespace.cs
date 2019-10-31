namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as white space.
		/// </summary>
		/// <param name="Char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="Char"/> is white space; otherwise, false.</returns>
		public static Boolean IsWhiteSpace(this Char Char) => Char.IsWhiteSpace(Char);
	}
}
