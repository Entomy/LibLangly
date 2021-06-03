namespace Streamy {
	/// <summary>
	/// The order of bytes of a multi-byte sequence.
	/// </summary>
	/// <remarks>
	/// This is an enumeration because technically there's more than just big and little endianness. While unlikely, support for those could happen, and this is a simple thing to do with an enumeration. Furthermore, the more common approach of using a boolean is problematic with respect to readability. What is "true"?
	/// </remarks>
	public enum Endian {
		/// <summary>
		/// Unkown endianess.
		/// </summary>
		Unknown = 0,

		/// <summary>
		/// Most significant byte first.
		/// </summary>
		Big,

		/// <summary>
		/// Least significcant byte first.
		/// </summary>
		Little,
	}
}
