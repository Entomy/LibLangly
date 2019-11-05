namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Returns a new string that center-aligns the characters in this instance by padding them with spaces on both sides, for a specified total length.
		/// </summary>
		/// <param name="string">The string to pad.</param>
		/// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
		/// <returns>A new string that is equivalent to this instance, but center-aligned and padded on both sides with as many spaces as needed to create a length of totalWidth. However, if totalWidth is less than the length of this instance, the method returns a reference to the existing instance. If totalWidth is equal to the length of this instance, the method returns a new string that is identical to this instance.</returns>
		public static String Pad(this String @string, Int32 totalWidth) {
			if (@string is null) {
				throw new ArgumentNullException(nameof(@string));
			}
			Int32 LeftPadWidth = @string.Length + ((totalWidth - @string.Length) / 2);
			return @string.PadLeft(LeftPadWidth).PadRight(totalWidth);
		}

		/// <summary>
		/// Returns a new string that center-aligns the characters in this instance by padding them with spaces on both sides, for a specified total length.
		/// </summary>
		/// <param name="string">The string to pad.</param>
		/// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
		/// <param name="paddingChar">A Unicode padding character.</param>
		/// <returns>A new string that is equivalent to this instance, but center-aligned and padded on both sides with as many spaces as needed to create a length of totalWidth. However, if totalWidth is less than the length of this instance, the method returns a reference to the existing instance. If totalWidth is equal to the length of this instance, the method returns a new string that is identical to this instance.</returns>
		public static String Pad(this String @string, Int32 totalWidth, Char paddingChar) {
			if (@string is null) {
				throw new ArgumentNullException(nameof(@string));
			}
			Int32 LeftPadWidth = @string.Length + ((totalWidth - @string.Length) / 2);
			return @string.PadLeft(LeftPadWidth, paddingChar).PadRight(totalWidth, paddingChar);
		}
	}
}
