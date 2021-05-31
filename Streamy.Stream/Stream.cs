using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Collectathon.Buffers;
using Streamy.Bases;

namespace Streamy {
	/// <summary>
	/// Provides a view of a sequence of <see cref="Byte"/>.
	/// </summary>
	/// <remarks>
	/// <para>This fundamentally operates differently from <see cref="System.IO.Stream"/>. While it is designed fairly similar in API, the way it operates, even at that level, differs greatly. There's three major components that make up the byte stream:</para>
	/// <para>This <see cref="Stream"/> type provides orchestration logic around the other components, tying everything together. Through those, it provides a low level, byte-centric, API.</para>
	/// <para>The actual datastream is provided by <see cref="StreamBase"/>, which implements the basic streaming API for the daatastream. Supporting additional stream types can be done by extended <see cref="StreamBase"/>, which greatly simplifies adding new datastreams.</para>
	/// <para>Buffers are provided by implementers of <see cref="IReadBuffer"/> and <see cref="IWriteBuffer"/>, which buffer the basic streaming from <see cref="StreamBase"/>, enabling features like <see cref="IPeek{TElement}.Peek(out TElement)"/> and limited <see cref="ISeek"/> behavior even when the underlying stream is not capable.</para>
	/// <para>Additional orchestration can be added by deriving from this type. However, most applications will not need to do this. Support for additional types should be done through the serialization mechanism.</para>
	/// </remarks>
	public partial class Stream {
		/// <summary>
		/// The <see cref="StreamBase"/> of this <see cref="Stream"/>.
		/// </summary>
		[DisallowNull, NotNull]
		protected readonly StreamBase Base;

		/// <summary>
		/// The buffer used for reads.
		/// </summary>
		[CLSCompliant(false)]
		[DisallowNull, NotNull]
		protected readonly IReadBuffer ReadBuffer;

		/// <summary>
		/// The buffer used for writes.
		/// </summary>
		/// <remarks>
		/// This can be <see langword="null"/>, in which case no buffering is done, and writes occur directly to <see cref="Base"/>.
		/// </remarks>
		[CLSCompliant(false)]
		[AllowNull, MaybeNull]
		protected readonly IWriteBuffer WriteBuffer;

		/// <summary>
		/// Initializes a new <see cref="Stream"/> over the given <paramref name="array"/>.
		/// </summary>
		/// <param name="array">The <see cref="Array"/> of <see cref="Byte"/> to stream.</param>
		public Stream([AllowNull] Byte[] array) {
			Base = new MemoryStreamBase(array);
			ReadBuffer = new MinimalBuffer(Base);
			WriteBuffer = null;
		}

		/// <summary>
		/// Initializes a new <see cref="Stream"/> over the given <paramref name="memory"/>.
		/// </summary>
		/// <param name="memory">The <see cref="Memory{T}"/> of <see cref="Byte"/> to stream.</param>
		public Stream(Memory<Byte> memory) {
			Base = new MemoryStreamBase(memory);
			ReadBuffer = new MinimalBuffer(Base);
			WriteBuffer = null;
		}

		/// <summary>
		/// Initializes a new <see cref="Stream"/> over the given <paramref name="memory"/>.
		/// </summary>
		/// <param name="memory">The <see cref="ReadOnlyMemory{T}"/> of <see cref="Byte"/> to stream.</param>
		public Stream(ReadOnlyMemory<Byte> memory) {
			Base = new ReadOnlyMemoryStreamBase(memory);
			ReadBuffer = new MinimalBuffer(Base);
			WriteBuffer = null;
		}

		/// <summary>
		/// Initializes a new <see cref="Stream"/> with the given <paramref name="base"/>.
		/// </summary>
		/// <param name="base">The <see cref="StreamBase"/> of this <see cref="Stream"/>.</param>
		[CLSCompliant(false)]
		protected Stream([DisallowNull] StreamBase @base) {
			Base = @base;
			ReadBuffer = new MinimalBuffer(Base);
			WriteBuffer = null;
		}

		/// <summary>
		/// Initializes a new <see cref="Stream"/> with the given <paramref name="base"/>, <paramref name="readBuffer"/>, and <paramref name="writeBuffer"/>.
		/// </summary>
		/// <param name="base">The <see cref="StreamBase"/> of this <see cref="Stream"/>.</param>
		/// <param name="readBuffer">The buffer used for reads.</param>
		/// <param name="writeBuffer">The buffer used for writes.</param>
		[CLSCompliant(false)]
		protected Stream([DisallowNull] StreamBase @base, [DisallowNull] IReadBuffer readBuffer, [AllowNull] IWriteBuffer writeBuffer) {
			Base = @base;
			ReadBuffer = readBuffer;
			WriteBuffer = writeBuffer;
		}

		/// <summary>
		/// Streams the <paramref name="array"/>.
		/// </summary>
		/// <param name="array">The <see cref="Array"/> of <see cref="Byte"/> to stream.</param>
		public static implicit operator Stream([AllowNull] Byte[] array) => new Stream(array);

		/// <summary>
		/// Streams the <paramref name="memory"/>.
		/// </summary>
		/// <param name="memory">The <see cref="Memory{T}"/> of <see cref="Byte"/> to stream.</param>
		public static implicit operator Stream(Memory<Byte> memory) => new Stream(memory);

		/// <summary>
		/// Streams the <paramref name="memory"/>.
		/// </summary>
		/// <param name="memory">The <see cref="ReadOnlyMemory{T}"/> of <see cref="Byte"/> to stream.</param>
		public static implicit operator Stream(ReadOnlyMemory<Byte> memory) => new Stream(memory);

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Base.ToString();
	}
}
