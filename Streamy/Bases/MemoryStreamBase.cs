using System;
using Logician;

namespace Streamy.Bases {
	/// <summary>
	/// Represents the base of a <see cref="Stream"/> whos backing data is stored in memory.
	/// </summary>
	internal class MemoryStreamBase : StreamBase {
		/// <summary>
		/// The backing memory buffer.
		/// </summary>
		protected readonly Byte[] Buffer;

		/// <inheritdoc/>
		internal MemoryStreamBase(Byte[] buffer) => Buffer = buffer;

		/// <inheritdoc/>
		public sealed override Ł3 AtEnd => Position == Buffer.Length;

		/// <inheritdoc/>
		public sealed override Boolean Readable => Position < Buffer.Length;

		/// <inheritdoc/>
		public sealed override Boolean Seekable => Buffer.Length > 0;

		/// <inheritdoc/>
		public sealed override Boolean Writable => Position < Buffer.Length;

		/// <inheritdoc/>
		public override void Read(out Byte element) => element = Buffer[Position++];

		/// <inheritdoc/>
		public override void Seek(nint offset) => Position += offset;

		/// <inheritdoc/>
		public override String ToString() => $"{Buffer}";

		/// <inheritdoc/>
		public override void Write(Byte element) => Buffer[Position++] = element;
	}
}
