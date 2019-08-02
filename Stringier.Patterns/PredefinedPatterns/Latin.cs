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
		/// Latin Punctuation and Symbols
		/// </summary>
		public static readonly Pattern PunctuationAndSymbols = BasicPunctuationAndSymbols;

		/// <summary>
		/// Non-Breaking Space
		/// </summary>
		/// <see href="https://www.unicode.org/charts/PDF/U0080.pdf"/>
		public static readonly Pattern NonBreakingSpace = "\u00A0";

		/// <summary>
		/// Supplimentary Latin Punctuarion and Symbols
		/// </summary>
		/// /// <see href="https://www.unicode.org/charts/PDF/U0080.pdf"/>
		public static readonly Pattern SupplimentPunctuationAndSymbols = (Pattern)((Char) =>
			(0xA0 <= Char && Char <= 0xBB) ||
			Char == 0xBF ||
			Char == 0xD7 ||
			Char == 0xF7);

		/// <summary>
		/// Supplimentary Latin Vulgar Fractions
		/// </summary>
		/// /// <see href="https://www.unicode.org/charts/PDF/U0080.pdf"/>
		public static readonly Pattern SupplimentVulgarFractions = (Pattern)((Char) =>
			0xBC <= Char && Char <= 0xBE);

		/// <summary>
		/// Lowercase Supplimentary Latin Letter
		/// </summary>
		/// /// <see href="https://www.unicode.org/charts/PDF/U0080.pdf"/>
		public static readonly Pattern SupplimentLowercase = (Pattern)((Char) =>
			(0xE0 <= Char && Char <= 0xF6) ||
			(0xF8 <= Char && Char <= 0xFF));

		/// <summary>
		/// Uppercase Supplimentary Latin Letter
		/// </summary>
		/// /// <see href="https://www.unicode.org/charts/PDF/U0080.pdf"/>
		public static readonly Pattern SupplimentUppercase = (Pattern)((Char) =>
			(0xC0 <= Char && Char <= 0xD6) ||
			(0xD8 <= Char && Char <= 0xDF));

		/// <summary>
		/// Supplimentary Latin Letter
		/// </summary>
		/// <see href="https://www.unicode.org/charts/PDF/U0080.pdf"/>
		public static readonly Pattern SupplimentLetter = SupplimentLowercase | SupplimentUppercase;


		/// <summary>
		/// Latin Spacing Characters
		/// </summary>
		public static readonly Pattern Spacing = Space | NonBreakingSpace;

		/// <summary>
		/// Latin Vulgar Fractions
		/// </summary>
		public static readonly Pattern VulgarFractions = SupplimentVulgarFractions;

		/// <summary>
		/// Latin Lowercase Letter
		/// </summary>
		public static readonly Pattern Lowercase = BasicLowercase | SupplimentLowercase;

		/// <summary>
		/// Latin Uppercase Letter
		/// </summary>
		public static readonly Pattern Uppercase = BasicUppercase | SupplimentUppercase;

		/// <summary>
		/// Latin Letter
		/// </summary>
		public static readonly Pattern Letter = Lowercase | Uppercase;

	}
}
