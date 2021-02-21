using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Versioning;

namespace Langly {
	/// <summary>
	/// Provides a view of a sequence of <see cref="Byte"/>.
	/// </summary>
	/// <remarks>
	/// <para>This fundamentally operates differently from <see cref="System.IO.Stream"/>. While it is designed fairly similar in API, the way it operates, even at that level, differs greatly. There's three major components that make up the byte stream:</para>
	/// <para>This <see cref="Stream"/> type provides orchestration logic around the other components, tying everything together. Through those, it provides a low level, byte-centric, API.</para>
	/// <para>The actual datastream is provided by <see cref="StreamBase"/>, which implements the basic streaming API for the daatastream. Supporting additional stream types can be done by extended <see cref="StreamBase"/>, which greatly simplifies adding new datastreams.</para>
	/// <para>Buffers are provided by <see cref="IReadBuffer"/> and <see cref="IWriteBuffer"/>, which buffer the basic streaming from <see cref="StreamBase"/>, enabling features like <see cref="IPeek{TElement, TError}.Peek(out TElement)"/> and limited <see cref="ISeek{TElement, TError}"/> behavior even when the underlying stream is not capable.</para>
	/// <para>Additional orchestration can be added by deriving from this type. However, most applications will not need to do this. Instead, the intended mechanism for supporting additional types is through extension methods.</para>
	/// </remarks>
	[SupportedOSPlatform("windows")]
	public partial class Stream {
	}
}
