using System;
using System.Text;
using Langly.Streams;
using Langly.Streams.Buffers;

namespace Stringier.Encodings {
	internal sealed class UTF32LECodec : UTF32Codec {
		internal UTF32LECodec(IReadBuffer readBuffer, IWriteBuffer writeBuffer) : base(readBuffer, writeBuffer) { }

		/// <inheritdoc/>
		public override Encoding Encoding => Encoding.UTF32LE;

		/// <inheritdoc/>
		public override void Peek(out Rune element) {
			ReadBuffer.EnsureLoaded(4);
			ReadBuffer.Peek(out Byte first, out Byte second, out Byte third, out Byte fourth);
			Int32 value = 0;
			value += fourth << 8;
			value += third << 8;
			value += second << 8;
			value += first;
			element = new Rune(value);
		}

		/// <inheritdoc/>
		public override void Read(out Rune element) {
			ReadBuffer.Read(out Byte first, out Byte second, out Byte third, out Byte fourth);
			Int32 value = 0;
			value += fourth << 8;
			value += third << 8;
			value += second << 8;
			value += first;
			element = new Rune(value);
		}

		/// <inheritdoc/>
		public override Boolean TryPeek(out Rune element, out Errors error) {
			if (ReadBuffer.TryEnsureLoaded(4, out error) && ReadBuffer.TryRead(out Byte first, out Byte second, out Byte third, out Byte fourth, out error)) {
				Int32 value = 0;
				value += fourth << 8;
				value += third << 8;
				value += second << 8;
				value += first;
				element = new Rune(value);
				return true;
			} else {
				element = Rune.ReplacementChar;
				return false;
			}
		}

		/// <inheritdoc/>
		public override Boolean TryRead(out Rune element, out Errors error) {
			if (ReadBuffer.TryRead(out Byte first, out Byte second, out Byte third, out Byte fourth, out error)) {
				Int32 value = 0;
				value += fourth << 8;
				value += third << 8;
				value += second << 8;
				value += first;
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
			return WriteBuffer.TryWrite((Byte)value, out error)
			&& WriteBuffer.TryWrite((Byte)(value >> 8), out error)
			&& WriteBuffer.TryWrite((Byte)(value >> 16), out error)
			&& WriteBuffer.TryWrite((Byte)(value >> 24), out error);
		}

		/// <inheritdoc/>
		public override void Write(Rune element) {
			Int32 value = element.Value;
			WriteBuffer.Write((Byte)value);
			WriteBuffer.Write((Byte)(value >> 8));
			WriteBuffer.Write((Byte)(value >> 16));
			WriteBuffer.Write((Byte)(value >> 24));
		}
	}
}
