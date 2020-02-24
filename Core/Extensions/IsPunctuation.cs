using System;
using System.Text;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether this <see cref="Char"/> is categorized as a punctuation mark.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="char"/> is a punctuation mark; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsPunctuation(this Char @char) => Char.IsPunctuation(@char);

		/// <summary>
		/// Indicates whether this <see cref="Rune"/> is categorized as a punctuation mark.
		/// </summary>
		/// <param name="rune">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="rune"/> is a punctuation mark; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsPunctuation(this Rune rune) => Rune.IsPunctuation(rune);
	}
}
