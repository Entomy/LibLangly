namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as an uppercase letter.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="char"/> is an uppercase letter; otherwise, false.</returns>
		public static Boolean IsUpper(this Char @char) => Char.IsUpper(@char);
	}
}
