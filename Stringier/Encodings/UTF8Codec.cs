using System;
using System.Text;
using Langly.Streams;
using Langly.Streams.Buffers;

namespace Stringier.Encodings {
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
			Byte first;
			Byte second;
			Byte third;
			Byte fourth;
			ReadBuffer.EnsureLoaded(1);
			ReadBuffer.Peek(out first);
			switch (UTF8.SequenceLength(first)) {
			case 1:
				element = UTF8.Decode(first);
				break;
			case 2:
				ReadBuffer.EnsureLoaded(2);
				ReadBuffer.Peek(out _, out second);
				element = UTF8.Decode(first, second);
				break;
			case 3:
				ReadBuffer.EnsureLoaded(3);
				ReadBuffer.Peek(out _, out second, out third);
				element = UTF8.Decode(first, second, third);
				break;
			case 4:
				ReadBuffer.EnsureLoaded(4);
				ReadBuffer.Peek(out _, out second, out third, out fourth);
				element = UTF8.Decode(first, second, third, fourth);
				break;
			default:
				element = Rune.ReplacementChar;
				break;
			}
		}

		/// <inheritdoc/>
		public override void Read(out Rune element) {
			Byte first;
			Byte second;
			Byte third;
			Byte fourth;
			ReadBuffer.Read(out first);
			switch (UTF8.SequenceLength(first)) {
			case 1:
				element = UTF8.Decode(first);
				break;
			case 2:
				ReadBuffer.Read(out second);
				element = UTF8.Decode(first, second);
				break;
			case 3:
				ReadBuffer.Read(out second, out third);
				element = UTF8.Decode(first, second, third);
				break;
			case 4:
				ReadBuffer.Read(out second, out third, out fourth);
				element = UTF8.Decode(first, second, third, fourth);
				break;
			default:
				element = Rune.ReplacementChar;
				break;
			}
		}

		/// <inheritdoc/>
		public override Boolean TryPeek(out Rune element, out Errors error) {
			Byte first;
			Byte second;
			Byte third;
			Byte fourth;
			if (ReadBuffer.TryEnsureLoaded(1, out error) && ReadBuffer.TryRead(out first, out error)) {
				switch (UTF8.SequenceLength(first)) {
				case 1:
					element = UTF8.Decode(first);
					return true;
				case 2:
					if (ReadBuffer.TryEnsureLoaded(2, out error) && ReadBuffer.TryRead(out second, out error)) {
						element = UTF8.Decode(first, second);
						return true;
					}
					break;
				case 3:
					if (ReadBuffer.TryEnsureLoaded(3, out error) && ReadBuffer.TryRead(out second, out third, out error)) {
						element = UTF8.Decode(first, second, third);
						return true;
					}
					break;
				case 4:
					if (ReadBuffer.TryEnsureLoaded(4, out error) && ReadBuffer.TryRead(out second, out third, out fourth, out error)) {
						element = UTF8.Decode(first, second, third, fourth);
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
		public override Boolean TryRead(out Rune element, out Errors error) {
			Byte first;
			Byte second;
			Byte third;
			Byte fourth;
			if (ReadBuffer.TryRead(out first, out error)) {
				switch (UTF8.SequenceLength(first)) {
				case 1:
					element = UTF8.Decode(first);
					return true;
				case 2:
					if (ReadBuffer.TryRead(out second, out error)) {
						element = UTF8.Decode(first, second);
						return true;
					}
					break;
				case 3:
					if (ReadBuffer.TryRead(out second, out third, out error)) {
						element = UTF8.Decode(first, second, third);
						return true;
					}
					break;
				case 4:
					if (ReadBuffer.TryRead(out second, out third, out fourth, out error)) {
						element = UTF8.Decode(first, second, third, fourth);
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
