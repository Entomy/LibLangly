namespace Stringier {
	/// <summary>
	/// Helper functions for working with UTF-32 data.
	/// </summary>
	/// <remarks>
	/// Most of these helpers assume working with a UTF-32 stream, not a buffer. This is important because it enables us to more easily support stream decoding. Buffered data doesn't need special considerations, so these operations still work with buffers.
	/// </remarks>
	public static partial class UTF32 { }
}
