using System;
using System.Globalization;
using System.Text;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Trim and replace multiple spaces with a single space
		/// </summary>
		/// <param name="string">String to clean</param>
		/// <returns>Cleaned up string</returns>
		public static String Clean(this String @string) {
			if (@string is null) {
				throw new ArgumentNullException(nameof(@string));
			}
			StringBuilder Result = new StringBuilder();
			Boolean AtSpace = false;
			foreach (Char C in @string) {
				if (Char.GetUnicodeCategory(C) == UnicodeCategory.SpaceSeparator) {
					if (!AtSpace) {
						AtSpace = true;
						_ = Result.Append(' ');
					}
				} else {
					AtSpace = false;
					_ = Result.Append(C);
				}
			}
			return Result.ToString().Trim();
		}

		/// <summary>
		/// Trim and replace multiple <paramref name="Char"/> with a single <paramref name="Char"/>
		/// </summary>
		/// <param name="String">String to clean</param>
		/// <param name="Char"></param>
		/// <returns>Cleaned up string</returns>
		public static String Clean(this String String, Char Char) {
			if (String is null) {
				throw new ArgumentNullException(nameof(String));
			}
			StringBuilder Result = new StringBuilder();
			Boolean AtChar = false;
			foreach (Char C in String) {
				if (C == Char) {
					if (!AtChar) {
						AtChar = true;
						_ = Result.Append(Char);
					}
				} else {
					AtChar = false;
					_ = Result.Append(C);
				}
			}
			return Result.ToString().Trim();
		}
	}
}
