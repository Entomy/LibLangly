using System;
using Defender;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Ensures the <paramref name="string"/> ends with the <paramref name="required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="string">The string to ensure.</param>
		/// <param name="required">The required ending.</param>
		/// <returns>A string with the ensured ending.</returns>
		public static String EnsureEndsWith(this String @string, String required) {
			Guard.NotNull(@string, nameof(@string));
			Guard.NotNull(required, nameof(required));
			return @string.Substring(@string.Length - required.Length, required.Length).Equals(required, StringComparison.CurrentCulture) ? @string : @string + required;
		}
	}
}
