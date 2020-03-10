using System;
using Defender;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Separate the <paramref name="string"/> into its words.
		/// </summary>
		/// <param name="string">String to separate.</param>
		/// <returns>Array of words within the <paramref name="string"/>.</returns>
		public static String[] Words(this String @string) {
			Guard.NotNull(@string, nameof(@string));
			return @string.Clean().Split(' ');
		}
	}
}
