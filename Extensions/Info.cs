using System;
using System.Globalization;
using Defender;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Gets the <see cref="StringInfo"/> object for this <paramref name="string"/>.
		/// </summary>
		/// <param name="string">The source <see cref="String"/>.</param>
		/// <returns>A <see cref="StringInfo"/> object.</returns>
		public static StringInfo Info(this String @string) {
			Guard.NotNull(@string, nameof(@string));
			return new StringInfo(@string);
		}
	}
}
