using System;
using System.Globalization;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Gets the <see cref="StringInfo"/> object for this <paramref name="string"/>.
		/// </summary>
		/// <param name="string">The source <see cref="String"/>.</param>
		/// <returns>A <see cref="StringInfo"/> object.</returns>
		public static StringInfo Info(this String @string) => new StringInfo(@string);
	}
}
