using System;
using System.Diagnostics.CodeAnalysis;

namespace Streamy.Bases {
	/// <summary>
	/// Represents a stream base whos backing is contiguous memory.
	/// </summary>
	internal sealed class MemoryCharStreamBase : CharStreamBase {
		/// <summary>
		/// The backing memory.
		/// </summary>
		private readonly Memory<Char> Memory;

		/// <inheritdoc/>
		public MemoryCharStreamBase(Memory<Char> memory) => Memory = memory;

		/// <inheritdoc/>
		public override Boolean Readable => Position < Memory.Length;

		/// <inheritdoc/>
		public override Boolean Seekable => true;

		/// <inheritdoc/>
		public override Boolean Writable => Position < Memory.Length;

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
		public override void Write(Char element) => Memory.Span[(Int32)Position++] = element;

		/// <inheritdoc/>
		public override void Write(Byte element) => throw new NotImplementedException();
	}
}
