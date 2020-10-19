using System;
using System.IO;
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
using System.Runtime.Serialization;
#endif

namespace Defender {
	/// <summary>
	/// Thrown when a stream is not readable, but should be.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public class ArgumentNotReadableException : ArgumentException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentNotReadableException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		public ArgumentNotReadableException(Stream value, String name) : base(value, name, $"Stream must be readable.") { }

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		protected ArgumentNotReadableException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}
}
