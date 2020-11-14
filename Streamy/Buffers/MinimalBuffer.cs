using System;
using System.Diagnostics.CodeAnalysis;
using Streamy.Bases;

namespace Streamy.Buffers {
	/// <summary>
	/// Provides a minimal buffer for <see cref="Stream"/>.
	/// </summary>
	/// <remarks>
	/// This is a <see cref="IReadBuffer"/> which does extremely minimal buffering, and is used in situations where buffering should generally not happen, but has to at certain times like determining the BOM or lack thereof, or peeking.
	/// </remarks>
	internal sealed class MinimalBuffer : IReadBuffer, IEquatable<MinimalBuffer>, IEquatable<Byte[]> {
		/// <summary>
		/// The actual <see cref="Byte"/> buffer.
		/// </summary>
		private readonly Byte[] Buffer = new Byte[4];

		/// <summary>
		/// Initializes a new <see cref="MinimalBuffer"/> for the specified <paramref name="stream"/>.
		/// </summary>
		/// <param name="stream">The datastream to buffer.</param>
		internal MinimalBuffer(StreamBase stream) => Stream = stream;

		/// <inheritdoc/>
		public nint Capacity => 4;

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
		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Byte[] array:
				return Equals(array);
			case MinimalBuffer buffer:
				return Equals(buffer);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals(Byte[] other) {
			if (Length < other.Length) {
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
		public Boolean Equals(MinimalBuffer other) => Equals(other.Buffer);

		/// <inheritdoc/>
		public override Int32 GetHashCode() => Buffer.GetHashCode();

		/// <inheritdoc/>
		public void Peek([MaybeNull] out Byte element) => throw new NotImplementedException();

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
			Buffer[3] = default;
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
		public void Store(Byte value) => Buffer[Length++] = value;

		/// <inheritdoc/>
		public override String ToString() => $"{Buffer[0]}, {Buffer[1]}, {Buffer[2]}, {Buffer[3]}";

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
		public Boolean TrySeek(nint offset, [MaybeNullWhen(true), NotNullWhen(false)] out Errors error) => throw new NotImplementedException();

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
