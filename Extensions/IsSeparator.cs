using System;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether a Unicode character is categorized as a separator character.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="char"/> is a separator character; otherwise, false.</returns>
		public static Boolean IsSeparator(this Char @char) => Char.IsSeparator(@char);
	}
}
