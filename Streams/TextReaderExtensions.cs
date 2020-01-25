using System;
using System.IO;
using Defender;

namespace Stringier.Streams {
	/// <summary>
	/// Provides extensions to <see cref="TextReader"/>.
	/// </summary>
	public static class TextReaderExtensions {
		/// <summary>
		/// Reads the next, maximum of, <paramref name="count"/> characters from the input stream and advances the character position by the amount read.
		/// </summary>
		/// <param name="reader"></param>
		/// <param name="count">The maximum of the characters to read.</param>
		/// <returns>A <see cref="String"/> containing the read characters.</returns>
		public static String Read(this TextReader reader, Int32 count) {
			Guard.NotNull(reader, nameof(reader));
			Char[] buf = new Char[count];
			Int32 c = reader.Read(buf, 0, count);
			return new String(buf, 0, c);
		}
	}
}
