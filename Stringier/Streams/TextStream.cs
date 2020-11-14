//using System;
//using System.Diagnostics.CodeAnalysis;
//using System.IO;
//using Streamy.Bases;
//using Streamy.Buffers;
//using Stringier;
//using Stringier.Encodings;
//using Philosoft;
//using Rune = System.Text.Rune;

//namespace Streamy {
//	/// <summary>
//	/// Provides a view of a sequence of UNICODE Characters.
//	/// </summary>
//	/// <remarks>
//	/// <para>This streams <see cref="Rune"/> instead of <see cref="Char"/> to avoid the misunderstandings and complexities working with UTF-16 Code Units causes. <see cref="Rune"/> represents a higher level that is closer to what people intend to work with.</para>
//	/// <para>This fundamentally operates differently from <see cref="System.IO.Stream"/>. While it is designed fairly similar in API, the way it operates, even at that level, differs greatly. There's four major components that make up the text stream:</para>
//	/// <para>This <see cref="TextStream"/> type provides orchestration logic around the other components, tying everything together. Through those, it provides the higher level, text-centric, API.</para>
//	/// <para>The actual datastream is provided by <see cref="StreamBase"/>, which implements the basic streaming API for the daatastream.</para>
//	/// <para>Buffers are provided by <see cref="IReadBuffer"/> and <see cref="IWriteBuffer"/>, which buffer the basic streaming from <see cref="StreamBase"/>, enabling features like <see cref="Peek()"/> and limited <see cref="Stream.Seekable"/> behavior even when the underlying stream is not capable.</para>
//	/// <para>Encoding is handled by <see cref="Stringier.Encodings.Encoder"/> helpers. These handle the translation between encodings through a consistent API.</para>
//	/// </remarks>
//	public class TextStream : Stream, IPeekable<Rune, Errors>, ISeekable<Rune, Errors>, IWritable<Rune, Errors> {
//		/// <summary>
//		/// The encoding helper.
//		/// </summary>
//		protected readonly Encoder Encoder;

//		/// <summary>
//		/// Initialize a new instance of the <see cref="TextStream"/> class. Reads BOM.
//		/// </summary>
//		/// <param name="buffer">The <see cref="Array"/> of <see cref="Byte"/> to stream.</param>
//		/// <remarks>
//		/// This constructor attempts to detect the encoding of the stream by reading the BOM from the stream. This operation can fail, but this constructor does not report why; use <see cref="TextStream(Byte[], out Errors)"/> if that information is desired. The encoding will always default to UTF-8 in the event no BOM was present, or something kept the BOM from being read.
//		/// </remarks>
//		public TextStream(Byte[] buffer) : this(new MemoryStreamBase(buffer), out _) { }

//		/// <summary>
//		/// Initialize a new instance of the <see cref="TextStream"/> class. Reads BOM.
//		/// </summary>
//		/// <param name="buffer">The <see cref="Array"/> of <see cref="Byte"/> to stream.</param>
//		/// <param name="error">The <see cref="Errors"/> that occured while detecting encoding, if any.</param>
//		/// <remarks>
//		/// This constructor attempts to detect the encoding of the stream by reading the BOM from the stream. Because this operation can fail, <paramref name="error"/> is passed out for indicating what went wrong. The encoding will always default to UTF-8 in the event no BOM was present, or something kept the BOM from being read.
//		/// </remarks>
//		[SuppressMessage("Maintainability", "AV1562:Do not declare a parameter as ref or out", Justification = "<Pending>")]
//		public TextStream(Byte[] buffer, out Errors error) : this(new MemoryStreamBase(buffer), out error) { }

//		/// <summary>
//		/// Initialize a new instance of the <see cref="TextStream"/> class.
//		/// </summary>
//		/// <param name="buffer">The <see cref="Array"/> of <see cref="Byte"/> to stream.</param>
//		/// <param name="encoding">The <see cref="Encoding"/> of the datastream.</param>
//		public TextStream(Byte[] buffer, Encoding encoding) : this(new MemoryStreamBase(buffer), encoding) { }

