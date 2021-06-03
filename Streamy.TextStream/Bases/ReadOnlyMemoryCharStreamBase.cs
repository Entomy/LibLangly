using System;
using System.Diagnostics.CodeAnalysis;

namespace Streamy.Bases {
	/// <summary>
	/// Represents a stream base whos backing is contiguous memory.
	/// </summary>
	internal sealed class ReadOnlyMemoryCharStreamBase : CharStreamBase {
		/// <summary>
		/// The backing memory.
		/// </summary>
		private readonly ReadOnlyMemory<Char> Memory;

		/// <inheritdoc/>
		public ReadOnlyMemoryCharStreamBase(ReadOnlyMemory<Char> memory) => Memory = memory;

		/// <inheritdoc/>
		public override Boolean Readable => Position < Memory.Length;

		/// <inheritdoc/>
		public override Boolean Seekable => true;

		/// <inheritdoc/>
		public override Boolean Writable => false;

		/// <inheritdoc/>
		public override void Read(out Char element) => element = Memory.Span[(Int32)Position++];

		/// <inheritdoc/>
		public override void Read(out Byte element) => throw new NotImplementedException();

		/// <inheritdoc/>
		public override void Seek(nint offset) => Position += offset;

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Memory.ToString();

		/// <inheritdoc/>
		public override void Write(Char element) => throw new NotSupportedException("Stream is read-only.");

		/// <inheritdoc/>
		public override void Write(Byte element) => throw new NotSupportedException("Stream is read-only.");
	}
}
