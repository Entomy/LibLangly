using System;
using Philosoft;
using Streamy.Bases;

namespace Streamy.Buffers {
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
