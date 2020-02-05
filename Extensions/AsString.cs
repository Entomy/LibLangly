using System;
using System.Text;
using Defender;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Gets the <see cref="String"/> representation of these <paramref name="runes"/>.
		/// </summary>
		/// <param name="runes">The <see cref="Array"/> of <see cref="Rune"/> to convert.</param>
		/// <returns>A <see cref="String"/> composed of the <paramref name="runes"/>.</returns>
		public static String AsString(this Rune[] runes) {
			Guard.NotNull(runes, nameof(runes));
			return ((ReadOnlySpan<Rune>)runes.AsSpan()).AsString();
		}

		/// <summary>
		/// Gets the <see cref="String"/> representation of these <paramref name="runes"/>.
		/// </summary>
		/// <param name="runes">The <see cref="ReadOnlySpan{T}"/> of <see cref="Rune"/> to convert.</param>
		/// <returns>A <see cref="String"/> composed of the <paramref name="runes"/>.</returns>
		public static String AsString(this ReadOnlySpan<Rune> runes) {
			Char[] chars = new Char[runes.Length * 2];
			Char[] runechars;
			Int32 c = 0;
			foreach (Rune rune in runes) {
				runechars = rune.AsChars();
				Array.Copy(runechars, 0, chars, c, runechars.Length);
				c += runechars.Length;
			}
			return new String(chars, 0, c);
		}
	}
}
