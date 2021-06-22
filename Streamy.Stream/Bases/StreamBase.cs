using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Streamy.Bases {
	/// <summary>
	/// Represents the base of all <see cref="Stream"/>.
	/// </summary>
	[SuppressMessage("Major Code Smell", "S3881:\"IDisposable\" should be implemented correctly", Justification = "We're using a slight variation of it that makes it safer to extend. Sonar doesn't understand that.")]
	public abstract class StreamBase : IControlled, IRead<Byte>, ISeek, IWrite<Byte> {
		/// <inheritdoc/>
		[SuppressMessage("Design", "MA0055:Do not use finalizer", Justification = "This is part of the correct IDisposable pattern")]
		~StreamBase() => Dispose(disposing: false);

		/// <inheritdoc/>
		public Boolean Disposed { get; set; }

		/// <inheritdoc/>
		public virtual Int32 Position { get; set; }

		/// <inheritdoc/>
		public abstract Boolean Readable { get; }

		/// <inheritdoc/>
		public abstract Boolean Seekable { get; }

		/// <inheritdoc/>
		public abstract Boolean Writable { get; }

		/// <inheritdoc/>
		public void Add([AllowNull] Byte element) => Write(element);

		/// <inheritdoc/>
		public void Dispose(Boolean disposing) {
			if (!Disposed) {
				if (disposing) {
					DisposeManaged();
				}
				DisposeUnmanaged();
				NullLargeFields();
				Disposed = true;
			}
		}

		/// <inheritdoc/>
		public void Dispose() {
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		/// <inheritdoc/>
		public virtual void DisposeManaged() { /* No-op */ }

		/// <inheritdoc/>
		public virtual void DisposeUnmanaged() { /* No-op */ }

		/// <inheritdoc/>
		public virtual void NullLargeFields() { /* No-op */ }

		/// <inheritdoc/>
		public abstract void Read([MaybeNull] out Byte element);

		/// <inheritdoc/>
		public abstract void Seek(Int32 offset);

		/// <inheritdoc/>
		[return: NotNull]
		public abstract override String ToString();

		/// <inheritdoc/>
		public abstract void Write([AllowNull] Byte element);
	}
}
