using System;
using System.Text;
using Langly.Streams;
using Langly.Streams.Buffers;

namespace Langly {
	internal sealed class UTF32BECodec : UTF32Codec {
		internal UTF32BECodec(IReadBuffer readBuffer, IWriteBuffer writeBuffer) : base(readBuffer, writeBuffer) { }

		/// <inheritdoc/>
		public override Encoding Encoding => Encoding.UTF32BE;

		/// <inheritdoc/>
		public override void Peek(out Rune element) {
			ReadBuffer.EnsureLoaded(4);
			Int32 value = 0;
			value += ReadBuffer[0] << 8;
			value += ReadBuffer[1] << 8;
			value += ReadBuffer[2] << 8;
			value += ReadBuffer[3];
			element = new Rune(value);
		}

		/// <inheritdoc/>
		public override unsafe void Read(out Rune element) {
			Span<Byte> buffer = stackalloc Byte[4];
			ReadBuffer.Read(buffer);
			Int32 value = 0;
			value += buffer[0] << 8;
			value += buffer[1] << 8;
			value += buffer[2] << 8;
			value += buffer[3];
			element = new Rune(value);
		}

		/// <inheritdoc/>
		public override Boolean TryPeek(out Rune element, out Errors error) {
			if (ReadBuffer.TryEnsureLoaded(4, out error)) {
				Int32 value = 0;
				value += ReadBuffer[0] << 8;
				value += ReadBuffer[1] << 8;
				value += ReadBuffer[2] << 8;
				value += ReadBuffer[3];
				element = new Rune(value);
				return true;
			} else {
				element = Rune.ReplacementChar;
				return false;
			}
		}

		/// <inheritdoc/>
		public override unsafe Boolean TryRead(out Rune element, out Errors error) {
			Span<Byte> buffer = stackalloc Byte[4];
			if (ReadBuffer.TryRead(buffer, out error)) {
				Int32 value = 0;
				value += buffer[0] << 8;
				value += buffer[1] << 8;
				value += buffer[2] << 8;
				value += buffer[3];
				element = new Rune(value);
				return true;
			} else {
				element = Rune.ReplacementChar;
				return false;
			}
		}

		/// <inheritdoc/>
		public override Boolean TryWrite(Rune element, out Errors error) {
			Int32 value = element.Value;
			return WriteBuffer.TryWrite((Byte)(value >> 24), out error)
			&& WriteBuffer.TryWrite((Byte)(value >> 16), out error)
			&& WriteBuffer.TryWrite((Byte)(value >> 8), out error)
			&& WriteBuffer.TryWrite((Byte)value, out error);
		}

		/// <inheritdoc/>
		public override void Write(Rune element) {
			Int32 value = element.Value;
			WriteBuffer.Write((Byte)(value >> 24));
			WriteBuffer.Write((Byte)(value >> 16));
			WriteBuffer.Write((Byte)(value >> 8));
			WriteBuffer.Write((Byte)value);
		}
	}
}
