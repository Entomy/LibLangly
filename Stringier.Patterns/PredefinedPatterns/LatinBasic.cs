namespace System.Text.Patterns {
	public static partial class Latin {
		/// <summary>
		/// Latin Character
		/// </summary>
		public static readonly Pattern Character = Lowercase | Uppercase;

		/// <summary>
		/// Latin Digit
		/// </summary>
		/// <see href="https://www.unicode.org/charts/PDF/U0000.pdf"/>
		public static readonly Pattern Digit = new Checker((Char) =>
			0x30 <= Char && Char <= 0x39);

		/// <summary>
		/// Lowercase Latin Character
		/// </summary>
		/// <see href="https://www.unicode.org/charts/PDF/U0000.pdf"/>
		public static readonly Pattern Lowercase = new Checker((Char) =>
			0x61 <= Char && Char <= 0x7A);

		/// <summary>
		/// Latin Punctuation and Symbols
		/// </summary>
		/// <see href="https://www.unicode.org/charts/PDF/U0000.pdf"/>
		public static readonly Pattern PunctuationAndSymbols = new Checker((Char) =>
			(0x20 <= Char && Char <= 0x2F) ||
			(0x3A <= Char && Char <= 0x40) ||
			(0x5B <= Char && Char <= 0x60) ||
			(0x7B <= Char && Char <= 0x7E));

		/// <summary>
		/// Latin Spacing
		/// </summary>
		/// <see href="https://www.unicode.org/charts/PDF/U0000.pdf"/>
		public static readonly Pattern Space = new Literal("\u0020");

		/// <summary>
		/// Uppercase Latin Character
		/// </summary>
		/// <see href="https://www.unicode.org/charts/PDF/U0000.pdf"/>
		public static readonly Pattern Uppercase = new Checker((Char) =>
			0x41 <= Char && Char <= 0x5A);
	}
}
