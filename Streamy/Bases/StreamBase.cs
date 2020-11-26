using System;
using Langly;

namespace Streamy.Bases {
	/// <summary>
	/// Represents the base of a <see cref="Stream"/>; the actual datastream.
	/// </summary>
	/// <remarks>
	/// <para>This is, essentially, the bare minimum required from a stream API.</para>
	/// <para><see cref="Stream"/> is a complex peice of orchestration logic. It ties together the actual datastream, buffers, encoding logic, and more, into a single, seamless, type. Unsurprisingly this is a very complex system that needs care and consideration in its design, for usabilitiy, maintainance, and even just for the design to work. <see cref="StreamBase"/>, the datastream part, was made separate for two reasons:</para>
	/// <para>First, the datastream must be constructed before anything else. But because of how constructor chains work, if new datastreams are provided by overriding <see cref="Stream"/>, then other things like encoding detection, which are datastream agnostic, will be executed before the datastream is constructed, breaking things. By having the datastream as a discrete part, it ensures a fully constructed datastream exists before setting up the orchestrated <see cref="Stream"/>.</para>
	/// <para>Second, separation of concerns is important. By separating out these components, we are left with four discrete components, the actual datastream, buffers, encoding logic, and orchestration of these components. Within each typeclass, only that component has to be addressed, greatly easing maintainance.</para>
	/// </remarks>
	public abstract class StreamBase : Controlled, IReadable<Byte, Errors>, ISeekable<Byte, Errors>, IWritable<Byte, Errors> {
		/// <inheritdoc/>
		protected StreamBase() { }

		/// <summary>
		/// Is this datastream at its end?
		/// </summary>
		public abstract Ł3 AtEnd { get; }

		/// <summary>
		/// The position within the datastream, counted by byte offset.
		/// </summary>
		public nint Position { get; set; }

		/// <inheritdoc/>
		public virtual Boolean Readable => true;

		/// <inheritdoc/>
		public virtual Boolean Seekable => true;

		/// <inheritdoc/>
		public virtual Boolean Writable => true;

		/// <inheritdoc/>
		public abstract void Read(out Byte element);

		/// <inheritdoc/>
		public abstract void Seek(nint offset);

		/// <inheritdoc/>
		public abstract override String ToString();

		/// <inheritdoc/>
		public Boolean TryRead(out Byte element, out Errors error) {
			error = Errors.None;
			if (AtEnd.Necessary()) {
				error |= Errors.EndOfStream;
			}
			if (!Readable) {
				error |= Errors.NotReadable;
			}
			if (Disposed) {
				error |= Errors.Disposed;
			}
			Read(out element);
			return error == Errors.None;
		}

		/// <inheritdoc/>
		public virtual Boolean TryRead(Span<Byte> elements, out Errors error) {
			error = Errors.None;
			for (Int32 i = 0; i < elements.Length; i++) {
				if (!TryRead(out elements[i], out Errors err)) {
					error |= err;
					return false;
				}
			}
			return true;
		}

		/// <inheritdoc/>
		public Boolean TrySeek(nint offset, out Errors error) {
			error = Errors.None;
			if (!Seekable) {
				error |= Errors.NotSeekable;
			}
			if (Disposed) {
				error |= Errors.Disposed;
			}
			Seek(offset);
			return error == Errors.None;
		}

		/// <inheritdoc/>
		public Boolean TryWrite(Byte element, out Errors error) {
			error = Errors.None;
			if (AtEnd.Necessary()) {
				error |= Errors.EndOfStream;
			}
			if (!Writable) {
				error |= Errors.NotWritable;
			}
			if (Disposed) {
				error |= Errors.Disposed;
			}
			Write(element);
			return error == Errors.None;
		}

		/// <inheritdoc/>
		public virtual Boolean TryWrite(ReadOnlySpan<Byte> elements, out Errors error) {
			error = Errors.None;
			for (Int32 i = 0; i < elements.Length; i++) {
				if (!TryWrite(elements[i], out Errors err)) {
					error |= err;
					return false;
				}
			}
			return true;
		}

		/// <inheritdoc/>
		public abstract void Write(Byte element);
	}
}
