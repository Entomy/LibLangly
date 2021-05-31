using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Streamy.Bases {
	/// <summary>
	/// Represents the base of all <see cref="Stream"/>.
	/// </summary>
	public abstract class StreamBase : IRead<Byte>, ISeek, IWrite<Byte> {
		/// <inheritdoc/>
		public virtual nint Position { get; set; }

		/// <inheritdoc/>
		public abstract Boolean Readable { get; }

		/// <inheritdoc/>
		public abstract Boolean Seekable { get; }

		/// <inheritdoc/>
		public abstract Boolean Writable { get; }

		/// <inheritdoc/>
		public void Add([AllowNull] Byte element) => Write(element);

		/// <inheritdoc/>
		public abstract void Read([MaybeNull] out Byte element);

		/// <inheritdoc/>
		public abstract void Seek(nint offset);

		/// <inheritdoc/>
		public abstract void Write([AllowNull] Byte element);
	}
}
