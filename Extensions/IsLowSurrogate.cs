using System;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether the specified Char object is a low surrogate.
		/// </summary>
		/// <param name="char">The character to evaluate.</param>
		/// <returns><see langword="true"/> if the numeric value of the <paramref name="char"/> parameter ranges from U+DC00 through U+DFFF; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsLowSurrogate(this Char @char) => Char.IsLowSurrogate(@char);
	}
}
