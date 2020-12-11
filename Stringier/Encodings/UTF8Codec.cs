using System;
using System.Text;
using Langly.Streams;
using Langly.Streams.Buffers;

namespace Langly {
	internal sealed class UTF8Codec : Codec {
		/// <summary>
		/// Initialize a new <see cref="Codec"/>.
		/// </summary>
		/// <param name="readBuffer">The buffer used for reads.</param>
		/// <param name="writeBuffer">The buffer used for writes.</param>
		internal UTF8Codec(IReadBuffer readBuffer, IWriteBuffer writeBuffer) : base(readBuffer, writeBuffer) { }

		/// <inheritdoc/>
		public override Encoding Encoding => Encoding.UTF8;

		/// <inheritdoc/>
		public override void Peek(out Rune element) {
			ReadBuffer.EnsureLoaded(1);
			switch (UTF8.SequenceLength(ReadBuffer[0])) {
			case 1:
				element = UTF8.Decode(ReadBuffer[0]);
				break;
			case 2:
				ReadBuffer.EnsureLoaded(2);
				element = UTF8.Decode(ReadBuffer[0], ReadBuffer[1]);
				break;
			case 3:
				ReadBuffer.EnsureLoaded(3);
				element = UTF8.Decode(ReadBuffer[0], ReadBuffer[1], ReadBuffer[2]);
				break;
			case 4:
				ReadBuffer.EnsureLoaded(4);
				element = UTF8.Decode(ReadBuffer[0], ReadBuffer[1], ReadBuffer[2], ReadBuffer[3]);
				break;
			default:
				element = Rune.ReplacementChar;
				break;
			}
		}

		/// <inheritdoc/>
		public override unsafe void Read(out Rune element) {
			Span<Byte> buffer = stackalloc Byte[4];
			ReadBuffer.Read(out buffer[0]);
			switch (UTF8.SequenceLength(buffer[0])) {
			case 1:
				element = UTF8.Decode(buffer[0]);
				break;
			case 2:
				ReadBuffer.Read(out buffer[1]);
				element = UTF8.Decode(buffer[0], buffer[1]);
				break;
			case 3:
				ReadBuffer.Read(buffer[1..2]);
				element = UTF8.Decode(buffer[0], buffer[1], buffer[2]);
				break;
			case 4:
				ReadBuffer.Read(buffer[1..3]);
				element = UTF8.Decode(buffer[0], buffer[1], buffer[2], buffer[3]);
				break;
			default:
				element = Rune.ReplacementChar;
				break;
			}
		}

		/// <inheritdoc/>
		public override Boolean TryPeek(out Rune element, out Errors error) {
			if (ReadBuffer.TryEnsureLoaded(1, out error)) {
				switch (UTF8.SequenceLength(ReadBuffer[0])) {
				case 1:
					element = UTF8.Decode(ReadBuffer[0]);
					return true;
				case 2:
					if (ReadBuffer.TryEnsureLoaded(2, out error)) {
						element = UTF8.Decode(ReadBuffer[0], ReadBuffer[1]);
						return true;
					}
					break;
				case 3:
					if (ReadBuffer.TryEnsureLoaded(3, out error)) {
						element = UTF8.Decode(ReadBuffer[0], ReadBuffer[1], ReadBuffer[2]);
						return true;
					}
					break;
				case 4:
					if (ReadBuffer.TryEnsureLoaded(4, out error)) {
						element = UTF8.Decode(ReadBuffer[0], ReadBuffer[1], ReadBuffer[2], ReadBuffer[3]);
						return true;
					}
					break;
				default:
					error |= Errors.Internal;
					break;
				}
			}
			element = Rune.ReplacementChar;
			return false;
		}

		/// <inheritdoc/>
		public override unsafe Boolean TryRead(out Rune element, out Errors error) {
			Span<Byte> buffer = stackalloc Byte[4];
			if (ReadBuffer.TryRead(out buffer[0], out error)) {
				switch (UTF8.SequenceLength(buffer[0])) {
				case 1:
					element = UTF8.Decode(buffer[0]);
					return true;
				case 2:
					if (ReadBuffer.TryRead(out buffer[1], out error)) {
						element = UTF8.Decode(buffer[0], buffer[1]);
						return true;
					}
					break;
				case 3:
					if (ReadBuffer.TryRead(buffer[1..2], out error)) {
						element = UTF8.Decode(buffer[0], buffer[1], buffer[2]);
						return true;
					}
					break;
				case 4:
					if (ReadBuffer.TryRead(buffer[1..3], out error)) {
						element = UTF8.Decode(buffer[0], buffer[1], buffer[2], buffer[3]);
						return true;
					}
					break;
				default:
					error |= Errors.Internal;
					break;
				}
			}
			element = Rune.ReplacementChar;
			return false;
		}

		/// <inheritdoc/>
		public override Boolean TryWrite(Rune element, out Errors error) {
			error = Errors.None;
			foreach (Byte @byte in UTF8.Encode(element)) {
				if (WriteBuffer.TryWrite(@byte, out error)) {
					return false;
				}
			}
			return true;
		}

		/// <inheritdoc/>
		public override void Write(Rune element) {
			foreach (Byte @byte in UTF8.Encode(element)) {
				WriteBuffer.Write(@byte);
			}
		}
	}
}
