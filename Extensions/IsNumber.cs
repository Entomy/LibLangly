namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether a Unicode character is categorized as a number.
		/// </summary>
		/// <param name="Char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="Char"/> is a number; otherwise, false.</returns>
		public static Boolean IsNumber(this Char Char) => Char.IsNumber(Char);
	}
}