//		/// <summary>
//		/// Initialize a new instance of the <see cref="TextStream"/> class.
//		/// </summary>
//		/// <param name="standard">The <see cref="Standard"/> stream.</param>
//		public TextStream(Standard standard) : this(new StandardStreamBase(standard),
//#if WINDOWS
//			Encoding.UTF16LE
//#else
//			Encoding.UTF8
//#endif
//			) { }

//		/// <summary>
//		/// Initialize a new instance of the <see cref="TextStream"/> class. Reads BOM.
//		/// </summary>
//		/// <param name="path">The path to the file.</param>
//		/// <param name="mode">The <see cref="FileMode"/> for opening the file.</param>
//		/// <remarks>
//		/// <para>This constructor presumes streaming a file, and looks for a file at <paramref name="path"/> to stream. It is <see langword="protected"/> as it is intended to be used as part of a constructor chain from a derived class.</para>
//		/// <para>This constructor attempts to detect the encoding of the stream by reading the BOM from the stream. This operation can fail, but this constructor does not report why; use <see cref="TextStream(String, FileMode, out Errors)"/> if that information is desired. The encoding will always default to UTF-8 in the event no BOM was present, or something kept the BOM from being read.</para>
//		/// </remarks>
//		protected TextStream(String path, FileMode mode) : this(new FileStreamBase(path, mode), out _) { }

//		/// <summary>
//		/// Initialize a new instance of the <see cref="TextStream"/> class. Reads BOM.
//		/// </summary>
//		/// <param name="path">The path to the file.</param>
//		/// <param name="mode">The <see cref="FileMode"/> for opening the file.</param>
//		/// <param name="error">The <see cref="Errors"/> that occured while detecting encoding, if any.</param>
//		/// <remarks>
//		/// <para>This constructor presumes streaming a file, and looks for a file at <paramref name="path"/> to stream. It is <see langword="protected"/> as it is intended to be used as part of a constructor chain from a derived class.</para>
//		/// <para>This constructor attempts to detect the encoding of the stream by reading the BOM from the stream. Because this operation can fail, <paramref name="error"/> is passed out for indicating what went wrong. The encoding will always default to UTF-8 in the event no BOM was present, or something kept the BOM from being read.</para>
//		/// </remarks>
//		protected TextStream(String path, FileMode mode, out Errors error) : this(new FileStreamBase(path, mode), out error) { }

//		/// <summary>
//		/// Initialize a new instance of the <see cref="TextStream"/> class.
//		/// </summary>
//		/// <param name="path">The path to the file.</param>
//		/// <param name="mode">The <see cref="FileMode"/> for opening the file.</param>
//		/// <param name="encoding">The <see cref="Encoding"/> of the datastream.</param>
//		/// <remarks>
//		/// <para>This constructor presumes streaming a file, and looks for a file at <paramref name="path"/> to stream. It is <see langword="protected"/> as it is intended to be used as part of a constructor chain from a derived class.</para>
//		/// </remarks>
//		protected TextStream(String path, FileMode mode, Encoding encoding) : this(new FileStreamBase(path, mode), encoding) { }

//		/// <summary>
//		/// Initialize a new instance of the <see cref="TextStream"/> class. Reads BOM.
//		/// </summary>
//		/// <param name="streamBase">The base datastream.</param>
//		/// <param name="error">The <see cref="Errors"/> that occured while detecting encoding, if any.</param>
//		/// <remarks>
//		/// This constructor attempts to detect the encoding of the stream by reading the BOM from the stream. Because this operation can fail, <paramref name="error"/> is passed out for indicating what went wrong. The encoding will always default to UTF-8 in the event no BOM was present, or something kept the BOM from being read.
//		/// </remarks>
//		protected TextStream(StreamBase streamBase, out Errors error) : this(streamBase, new MinimalBuffer(streamBase), new PassthroughBuffer(streamBase), out error) { }

