namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as an uppercase letter.
		/// </summary>
		/// <param name="Char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="Char"/> is an uppercase letter; otherwise, false.</returns>
		public static Boolean IsUpper(this Char Char) => Char.IsUpper(Char);
	}
}
