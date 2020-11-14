using System;
using Streamy.Bases;
using System.Diagnostics.CodeAnalysis;

namespace Streamy.Buffers {
	/// <summary>
	/// Provides a passthrough buffer for <see cref="Stream"/>.
	/// </summary>
	/// <remarks>
	/// This is a <see cref="IWriteBuffer"/> which effectively does not buffer, and is used for situations where buffering should not happen.
	/// </remarks>
	internal sealed class PassthroughBuffer : IWriteBuffer, IEquatable<PassthroughBuffer>, IEquatable<Byte[]> {
		/// <summary>
		/// Initializes a new <see cref="PassthroughBuffer"/> for the specified <paramref name="stream"/>.
		/// </summary>
		/// <param name="stream">The datastream to buffer.</param>
		internal PassthroughBuffer(StreamBase stream) => Stream = stream;

		/// <inheritdoc/>
		public nint Capacity => 0;

		/// <inheritdoc/>
		public StreamBase Stream { get; }

		/// <inheritdoc/>
		public Boolean Writable => true;

		/// <inheritdoc/>
		public override Boolean Equals([AllowNull] Object obj) {
			switch (obj) {
			case Byte[] array:
				return Equals(array);
			case PassthroughBuffer buffer:
				return Equals(buffer);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals([AllowNull] Byte[] other) => other?.Length == 0;

		/// <inheritdoc/>
		public Boolean Equals([AllowNull] PassthroughBuffer other) => true;

		/// <inheritdoc/>
		public override Int32 GetHashCode() => 0;

		/// <inheritdoc/>
		public Boolean TryWrite(Byte element, out Errors error) => Stream.TryWrite(element, out error);

		/// <inheritdoc/>
		public void Write(Byte element) => Stream.Write(element);
	}
}
