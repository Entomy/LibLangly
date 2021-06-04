using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Streamy.Bases;
using Streamy.Buffers;

namespace Streamy {
	/// <summary>
	/// Provides a view of a sequence of <see cref="Char"/>.
	/// </summary>
	/// <remarks>
	/// <para>This is a specialization of <see cref="Stream"/>, and as such, everything for <see cref="Stream"/> applies here as well. There's one additional component that makes up a text stream:</para>
	/// <para>Encoders are injected through helper objects.</para>
	/// <para>Additional orchestration can be added by deriving from this type. However, most applications will not need to do this. Support for additional types should be done through the serialization mechanism.</para>
	/// </remarks>
	public partial class CharStream : Stream, IPeek<Char>, ISeek, IWrite<Char> {
		/// <summary>
		/// Initializes a new <see cref="CharStream"/> over the given <paramref name="string"/>.
		/// </summary>
		/// <param name="string">The <see cref="String"/> to stream.</param>
		public CharStream([AllowNull] String @string) : this(new ReadOnlyMemoryCharStreamBase(@string.AsMemory())) { }

		/// <summary>
		/// Initializes a new <see cref="CharStream"/> over the given <paramref name="array"/>.
		/// </summary>
		/// <param name="array">The <see cref="Array"/> of <see cref="Char"/> to stream.</param>
		public CharStream([AllowNull] Char[] array) : this(new MemoryCharStreamBase(array)) { }

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
		/// <param name="memory">The <see cref="Memory{T}"/> of <see cref="Char"/> to stream.</param>
		public CharStream(Memory<Char> memory) : this(new MemoryCharStreamBase(memory)) { }

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
		/// <param name="memory">The <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> to stream.</param>
		public CharStream(ReadOnlyMemory<Char> memory) : this(new ReadOnlyMemoryCharStreamBase(memory)) { }

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
		/// Initializes a new <see cref="CharStream"/> with the given <paramref name="base"/>.
		/// </summary>
		/// <param name="base">The <see cref="CharStreamBase"/> of this <see cref="CharStream"/>.</param>
		/// <remarks>This is necessary for setting everything up because we can't initialize the buffers inside this constructor body, because it's already readonly by this point. But we also need to be able to reference the <see cref="CharStreamBase"/>, which the public constructors can't do. This serves as an intermediary, allowing good immutable design while also not piling on responsibility to downstream.</remarks>
		private CharStream([DisallowNull] CharStreamBase @base) :
			base(@base, new MinimalCharBuffer(@base), null, BitConverter.IsLittleEndian ? Endian.Little : Endian.Big)
			=> Encoding = BitConverter.IsLittleEndian ? Encoding.UTF16LE : Encoding.UTF16BE;

		/// <summary>
		/// The <see cref="Streamy.Encoding"/> of this stream.
		/// </summary>
		public Encoding Encoding { get; }
	}
}
