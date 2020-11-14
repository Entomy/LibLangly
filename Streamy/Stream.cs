using System;
using System.Diagnostics.CodeAnalysis;
using Defender.Patterns;
using Streamy.Bases;
using Streamy.Buffers;
using Philosoft;

namespace Streamy {
	/// <summary>
	/// Provides a view of a sequence of <see cref="Byte"/>.
	/// </summary>
	/// <remarks>
	/// <para>This fundamentally operates differently from <see cref="System.IO.Stream"/>. While it is designed fairly similar in API, the way it operates, even at that level, differs greatly. There's three major components that make up the byte stream:</para>
	/// <para>This <see cref="Stream"/> type provides orchestration logic around the other components, tying everything together. Through those, it provides the higher level, text-centric, API.</para>
	/// <para>The actual datastream is provided by <see cref="StreamBase"/>, which implements the basic streaming API for the daatastream.</para>
	/// <para>Buffers are provided by <see cref="IReadBuffer"/> and <see cref="IWriteBuffer"/>, which buffer the basic streaming from <see cref="StreamBase"/>, enabling features like <see cref="IPeekable{TElement, TError}.Peek(out TElement)"/> and limited <see cref="Seekable"/> behavior even when the underlying stream is not capable.</para>
	/// </remarks>
	public class Stream : Controlled, IPeekable<Byte, Errors>, ISeekable<Byte, Errors>, IWritable<Byte, Errors> {
		/// <summary>
		/// The base of the <see cref="Stream"/>, the actual datastream.
		/// </summary>
		[SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP008:Don't assign member with injected and created disposables.", Justification = "We own this, as StreamBase isn't considered a complete type on its own.")]
		protected readonly StreamBase Base;

		/// <summary>
		/// The buffer used for reads.
		/// </summary>
		protected readonly IReadBuffer ReadBuffer;

		/// <summary>
		/// The buffer used for writes.
		/// </summary>
		protected readonly IWriteBuffer WriteBuffer;

		/// <summary>
		/// Initialize a new instance of the <see cref="Stream"/> class.
		/// </summary>
		/// <param name="buffer">The <see cref="Array"/> of <see cref="Byte"/> to stream.</param>
		[SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP003:Dispose previous before re-assigning.", Justification = "This is a constructor and the field is not inline initialized, so there's nothing to dispose of.")]
		public Stream(Byte[] buffer) {
			Base = new MemoryStreamBase(buffer);
			ReadBuffer = new MinimalBuffer(Base);
			WriteBuffer = new PassthroughBuffer(Base);
		}

		/// <summary>
		/// Initialize a new instance of the <see cref="Stream"/> class.
		/// </summary>
		/// <param name="buffer">The <see cref="Array"/> of <see cref="Byte"/> to stream.</param>
		/// <param name="readBuffer">The buffer used for reads.</param>
		/// <param name="writeBuffer">The buffer used for writes.</param>
		public Stream(Byte[] buffer, IReadBuffer readBuffer, IWriteBuffer writeBuffer) : this(new MemoryStreamBase(buffer), readBuffer, writeBuffer) { }

		/// <summary>
		/// Initialize a new instance of the <see cref="Stream"/> class.
		/// </summary>
		/// <param name="streamBase">The base datastream.</param>
		/// <param name="readBuffer">The buffer used for reads.</param>
		/// <param name="writeBuffer">The buffer used for writes.</param>
		[SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP003:Dispose previous before re-assigning.", Justification = "This is a constructor and the field is not inline initialized, so there's nothing to dispose of.")]
		protected Stream(StreamBase streamBase, IReadBuffer readBuffer, IWriteBuffer writeBuffer) {
			Base = streamBase;
			ReadBuffer = readBuffer;
			WriteBuffer = writeBuffer;
		}

		/// <summary>
		/// The position within the stream, counted by byte offset.
		/// </summary>
		/// <remarks>
		/// This is <see langword="virtual"/> so that extenders may change how indexing appears, such as a text stream being counted by some text element.
		/// </remarks>
		public virtual nint Position { get; set; }

		/// <inheritdoc/>
		public Boolean Readable => Base.Readable;

		/// <inheritdoc/>
		public Boolean Seekable => Base.Seekable;

		/// <inheritdoc/>
		public Boolean Writable => Base.Writable;

		/// <summary>
		/// Stream this <paramref name="buffer"/>.
		/// </summary>
		/// <param name="buffer">The <see cref="Array"/> of <see cref="Byte"/> to stream.</param>
		/// <returns>This <paramref name="buffer"/> as a datastream.</returns>
		[SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "There is, one of the compilers.")]
		public static implicit operator Stream(Byte[] buffer) => buffer is not null ? new Stream(buffer) : new Stream(Array.Empty<Byte>());

		/// <inheritdoc/>
		void IPeekable<Byte, Errors>.Peek(out Byte element) => ReadBuffer.Peek(out element);

		/// <inheritdoc/>
		void IReadable<Byte, Errors>.Read(out Byte element) => ReadBuffer.Read(out element);

		/// <inheritdoc/>
		void ISeekable<Byte, Errors>.Seek(nint offset) => throw new NotImplementedException();

		/// <inheritdoc/>
		public sealed override String ToString() => Base.ToString();

		/// <inheritdoc/>
		Boolean IPeekable<Byte, Errors>.TryPeek(out Byte element, out Errors error) => ReadBuffer.TryPeek(out element, out error);

		/// <inheritdoc/>
		Boolean IReadable<Byte, Errors>.TryRead(out Byte element, out Errors error) => ReadBuffer.TryRead(out element, out error);

		/// <inheritdoc/>
		Boolean ISeekable<Byte, Errors>.TrySeek(nint offset, out Errors error) => throw new NotImplementedException();

		/// <inheritdoc/>
		Boolean IWritable<Byte, Errors>.TryWrite(Byte element, out Errors error) => WriteBuffer.TryWrite(element, out error);

		/// <inheritdoc/>
		void IWritable<Byte, Errors>.Write(Byte element) => WriteBuffer.Write(element);

		/// <inheritdoc/>
		protected override void DisposeManaged() => Base.Dispose();
	}
}
