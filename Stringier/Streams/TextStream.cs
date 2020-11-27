using System;
using System.Diagnostics.CodeAnalysis;
using Langly.Streams.Bases;
using Langly.Streams.Buffers;
using Rune = System.Text.Rune;

namespace Langly.Streams {
	/// <summary>
	/// Provides a view of a sequence of UNICODE Characters.
	/// </summary>
	/// <remarks>
	/// <para>This streams <see cref="Rune"/> instead of <see cref="Char"/> to avoid the misunderstandings and complexities working with UTF-16 Code Units causes. <see cref="Rune"/> represents a higher level that is closer to what people intend to work with.</para>
	/// <para>This fundamentally operates differently from <see cref="System.IO.Stream"/>. While it is designed fairly similar in API, the way it operates, even at that level, differs greatly. There's four major components that make up the text stream:</para>
	/// <para>This <see cref="TextStream"/> type provides orchestration logic around the other components, tying everything together. Through those, it provides the higher level, text-centric, API.</para>
	/// <para>The actual datastream is provided by <see cref="StreamBase"/>, which implements the basic streaming API for the daatastream. Supporting additional stream types can be done by extended <see cref="StreamBase"/>, which greatly simplifies adding new datastreams.</para>
	/// <para>Buffers are provided by <see cref="IReadBuffer"/> and <see cref="IWriteBuffer"/>, which buffer the basic streaming from <see cref="StreamBase"/>, enabling features like <see cref="IPeekable{TElement, TError}.Peek(out TElement)"/> and limited <see cref="ISeekable{TElement, TError}"/> behavior even when the underlying stream is not capable.</para>
	/// <para>Encoding is handled by <see cref="Langly.Codec"/> helpers. These handle the translation between encodings through a consistent API.</para>
	/// <para>Additional orchestration can be added by deriving from this type. However, most applications will not need to do this. Instead, the intended mechanism for supporting additional types is through extension methods.</para>
	/// </remarks>
	public class TextStream : Stream, IPeekable<Rune, Errors>, ISeekable<Rune, Errors>, IWritable<Rune, Errors> {
		/// <summary>
		/// The encoding helper.
		/// </summary>
		[AllowNull] private Codec codec;

		/// <summary>
		/// The position within the stream, counted by rune offset.
		/// </summary>
		private nint position;

		/// <summary>
		/// Initialize a new instance of the <see cref="TextStream"/> class. Reads BOM.
		/// </summary>
		/// <remarks>
		/// <param name="buffer">The <see cref="Array"/> of <see cref="Byte"/> to stream.</param>
		/// </remarks>
		public TextStream(Byte[] buffer) : base(buffer) { }

		/// <summary>
		/// Initialize a new instance of the <see cref="TextStream"/> class.
		/// </summary>
		/// <param name="buffer">The <see cref="Array"/> of <see cref="Byte"/> to stream.</param>
		/// <param name="encoding">The <see cref="Encoding"/> of the datastream.</param>
		public TextStream(Byte[] buffer, Encoding encoding) : base(buffer) {
			codec = GetCodec(encoding);
			ConfirmEncoding(encoding);
		}

		/// <summary>
		/// Initialize a new instance of the <see cref="Stream"/> class.
		/// </summary>
		/// <param name="string">The <see cref="String"/> to stream.</param>
		public TextStream(String @string) : base(@string) => codec = new UTF16LECodec(ReadBuffer, WriteBuffer);

		/// <summary>
		/// Initialize a new instance of the <see cref="TextStream"/> class.
		/// </summary>
		/// <param name="standard">The <see cref="Standard"/> stream.</param>
		public TextStream(Standard standard) : base(standard) =>
#if WINDOWS
			codec = new UTF16LECodec(ReadBuffer, WriteBuffer);
#else
			codec = new UTF8Codec(ReadBuffer, WriteBuffer);
#endif

