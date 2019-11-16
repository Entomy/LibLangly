namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as a decimal digit.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="char"/> is a decimal digit; otherwise, false.</returns>
		public static Boolean IsDigit(this Char @char) => Char.IsDigit(@char);
	}
}
