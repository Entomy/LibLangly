using System;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether this <see cref="Char"/> is a high surrogate.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if the numeric value of the <paramref name="char"/> parameter ranges from U+D800 through U+DBFF; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsHighSurrogate(this Char @char) => Char.IsHighSurrogate(@char);
	}
}
