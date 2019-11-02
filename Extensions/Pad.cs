namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Returns a new string that center-aligns the characters in this instance by padding them with spaces on both sides, for a specified total length.
		/// </summary>
		/// <param name="String">The string to pad.</param>
		/// <param name="TotalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
		/// <returns>A new string that is equivalent to this instance, but center-aligned and padded on both sides with as many spaces as needed to create a length of totalWidth. However, if totalWidth is less than the length of this instance, the method returns a reference to the existing instance. If totalWidth is equal to the length of this instance, the method returns a new string that is identical to this instance.</returns>
		public static String Pad(this String String, Int32 TotalWidth) {
			if (String is null) {
				throw new ArgumentNullException(nameof(String));
			}
			Int32 LeftPadWidth = String.Length + ((TotalWidth - String.Length) / 2);
			return String.PadLeft(LeftPadWidth).PadRight(TotalWidth);
		}

		/// <summary>
		/// Returns a new string that center-aligns the characters in this instance by padding them with spaces on both sides, for a specified total length.
		/// </summary>
		/// <param name="String">The string to pad.</param>
		/// <param name="TotalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
		/// <param name="PaddingChar">A Unicode padding character.</param>
		/// <returns>A new string that is equivalent to this instance, but center-aligned and padded on both sides with as many spaces as needed to create a length of totalWidth. However, if totalWidth is less than the length of this instance, the method returns a reference to the existing instance. If totalWidth is equal to the length of this instance, the method returns a new string that is identical to this instance.</returns>
		public static String Pad(this String String, Int32 TotalWidth, Char PaddingChar) {
			if (String is null) {
				throw new ArgumentNullException(nameof(String));
			}
			Int32 LeftPadWidth = String.Length + ((TotalWidth - String.Length) / 2);
			return String.PadLeft(LeftPadWidth, PaddingChar).PadRight(TotalWidth, PaddingChar);
		}
	}
}
