using System;
using System.Text;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Removes all the leading and trailing occurrences of a set of runes specified in an array from the current string.
		/// </summary>
		/// <param name="source">The current string.</param>
		/// <param name="trimRunes">An array of <see cref="Rune"/> to remove, or <see langword="null"/>.</param>
		/// <returns>
		/// The string that remains after all occurrences of the runes in the <paramref name="trimRunes"/> parameter are removed from the start and end of the current string. If <paramref name="trimRunes"/> is <see langword="null"/> or an empty array, Unicode white-space runes are removed instead. If no runes can be trimmed from the current instance, the method returns the current instance unchanged.
		/// </returns>
		public static String Trim(this String source, params Rune[] trimRunes) => source.TrimEnd(trimRunes).TrimStart(trimRunes);
	}
}
