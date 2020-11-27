using System;
using Langly.Streams;
using Langly.Streams.Buffers;

namespace Stringier.Encodings {
	internal sealed class UTF16LECodec : UTF16Codec {
		internal UTF16LECodec(IReadBuffer readBuffer, IWriteBuffer writeBuffer) : base(readBuffer, writeBuffer) { }

		/// <inheritdoc/>
		public override Encoding Encoding => Encoding.UTF16LE;

		/// <inheritdoc/>
		public override void Peek(out Char element) {
			ReadBuffer.EnsureLoaded(2);
			ReadBuffer.Peek(out Byte first, out Byte second);
			element = (Char)first;
			element += (Char)(second << 8);
		}

		/// <inheritdoc/>
		public override void Read(out Char element) {
			ReadBuffer.Read(out Byte first, out Byte second);
			element = (Char)first;
			element += (Char)(second << 8);
		}

		/// <inheritdoc/>
		public override Boolean TryPeek(out Char element, out Errors error) {
			if (ReadBuffer.TryEnsureLoaded(2, out error) && ReadBuffer.TryPeek(out Byte first, out Byte second, out error)) {
				element = (Char)first;
				element += (Char)(second << 8);
				return true;
			} else {
				element = default;
				return false;
			}
		}

		/// <inheritdoc/>
		public override Boolean TryRead(out Char element, out Errors error) {
			if (ReadBuffer.TryRead(out Byte first, out Byte second, out error)) {
				element = (Char)first;
				element += (Char)(second << 8);
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
			ReadBuffer.Peek(out Byte first, out Byte second, out Byte third, out Byte fourth);
			high = (Char)first;
			high += (Char)(second << 8);
			low = (Char)third;
			low += (Char)(fourth << 8);
		}

		/// <inheritdoc/>
		protected override Boolean TryPeek(out Char high, out Char low, out Errors error) {
			if (ReadBuffer.TryEnsureLoaded(4, out error) && ReadBuffer.TryPeek(out Byte first, out Byte second, out Byte third, out Byte fourth, out error)) {
				high = (Char)first;
				high += (Char)(second << 8);
				low = (Char)third;
				low += (Char)(fourth << 8);
				return true;
			} else {
				high = default;
				low = default;
				return false;
			}
		}
	}
}
