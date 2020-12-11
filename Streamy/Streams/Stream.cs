using System;
using System.Diagnostics.CodeAnalysis;
using Langly.Streams.Bases;
using Langly.Streams.Buffers;

namespace Langly.Streams {
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
		IPeekable<Byte, Errors>, IPeekable<SByte, Errors>, IPeekable<Int16, Errors>, IPeekable<UInt16, Errors>, IPeekable<Int32, Errors>, IPeekable<UInt32, Errors>, IPeekable<Int64, Errors>, IPeekable<UInt64, Errors>, IPeekable<Single, Errors>, IPeekable<Double, Errors>,
		ISeekable<Byte, Errors>,
		IWritable<Byte, Errors>, IWritable<SByte, Errors>, IWritable<Int16, Errors>, IWritable<UInt16, Errors>, IWritable<Int32, Errors>, IWritable<UInt32, Errors>, IWritable<Int64, Errors>, IWritable<UInt64, Errors>, IWritable<Single, Errors>, IWritable<Double, Errors> {
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
		public Boolean Readable => Base.Readable || ReadBuffer.Readable;

		/// <inheritdoc/>
		public Boolean Seekable => Base.Seekable || ReadBuffer.Seekable;

		/// <inheritdoc/>
		public Boolean Writable => Base.Writable || WriteBuffer.Writable;

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
			ReadBuffer.EnsureLoaded(sizeof(Int16));
			element = BitConverter.ToInt16(ReadBuffer.Slice(0, sizeof(Int16)).Span);
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public void Peek(out UInt16 element) {
			ReadBuffer.EnsureLoaded(sizeof(UInt16));
			element = BitConverter.ToUInt16(ReadBuffer.Slice(0, sizeof(UInt16)).Span);
		}

		/// <inheritdoc/>
		public void Peek(out Int32 element) {
			ReadBuffer.EnsureLoaded(sizeof(Int32));
			element = BitConverter.ToInt32(ReadBuffer.Slice(0, sizeof(Int32)).Span);
		}

		/// <inheritdoc/>
		public void Peek(out UInt32 element) {
			ReadBuffer.EnsureLoaded(sizeof(UInt32));
			element = BitConverter.ToUInt32(ReadBuffer.Slice(0, sizeof(UInt32)).Span);
		}

		/// <inheritdoc/>
		public void Peek(out Int64 element) {
			ReadBuffer.EnsureLoaded(sizeof(Int64));
			element = BitConverter.ToInt64(ReadBuffer.Slice(0, sizeof(Int64)).Span);
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public void Peek(out UInt64 element) {
			ReadBuffer.EnsureLoaded(sizeof(UInt64));
			element = BitConverter.ToUInt64(ReadBuffer.Slice(0, sizeof(UInt64)).Span);
		}

		/// <inheritdoc/>
		public void Peek(out Single element) {
			ReadBuffer.EnsureLoaded(sizeof(Single));
			element = BitConverter.ToSingle(ReadBuffer.Slice(0, sizeof(Single)).Span);
		}

		/// <inheritdoc/>
		public void Peek(out Double element) {
			ReadBuffer.EnsureLoaded(sizeof(Double));
			element = BitConverter.ToDouble(ReadBuffer.Slice(0, sizeof(Double)).Span);
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
		public unsafe void Read(out Int16 element) {
			Span<Byte> buffer = stackalloc Byte[sizeof(Int16)];
			ReadBuffer.Read(buffer);
			element = BitConverter.ToInt16(buffer);
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public unsafe void Read(out UInt16 element) {
			Span<Byte> buffer = stackalloc Byte[sizeof(UInt16)];
			ReadBuffer.Read(buffer);
			element = BitConverter.ToUInt16(buffer);
		}

		/// <inheritdoc/>
		public unsafe void Read(out Int32 element) {
			Span<Byte> buffer = stackalloc Byte[sizeof(Int32)];
			ReadBuffer.Read(buffer);
			element = BitConverter.ToInt32(buffer);
		}

		/// <inheritdoc/>
		public unsafe void Read(out UInt32 element) {
			Span<Byte> buffer = stackalloc Byte[sizeof(UInt32)];
			ReadBuffer.Read(buffer);
			element = BitConverter.ToUInt32(buffer);
		}

		/// <inheritdoc/>
		public unsafe void Read(out Int64 element) {
			Span<Byte> buffer = stackalloc Byte[sizeof(Int64)];
			ReadBuffer.Read(buffer);
			element = BitConverter.ToInt64(buffer);
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public unsafe void Read(out UInt64 element) {
			Span<Byte> buffer = stackalloc Byte[sizeof(UInt64)];
			ReadBuffer.Read(buffer);
			element = BitConverter.ToUInt64(buffer);
		}

		/// <inheritdoc/>
		public unsafe void Read(out Single element) {
			Span<Byte> buffer = stackalloc Byte[sizeof(Single)];
			ReadBuffer.Read(buffer);
			element = BitConverter.ToSingle(buffer);
		}

		/// <inheritdoc/>
		public unsafe void Read(out Double element) {
			Span<Byte> buffer = stackalloc Byte[sizeof(Double)];
			ReadBuffer.Read(buffer);
			element = BitConverter.ToDouble(buffer);
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
			if (ReadBuffer.TryEnsureLoaded(sizeof(Int16), out error)) {
				element = BitConverter.ToInt16(ReadBuffer.Slice(0, sizeof(Int16)).Span);
				return true;
			} else {
				element = default;
				return false;
			}
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public Boolean TryPeek(out UInt16 element, out Errors error) {
			if (ReadBuffer.TryEnsureLoaded(sizeof(UInt16), out error)) {
				element = BitConverter.ToUInt16(ReadBuffer.Slice(0, sizeof(UInt16)).Span);
				return true;
			} else {
				element = default;
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean TryPeek(out Int32 element, out Errors error) {
			if (ReadBuffer.TryEnsureLoaded(sizeof(Int32), out error)) {
				element = BitConverter.ToInt32(ReadBuffer.Slice(0, sizeof(Int32)).Span);
				return true;
			} else {
				element = default;
				return false;
			}
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public Boolean TryPeek(out UInt32 element, out Errors error) {
			if (ReadBuffer.TryEnsureLoaded(sizeof(UInt32), out error)) {
				element = BitConverter.ToUInt32(ReadBuffer.Slice(0, sizeof(UInt32)).Span);
				return true;
			} else {
				element = default;
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean TryPeek(out Int64 element, out Errors error) {
			if (ReadBuffer.TryEnsureLoaded(sizeof(Int64), out error)) {
				element = BitConverter.ToInt64(ReadBuffer.Slice(0, sizeof(Int64)).Span);
				return true;
			} else {
				element = default;
				return false;
			}
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public Boolean TryPeek(out UInt64 element, out Errors error) {
			if (ReadBuffer.TryEnsureLoaded(sizeof(UInt64), out error)) {
				element = BitConverter.ToUInt64(ReadBuffer.Slice(0, sizeof(UInt64)).Span);
				return true;
			} else {
				element = default;
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean TryPeek(out Single element, out Errors error) {
			if (ReadBuffer.TryEnsureLoaded(sizeof(Single), out error)) {
				element = BitConverter.ToSingle(ReadBuffer.Slice(0, sizeof(Single)).Span);
				return true;
			} else {
				element = default;
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean TryPeek(out Double element, out Errors error) {
			if (ReadBuffer.TryEnsureLoaded(sizeof(Double), out error)) {
				element = BitConverter.ToDouble(ReadBuffer.Slice(0, sizeof(Double)).Span);
				return true;
			} else {
				element = default;
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
		public unsafe Boolean TryRead(out Int16 element, out Errors error) {
			Span<Byte> buffer = stackalloc Byte[sizeof(Int16)];
			if (ReadBuffer.TryRead(buffer, out error)) {
				element = BitConverter.ToInt16(buffer);
				return true;
			} else {
				element = default;
				return false;
			}
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public unsafe Boolean TryRead(out UInt16 element, out Errors error) {
			Span<Byte> buffer = stackalloc Byte[sizeof(UInt16)];
			if (ReadBuffer.TryRead(buffer, out error)) {
				element = BitConverter.ToUInt16(buffer);
				return true;
			} else {
				element = default;
				return false;
			}
		}

		/// <inheritdoc/>
		public unsafe Boolean TryRead(out Int32 element, out Errors error) {
			Span<Byte> buffer = stackalloc Byte[sizeof(Int32)];
			if (ReadBuffer.TryRead(buffer, out error)) {
				element = BitConverter.ToInt32(buffer);
				return true;
			} else {
				element = default;
				return false;
			}
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public unsafe Boolean TryRead(out UInt32 element, out Errors error) {
			Span<Byte> buffer = stackalloc Byte[sizeof(UInt32)];
			if (ReadBuffer.TryRead(buffer, out error)) {
				element = BitConverter.ToUInt32(buffer);
				return true;
			} else {
				element = default;
				return false;
			}
		}

		/// <inheritdoc/>
		public unsafe Boolean TryRead(out Int64 element, out Errors error) {
			Span<Byte> buffer = stackalloc Byte[sizeof(Int64)];
			if (ReadBuffer.TryRead(buffer, out error)) {
				element = BitConverter.ToInt64(buffer);
				return true;
			} else {
				element = default;
				return false;
			}
		}

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public unsafe Boolean TryRead(out UInt64 element, out Errors error) {
			Span<Byte> buffer = stackalloc Byte[sizeof(UInt64)];
			if (ReadBuffer.TryRead(buffer, out error)) {
				element = BitConverter.ToUInt64(buffer);
				return true;
			} else {
				element = default;
				return false;
			}
		}

		/// <inheritdoc/>
		public unsafe Boolean TryRead(out Single element, out Errors error) {
			Span<Byte> buffer = stackalloc Byte[sizeof(Single)];
			if (ReadBuffer.TryRead(buffer, out error)) {
				element = BitConverter.ToSingle(buffer);
				return true;
			} else {
				element = default;
				return false;
			}
		}

		/// <inheritdoc/>
		public unsafe Boolean TryRead(out Double element, out Errors error) {
			Span<Byte> buffer = stackalloc Byte[sizeof(Double)];
			if (ReadBuffer.TryRead(buffer, out error)) {
				element = BitConverter.ToDouble(buffer);
				return true;
			} else {
				element = default;
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
		public Boolean TryWrite(Int16 element, out Errors error) => WriteBuffer.TryWrite(BitConverter.GetBytes(element), out error);

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public Boolean TryWrite(UInt16 element, out Errors error) => WriteBuffer.TryWrite(BitConverter.GetBytes(element), out error);

		/// <inheritdoc/>
		public Boolean TryWrite(Int32 element, out Errors error) => WriteBuffer.TryWrite(BitConverter.GetBytes(element), out error);

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public Boolean TryWrite(UInt32 element, out Errors error) => WriteBuffer.TryWrite(BitConverter.GetBytes(element), out error);

		/// <inheritdoc/>
		public Boolean TryWrite(Int64 element, out Errors error) => WriteBuffer.TryWrite(BitConverter.GetBytes(element), out error);

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public Boolean TryWrite(UInt64 element, out Errors error) => WriteBuffer.TryWrite(BitConverter.GetBytes(element), out error);

		/// <inheritdoc/>
		public Boolean TryWrite(Single element, out Errors error) => WriteBuffer.TryWrite(BitConverter.GetBytes(element), out error);

		/// <inheritdoc/>
		public Boolean TryWrite(Double element, out Errors error) => WriteBuffer.TryWrite(BitConverter.GetBytes(element), out error);

		/// <inheritdoc/>
		public void Write(Byte element) => WriteBuffer.Write(element);

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public void Write(SByte element) => Write(unchecked((Byte)element));

		/// <inheritdoc/>
		public void Write(Int16 element) => WriteBuffer.Write(BitConverter.GetBytes(element));

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public void Write(UInt16 element) => WriteBuffer.Write(BitConverter.GetBytes(element));

		/// <inheritdoc/>
		public void Write(Int32 element) => WriteBuffer.Write(BitConverter.GetBytes(element));

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public void Write(UInt32 element) => WriteBuffer.Write(BitConverter.GetBytes(element));

		/// <inheritdoc/>
		public void Write(Int64 element) => WriteBuffer.Write(BitConverter.GetBytes(element));

		/// <inheritdoc/>
		[CLSCompliant(false)]
		public void Write(UInt64 element) => WriteBuffer.Write(BitConverter.GetBytes(element));

		/// <inheritdoc/>
		public void Write(Single element) => WriteBuffer.Write(BitConverter.GetBytes(element));

		/// <inheritdoc/>
		public void Write(Double element) => WriteBuffer.Write(BitConverter.GetBytes(element));

		/// <inheritdoc/>
		protected override void DisposeManaged() => Base.Dispose();
	}
}
