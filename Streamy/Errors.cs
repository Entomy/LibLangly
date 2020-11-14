using System;

namespace Streamy {
	/// <summary>
	/// Specifies the errors that occured.
	/// </summary>
	[Flags]
	public enum Errors {
		/// <summary>
		/// No error has occured.
		/// </summary>
		None = 0,

		/// <summary>
		/// A read was attempted at the end of the stream.
		/// </summary>
		EndOfStream = 1 << 0,

		/// <summary>
		/// An operation was attemped on a stream which has already been disposed.
		/// </summary>
		Disposed = 1 << 1,

		/// <summary>
		/// A read was attempted on a non-readable stream.
		/// </summary>
		NotReadable = 1 << 2,

		/// <summary>
		/// A seek was attempted on a non-seekable stream.
		/// </summary>
		NotSeekable = 1 << 3,

		/// <summary>
		/// A write was attempted on a non-writable stream.
		/// </summary>
		NotWritable = 1 << 4,

		/// <summary>
		/// An operation was attempted with an incomplete sequence of UNICODE Code Units.
		/// </summary>
		IncompleteSequence = 1 << 5,

		/// <summary>
		/// An operation was attempted with an invalid sequence of UNICODE Code Units.
		/// </summary>
		InvalidSequence = 1 << 6,

		/// <summary>
		/// An operation was attempted that loaded the buffer more than its capacity.
		/// </summary>
		OverloadedBuffer = 1 << 7,
	}
}