//		/// <summary>
//		/// Initialize a new instance of the <see cref="TextStream"/> class. Reads BOM.
//		/// </summary>
//		/// <param name="streamBase">The base datastream.</param>
//		/// <param name="readBuffer">The <see cref="IBuffer"/> used for reads.</param>
//		/// <param name="writeBuffer">The <see cref="IBuffer"/> used for writes.</param>
//		/// <param name="error">The <see cref="Errors"/> that occured while detecting encoding, if any.</param>
//		/// <remarks>
//		/// This constructor attempts to detect the encoding of the stream by reading the BOM from the stream. Because this operation can fail, <paramref name="error"/> is passed out for indicating what went wrong. The encoding will always default to UTF-8 in the event no BOM was present, or something kept the BOM from being read.
//		/// </remarks>
//		protected TextStream(StreamBase streamBase, IReadBuffer readBuffer, IWriteBuffer writeBuffer, out Errors error) {
//			Base = streamBase;
//			ReadBuffer = readBuffer;
//			WriteBuffer = writeBuffer;
//			error = ReadBuffer.Load(4);
//			if (ReadBuffer.Equals(new Byte[] { 0xEF, 0xBB, 0xBF })) {
//				ReadBuffer.Shift(3);
//				Encoder = new UTF8Encoder(ReadBuffer, WriteBuffer);
//			} else if (ReadBuffer.Equals(new Byte[] { 0xFF, 0xFE, 0x00, 0x00 })) {
//				ReadBuffer.Shift(4);
//				Encoder = new UTF32LEEncoder(ReadBuffer, WriteBuffer);
//			} else if (ReadBuffer.Equals(new Byte[] { 0x00, 0x00, 0xFE, 0xFF })) {
//				ReadBuffer.Shift(4);
//				Encoder = new UTF32BEEncoder(ReadBuffer, WriteBuffer);
//			} else if (ReadBuffer.Equals(new Byte[] { 0xFF, 0xFE })) {
//				ReadBuffer.Shift(2);
//				Encoder = new UTF16LEEncoder(ReadBuffer, WriteBuffer);
//			} else if (ReadBuffer.Equals(new Byte[] { 0xFE, 0xFF })) {
//				ReadBuffer.Shift(2);
//				Encoder = new UTF16BEEncoder(ReadBuffer, WriteBuffer);
//			} else {
//				goto Default;
//			}
//			return;
//		Default:
//			Encoder = new UTF8Encoder(ReadBuffer, WriteBuffer);
//		}

//		/// <summary>
//		/// Initialize a new instance of the <see cref="TextStream"/> class.
//		/// </summary>
//		/// <param name="streamBase">The base datastream.</param>
//		/// <param name="encoding">The <see cref="Encoding"/> of the datastream.</param>
//		protected TextStream(StreamBase streamBase, Encoding encoding) : this(streamBase, encoding, new MinimalBuffer(streamBase), new PassthroughBuffer(streamBase)) { }

//		/// <summary>
//		/// Initialize a new instance of the <see cref="TextStream"/> class.
//		/// </summary>
//		/// <param name="streamBase">The base datastream.</param>
//		/// <param name="encoding">The <see cref="Encoding"/> of the datastream.</param>
//		/// <param name="readBuffer">The buffer used for reads.</param>
//		/// <param name="writeBuffer">The buffer used for writes.</param>
//		protected TextStream(StreamBase streamBase, Encoding encoding, IReadBuffer readBuffer, IWriteBuffer writeBuffer) {
//			Base = streamBase;
//			ReadBuffer = readBuffer;
//			WriteBuffer = writeBuffer;
//			Encoder = encoding switch {
//				Encoding.UTF8 => new UTF8Encoder(ReadBuffer, WriteBuffer),
//				Encoding.UTF16BE => new UTF16BEEncoder(ReadBuffer, WriteBuffer),
//				Encoding.UTF16LE => new UTF16LEEncoder(ReadBuffer, WriteBuffer),
//				Encoding.UTF32BE => new UTF32BEEncoder(ReadBuffer, WriteBuffer),
//				Encoding.UTF32LE => new UTF32LEEncoder(ReadBuffer, WriteBuffer),
//				_ => throw new System.ArgumentException($"Encoding '{encoding}' was not handled.", nameof(encoding)),
//			};
//		}

