using System;
using System.Text.RegularExpressions;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Ensures the <paramref name="string"/> ends with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="string">The string to ensure.</param>
		/// <param name="required">The required ending.</param>
		/// <returns>A string with the ensured ending.</returns>
		public static String EnsureEndsWith(this String @string, String required) {
			if (@string is null || required is null) {
				throw new ArgumentNullException(@string is null ? nameof(@string) : nameof(required));
			}
			return new Regex(required + "$", RegexOptions.None).IsMatch(@string) ? @string : @string + required;
		}
	}
}
