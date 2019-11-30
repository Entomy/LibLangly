using System;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as a symbol character.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="char"/> is a symbol character; otherwise, false.</returns>
		public static Boolean IsSymbol(this Char @char) => Char.IsSymbol(@char);
	}
}
