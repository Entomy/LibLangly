using Streamy.Buffers;

namespace Stringier.Encodings {
	internal abstract class UTF32Codec : Codec {
		protected UTF32Codec(IReadBuffer readBuffer, IWriteBuffer writeBuffer) : base(readBuffer, writeBuffer) { }
	}
}
