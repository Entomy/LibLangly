using System;
using Langly.Streams;
using Langly.Streams.Buffers;

namespace Stringier.Encodings {
	internal sealed class UTF16BECodec : UTF16Codec {
		internal UTF16BECodec(IReadBuffer readBuffer, IWriteBuffer writeBuffer) : base(readBuffer, writeBuffer) { }

		/// <inheritdoc/>
		public override Encoding Encoding => Encoding.UTF16BE;

		/// <inheritdoc/>
		public override void Peek(out Char element) {
			ReadBuffer.EnsureLoaded(2);
			ReadBuffer.Peek(out Byte first, out Byte second);
			element = (Char)(first << 8);
			element += (Char)second;
		}

		/// <inheritdoc/>
		public override void Read(out Char element) {
			ReadBuffer.EnsureLoaded(2);
			ReadBuffer.Read(out Byte first, out Byte second);
			element = (Char)(first << 8);
			element += (Char)second;
		}

		/// <inheritdoc/>
		public override Boolean TryPeek(out Char element, out Errors error) {
			if (ReadBuffer.TryEnsureLoaded(2, out error) && ReadBuffer.TryPeek(out Byte first, out Byte second, out error)) {
				element = (Char)(first << 8);
				element += (Char)second;
				return true;
			} else {
				element = default;
				return false;
			}
		}

		/// <inheritdoc/>
		public override Boolean TryRead(out Char element, out Errors error) {
			if (ReadBuffer.TryRead(out Byte first, out Byte second, out error)) {
				element = (Char)(first << 8);
				element += (Char)second;
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
			ReadBuffer.Peek(out Byte first, out Byte second, out Byte third, out Byte fourth);
			high = (Char)(first << 8);
			high += (Char)second;
			low = (Char)(third << 8);
			low += (Char)fourth;
		}

		/// <inheritdoc/>
		protected override Boolean TryPeek(out Char high, out Char low, out Errors error) {
			if (ReadBuffer.TryEnsureLoaded(4, out error) && ReadBuffer.TryPeek(out Byte first, out Byte second, out Byte third, out Byte fourth, out error)) {
				high = (Char)(first << 8);
				high += (Char)second;
				low = (Char)(third << 8);
				low += (Char)fourth;
				return true;
			} else {
				high = default;
				low = default;
				return false;
			}
		}
	}
}
