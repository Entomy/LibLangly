namespace System.Text.Patterns {
	public static partial class Latin {

		/// <summary>
		/// Non-Breaking Space
		/// </summary>
		/// <see href="https://www.unicode.org/charts/PDF/U0080.pdf"/>
		public static readonly Pattern NonBreakingSpace = new Literal("\u00A0");

		/// <summary>
		/// Supplimentary Latin Letter
		/// </summary>
		/// <see href="https://www.unicode.org/charts/PDF/U0080.pdf"/>
		public static readonly Pattern SupplimentLetter = SupplimentLowercase | SupplimentUppercase;

		/// <summary>
		/// Lowercase Supplimentary Latin Letter
		/// </summary>
		/// /// <see href="https://www.unicode.org/charts/PDF/U0080.pdf"/>
		public static readonly Pattern SupplimentLowercase = new Checker((Char) =>
			(0xE0 <= Char && Char <= 0xF6) ||
			(0xF8 <= Char && Char <= 0xFF));

		/// <summary>
		/// Supplimentary Latin Punctuarion and Symbols
		/// </summary>
		/// /// <see href="https://www.unicode.org/charts/PDF/U0080.pdf"/>
		public static readonly Pattern SupplimentPunctuationAndSymbols = new Checker((Char) =>
			(0xA0 <= Char && Char <= 0xBB) ||
			Char == 0xBF ||
			Char == 0xD7 ||
			Char == 0xF7);

		/// <summary>
		/// Uppercase Supplimentary Latin Letter
		/// </summary>
		/// /// <see href="https://www.unicode.org/charts/PDF/U0080.pdf"/>
		public static readonly Pattern SupplimentUppercase = new Checker((Char) =>
			(0xC0 <= Char && Char <= 0xD6) ||
			(0xD8 <= Char && Char <= 0xDF));

		/// <summary>
		/// Supplimentary Latin Vulgar Fractions
		/// </summary>
		/// /// <see href="https://www.unicode.org/charts/PDF/U0080.pdf"/>
		public static readonly Pattern SupplimentVulgarFractions = new Checker((Char) =>
			0xBC <= Char && Char <= 0xBE);
	}
}
