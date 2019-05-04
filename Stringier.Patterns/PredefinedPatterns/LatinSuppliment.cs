namespace System.Text.Patterns {
	public static partial class Latin {

		/// <summary>
		/// Non-Breaking Space
		/// </summary>
		public static readonly Pattern NonBreakingSpace = new Literal("\u00A0");

		/// <summary>
		/// 
		/// </summary>
		public static readonly Pattern SupplimentPunctuationAndSymbols = new Checker((Char) => false);

	}
}
