namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether the specified character has a surrogate code unit.
		/// </summary>
		/// <param name="Char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="Char"/> is either a high surrogate or a low surrogate; otherwise, false.</returns>
		public static Boolean IsSurrogate(this Char Char) => Char.IsSurrogate(Char);
	}
}
