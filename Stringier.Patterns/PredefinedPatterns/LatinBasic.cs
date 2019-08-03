namespace System.Text.Patterns {
	public static partial class Latin {
		/// <summary>
		/// Latin Digit
		/// </summary>
		/// <see href="https://www.unicode.org/charts/PDF/U0000.pdf"/>
		public static readonly Pattern Digit = (Pattern)((Char) =>
			0x30 <= Char && Char <= 0x39);

		/// <summary>
		/// Basic Latin Punctuation and Symbols
		/// </summary>
		/// <see href="https://www.unicode.org/charts/PDF/U0000.pdf"/>
		public static readonly Pattern BasicPunctuationAndSymbols = (Pattern)((Char) =>
			(0x20 <= Char && Char <= 0x2F) ||
			(0x3A <= Char && Char <= 0x40) ||
			(0x5B <= Char && Char <= 0x60) ||
			(0x7B <= Char && Char <= 0x7E));

		/// <summary>
		/// Latin Spacing
		/// </summary>
		/// <see href="https://www.unicode.org/charts/PDF/U0000.pdf"/>
		public static readonly Pattern Space = "\u0020";

		/// <summary>
		/// Lowercase Basic Latin Letter
		/// </summary>
		/// <see href="https://www.unicode.org/charts/PDF/U0000.pdf"/>
		public static readonly Pattern BasicLowercase = (Pattern)((Char) =>
			0x61 <= Char && Char <= 0x7A);

		/// <summary>
		/// Uppercase Basic Latin Letter
		/// </summary>
		/// <see href="https://www.unicode.org/charts/PDF/U0000.pdf"/>
		public static readonly Pattern BasicUppercase = (Pattern)((Char) =>
			0x41 <= Char && Char <= 0x5A);

		/// <summary>
		/// Basic Latin Letter
		/// </summary>
		/// <see href="https://www.unicode.org/charts/PDF/U0000.pdf"/>
		public static readonly Pattern BasicLetter = BasicLowercase | BasicUppercase;

		/// <summary>
		/// Non-Breaking Space
		/// </summary>
		/// <see href="https://www.unicode.org/charts/PDF/U0080.pdf"/>
		public static readonly Pattern NonBreakingSpace = "\u00A0";
	}
}
