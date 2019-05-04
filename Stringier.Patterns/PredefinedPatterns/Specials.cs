namespace System.Text.Patterns {
	public abstract partial class Pattern : IEquatable<String> {
		/// <summary>
		/// C0 Control Characters
		/// </summary>
		/// <see href="https://www.unicode.org/charts/PDF/U0000.pdf"/>
		public static readonly Pattern C0ControlCharacter = new Checker((Char) => (0x00 <= Char && Char <= 0x1F) || Char == 0x7F);

		/// <summary>
		/// C1 Control Characters
		/// </summary>
		/// <see href="https://www.unicode.org/charts/PDF/U0080.pdf"/>
		public static readonly Pattern C1ControlCharacter = new Checker((Char) => 0x80 <= Char && Char <= 0xA0);

		/// <summary>
		/// All Control Characters
		/// </summary>
		public static readonly Pattern ControlCharacter = C0ControlCharacter | C1ControlCharacter;
	}
}
