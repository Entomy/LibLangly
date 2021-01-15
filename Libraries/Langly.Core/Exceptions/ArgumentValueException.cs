using System;
using System.Runtime.Serialization;

namespace Langly.Exceptions {
	/// <summary>
	/// Thrown when one of the arguments' value is not valid.
	/// </summary>
	[Serializable]
	public abstract class ArgumentValueException : ArgumentException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentValueException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentValueException(System.Object value, String name, String message) : base(value, name, message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ArgumentValueException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
