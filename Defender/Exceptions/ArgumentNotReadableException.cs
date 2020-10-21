using System;
using System.IO;
using System.Runtime.Serialization;

namespace Defender.Exceptions {
	/// <summary>
	/// Thrown when a stream is not readable, but should be.
	/// </summary>
	[Serializable]
	public class ArgumentNotReadableException : ArgumentException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentNotReadableException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentNotReadableException(Object value, String name, String message) : base(value, name, message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ArgumentNotReadableException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Initializes a <see cref="ArgumentNotReadableException"/> with the provided values.
		/// </summary>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <returns>An <see cref="ArgumentNotReadableException"/> instance.</returns>
		public static ArgumentNotReadableException With(Stream value, String name) => new ArgumentNotReadableException(value, name, "Stream must be readable.");
	}
}
