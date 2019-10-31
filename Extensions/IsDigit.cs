namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as a decimal digit.
		/// </summary>
		/// <param name="Char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="Char"/> is a decimal digit; otherwise, false.</returns>
		public static Boolean IsDigit(this Char Char) => Char.IsDigit(Char);
	}
}