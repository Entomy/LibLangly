using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Langly.Streams.Bases;

namespace Langly.Streams.Buffers {
	/// <summary>
	/// Provides a minimal buffer for <see cref="Stream"/>.
	/// </summary>
	/// <remarks>
	/// This is a <see cref="IReadBuffer"/> which does extremely minimal buffering, and is used in situations where buffering should generally not happen, but has to at certain times like determining the BOM or lack thereof, or peeking.
	/// </remarks>
	internal sealed class MinimalBuffer : IReadBuffer {
		/// <summary>
		/// The actual <see cref="Byte"/> buffer.
		/// </summary>
		private readonly Byte[] Buffer = new Byte[8];

		/// <summary>
		/// Initializes a new <see cref="MinimalBuffer"/> for the specified <paramref name="stream"/>.
		/// </summary>
		/// <param name="stream">The datastream to buffer.</param>
		internal MinimalBuffer(StreamBase stream) => Stream = stream;

		/// <inheritdoc/>
		public nint Capacity => Buffer.Length;

		/// <inheritdoc/>
		public nint Length { get; set; }

		/// <inheritdoc/>
		public nint Position { get; set; }

		/// <inheritdoc/>
		public Boolean Readable => Length > 0;

		/// <inheritdoc/>
		public Boolean Seekable => Length > 0;

		/// <inheritdoc/>
		public StreamBase Stream { get; }

		/// <inheritdoc/>
		public Boolean Writable { get; }

		/// <inheritdoc/>
		public Byte this[nint index] => Buffer[index];

		/// <inheritdoc/>
		public ReadOnlyMemory<Byte> this[Range range] => Buffer[range];
		/// <inheritdoc/>
		public override Boolean Equals([AllowNull] Object obj) {
			switch (obj) {
			case Byte[] array:
				return Equals(array);
			case IReadOnlyList<Byte> list:
				return Equals(list);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals([AllowNull] Byte[] other) {
			if (other is null || Length < other.Length) {
				return false;
			}
			for (Int32 i = 0; i < other.Length; i++) {
				if (Buffer[i] != other[i]) {
					return false;
				}
			}
			return true;
		}

		/// <inheritdoc/>
		public Boolean Equals([AllowNull] IReadOnlyList<Byte> other) {
			if (other is null || Length < other.Count) {
				return false;
			}
			using System.Collections.Generic.IEnumerator<Byte> oth = other.GetEnumerator();
			for (Int32 i = 0; i < other.Count; i++) {
				if (!oth.MoveNext() || Buffer[i] != oth.Current) {
					return false;
				}
			}
			return !oth.MoveNext();
		}

		/// <inheritdoc/>
		public override Int32 GetHashCode() => Buffer.GetHashCode();

		/// <inheritdoc/>
		public void Peek(out Byte element) {
			((IReadBuffer)this).EnsureLoaded(1);
			element = Buffer[0];
		}

		/// <inheritdoc/>
		public void Peek(Span<Byte> elements) {
			((IReadBuffer)this).EnsureLoaded(elements.Length);
			Buffer.AsSpan().Slice(0, elements.Length).CopyTo(elements);
		}

		/// <inheritdoc/>
		public void Read(out Byte element) {
			if (Length == 0) {
				// If there is nothing in the buffer, bypass the buffer and read directly from the datastream.
				Stream.Read(out element);
			} else {
				// Otherwise, read from the buffer.
				element = Buffer[0];
				ShiftLeft();
			}
		}

		/// <inheritdoc/>
		public void Seek(nint offset) => throw new NotImplementedException();

		/// <inheritdoc/>
		public void ShiftLeft() {
			Buffer[0] = Buffer[1];
			Buffer[1] = Buffer[2];
			Buffer[2] = Buffer[3];
			Buffer[3] = Buffer[4];
			Buffer[4] = Buffer[5];
			Buffer[5] = Buffer[6];
			Buffer[6] = Buffer[7];
			Buffer[7] = default;
			Length--;
		}

		/// <inheritdoc/>
		public void ShiftLeft(nint amount) {
			for (nint i = 0; i < amount && Length > 0; i++) {
				ShiftLeft();
			}
		}

		/// <inheritdoc/>
		public void ShiftRight() {
			Buffer[7] = Buffer[6];
			Buffer[6] = Buffer[5];
			Buffer[5] = Buffer[4];
			Buffer[4] = Buffer[3];
			Buffer[3] = Buffer[2];
			Buffer[2] = Buffer[1];
			Buffer[1] = Buffer[0];
			Buffer[0] = default;
			Length++;
		}

		/// <inheritdoc/>
		public void ShiftRight(nint amount) {
			for (nint i = 0; i < amount && Length < Capacity; i++) {
				ShiftRight();
			}
		}

		/// <inheritdoc/>
		ReadOnlyMemory<Byte> IReadOnlySliceable<ReadOnlyMemory<Byte>>.Slice() => Buffer.AsMemory();

		/// <inheritdoc/>
		ReadOnlyMemory<Byte> IReadOnlySliceable<ReadOnlyMemory<Byte>>.Slice(nint start) => Buffer.AsMemory().Slice((Int32)start);

		/// <inheritdoc/>
		ReadOnlyMemory<Byte> IReadOnlySliceable<ReadOnlyMemory<Byte>>.Slice(nint start, nint length) => Buffer.AsMemory().Slice((Int32)start, (Int32)length);

		/// <inheritdoc/>
		public void Store(Byte value) => Buffer[Length++] = value;

		/// <inheritdoc/>
		public override String ToString() => $"{Buffer[0]:X}, {Buffer[1]:X}, {Buffer[2]:X}, {Buffer[3]:X}, {Buffer[4]:X}, {Buffer[5]:X}, {Buffer[6]:X}, {Buffer[7]:X}";

		/// <inheritdoc/>
		public Boolean TryPeek(out Byte element, out Errors error) {
			if (!((IReadBuffer)this).TryEnsureLoaded(1, out error)) {
				element = default;
				return false;
			}
			element = Buffer[0];
			return true;
		}

		/// <inheritdoc/>
		public Boolean TryPeek(Span<Byte> elements, out Errors error) {
			if (!((IReadBuffer)this).TryEnsureLoaded(elements.Length, out error)) {
				return false;
			}
			Buffer.AsSpan().Slice(0, elements.Length).CopyTo(elements);
			return true;
		}

		/// <inheritdoc/>
		public Boolean TryRead(out Byte element, out Errors error) {
			if (Length == 0) {
				// If there is nothing in the buffer, bypass the buffer and read directly from the datastream.
				return Stream.TryRead(out element, out error);
			} else {
				// Otherwise, read from the buffer.
				element = Buffer[0];
				error = Errors.None;
				ShiftLeft();
				return true;
			}
		}

		/// <inheritdoc/>
		public Boolean TrySeek(nint offset, out Errors error) => throw new NotImplementedException();

		/// <inheritdoc/>
		public Boolean TryStore(Byte value, out Errors error) {
			if (Length == Capacity) {
				error = Errors.OverloadedBuffer;
				return false;
			} else {
				Buffer[Length++] = value;
				error = Errors.None;
				return true;
			}
		}
	}
}
