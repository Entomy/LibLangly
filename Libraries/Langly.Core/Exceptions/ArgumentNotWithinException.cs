using System;
using System.Runtime.Serialization;

namespace Langly.Exceptions {
	/// <summary>
	/// Thrown when a valid should be within a range, but isn't.
	/// </summary>
	[Serializable]
	public class ArgumentNotWithinException : ArgumentValueException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentNotWithinException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentNotWithinException(System.Object value, String name, String message) : base(value, name, message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ArgumentNotWithinException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Initializes a <see cref="ArgumentNotWithinException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <returns>An <see cref="ArgumentNotWithinException"/> instance.</returns>
		public static ArgumentNotWithinException With<TValue>(TValue value, String name, TValue lower, TValue upper) => new ArgumentNotWithinException(value, name, $"Value must be within {lower}..{upper}, inclusive.");
	}
}
