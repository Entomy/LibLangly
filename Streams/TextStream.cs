using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Defender;

namespace Stringier.Streams {
	/// <summary>
	/// Provides a view of a sequence of characters.
	/// </summary>
	/// <remarks>
	/// This wraps up a <see cref="Stream"/> in a way that reframes the underlying <typeparamref name="S"/> as a stream of <see cref="Char"/>.
	/// </remarks>
	/// <typeparam name="S"></typeparam>
	public sealed class TextStream<S> : Stream where S : Stream {
		/// <summary>
		/// The underlying <see cref="Stream"/>.
		/// </summary>
		private readonly S BaseStream;

		/// <summary>
		/// Initializes a new instance of the <see cref="TextStream{S}"/> class.
		/// </summary>
		/// <param name="stream"></param>
		public TextStream(S stream) => BaseStream = stream;

		/// <summary>
		/// When overridden in <typeparamref name="S"/>, gets a value indicating whether the current stream supports reading.
		/// </summary>
		/// <value><see langword="true"/> if the stream supports reading; otherwise, <see langword="false"/>.</value>
		public override Boolean CanRead => BaseStream.CanRead;

		/// <summary>
		/// When overridden in <typeparamref name="S"/>, gets a value indicating whether the current stream supports seeking.
		/// </summary>
		/// <value><see langword="true"/> if the stream supports seeking; otherwise, <see langword="false"/>.</value>
		public override Boolean CanSeek => BaseStream.CanSeek;

		/// <summary>
		/// When overridden in <typeparamref name="S"/>, gets a value indicating whether the current stream can timeout.
		/// </summary>
		/// <value><see langword="true"/> if the stream can timeout; otherwise, <see langword="false"/>.</value>
		public override Boolean CanTimeout => BaseStream.CanTimeout;

		/// <summary>
		/// When overridden in <typeparamref name="S"/>, gets a value indicating whether the current stream supports writing.
		/// </summary>
		/// <value><see langword="true"/> if the stream supports writing; otherwise, <see langword="false"/>.</value>
		public override Boolean CanWrite => BaseStream.CanWrite;

		/// <summary>
		/// When overridden in <typeparamref name="S"/>, gets the length in bytes of the stream.
		/// </summary>
		/// <value>A long value representing the length of the stream in bytes.</value>
		/// <exception cref="NotSupportedException"><typeparamref name="S"/> does not support seeking.</exception>
		/// <exception cref="ObjectDisposedException">Methods were called after the stream was closed.</exception>
		public override Int64 Length => BaseStream.Length;

		/// <summary>
		/// When overridden in <typeparamref name="S"/>, gets or sets the position within the current stream.
		/// </summary>
		/// <value>The current position within the stream.</value>
		/// <exception cref="IOException">An I/O error occurs.</exception>
		/// <exception cref="NotSupportedException">The stream does not support seeking.</exception>
		/// <exception cref="ObjectDisposedException">Methods were called after the stream was closed.</exception>
		public override Int64 Position {
			get => BaseStream.Position;
			set => BaseStream.Position = value;
		}

		/// <summary>
		/// Gets or sets a value, in milliseconds, that determines how long the stream will attempt to read before timing out.
		/// </summary>
		/// <value>A value, in milliseconds, that determines how long the stream will attempt to read before timing out.</value>
		public override Int32 ReadTimeout {
			get => BaseStream.ReadTimeout;
			set => BaseStream.ReadTimeout = value;
		}

		/// <summary>
		/// Gets or sets a value, in milliseconds, that determines how long the stream will attempt to write before timing out.
		/// </summary>
		/// <value>A value, in milliseconds, that determines how long the stream will attempt to write before timing out.</value>
		public override Int32 WriteTimeout {
			get => BaseStream.WriteTimeout;
			set => BaseStream.WriteTimeout = value;
		}

