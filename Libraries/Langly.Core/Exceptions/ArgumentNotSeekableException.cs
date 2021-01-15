using System;
using System.IO;
using System.Runtime.Serialization;

namespace Langly.Exceptions {
	/// <summary>
	/// Thrown when a stream is not seekable, but should be.
	/// </summary>
	[Serializable]
	public class ArgumentNotSeekableException : ArgumentModeException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentNotSeekableException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentNotSeekableException(System.Object value, String name, String message) : base(value, name, message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ArgumentNotSeekableException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Initializes a <see cref="ArgumentNotSeekableException"/> with the provided values.
		/// </summary>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <returns>An <see cref="ArgumentNotSeekableException"/> instance.</returns>
		public static ArgumentNotSeekableException With(Stream value, String name) => new ArgumentNotSeekableException(value, name, "Stream must be seekable.");

		/// <summary>
		/// Initializes a <see cref="ArgumentNotSeekableException"/> with the provided values.
		/// </summary>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <returns>An <see cref="ArgumentNotSeekableException"/> instance.</returns>
		public static ArgumentNotSeekableException With<TElement, TError>(ISeek<TElement, TError> value, String name) => new ArgumentNotSeekableException(value, name, "Stream must be seekable.");
	}
}
