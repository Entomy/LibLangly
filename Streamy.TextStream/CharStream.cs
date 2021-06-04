using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Streamy.Bases;
using Streamy.Buffers;
using Stringier;

namespace Streamy {
	/// <summary>
	/// Provides a view of a sequence of <see cref="Char"/>.
	/// </summary>
	/// <remarks>
	/// <para>This is a specialization of <see cref="Stream"/>, and as such, everything for <see cref="Stream"/> applies here as well.</para>
	/// <para>Additional orchestration can be added by deriving from this type. However, most applications will not need to do this. Support for additional types should be done through the serialization mechanism.</para>
	/// </remarks>
	public class CharStream : Stream, IPeek<Char>, ISeek, IWrite<Char> {
		/// <summary>
		/// The position within the datastream, counted by a <see cref="Char"/> offset from the start.
		/// </summary>
		private nint position = 0;

		/// <summary>
		/// Initializes a new <see cref="CharStream"/> over the given <paramref name="array"/>.
		/// </summary>
		/// <param name="array">The <see cref="Array"/> of <see cref="Byte"/> to stream.</param>
		public CharStream([AllowNull] Byte[] array) : this(array, BitConverter.IsLittleEndian ? Encoding.UTF16LE : Encoding.UTF16BE) { }

		/// <summary>
		/// Initializes a new <see cref="CharStream"/> over the given <paramref name="array"/>.
		/// </summary>
		/// <param name="array">The <see cref="Array"/> of <see cref="Byte"/> to stream.</param>
		/// <param name="encoding">The encoding of the <paramref name="array"/>.</param>
		public CharStream([AllowNull] Byte[] array, Encoding encoding) : base(array, encoding.Endianness()) => Encoding = encoding;

		/// <summary>
		/// Initializes a new <see cref="CharStream"/> over the given <paramref name="memory"/>.
		/// </summary>
		/// <param name="memory">The <see cref="Memory{T}"/> of <see cref="Byte"/> to stream.</param>
		public CharStream(Memory<Byte> memory) : this(memory, BitConverter.IsLittleEndian ? Encoding.UTF16LE : Encoding.UTF16BE) { }

		/// <summary>
		/// Initializes a new <see cref="CharStream"/> over the given <paramref name="memory"/>.
		/// </summary>
		/// <param name="memory">The <see cref="Memory{T}"/> of <see cref="Byte"/> to stream.</param>
		/// <param name="encoding">The encoding of the <paramref name="memory"/>.</param>
		public CharStream(Memory<Byte> memory, Encoding encoding) : base(memory, encoding.Endianness()) => Encoding = encoding;

		/// <summary>
		/// Initializes a new <see cref="CharStream"/> over the given <paramref name="memory"/>.
		/// </summary>
		/// <param name="memory">The <see cref="ReadOnlyMemory{T}"/> of <see cref="Byte"/> to stream.</param>
		public CharStream(ReadOnlyMemory<Byte> memory) : this(memory, BitConverter.IsLittleEndian ? Encoding.UTF16LE : Encoding.UTF16BE) { }

		/// <summary>
		/// Initializes a new <see cref="CharStream"/> over the given <paramref name="memory"/>.
		/// </summary>
		/// <param name="memory">The <see cref="ReadOnlyMemory{T}"/> of <see cref="Byte"/> to stream.</param>
		/// <param name="encoding">The encoding of the <paramref name="memory"/>.</param>
		public CharStream(ReadOnlyMemory<Byte> memory, Encoding encoding) : base(memory, encoding.Endianness()) => Encoding = encoding;

		/// <summary>
		/// Initializes a new <see cref="CharStream"/> with the given <paramref name="base"/>, <paramref name="readBuffer"/>, and <paramref name="writeBuffer"/>.
		/// </summary>
		/// <param name="base">The <see cref="StreamBase"/> of this <see cref="CharStream"/>.</param>
		/// <param name="readBuffer">The buffer used for reads.</param>
		/// <param name="writeBuffer">The buffer used for writes.</param>
		/// <param name="encoding">The encoding of the underlying data.</param>
		[CLSCompliant(false)]
		protected CharStream([DisallowNull] StreamBase @base, [DisallowNull] IReadBuffer readBuffer, [AllowNull] IWriteBuffer writeBuffer, Encoding encoding) : base(@base, readBuffer, writeBuffer, encoding.Endianness()) => Encoding = encoding;

		/// <summary>
		/// The <see cref="Streamy.Encoding"/> of this stream.
		/// </summary>
		public Encoding Encoding { get; }

		/// <inheritdoc/>
		nint ISeek.Position {
			get => Position;
			set => Position = value;
		}

		/// <summary>
		/// The position within the datastream, counted by a <see cref="Char"/> offset from the start.
		/// </summary>
		new public nint Position {
			get => position;
			set {
				switch (Encoding) {
				case Encoding.UTF16BE:
				case Encoding.UTF16LE:
					base.Position = value * 2;
					break;
				default:
					throw new NotSupportedException($"Not sure how to seek '{Encoding}' encoded streams.");
				}
				position = value;
			}
		}

		/// <inheritdoc/>
		public void Add(Char element) => Write(element);

		/// <inheritdoc/>
		public void Peek(out Char element) {
			switch (Encoding) {
			case Encoding.UTF16BE:
			case Encoding.UTF16LE:
				Peek(out Int16 elmt);
				element = (Char)elmt;
				break;
			default:
				throw new NotSupportedException($"Not sure how to read '{Encoding}' encoded streams.");
			}
		}

		/// <inheritdoc/>
		public void Read(out Char element) {
			Peek(out element);
			Source.ShiftLeft(sizeof(Char));
		}

		/// <inheritdoc/>
		void ISeek.Seek(nint offset) => Seek(offset);

		/// <summary>
		/// Seeks to the <paramref name="offset"/>, counted by <see cref="Byte"/>.
		/// </summary>
		/// <param name="offset">The amount of <see cref="Byte"/> to seek.</param>
		new public void Seek(nint offset) {
			switch (Encoding) {
			case Encoding.UTF16BE:
			case Encoding.UTF16LE:
				base.Seek(offset * 2);
				break;
			default:
				throw new NotSupportedException($"Not sure how to seek '{Encoding}' encoded streams.");
			}
			position += offset;
		}

		/// <inheritdoc/>
		public void Write(Char element) {
			switch (Encoding) {
			case Encoding.UTF16BE:
			case Encoding.UTF16LE:
				Write((Int16)element);
				break;
			default:
				throw new NotSupportedException($"Not sure how to write '{Encoding}' encoded streams.");
			}
		}
	}
}
