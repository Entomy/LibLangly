namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as a symbol character.
		/// </summary>
		/// <param name="Char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="Char"/> is a symbol character; otherwise, false.</returns>
		public static Boolean IsSymbol(this Char Char) => Char.IsSymbol(Char);
	}
}
