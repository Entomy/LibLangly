using System;
using Langly.Streams;
using Langly.Streams.Buffers;

namespace Langly {
	internal sealed class UTF16LECodec : UTF16Codec {
		internal UTF16LECodec(IReadBuffer readBuffer, IWriteBuffer writeBuffer) : base(readBuffer, writeBuffer) { }

		/// <inheritdoc/>
		public override Encoding Encoding => Encoding.UTF16LE;

		/// <inheritdoc/>
		public override void Peek(out Char element) {
			ReadBuffer.EnsureLoaded(2);
			element = (Char)ReadBuffer[0];
			element += (Char)(ReadBuffer[1] << 8);
		}

		/// <inheritdoc/>
		public override unsafe void Read(out Char element) {
			Span<Byte> buffer = stackalloc Byte[2];
			ReadBuffer.Read(buffer);
			element = (Char)buffer[0];
			element += (Char)(buffer[1] << 8);
		}

		/// <inheritdoc/>
		public override Boolean TryPeek(out Char element, out Errors error) {
			if (ReadBuffer.TryEnsureLoaded(2, out error)) {
				element = (Char)ReadBuffer[0];
				element += (Char)(ReadBuffer[1] << 8);
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
				element = (Char)buffer[0];
				element += (Char)(buffer[1] << 8);
				return true;
			} else {
				element = default;
				return false;
			}
		}

		/// <inheritdoc/>
		public override Boolean TryWrite(Char element, out Errors error) =>
			WriteBuffer.TryWrite((Byte)element, out error)
			&& WriteBuffer.TryWrite((Byte)(element >> 8), out error);

		/// <inheritdoc/>
		public override void Write(Char element) {
			WriteBuffer.Write((Byte)element);
			WriteBuffer.Write((Byte)(element >> 8));
		}

		/// <inheritdoc/>
		protected override void Peek(out Char high, out Char low) {
			ReadBuffer.EnsureLoaded(4);
			high = (Char)ReadBuffer[0];
			high += (Char)(ReadBuffer[1] << 8);
			low = (Char)ReadBuffer[2];
			low += (Char)(ReadBuffer[3] << 8);
		}

		/// <inheritdoc/>
		protected override Boolean TryPeek(out Char high, out Char low, out Errors error) {
			if (ReadBuffer.TryEnsureLoaded(4, out error)) {
				high = (Char)ReadBuffer[0];
				high += (Char)(ReadBuffer[1] << 8);
				low = (Char)ReadBuffer[2];
				low += (Char)(ReadBuffer[3] << 8);
				return true;
			} else {
				high = default;
				low = default;
				return false;
			}
		}
	}
}
