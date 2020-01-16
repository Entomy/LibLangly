#if !NETSTANDARD1_6 && !NETSTANDARD2_0
using System;
using System.Text;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Get the <see cref="Char"/> representation of this <see cref="Rune"/>.
		/// </summary>
		/// <param name="rune">The <see cref="Rune"/> to convert.</param>
		/// <returns>An <see cref="Array"/> of zero to two <see cref="Char"/> representing this <paramref name="rune"/>. <see cref="Array.Empty{T}"/> signifies an invalid conversion.</returns>
		public static Char[] AsChars(this Rune rune) {
			Char[] chars = new Char[2];
			Span<Char> span = new Span<Char>(chars);
			switch (rune.EncodeToUtf16(span)) {
			case 1:
				return new[] { chars[0] };
			case 2:
				return chars;
			default:
				return Array.Empty<Char>();
			}
		}

		/// <summary>
		/// Gets the <see cref="Char"/> representation of this codepoint.
		/// </summary>
		/// <param name="codepoint">A <see cref="Rune"/> cast to a <see cref="Int32"/>.</param>
		/// <returns>An <see cref="Array"/> of zero to two <see cref="Char"/> representing this <paramref name="codepoint"/>. <see cref="Array.Empty{T}"/> signifies an invalid conversion.</returns>
		public static Char[] AsChars(this Int32 codepoint) => new Rune(codepoint).AsChars();
	}
}
#endif