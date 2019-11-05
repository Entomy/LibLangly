namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as a control character.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="char"/> is a control character; otherwise, false.</returns>
		public static Boolean IsControl(this Char @char) => Char.IsControl(@char);
	}
}