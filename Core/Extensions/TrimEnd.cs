using System;
using System.Linq;
using System.Text;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Removes all the trailing occurrences of a set of runes specified in an array from the current string.
		/// </summary>
		/// <param name="source">The current string.</param>
		/// <param name="trimRunes">An array of <see cref="Rune"/> to remove, or <see langword="null"/>.</param>
		/// <returns>
		/// The string that remains after all occurrences of the runes in the <paramref name="trimRunes"/> parameter are removed from the end of the current string. If <paramref name="trimRunes"/> is <see langword="null"/> or an empty array, Unicode white-space runes are removed instead. If no runes can be trimmed from the current instance, the method returns the current instance unchanged.
		/// </returns>
		public static String TrimEnd(this String source, params Rune[] trimRunes) {
			if (trimRunes is null || trimRunes.Length == 0) {
				// There's no point in replicating whitespace removal behavior, so just call the existing one to do that work.
				return source.TrimEnd();
			}
			Rune[] runes = source.EnumerateRunes().ToArray();
			Int32 r = runes.Length - 1;
			foreach (Rune trim in trimRunes) {
				if (runes[r--] != trim) {
					break;
				}
			}
			Rune[] result = new Rune[r];
			Array.Copy(runes, 0, result, 0, r);
			return result.AsString();
		}
	}
}
