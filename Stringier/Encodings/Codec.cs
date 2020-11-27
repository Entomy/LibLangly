using System;
using System.Text;
using Langly.Streams;
using Langly.Streams.Buffers;

namespace Langly {
	/// <summary>
	/// Represents an encoding/decoding helper for <see cref="TextStream"/>.
	/// </summary>
	/// <remarks>
	/// This exists to help manage encoded read/writes in a maintainable and scalable way.
	/// </remarks>
	public abstract class Codec : IPeekable<Rune, Errors>, IWritable<Rune, Errors> {
		/// <summary>
		/// The buffer used for reads.
		/// </summary>
		protected readonly IReadBuffer ReadBuffer;

		/// <summary>
		/// The buffer used for writes.
		/// </summary>
		protected readonly IWriteBuffer WriteBuffer;

		/// <summary>
		/// Initialize a new <see cref="Codec"/>.
		/// </summary>
		/// <param name="readBuffer">The buffer used for reads.</param>
		/// <param name="writeBuffer">The buffer used for writes.</param>
		protected Codec(IReadBuffer readBuffer, IWriteBuffer writeBuffer) {
			ReadBuffer = readBuffer;
			WriteBuffer = writeBuffer;
		}

		/// <summary>
		/// The <see cref="Encodings.Encoding"/> corresponding to this <see cref="Codec"/>.
		/// </summary>
		public abstract Encoding Encoding { get; }

		/// <inheritdoc/>
		public Boolean Readable => ReadBuffer.Readable;

		/// <inheritdoc/>
		public Boolean Writable => WriteBuffer.Writable;

		/// <inheritdoc/>
		public abstract void Peek(out Rune element);

		/// <inheritdoc/>
		public abstract void Read(out Rune element);

		/// <inheritdoc/>
		public abstract Boolean TryPeek(out Rune element, out Errors error);

		/// <inheritdoc/>
		public abstract Boolean TryRead(out Rune element, out Errors error);

		/// <inheritdoc/>
		public abstract Boolean TryWrite(Rune element, out Errors error);

		/// <inheritdoc/>
		public abstract void Write(Rune element);
	}
}
