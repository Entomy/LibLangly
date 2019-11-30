using System;
using System.Text.RegularExpressions;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Ensures the <paramref name="string"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="string">The string to ensure.</param>
		/// <param name="required">The required beginning.</param>
		/// <returns>A string with the ensured beginning.</returns>
		public static String EnsureBeginsWith(this String @string, String required) {
			if (@string is null || required is null) {
				throw new ArgumentNullException(@string is null ? nameof(@string) : nameof(required));
			}
			return new Regex("^" + required, RegexOptions.None).IsMatch(@string) ? @string : required + @string;
		}
	}
}
