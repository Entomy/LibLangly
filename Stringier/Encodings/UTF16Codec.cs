using System;
using System.Text;
using Streamy;
using Streamy.Buffers;
using Langly;

namespace Stringier.Encodings {
	internal abstract class UTF16Codec : Codec, IPeekable<Char, Errors>, IWritable<Char, Errors> {
		protected UTF16Codec(IReadBuffer readBuffer, IWriteBuffer writeBuffer) : base(readBuffer, writeBuffer) { }

		/// <inheritdoc/>
		public abstract void Peek(out Char element);

		/// <inheritdoc/>
		public override void Peek(out Rune element) {
			ReadBuffer.EnsureLoaded(2);
			Peek(out Char high);
			switch (UTF16.SequenceLength(high)) {
			case 1:
				element = UTF16.Decode(high);
				break;
			case 2:
				ReadBuffer.EnsureLoaded(2);
				Peek(out _, out Char low);
				element = UTF16.Decode(high, low);
				break;
			default:
				element = Rune.ReplacementChar;
				break;
			}
		}

		/// <inheritdoc/>
		public abstract void Read(out Char element);

		/// <inheritdoc/>
		public override void Read(out Rune element) {
			Read(out Char high);
			switch (UTF16.SequenceLength(high)) {
			case 1:
				element = UTF16.Decode(high);
				break;
			case 2:
				Read(out Char low);
				element = UTF16.Decode(low, high);
				break;
			default:
				element = Rune.ReplacementChar;
				break;
			}
		}

		/// <inheritdoc/>
		public sealed override Boolean TryPeek(out Rune element, out Errors error) {
			if (TryPeek(out Char high, out error)) {
				switch (UTF16.SequenceLength(high)) {
				case 1:
					element = UTF16.Decode(high);
					return true;
				case 2:
					if (TryPeek(out Char _, out Char low, out error)) {
						element = UTF16.Decode(low, high);
						return true;
					}
					error |= Errors.IncompleteSequence;
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
		public abstract Boolean TryPeek(out Char element, out Errors error);

		/// <inheritdoc/>
		public sealed override Boolean TryRead(out Rune element, out Errors error) {
			if (TryRead(out Char high, out error)) {
				switch (UTF16.SequenceLength(high)) {
				case 1:
					element = UTF16.Decode(high);
					return true;
				case 2:
					if (TryRead(out Char low, out error)) {
						element = UTF16.Decode(low, high);
						return true;
					}
					error |= Errors.IncompleteSequence;
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
		public abstract Boolean TryRead(out Char element, out Errors error);

		/// <inheritdoc/>
		public abstract Boolean TryWrite(Char element, out Errors error);

		/// <inheritdoc/>
		public sealed override Boolean TryWrite(Rune element, out Errors error) {
			error = Errors.None;
			foreach (Char @char in UTF16.Encode(element)) {
				if (TryWrite(@char, out error)) {
					return false;
				}
			}
			return true;
		}

		/// <inheritdoc/>
		public abstract void Write(Char element);

		/// <inheritdoc/>
		public override void Write(Rune element) {
			foreach (Char @char in UTF16.Encode(element)) {
				Write(@char);
			}
		}

		protected abstract void Peek(out Char high, out Char low);

		protected abstract Boolean TryPeek(out Char high, out Char low, out Errors error);
	}
}
