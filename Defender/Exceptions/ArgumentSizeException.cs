using System;
using System.Runtime.Serialization;

namespace Defender.Exceptions {
	/// <summary>
	/// Thrown when one of the arguments' size is not valid.
	/// </summary>
	[Serializable]
	public abstract class ArgumentSizeException : ArgumentException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentSizeException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentSizeException(Object value, String name, String message) : base(value, name, message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ArgumentSizeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