		/// <summary>
		/// Initialize a new instance of the <see cref="Stream"/> class.
		/// </summary>
		/// <param name="path">The path to the file.</param>
		/// <param name="mode">The <see cref="System.IO.FileMode"/> for opening the file.</param>
		/// <param name="encoding">The <see cref="Encoding"/> of the datastream.</param>
		/// <param name="readBuffer">The buffer used for reads.</param>
		/// <param name="writeBuffer">The buffer used for writes.</param>
		/// <remarks>
		/// <para>This constructor presumes streaming a file, and looks for a file at <paramref name="path"/> to stream. It is <see langword="protected"/> as it is intended to be used as part of a constructor chain from a derived class.</para>
		/// </remarks>
		protected TextStream(String path, System.IO.FileMode mode, Encoding encoding, IReadBuffer readBuffer, IWriteBuffer writeBuffer) : base(path, mode, readBuffer, writeBuffer) {
			codec = GetCodec(encoding);
			ConfirmEncoding(encoding);
		}

		/// <summary>
		/// The <see cref="Stringier.Encodings.Encoding"/> of this stream.
		/// </summary>
		/// <remarks>
		/// <para>If the current encoding is not known, this will be <see cref="Encoding.Unknown"/>. When this happens, if the encoding has to be determined, it will be done so automatically, and then changed to the determined encoding. This always defaults to <see cref="Encoding.UTF8"/> if another specific encoding was not specified at construction or as a BOM.</para>
		/// <para>Determining the stream encoding can be a complex matter.</para>
		/// <para>If the encoding is specified in the constructor, that is the encoding that will be used for all operations. This is the most efficient, so when the encoding is known, specify it upfront.</para>
		/// <para>If the first operation upon the stream is a write and the encoding has not been specified in the constructor, <see cref="Encoding.UTF8"/> will be used.</para>
		/// <para>If the first operation upon the stream is a read and the encoding has not been specified in the constructor, an attempt will be made to buffer and read the BOM. If a BOM is present, the associated encoding will be used. This includes the UTF-8 psuedo-BOM. If no BOM is present <see cref="Encoding.UTF8"/> will be used.</para>
		/// <para>When the encoding is already known, either because it was specified in the constructor, or a write occurred before a read, an attempt to buffer and read the BOM is still made. If no read was possible this is considered successful and everything continues. If a read was possible and there was no BOM present this is considered successful and everything continues. If a read was possible and there is a BOM present, the encoding indicated by the BOM is compared against the specified encoding, failing if it does not match.</para>
		/// </remarks>
		public Encoding Encoding => Codec?.Encoding ?? Encoding.Unknown;

		/// <summary>
		/// The position within the stream, counted by rune offset.
		/// </summary>
		/// <remarks>
		/// The base <see cref="Stream"/> type determines position by <see cref="Byte"/> offset. <see cref="TextStream"/> overrides this behavior, exposing the position as <see cref="Rune"/> offset. This is done to simplify and unify the overall concept. If a stream is UTF-8 encoded, advancing two code points could mean advancing two bytes, eight bytes, or anywhere in between. This issue applies to any variable-width encoding, which the majority of modern encoding schemes are. Furthermore, seeking the stream, which can be done through this property, is remarkably difficult to keep track of with byte offset positioning. Translations are done internally to simplify this.
		/// </remarks>
		public override nint Position {
			get => position;
			set {
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// The encoding helper.
		/// </summary>
		/// <remarks>
		/// This will lazy-load the <see cref="codec"/> by attempting to read the BOM, defaulting to <see cref="Encoding.UTF8"/> if that fails for any reason.
		/// </remarks>
		protected Codec Codec {
			get {
				if (codec is null) {
					if (TryReadBOM(out Encoding encoding, out Errors error)) {
						if (error != Errors.None) {
							codec = GetCodec(encoding)!; // If this branch is taken GetCodec won't return null, but there's no attribute that can declare this behavior.
						} else {
							codec = new UTF8Codec(ReadBuffer, WriteBuffer);
						}
					}
				}
				return codec;
			}
			set => codec = value;
		}
		/// <summary>
		/// Stream this <paramref name="buffer"/>.
		/// </summary>
		/// <param name="buffer">The <see cref="Array"/> of <see cref="Byte"/> to stream.</param>
		/// <returns>This <paramref name="buffer"/> as a datastream.</returns>
		[SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "A constructor takes care of this.")]
		public static implicit operator TextStream(Byte[] buffer) => new TextStream(buffer);

		/// <summary>
		/// Stream this <paramref name="string"/>.
		/// </summary>
		/// <param name="string">The <see cref="String"/> to stream.</param>
		/// <returns>This <paramref name="string"/> as a datastream.</returns>
		[SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "A constructor takes care of this.")]
		public static implicit operator TextStream(String @string) => new TextStream(@string);

