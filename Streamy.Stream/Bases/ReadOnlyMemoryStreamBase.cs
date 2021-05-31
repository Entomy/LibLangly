using System;

namespace Streamy.Bases {
	/// <summary>
	/// Represents a stream base whos backing is contiguous memory.
	/// </summary>
	internal sealed class ReadOnlyMemoryStreamBase : StreamBase {
		/// <summary>
		/// The backing memory.
		/// </summary>
		private readonly ReadOnlyMemory<Byte> Memory;

		/// <inheritdoc/>
		public ReadOnlyMemoryStreamBase(ReadOnlyMemory<Byte> memory) => Memory = memory;

		/// <inheritdoc/>
		public override Boolean Readable => Position < Memory.Length;

		/// <inheritdoc/>
		public override Boolean Seekable => true;

		/// <inheritdoc/>
		public override Boolean Writable => false;

		/// <inheritdoc/>
		public override void Read(out Byte element) => element = Memory.Span[(Int32)Position++];

		/// <inheritdoc/>
		public override void Seek(nint offset) => Position += offset;

		/// <inheritdoc/>
		public override void Write(Byte element) => throw new NotSupportedException("Stream is read-only.");

		/// <inheritdoc/>
		public override String ToString() => Memory.ToString();
	}
}
