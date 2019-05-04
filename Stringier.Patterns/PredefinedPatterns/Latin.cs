namespace System.Text.Patterns {
	public static partial class Latin {
		/// <summary>
		/// Latin Punctuation and Symbols
		/// </summary>
		public static readonly Pattern PunctuationAndSymbols = BasicPunctuationAndSymbols;

		/// <summary>
		/// Latin Lowercase Letter
		/// </summary>
		public static readonly Pattern Lowercase = BasicLowercase;

		/// <summary>
		/// Latin Uppercase Letter
		/// </summary>
		public static readonly Pattern Uppercase = BasicUppercase;

		/// <summary>
		/// Latin Letter
		/// </summary>
		public static readonly Pattern Letter = Lowercase | Uppercase;

		/// <summary>
		/// Latin Spacing Characters
		/// </summary>
		public static readonly Pattern Spacing = Space | NonBreakingSpace;
	}
}
