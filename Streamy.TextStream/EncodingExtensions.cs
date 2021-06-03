using System;

namespace Streamy {
	internal static class EncodingExtensions {
		/// <summary>
		/// Gets the <see cref="Endian"/> of this <see cref="Encoding"/>.
		/// </summary>
		/// <param name="encoding">This <see cref="Encoding"/> value.</param>
		/// <returns>The <see cref="Endian"/> associated with this <see cref="Encoding"/>.</returns>
		/// <remarks>
		/// <see cref="Encoding.UTF8"/> returns whatever the native system endianness is.
		/// </remarks>
		internal static Endian Endianness(this Encoding encoding) {
			switch (encoding) {
			case Encoding.UTF16BE:
			case Encoding.UTF32BE:
				return Endian.Big;
			case Encoding.UTF16LE:
			case Encoding.UTF32LE:
				return Endian.Little;
			case Encoding.UTF8:
				return BitConverter.IsLittleEndian ? Endian.Little : Endian.Big;
			case Encoding.Unknown:
				return Endian.Unknown;
			default:
				throw new NotImplementedException($"Encoding '{encoding}' was not handled. This is an internal error and should be reported as a bug.");
			}
		}
	}
}