		/// <summary>
		/// Begins an asynchronous read operation. (Consider using <see cref="ReadAsync(byte[], int, int, CancellationToken)"/> instead.)
		/// </summary>
		/// <param name="buffer">The buffer to read the data into.</param>
		/// <param name="offset">The byte offset in <paramref name="buffer"/> at which to begin writing data read from the stream.</param>
		/// <param name="count">The maximum number of bytes to read.</param>
		/// <param name="callback">An optional asynchronous callback, to be called when the read is complete.</param>
		/// <param name="state">A user-provided object that distinguishes this particular asynchronous read request from other requests.</param>
		/// <returns>An <see cref="IAsyncResult"/> that represents the asynchronous read, which could still be pending.</returns>
		/// <exception cref="IOException">Attempted an asynchronous read past the end of the stream, or a disk error occurs.</exception>
		/// <exception cref="ArgumentException">One or more of the arguments is invalid.</exception>
		/// <exception cref="ObjectDisposedException">Methods were called after the stream was closed.</exception>
		/// <exception cref="NotSupportedException">The current <typeparamref name="S"/> implementation does not support the read operation.</exception>
		public override IAsyncResult BeginRead(Byte[] buffer, Int32 offset, Int32 count, AsyncCallback callback, Object? state) => BaseStream.BeginRead(buffer, offset, count, callback, state);

		/// <summary>
		/// Begins an asynchronous write operation. (Consider using <see cref="WriteAsync(byte[], int, int, CancellationToken)"/> instead.)
		/// </summary>
		/// <param name="buffer">The buffer to write data from.</param>
		/// <param name="offset">The byte offset in <paramref name="buffer"/> from which to begin writing.</param>
		/// <param name="count">The maximum number of bytes to write.</param>
		/// <param name="callback">An optional asynchronous callback, to be called when the write is complete.</param>
		/// <param name="state">A user-provided object that distinguishes this particular asynchronous write request from other requests.</param>
		/// <returns>An <see cref="IAsyncResult"/> that represents the asynchronous write, which could still be pending.</returns>
		/// <exception cref="IOException">Attempted an asynchronous write past the end of the stream, or a disk error occurs.</exception>
		/// <exception cref="ArgumentException">One or more of the arguments is invalid.</exception>
		/// <exception cref="ObjectDisposedException">Methods were called after the stream was closed.</exception>
		/// <exception cref="NotSupportedException">The current <typeparamref name="S"/> implementation does not support the write operation.</exception>
		public override IAsyncResult BeginWrite(Byte[] buffer, Int32 offset, Int32 count, AsyncCallback callback, Object? state) => BaseStream.BeginWrite(buffer, offset, count, callback, state);

		/// <summary>
		/// Closes the current stream and releases any resources (such as sockets and file handles) associated with the current stream. Instead of calling this method, ensure that the stream is properly disposed.
		/// </summary>
		public override void Close() => BaseStream.Close();

		/// <summary>
		/// Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified buffer size and cancellation token.
		/// </summary>
		/// <param name="destination">The stream to which the contents of the current stream will be copied.</param>
		/// <param name="bufferSize">The size, in bytes, of the buffer. This value must be greater than zero. The default size is 81920.</param>
		/// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
		/// <returns>A task that represents the asynchronous copy operation.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="destination"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="bufferSize"/> is negative or zero.</exception>
		/// <exception cref="ObjectDisposedException">Either the current stream or the destination stream is disposed.</exception>
		/// <exception cref="NotSupportedException">The current stream does not support reading, or the destination stream does not support writing.</exception>
		public override Task CopyToAsync(Stream destination, Int32 bufferSize, CancellationToken cancellationToken) {
			Guard.NotNull(destination, nameof(destination));
			return BaseStream.CopyToAsync(destination, bufferSize, cancellationToken);
		}

		/// <summary>
		/// Waits for the pending asynchronous read to complete. (Consider using <see cref="ReadAsync(byte[], int, int, CancellationToken)"/> instead.)
		/// </summary>
		/// <param name="asyncResult">The reference to the pending asynchronous request to finish.</param>
		/// <returns>The number of bytes read from the stream, between zero (0) and the number of bytes you requested. Streams return zero (0) only at the end of the stream, otherwise, they should block until at least one byte is available.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="asyncResult"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException">
		/// <para>A handle to the pending read operation is not available.</para>
		/// -or-
		/// <para>The pending operation does not support reading.</para>
		/// </exception>
		/// <exception cref="InvalidOperationException"><paramref name="asyncResult"/> did not originate from a <see cref="BeginRead(byte[], int, int, AsyncCallback, object)"/> method on the current stream.</exception>
		/// <exception cref="IOException">The stream is closed or an internal error has occurred.</exception>
		public override Int32 EndRead(IAsyncResult asyncResult) {
			Guard.NotNull(asyncResult, nameof(asyncResult));
			return BaseStream.EndRead(asyncResult);
		}

