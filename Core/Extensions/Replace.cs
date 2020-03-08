using System;
using System.Diagnostics.CodeAnalysis;
using Defender;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
		/// </summary>
		/// <param name="string">The source <see cref="String"/>.</param>
		/// <param name="m1">The first mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements  have been performed.</returns>
		public static String Replace(this String @string, (Char seek, Char replace) m1) => @string.Replace(m1.seek, m1.replace);

		/// <summary>
		/// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
		/// </summary>
		/// <param name="string">The source <see cref="String"/>.</param>
		/// <param name="m1">The first mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <param name="m2">The second mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements  have been performed.</returns>
		public static unsafe String Replace(this String @string, (Char seek, Char replace) m1, (Char seek, Char replace) m2) {
			Guard.NotNull(@string, nameof(@string));
			Char* buffer = stackalloc Char[@string.Length];
			Int32 b = 0;
			foreach (Char c in @string) {
				if (c == m1.seek) {
					buffer[b++] = m1.replace;
				} else if (c == m2.seek) {
					buffer[b++] = m2.replace;
				} else {
					buffer[b++] = c;
				}
			}
			return new String(buffer, 0, b);
		}

		/// <summary>
		/// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
		/// </summary>
		/// <param name="string">The source <see cref="String"/>.</param>
		/// <param name="map">A mapping of <see cref="Char"/> to seek and <see cref="Char"/> to replace.</param>
		/// <returns>A string that is equivalent to this instance, except that all replacements described in <paramref name="map"/> have been performed.</returns>
		[SuppressMessage("Minor Code Smell", "S1116:Empty statements should be removed", Justification = "Well then implement better control structures.")]
		[SuppressMessage("Major Code Smell", "S907:\"goto\" statement should not be used", Justification = "Well then implement better control structures.")]
		public static unsafe String Replace(this String @string, params (Char seek, Char replace)[] map) {
			Guard.NotNull(@string, nameof(@string));
			Guard.NotNull(map, nameof(map));
			Guard.GreaterThan(map, nameof(map), 0);
			Char* buffer = stackalloc Char[@string.Length];
			Int32 b = 0;
			foreach (Char c in @string) {
				foreach ((Char seek, Char replace) m in map) {
					if (c == m.seek) {
						buffer[b++] = m.replace;
						goto Next;
					}
				}
				buffer[b++] = c;
			Next:
				;
			}
			return new String(buffer, 0, b);
		}
	}
}
