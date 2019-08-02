namespace System.Text.Patterns {
	public static class Control {
		/// <summary>
		/// C0 Control Characters
		/// </summary>
		/// <see href="https://www.unicode.org/charts/PDF/U0000.pdf"/>
		public static readonly Pattern C0ControlCharacter = (Pattern)((Char) =>
			(0x00 <= Char && Char <= 0x1F) ||
			Char == 0x7F);

		/// <summary>
		/// C1 Control Characters
		/// </summary>
		/// <see href="https://www.unicode.org/charts/PDF/U0080.pdf"/>
		public static readonly Pattern C1ControlCharacter = (Pattern)((Char) =>
			0x80 <= Char && Char <= 0xA0);

		/// <summary>
		/// All Control Characters
		/// </summary>
		/// <see href="https://www.unicode.org/charts/PDF/U0080.pdf"/>
		public static readonly Pattern ControlCharacter = C0ControlCharacter | C1ControlCharacter;

		public static readonly Pattern CarriageReturn = "\u000D";

		public static readonly Pattern FormFeed = "\u000C";

		public static readonly Pattern LineFeed = "\u000A";

		public static readonly Pattern LineSeparator = "\u2028";

		public static readonly Pattern NextLine = "\u0085";

		public static readonly Pattern ParagraphSeparator = "\u2029";

		/// <summary>
		/// Line terminator used by UNIX and macOS systems by convention
		/// </summary>
		public static readonly Pattern UnixLineTerminator = LineFeed;

		public static readonly Pattern VerticalTab = "\u000B";

		/// <summary>
		/// Line terminator used by Windows systems by convention
		/// </summary>
		public static readonly Pattern WindowsLineTerminator = CarriageReturn & LineFeed;

		/// <summary>
		/// Any line terminator pattern
		/// </summary>
		/// <remarks>
		/// This checks for the WindowsLineTerminator first, and that's important, as that's the only multicharacter terminator; checking others first could cause two recognized line breaks.
		/// </remarks>
		public static readonly Pattern AnyLineTerminator = WindowsLineTerminator | LineFeed | VerticalTab | FormFeed | CarriageReturn | NextLine | LineSeparator | ParagraphSeparator;

	}
}
