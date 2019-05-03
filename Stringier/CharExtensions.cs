using System;
using System.Collections.Generic;
using System.Text;

namespace System {
	public static class CharExtensions {

		/// <summary>
		/// Joins the <paramref name="Chars"/> into a string.
		/// </summary>
		/// <param name="Chars">The <see cref="Char[]"/> to join.</param>
		/// <returns>The joined <see cref="String"/>.</returns>
		public static String Join(this Char[] Chars) => new String(Chars);

		/// <summary>
		/// Joins the <paramref name="Chars"/> with <paramref name="Separator"/> into a string.
		/// </summary>
		/// <param name="Chars">The <see cref="Char[]"/> to join.</param>
		/// <param name="Separator">The <see cref="Char"/> to interleave.</param>
		/// <returns>The joined <see cref="String"/>.</returns>
		public static String Join(this Char[] Chars, Char Separator) {
			Char[] Result = new Char[Chars.Length * 2 - 1];
			for (int i = 0; i < Chars.Length * 2 - 1; i++) {
				if (i % 2 == 0) {
					Result[i] = Chars[i / 2];
				} else {
					Result[i] = Separator;
				}
			}
			return Result.Join();
		}

	}
}
