namespace System.Text.Patterns {
	//! Don't change the name of this file, its order is important because we're dealing with static elaboration
	public static partial class Latin {
		/// <summary>
		/// Latin Spacing Characters
		/// </summary>
		public static readonly Pattern Spacing = Space | NonBreakingSpace;

		/// <summary>
		/// Latin Punctuation and Symbols
		/// </summary>
		public static readonly Pattern PunctuationAndSymbols = BasicPunctuationAndSymbols | SupplimentPunctuationAndSymbols;

		/// <summary>
		/// Latin Vulgar Fractions
		/// </summary>
		public static readonly Pattern VulgarFractions = SupplimentVulgarFractions;

		/// <summary>
		/// Latin Lowercase Letter
		/// </summary>
		public static readonly Pattern Lowercase = BasicLowercase | SupplimentLowercase | ExtendedALowercase;

		/// <summary>
		/// Latin Uppercase Letter
		/// </summary>
		public static readonly Pattern Uppercase = BasicUppercase | SupplimentUppercase | ExtendedAUppercase;

		/// <summary>
		/// Latin Letter
		/// </summary>
		public static readonly Pattern Letter = Lowercase | Uppercase;
	}
}
