using System;
using System.Linq;
using System.Text;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Removes all the leading occurrences of a set of runes specified in an array from the current string.
		/// </summary>
		/// <param name="source">The current string.</param>
		/// <param name="trimRunes">An array of <see cref="Rune"/> to remove, or <see langword="null"/>.</param>
		/// <returns>
		/// The string that remains after all occurrences of the runes in the <paramref name="trimRunes"/> parameter are removed from the start of the current string. If <paramref name="trimRunes"/> is <see langword="null"/> or an empty array, Unicode white-space runes are removed instead. If no runes can be trimmed from the current instance, the method returns the current instance unchanged.
		/// </returns>
		public static String TrimStart(this String source, params Rune[] trimRunes) {
			if (trimRunes is null || trimRunes.Length == 0) {
				// There's no point in replicating whitespace removal behavior, so just call the existing one to do that work.
				return source.TrimEnd();
			}
			Rune[] runes = source.EnumerateRunes().ToArray();
			Int32 r = 0;
			Int32 l = runes.Length - 1;
			foreach (Rune trim in trimRunes) {
				if (runes[r++] == trim) {
					l--;
				} else {
					break;
				}
			}
			Rune[] result = new Rune[l];
			Array.Copy(runes, ++r, result, 0, l);
			return result.AsString();
		}
	}
}
