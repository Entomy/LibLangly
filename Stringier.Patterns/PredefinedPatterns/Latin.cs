namespace System.Text.Patterns {
	public static partial class Latin {
		/// <summary>
		/// Latin Letter
		/// </summary>
		public static readonly Pattern Letter = Lowercase | Uppercase;

		/// <summary>
		/// Latin Lowercase Letter
		/// </summary>
		public static readonly Pattern Lowercase = BasicLowercase | SupplimentLowercase;

		/// <summary>
		/// Latin Punctuation and Symbols
		/// </summary>
		public static readonly Pattern PunctuationAndSymbols = BasicPunctuationAndSymbols;

		/// <summary>
		/// Latin Spacing Characters
		/// </summary>
		public static readonly Pattern Spacing = Space | NonBreakingSpace;

		/// <summary>
		/// Latin Uppercase Letter
		/// </summary>
		public static readonly Pattern Uppercase = BasicUppercase | SupplimentUppercase;

		/// <summary>
		/// Latin Vulgar Fractions
		/// </summary>
		public static readonly Pattern VulgarFractions = SupplimentVulgarFractions;
	}
}
