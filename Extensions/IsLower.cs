namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as a lowercase letter.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="char"/> is a lowercase letter; otherwise, false.</returns>
		public static Boolean IsLower(this Char @char) => Char.IsLower(@char);
	}
}