//		/// <summary>
//		/// Initialize a new instance of the <see cref="TextStream"/> class.
//		/// </summary>
//		/// <param name="streamBase">The base datastream.</param>
//		/// <param name="encoder">The encoding helper.</param>
//		/// <param name="readBuffer">The <see cref="IBuffer"/> used for reads.</param>
//		/// <param name="writeBuffer">The <see cref="IBuffer"/> used for writes.</param>
//		protected TextStream(StreamBase streamBase, Encoder encoder, IReadBuffer readBuffer, IWriteBuffer writeBuffer) : base(streamBase, readBuffer, writeBuffer) => Encoder = encoder;

//		/// <summary>
//		/// Initialize a new instance of the <see cref="TextStream"/> class.
//		/// </summary>
//		/// <param name="streamBase">The base datastream.</param>
//		/// <param name="encoder">The encoding helper.</param>
//		private TextStream(StreamBase streamBase, Encoder encoder) : this(streamBase, encoder, new MinimalBuffer(streamBase), new PassthroughBuffer(streamBase)) { }
//		/// <summary>
//		/// The <see cref="Stringier.Encodings.Encoding"/> of this stream.
//		/// </summary>
//		public Encoding Encoding => Encoder.Encoding;

//		/// <summary>
//		/// The position within the stream, counted by rune offset.
//		/// </summary>
//		public override nint Position { get; set; }

//		/// <summary>
//		/// Stream this <paramref name="buffer"/>.
//		/// </summary>
//		/// <param name="buffer">The <see cref="Array"/> of <see cref="Byte"/> to stream.</param>
//		/// <returns>This <paramref name="buffer"/> as a datastream.</returns>
//		/// <remarks>
//		/// This constructor attempts to detect the encoding of the stream by reading the BOM from the stream. This operation can fail, but this constructor does not report why; use <see cref="TextStream(Byte[], out Errors)"/> if that information is desired. The encoding will always default to UTF-8 in the event no BOM was present, or something kept the BOM from being read.
//		/// </remarks>
//		public static implicit operator TextStream(Byte[] buffer) => new TextStream(buffer);

//		/// <summary>
//		/// Stream this <paramref name="string"/>.
//		/// </summary>
//		/// <param name="string">The <see cref="String"/> to stream.</param>
//		/// <returns>The <paramref name="string"/> as a datastream.</returns>
//		public static implicit operator TextStream(String @string) => new TextStream(new StringStreamBase(@string), Encoding.UTF16LE);

//		///<inheritdoc/>
//		void IPeekable<Rune, Errors>.Peek(out Rune element) => Encoder.Peek(out element);

//		/// <inheritdoc/>
//		void IReadable<Rune, Errors>.Read(out Rune element) => Encoder.Read(out element);

//		/// <inheritdoc/>
//		void ISeekable<Rune, Errors>.Seek(nint offset) => throw new NotImplementedException();

//		/// <inheritdoc/>
//		Boolean IPeekable<Rune, Errors>.TryPeek(out Rune element, out Errors error) => Encoder.TryPeek(out element, out error);

//		/// <inheritdoc/>
//		Boolean IReadable<Rune, Errors>.TryRead(out Rune element, out Errors error) => Encoder.TryRead(out element, out error);

//		/// <inheritdoc/>
//		Boolean ISeekable<Rune, Errors>.TrySeek(nint offset, out Errors error) => throw new NotImplementedException();

//		/// <inheritdoc/>
//		Boolean IWritable<Rune, Errors>.TryWrite(Rune element, out Errors error) => Encoder.TryWrite(element, out error);

//		/// <inheritdoc/>
//		void IWritable<Rune, Errors>.Write(Rune element) => throw new NotImplementedException();
//	}
//}
