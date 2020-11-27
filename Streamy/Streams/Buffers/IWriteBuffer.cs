using System;
using Langly.Streams.Bases;

namespace Langly.Streams.Buffers {
	/// <summary>
	/// Indicates the type can be used as a write buffer for a <see cref="Streams.Stream"/>.
	/// </summary>
	public interface IWriteBuffer : IWritable<Byte, Errors> {
		/// <summary>
		/// The capacity of this buffer.
		/// </summary>
		nint Capacity { get; }

		/// <summary>
		/// The datastream being buffered.
		/// </summary>
		StreamBase Stream { get; }
	}
}
