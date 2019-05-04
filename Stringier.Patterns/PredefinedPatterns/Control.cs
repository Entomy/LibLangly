namespace System.Text.Patterns {
	public static class Control {
		/// <summary>
		/// Any line terminator pattern
		/// </summary>
		/// <remarks>
		/// This checks for the WindowsLineTerminator first, and that's important, as that's the only multicharacter terminator; checking others first could cause two recognized line breaks.
		/// </remarks>
		public static readonly Pattern AnyLineTerminator = WindowsLineTerminator | LineFeed | VerticalTab | FormFeed | CarriageReturn | NextLine | LineSeparator | ParagraphSeparator;

		/// <summary>
		/// C0 Control Characters
		/// </summary>
		/// <see href="https://www.unicode.org/charts/PDF/U0000.pdf"/>
		public static readonly Pattern C0ControlCharacter = new Checker((Char) =>
			(0x00 <= Char && Char <= 0x1F) ||
			Char == 0x7F);

		/// <summary>
		/// C1 Control Characters
		/// </summary>
		/// <see href="https://www.unicode.org/charts/PDF/U0080.pdf"/>
		public static readonly Pattern C1ControlCharacter = new Checker((Char) =>
			0x80 <= Char && Char <= 0xA0);

		public static readonly Literal CarriageReturn = "\u000D";

		/// <summary>
		/// All Control Characters
		/// </summary>
		/// <see href="https://www.unicode.org/charts/PDF/U0080.pdf"/>
		public static readonly Pattern ControlCharacter = C0ControlCharacter | C1ControlCharacter;

		public static readonly Literal FormFeed = "\u000C";

		public static readonly Literal LineFeed = "\u000A";

		public static readonly Literal LineSeparator = "\u2028";

		public static readonly Literal NextLine = "\u0085";

		public static readonly Literal ParagraphSeparator = "\u2029";

		/// <summary>
		/// Line terminator used by UNIX and macOS systems by convention
		/// </summary>
		public static readonly Pattern UnixLineTerminator = LineFeed;

		public static readonly Literal VerticalTab = "\u000B";

		/// <summary>
		/// Line terminator used by Windows systems by convention
		/// </summary>
		public static readonly Pattern WindowsLineTerminator = CarriageReturn & LineFeed;
	}
}
