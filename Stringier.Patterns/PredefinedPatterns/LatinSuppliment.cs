namespace System.Text.Patterns {
	public static partial class Latin {
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
	}
}
