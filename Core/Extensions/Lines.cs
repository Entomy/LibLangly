using System;
using Defender;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Separate the <paramref name="string"/> into its lines.
		/// </summary>
		/// <param name="string">String to separate.</param>
		/// <returns>Array of lines within the <paramref name="string"/>.</returns>
		public static String[] Lines(this String @string) {
			Guard.NotNull(@string, nameof(@string));
			return @string.Split('\n');
		}

		/// <summary>
		/// Separate the <paramref name="span"/> into its lines.
		/// </summary>
		/// <param name="span">Span to separate.</param>
		/// <returns>Array of lines within the <paramref name="span"/>.</returns>
		public static String[] Lines(this ReadOnlySpan<Char> span) => span.Split('\n');
	}
}
