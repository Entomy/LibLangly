using System;
using Langly.Streams;
using Langly.Streams.Buffers;

namespace Langly {
	internal sealed class UTF16BECodec : UTF16Codec {
		internal UTF16BECodec(IReadBuffer readBuffer, IWriteBuffer writeBuffer) : base(readBuffer, writeBuffer) { }

		/// <inheritdoc/>
		public override Encoding Encoding => Encoding.UTF16BE;

		/// <inheritdoc/>
		public override void Peek(out Char element) {
			ReadBuffer.EnsureLoaded(2);
			element = (Char)(ReadBuffer[0] << 8);
			element += (Char)ReadBuffer[1];
		}

		/// <inheritdoc/>
		public override unsafe void Read(out Char element) {
			Span<Byte> buffer = stackalloc Byte[2];
			ReadBuffer.Read(buffer);
			element = (Char)(buffer[0] << 8);
			element += (Char)buffer[1];
		}

		/// <inheritdoc/>
		public override Boolean TryPeek(out Char element, out Errors error) {
			if (ReadBuffer.TryEnsureLoaded(2, out error)) {
				element = (Char)(ReadBuffer[0] << 8);
				element += (Char)ReadBuffer[1];
				return true;
			} else {
				element = default;
				return false;
			}
		}

		/// <inheritdoc/>
		public override unsafe Boolean TryRead(out Char element, out Errors error) {
			Span<Byte> buffer = stackalloc Byte[2];
			if (ReadBuffer.TryRead(buffer, out error)) {
				element = (Char)(buffer[0] << 8);
				element += (Char)buffer[1];
				return true;
			} else {
				element = default;
				return false;
			}
		}

		/// <inheritdoc/>
		public override Boolean TryWrite(Char element, out Errors error) =>
			WriteBuffer.TryWrite((Byte)(element >> 8), out error)
			&& WriteBuffer.TryWrite((Byte)element, out error);

		/// <inheritdoc/>
		public override void Write(Char element) {
			WriteBuffer.Write((Byte)(element >> 8));
			WriteBuffer.Write((Byte)element);
		}

		/// <inheritdoc/>
		protected override void Peek(out Char high, out Char low) {
			ReadBuffer.EnsureLoaded(4);
			high = (Char)(ReadBuffer[0] << 8);
			high += (Char)ReadBuffer[1];
			low = (Char)(ReadBuffer[2] << 8);
			low += (Char)ReadBuffer[3];
		}

		/// <inheritdoc/>
		protected override Boolean TryPeek(out Char high, out Char low, out Errors error) {
			if (ReadBuffer.TryEnsureLoaded(4, out error)) {
				high = (Char)(ReadBuffer[0] << 8);
				high += (Char)ReadBuffer[1];
				low = (Char)(ReadBuffer[2] << 8);
				low += (Char)ReadBuffer[3];
				return true;
			} else {
				high = default;
				low = default;
				return false;
			}
		}
	}
}
