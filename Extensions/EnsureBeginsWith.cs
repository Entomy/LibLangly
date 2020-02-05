using System;
using Defender;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Ensures the <paramref name="string"/> beings with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="string">The string to ensure.</param>
		/// <param name="required">The required beginning.</param>
		/// <returns>A string with the ensured beginning.</returns>
		public static String EnsureBeginsWith(this String @string, String required) {
			Guard.NotNull(@string, nameof(@string));
			Guard.NotNull(required, nameof(required));
			return @string.Substring(0, required.Length).Equals(required, StringComparison.CurrentCulture) ? @string : required + @string;
		}
	}
}