		/// <summary>
		/// Ends an asyncrhonous write operation. (Consider using <see cref="WriteAsync(byte[], int, int, CancellationToken)"/> instead.)
		/// </summary>
		/// <param name="asyncResult">A reference to the outstanding asynchronous I/O request.</param>
		/// <exception cref="ArgumentNullException"><paramref name="asyncResult"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException">
		/// <para>A handle to the pending write operation is not available.</para>
		/// -or-
		/// <para>The pending operation does not support writing.</para>
		/// </exception>
		/// <exception cref="InvalidOperationException"><paramref name="asyncResult"/> did not originate from a <see cref="BeginWrite(byte[], int, int, AsyncCallback, object)"/> method on the current stream.</exception>
		/// <exception cref="IOException">The stream is closed or an internal error has occurred.</exception>
		public override void EndWrite(IAsyncResult asyncResult) {
			Guard.NotNull(asyncResult, nameof(asyncResult));
			BaseStream.EndWrite(asyncResult);
		}

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public override Boolean Equals(Object? obj) => BaseStream.Equals(obj);

		/// <summary>
		/// When overridden in a derived class, clears all buffers for this stream and causes any buffered data to be written to the underlying device.
		/// </summary>
		/// <exception cref="IOException">An I/O error occurs.</exception>
		public override void Flush() => BaseStream.Flush();

		/// <summary>
		/// Asynchronously clears all buffers for this stream, causes any buffered data to be written to the underlying device, and monitors cancellation requests.
		/// </summary>
		/// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
		/// <returns>A task that represents the asynchronous flush operation.</returns>
		/// <exception cref="ObjectDisposedException">The stream has been disposed.</exception>
		public override Task FlushAsync(CancellationToken cancellationToken) => BaseStream.FlushAsync(cancellationToken);

		/// <summary>
		/// Serves as the default hash function.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override Int32 GetHashCode() => BaseStream.GetHashCode();

		/// <summary>
		/// Obtains a lifetime service object to control the lifetime policy for this instance.
		/// </summary>
		/// <returns>An object of type ILease used to control the lifetime policy for this instance. This is the current lifetime service object for this instance if one exists; otherwise, a new lifetime service object initialized to the value of the LeaseManagerPollTime property.</returns>
		public override Object InitializeLifetimeService() => BaseStream.InitializeLifetimeService();

		/// <summary>
		/// When overridden in a derived class, reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read. 
		/// </summary>
		/// <param name="buffer">An array of bytes. When this method returns, the buffer contains the specified byte array with the values between <paramref name="offset"/> and (<paramref name="offset"/> + <paramref name="count"/> - 1) replaced by the bytes read from the current source.</param>
		/// <param name="offset">The zero-based byte offset in <paramref name="buffer"/> at which to begin storing the data read from the current stream.</param>
		/// <param name="count">The maximum number of bytes to be read from the current stream.</param>
		/// <returns>The total number of bytes read into the buffer. This can be less than the number of bytes requested if that many bytes are not currently available, or zero (0) if the end of the stream has been reached.</returns>
		public override Int32 Read(Byte[] buffer, Int32 offset, Int32 count) => BaseStream.Read(buffer, offset, count);

		/// <summary>
		/// Asynchronously reads a sequence of bytes from the current stream, advances the position within the stream by the number of bytes read, and monitors cancellation requests.
		/// </summary>
		/// <param name="buffer">The buffer to write the data into.</param>
		/// <param name="offset">The byte offset in <paramref name="buffer"/> at which to begin writing data from the stream.</param>
		/// <param name="count">The maximum number of bytes to read.</param>
		/// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
		/// <returns>A task that represents the asynchronous read operation. The value of the TResult parameter contains the total number of bytes read into the buffer. The result value can be less than the number of bytes requested if the number of bytes currently available is less than the requested number, or it can be 0 (zero) if the end of the stream has been reached.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="buffer"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="offset"/> or <paramref name="count"/> is negative.</exception>
		/// <exception cref="ArgumentException">The sum of <paramref name="offset"/> and <paramref name="count"/> is larger than the buffer length.</exception>
		/// <exception cref="NotSupportedException">The stream does not support reading.</exception>
		/// <exception cref="ObjectDisposedException">The stream has been disposed.</exception>
		/// <exception cref="InvalidOperationException">The stream is currently in use by a previous read operation.</exception>
		public override Task<Int32> ReadAsync(Byte[] buffer, Int32 offset, Int32 count, CancellationToken cancellationToken) => BaseStream.ReadAsync(buffer, offset, count, cancellationToken);

