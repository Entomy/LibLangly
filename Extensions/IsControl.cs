namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as a control character.
		/// </summary>
		/// <param name="Char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="Char"/> is a control character; otherwise, false.</returns>
		public static Boolean IsControl(this Char Char) => Char.IsControl(Char);
	}
}