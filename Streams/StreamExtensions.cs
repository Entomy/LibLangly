using System;
using System.IO;

namespace Stringier.Streams {
	public static class StreamExtensions {
		/// <summary>
		/// Reads the next, maximum of, <paramref name="count"/> characters from the input stream and advances the byte position by the amount read.
		/// </summary>
		/// <param name="stream"></param>
		/// <param name="count">The maximum of the characters to read.</param>
		/// <returns>An <see cref="Array"/> of <see cref="Byte"/> containing the read characters.</returns>
		public static Byte[] Read(this Stream stream, Int32 count) {
			Byte[] buf = new Byte[count];
			Int32 c = stream.Read(buf, 0, count);
			Byte[] res = new Byte[c];
			Array.Copy(buf, 0, res, 0, c);
			return res;
		}
	}
}
