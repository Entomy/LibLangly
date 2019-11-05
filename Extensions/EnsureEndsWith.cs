using System.Text.RegularExpressions;

namespace System {
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
			if (new Regex(required + "$", RegexOptions.None).IsMatch(@string)) {
				return @string;
			}
			else {
				return @string + required;
			}
		}
	}
}
