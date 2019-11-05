using System;
using System.Globalization;

namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Categorizes a specified Unicode character into a group identified by one of the <see cref="UnicodeCategory"/> values.
		/// </summary>
		/// <param name="char">The Unicode character to categorize.</param>
		/// <returns>A <see cref="UnicodeCategory"/> value that identifies the group that contains <paramref name="char"/>.</returns>
		public static UnicodeCategory GetUnicodeCategory(this Char @char) => Char.GetUnicodeCategory(@char);
	}
}
