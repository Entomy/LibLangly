using System;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether this <see cref="Char"/> has a surrogate code unit.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="char"/> is either a high surrogate or a low surrogate; otherwise, false.</returns>
		public static Boolean IsSurrogate(this Char @char) => Char.IsSurrogate(@char);
	}
}
