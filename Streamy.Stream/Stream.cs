using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Streamy.Bases;
using Streamy.Buffers;

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
	[SuppressMessage("Major Code Smell", "S3881:\"IDisposable\" should be implemented correctly", Justification = "We're using a slight variation of it that makes it safer to extend. Sonar doesn't understand that.")]
	public partial class Stream : IControlled {
		/// <summary>
		/// The <see cref="StreamBase"/> of this <see cref="Stream"/>.
		/// </summary>
		[SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP008:Don't assign member with injected and created disposables.", Justification = "We're claiming ownership. A derived class can internally assign this during construction, but it would be an error to set this externally. It's readonly, so there's no resassignment errors. Just have to content with potentially stupid but bizarre derived class behavior.")]
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
		[SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP003:Dispose previous before re-assigning.", Justification = "This is a constructor, it hasn't been assigned yet.")]
		public Stream([AllowNull] Byte[] array) {
			Base = new MemoryStreamBase(array);
			ReadBuffer = new MinimalBuffer(Base);
			WriteBuffer = null;
			Endianness = BitConverter.IsLittleEndian ? Endian.Little : Endian.Big;
		}

		/// <summary>
		/// Initializes a new <see cref="Stream"/> over the given <paramref name="memory"/>.
		/// </summary>
		/// <param name="memory">The <see cref="Memory{T}"/> of <see cref="Byte"/> to stream.</param>
		[SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP003:Dispose previous before re-assigning.", Justification = "This is a constructor, it hasn't been assigned yet.")]
		public Stream(Memory<Byte> memory) {
			Base = new MemoryStreamBase(memory);
			ReadBuffer = new MinimalBuffer(Base);
			WriteBuffer = null;
			Endianness = BitConverter.IsLittleEndian ? Endian.Little : Endian.Big;
		}

		/// <summary>
		/// Initializes a new <see cref="Stream"/> over the given <paramref name="memory"/>.
		/// </summary>
		/// <param name="memory">The <see cref="ReadOnlyMemory{T}"/> of <see cref="Byte"/> to stream.</param>
		[SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP003:Dispose previous before re-assigning.", Justification = "This is a constructor, it hasn't been assigned yet.")]
		public Stream(ReadOnlyMemory<Byte> memory) {
			Base = new ReadOnlyMemoryStreamBase(memory);
			ReadBuffer = new MinimalBuffer(Base);
			WriteBuffer = null;
			Endianness = BitConverter.IsLittleEndian ? Endian.Little : Endian.Big;
		}

		/// <summary>
		/// Initializes a new <see cref="Stream"/> with the given <paramref name="base"/>, the minimum necessary buffers, and the system endianness.
		/// </summary>
		/// <param name="base">The <see cref="StreamBase"/> of this <see cref="Stream"/>.</param>
		/// <remarks>
		/// This should only be used for derived classes that are <see langword="sealed"/> and will not need a buffer in most situations. In practice, this is rarely the case, and you should chain with <see cref="Stream(StreamBase, IReadBuffer, IWriteBuffer, Endian)"/> instead.
		/// </remarks>
		protected Stream([DisallowNull] StreamBase @base) : this(@base, new MinimalBuffer(@base), null, BitConverter.IsLittleEndian ? Endian.Little : Endian.Big) { }

		/// <summary>
		/// Initializes a new <see cref="Stream"/> with the given <paramref name="base"/>, <paramref name="readBuffer"/>, <paramref name="writeBuffer"/>, and <paramref name="endianness"/>.
		/// </summary>
		/// <param name="base">The <see cref="StreamBase"/> of this <see cref="Stream"/>.</param>
		/// <param name="readBuffer">The buffer used for reads.</param>
		/// <param name="writeBuffer">The buffer used for writes.</param>
		/// <param name="endianness">The byte ordering of this stream.</param>
		/// <remarks>
		/// This is the intended constructor for chaining with derived classes.
		/// </remarks>
		[SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP003:Dispose previous before re-assigning.", Justification = "This is a constructor, it hasn't been assigned yet.")]
		[CLSCompliant(false)]
		protected Stream([DisallowNull] StreamBase @base, [DisallowNull] IReadBuffer readBuffer, [AllowNull] IWriteBuffer writeBuffer, Endian endianness) {
			Base = @base;
			ReadBuffer = readBuffer;
			WriteBuffer = writeBuffer;
			Endianness = endianness;
		}

		/// <inheritdoc/>
		[SuppressMessage("Design", "MA0055:Do not use finalizer", Justification = "This is part of the correct IDisposable pattern")]
		~Stream() => Dispose(disposing: false);

		/// <inheritdoc/>
		Boolean IControlled.Disposed {
			get => Disposed;
			set => Disposed = value;
		}

		/// <summary>
		/// Used to detect and handle redundant calls to <see cref="Dispose(Boolean)"/>.
		/// </summary>
		protected Boolean Disposed {
			get => Base.Disposed;
			set => Base.Disposed = value;
		}

		/// <summary>
		/// The byte ordering of this stream.
		/// </summary>
		public Endian Endianness { get; }

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
		void IControlled.Dispose(Boolean disposing) => Dispose(disposing);

		/// <inheritdoc/>
		void IDisposable.Dispose() {
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		/// <inheritdoc/>
		void IControlled.DisposeManaged() => DisposeManaged();

		/// <inheritdoc/>
		void IControlled.DisposeUnmanaged() => DisposeUnmanaged();

		/// <inheritdoc/>
		void IControlled.NullLargeFields() => NullLargeFields();

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Base.ToString();

		/// <summary>
		/// Dispose of managed resources. Part of <see cref="IDisposable.Dispose()"/>.
		/// </summary>
		protected virtual void DisposeManaged() {  /* No-op */ }

		/// <summary>
		/// Dispose of unmanaged resources. Part of <see cref="IDisposable.Dispose()"/>.
		/// </summary>
		protected virtual void DisposeUnmanaged() {  /* No-op */ }

		/// <summary>
		/// Null out large fields. Part of <see cref="IDisposable.Dispose()"/>.
		/// </summary>
		protected virtual void NullLargeFields() {  /* No-op */ }

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		/// <param name="disposing">Whether managed resources should be disposed.</param>
		private void Dispose(Boolean disposing) {
			if (!Disposed) {
				if (disposing) {
					Base.Dispose();
					DisposeManaged();
				}
				DisposeUnmanaged();
				NullLargeFields();
				Disposed = true;
			}
		}
	}
}