		/// <summary>
		/// Reads a byte from the stream and advances the position within the stream by one byte, or returns -1 if at the end of the stream.
		/// </summary>
		/// <returns>The unsigned byte cast to an <see cref="Int32"/>, or -1 if at the end of the stream.</returns>
		/// <exception cref="NotSupportedException">The stream does not support reading.</exception>
		/// <exception cref="ObjectDisposedException">Methods were called after the stream was closed.</exception>
		public override Int32 ReadByte() => BaseStream.ReadByte();

		/// <summary>
		/// When overridden in a derived class, sets the position within the current stream.
		/// </summary>
		/// <param name="offset">A byte offset relative to the origin parameter.</param>
		/// <param name="origin">A value of type <see cref="SeekOrigin"/> indicating the reference point used to obtain the new position.</param>
		/// <returns>The new position within the current stream.</returns>
		/// <exception cref="IOException">An I/O error occurs.</exception>
		/// <exception cref="NotSupportedException">The stream does not support seeking, such as if the stream is constructed from a pipe or console output.</exception>
		/// <exception cref="ObjectDisposedException">Methods were called after the stream was closed.</exception>
		public override Int64 Seek(Int64 offset, SeekOrigin origin) => BaseStream.Seek(offset, origin);

		/// <summary>
		/// When overridden in a derived class, sets the length of the current stream.
		/// </summary>
		/// <param name="value">The desired length of the current stream in bytes.</param>
		/// <exception cref="IOException">An I/O error occurs.</exception>
		/// <exception cref="NotSupportedException">The stream does not support both writing and seeking, such as if the stream is constructed from a pipe or console output.</exception>
		/// <exception cref="ObjectDisposedException">Methods were called after the stream was closed.</exception>
		public override void SetLength(Int64 value) => BaseStream.SetLength(value);

		/// <summary>
		/// When overridden in a derived class, writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written.
		/// </summary>
		/// <param name="buffer">An array of bytes. This method copies <paramref name="count"/> bytes from <paramref name="buffer"/> to the current stream.</param>
		/// <param name="offset">The zero-based byte offset in <paramref name="buffer"/> at which to begin copying bytes to the current stream.</param>
		/// <param name="count">The number of bytes to be written to the current stream.</param>
		/// <exception cref="ArgumentException">The sum of <paramref name="offset"/> and <paramref name="count"/> is greater than the buffer length.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="buffer"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="offset"/> or <paramref name="count"/> is negative.</exception>
		/// <exception cref="IOException">An I/O error occurred, such as the specified file cannot be found.</exception>
		/// <exception cref="NotSupportedException">The stream does not support writing.</exception>
		/// <exception cref="ObjectDisposedException"><see cref="Write(byte[], int, int)"/> was called after the stream was closed.</exception>
		public override void Write(Byte[] buffer, Int32 offset, Int32 count) => BaseStream.Write(buffer, offset, count);

		/// <summary>
		/// Asynchronously writes a sequence of bytes to the current stream, advances the current position within this stream by the number of bytes written, and monitors cancellation requests.
		/// </summary>
		/// <param name="buffer">The buffer to write data from.</param>
		/// <param name="offset">The zero-based byte offset in <paramref name="buffer"/> from which to begin copying bytes to the stream.</param>
		/// <param name="count">The maximum number of bytes to write.</param>
		/// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
		/// <returns>A task that represents the asynchronous write operation.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="buffer"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="offset"/> or <paramref name="count"/> is negative.</exception>
		/// <exception cref="ArgumentException">The sum of <paramref name="offset"/> and <paramref name="count"/> is larger than the buffer length.</exception>
		/// <exception cref="NotSupportedException">The stream does not support writing.</exception>
		/// <exception cref="ObjectDisposedException">The stream has been disposed.</exception>
		/// <exception cref="InvalidOperationException">The stream is currently in use by a previous write operation.</exception>
		public override Task WriteAsync(Byte[] buffer, Int32 offset, Int32 count, CancellationToken cancellationToken) => BaseStream.WriteAsync(buffer, offset, count, cancellationToken);

		/// <summary>
		/// Writes a byte to the current position in the stream and advances the position within the stream by one byte.
		/// </summary>
		/// <param name="value">The byte to write to the stream.</param>
		/// <exception cref="IOException">An I/O error occurs.</exception>
		/// <exception cref="NotSupportedException">The stream does not support writing, or the stream is already closed.</exception>
		/// <exception cref="ObjectDisposedException">Methods were called after the stream was closed.</exception>
		public override void WriteByte(Byte value) => BaseStream.WriteByte(value);
	}
}
