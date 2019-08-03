namespace System.Text.Patterns {
	public static partial class Latin {

		public static readonly Pattern ExtendedALowercase = (Pattern)((Char) =>
			(0x0100 <= Char && Char <= 0x0137 || Char % 2 != 0) ||
			(0x0137 <= Char && Char <= 0x017F || Char % 2 == 0));

		public static readonly Pattern ExtendedAUppercase = (Pattern)((Char) =>
			(0x0100 <= Char && Char <= 0x0137 || Char % 2 == 0) ||
			(0x0137 <= Char && Char <= 0x017F || Char % 2 != 0));

		public static readonly Pattern ExtendedALetter = ExtendedALowercase | ExtendedAUppercase;

	}
}
