//! This exists to backport Rune to older runtimes, since we're going to take advantage of it throughout the entire project, so it must exist. By conditionally including it, and multitargeting both runtimes without and with the Rune type, it can be provided without colliding.
//! This (public) API must match the official one exactly. As such, copyright belongs to the .NET Foundation. The internals can be implemented using existing API's in Core.

#if NETSTANDARD2_0
namespace System.Buffers {
	/// <summary>
	/// Defines the values that can be returned from span-based operations that support processing of input contained in multiple discontiguous buffers.
	/// </summary>
	public enum OperationStatus {
		/// <summary>
		/// The entire input buffer has been processed and the operation is complete.
		/// </summary>
		Done = 0,

		/// <summary>
		/// The input is partially processed, up to what could fit into the destination buffer. The caller can enlarge the destination buffer, slice the buffers appropriately, and retry.
		/// </summary>
		DestinationTooSmall = 1,

		/// <summary>
		/// The input is partially processed, up to the last valid chunk of the input that could be consumed. The caller can stitch the remaining unprocessed input with more data, slice the buffers appropriately, and retry.
		/// </summary>
		NeedMoreData = 2,

		/// <summary>
		/// The input contained invalid bytes which could not be processed. If the input is partially processed, the destination contains the partial result. This guarantees that no additional data appended to the input will make the invalid sequence valid.
		/// </summary>
		InvalidData = 3,
	}
}
#endif