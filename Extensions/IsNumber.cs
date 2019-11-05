namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether a Unicode character is categorized as a number.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="char"/> is a number; otherwise, false.</returns>
		public static Boolean IsNumber(this Char @char) => Char.IsNumber(@char);
	}
}
