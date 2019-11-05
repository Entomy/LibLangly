using System.Text.RegularExpressions;

namespace System {
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
			if (new Regex("^" + required, RegexOptions.None).IsMatch(@string)) {
				return @string;
			} else {
				return required + @string;
			}
		}
	}
}
