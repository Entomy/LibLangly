using System;
using System.IO;
using System.Runtime.Serialization;

namespace Langly {
	/// <summary>
	/// Thrown when a stream is not writable, but should be.
	/// </summary>
	[Serializable]
	public class ArgumentNotWritableException : ArgumentModeException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentNotWritableException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentNotWritableException(Object value, String name, String message) : base(value, name, message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ArgumentNotWritableException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Initializes a <see cref="ArgumentNotWritableException"/> with the provided values.
		/// </summary>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <returns>An <see cref="ArgumentNotWritableException"/> instance.</returns>
		public static ArgumentNotWritableException With(Stream value, String name) => new ArgumentNotWritableException(value, name, "Stream must be writable.");
	}
}