		///<inheritdoc/>
		public void Peek(out Rune element) => Codec.Peek(out element);

		/// <inheritdoc/>
		public void Read(out Rune element) {
			position++;
			Codec.Read(out element);
		}

		/// <inheritdoc/>
		public override void Seek(nint offset) => throw new NotImplementedException();

		/// <inheritdoc/>
		public Boolean TryPeek(out Rune element, out Errors error) => Codec.TryPeek(out element, out error);

		/// <inheritdoc/>
		public Boolean TryRead(out Rune element, out Errors error) {
			position++;
			return Codec.TryRead(out element, out error);
		}

		/// <inheritdoc/>
		public override Boolean TrySeek(nint offset, out Errors error) => throw new NotImplementedException();

		/// <inheritdoc/>
		public Boolean TryWrite(Rune element, out Errors error) {
			position++;
			return Codec.TryWrite(element, out error);
		}

		/// <inheritdoc/>
		public void Write(Rune element) {
			position++;
			Codec.Write(element);
		}

		private void ConfirmEncoding(Encoding encoding) {
			if (codec is null) {
				return;
			}
			if (TryReadBOM(out Encoding bom, out Errors error)) {
				if (encoding != bom) {
					throw new InvalidOperationException();
				}
			}
		}

		/// <summary>
		/// Gets the <see cref="Stringier.Encodings.Codec"/> associated with the <paramref name="encoding"/>.
		/// </summary>
		/// <param name="encoding">The <see cref="Stringier.Encodings.Encoding"/> designator.</param>
		/// <returns>The associated <see cref="Stringier.Encodings.Codec"/>.</returns>
		[return: MaybeNull]
		private Codec GetCodec(Encoding encoding) => encoding switch {
			Encoding.UTF8 => new UTF8Codec(ReadBuffer, WriteBuffer),
			Encoding.UTF16BE => new UTF16BECodec(ReadBuffer, WriteBuffer),
			Encoding.UTF16LE => new UTF16LECodec(ReadBuffer, WriteBuffer),
			Encoding.UTF32BE => new UTF32BECodec(ReadBuffer, WriteBuffer),
			Encoding.UTF32LE => new UTF32LECodec(ReadBuffer, WriteBuffer),
			_ => null
		};

		private Boolean TryReadBOM(out Encoding encoding, out Errors error) {
			if (ReadBuffer.TryEnsureLoaded(4, out error)) {
				if (ReadBuffer.Equals(UTF8.BOM)) {
					ReadBuffer.ShiftLeft(3);
					encoding = Encoding.UTF8;
				} else if (ReadBuffer.Equals(UTF32.LE.BOM)) {
					ReadBuffer.ShiftLeft(4);
					encoding = Encoding.UTF32LE;
				} else if (ReadBuffer.Equals(UTF32.BE.BOM)) {
					ReadBuffer.ShiftLeft(4);
					encoding = Encoding.UTF32BE;
				} else if (ReadBuffer.Equals(UTF16.LE.BOM)) {
					ReadBuffer.ShiftLeft(2);
					encoding = Encoding.UTF16LE;
				} else if (ReadBuffer.Equals(UTF16.BE.BOM)) {
					ReadBuffer.ShiftLeft(2);
					encoding = Encoding.UTF16BE;
				} else {
					encoding = Encoding.Unknown;
					return false;
				}
				return true;
			} else {
				encoding = Encoding.Unknown;
				return false;
			}
		}
	}
}
