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
	/// <para>This <see cref="Stream"/> type provides orchestration logic around the other components, tying everything together. Through those, it provides a low level, byte-centric, API.</para>
	/// <para>The actual datastream is provided by <see cref="StreamBase"/>, which implements the basic streaming API for the daatastream. Supporting additional stream types can be done by extended <see cref="StreamBase"/>, which greatly simplifies adding new datastreams.</para>
	/// <para>Buffers are provided by <see cref="IReadBuffer"/> and <see cref="IWriteBuffer"/>, which buffer the basic streaming from <see cref="StreamBase"/>, enabling features like <see cref="IPeekable{TElement, TError}.Peek(out TElement)"/> and limited <see cref="ISeekable{TElement, TError}"/> behavior even when the underlying stream is not capable.</para>
	/// <para>Additional orchestration can be added by deriving from this type. However, most applications will not need to do this. Instead, the intended mechanism for supporting additional types is through extension methods.</para>
	/// </remarks>
	public class Stream : Controlled,
		IPeekable<Byte, Errors>, IPeekable<SByte, Errors>, IPeekable<Int16, Errors>, IPeekable<UInt16, Errors>,
		ISeekable<Byte, Errors>,
		IWritable<Byte, Errors>, IWritable<SByte, Errors>, IWritable<Int16, Errors>, IWritable<UInt16, Errors> {
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
		/// <param name="string">The <see cref="String"/> to stream.</param>
		[SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP003:Dispose previous before re-assigning.", Justification = "This is a constructor and the field is not inline initialized, so there's nothing to dispose of.")]
		protected Stream(String @string) {
			Base = new StringStreamBase(@string);
			ReadBuffer = new MinimalBuffer(Base);
			WriteBuffer = new PassthroughBuffer(Base);
		}

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
		/// Initialize a new instance of the <see cref="Stream"/> class.
		/// </summary>
		/// <param name="path">The path to the file.</param>
		/// <param name="mode">The <see cref="System.IO.FileMode"/> for opening the file.</param>
		/// <param name="readBuffer">The buffer used for reads.</param>
		/// <param name="writeBuffer">The buffer used for writes.</param>
		/// <remarks>
		/// <para>This constructor presumes streaming a file, and looks for a file at <paramref name="path"/> to stream. It is <see langword="protected"/> as it is intended to be used as part of a constructor chain from a derived class.</para>
		/// </remarks>
		protected Stream(String path, System.IO.FileMode mode, IReadBuffer readBuffer, IWriteBuffer writeBuffer) : this(new FileStreamBase(path, mode), readBuffer, writeBuffer) { }

		/// <summary>
		/// Initialize a new instance of the <see cref="Stream"/> class.
		/// </summary>
		/// <param name="stream">The <see cref="Standard"/> stream designator.</param>
		[SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP003:Dispose previous before re-assigning.", Justification = "This is a constructor and the field is not inline initialized, so there's nothing to dispose of.")]
		protected Stream(Standard stream) {
			Base = new StandardStreamBase(stream);
			ReadBuffer = new MinimalBuffer(Base);
			WriteBuffer = new PassthroughBuffer(Base);
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
		public void Peek(out Byte element) => ReadBuffer.Peek(out element);

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public void Peek(out SByte element) {
			Peek(out Byte elmt);
			element = unchecked((SByte)elmt);
		}

		/// <inheritdoc/>
		public void Peek(out Int16 element) {
			ReadBuffer.Peek(out Byte first, out Byte second);
			element = unchecked((Int16)(second << 8));
			element |= unchecked((Int16)first);
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public void Peek(out UInt16 element) {
			ReadBuffer.Peek(out Byte first, out Byte second);
			element = unchecked((UInt16)(second << 8));
			element |= unchecked((UInt16)first);
		}

		/// <inheritdoc/>
		public void Read(out Byte element) => ReadBuffer.Read(out element);

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public void Read(out SByte element) {
			Read(out Byte elmt);
			element = unchecked((SByte)elmt);
		}

		/// <inheritdoc/>
		public void Read(out Int16 element) {
			ReadBuffer.Read(out Byte first, out Byte second);
			element = unchecked((Int16)(second << 8));
			element |= unchecked((Int16)first);
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public void Read(out UInt16 element) {
			ReadBuffer.Read(out Byte first, out Byte second);
			element = unchecked((UInt16)(second << 8));
			element |= unchecked((UInt16)first);
		}

		/// <inheritdoc/>
		public virtual void Seek(nint offset) => throw new NotImplementedException();

		/// <inheritdoc/>
		public sealed override String ToString() => Base.ToString();

		/// <inheritdoc/>
		public Boolean TryPeek(out Byte element, out Errors error) => ReadBuffer.TryPeek(out element, out error);

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public Boolean TryPeek(out SByte element, out Errors error) {
			Boolean result = TryPeek(out Byte elmt, out error);
			element = unchecked((SByte)elmt);
			return result;
		}

		/// <inheritdoc/>
		public Boolean TryPeek(out Int16 element, out Errors error) {
			if (ReadBuffer.TryPeek(out Byte first, out Byte second, out error)) {
				element = unchecked((Int16)(second << 8));
				element |= unchecked((Int16)first);
				return true;
			} else {
				element = 0;
				return false;
			}
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public Boolean TryPeek(out UInt16 element, out Errors error) {
			if (ReadBuffer.TryPeek(out Byte first, out Byte second, out error)) {
				element = unchecked((UInt16)(second << 8));
				element |= unchecked((UInt16)first);
				return true;
			} else {
				element = 0;
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean TryRead(out Byte element, out Errors error) => ReadBuffer.TryRead(out element, out error);

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public Boolean TryRead(out SByte element, out Errors error) {
			Boolean result = TryRead(out Byte elmt, out error);
			element = unchecked((SByte)elmt);
			return result;
		}

		/// <inheritdoc/>
		public Boolean TryRead(out Int16 element, out Errors error) {
			if (ReadBuffer.TryRead(out Byte first, out Byte second, out error)) {
				element = unchecked((Int16)(second << 8));
				element |= unchecked((Int16)first);
				return true;
			} else {
				element = 0;
				return false;
			}
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public Boolean TryRead(out UInt16 element, out Errors error) {
			if (ReadBuffer.TryPeek(out Byte first, out Byte second, out error)) {
				element = unchecked((UInt16)(second << 8));
				element |= unchecked((UInt16)first);
				return true;
			} else {
				element = 0;
				return false;
			}
		}

		/// <inheritdoc/>
		public virtual Boolean TrySeek(nint offset, out Errors error) => throw new NotImplementedException();

		/// <inheritdoc/>
		public Boolean TryWrite(Byte element, out Errors error) => WriteBuffer.TryWrite(element, out error);

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public Boolean TryWrite(SByte element, out Errors error) => TryWrite(unchecked((Byte)element), out error);

		/// <inheritdoc/>
		public Boolean TryWrite(Int16 element, out Errors error) =>
			TryWrite(unchecked((Byte)element), out error)
			&& TryWrite(unchecked((Byte)(element >> 8)), out error);

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public Boolean TryWrite(UInt16 element, out Errors error) =>
			TryWrite(unchecked((Byte)element), out error)
			&& TryWrite(unchecked((Byte)(element >> 8)), out error);

		/// <inheritdoc/>
		public void Write(Byte element) => WriteBuffer.Write(element);

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public void Write(SByte element) => Write(unchecked((Byte)element));

		/// <inheritdoc/>
		public void Write(Int16 element) {
			Write(unchecked((Byte)element));
			Write(unchecked((Byte)(element >> 8)));
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public void Write(UInt16 element) {
			Write(unchecked((Byte)element));
			Write(unchecked((Byte)(element >> 8)));
		}

		/// <inheritdoc/>
		protected override void DisposeManaged() => Base.Dispose();
	}
}
