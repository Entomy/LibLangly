using System;
using System.Runtime.Serialization;

namespace Langly {
	/// <summary>
	/// Thrown when an argument was unhandled, but should have been.
	/// </summary>
	[Serializable]
	public class ArgumentUnhandledException : ArgumentException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentUnhandledException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentUnhandledException(Object value, String name, String message) : base(value, name, message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ArgumentUnhandledException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Initializes a <see cref="ArgumentUnhandledException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <returns>An <see cref="ArgumentUnhandledException"/> instance.</returns>
		public static ArgumentUnhandledException With<TValue>(TValue value, String name) => new ArgumentUnhandledException(value, name, $"Case '{value}' was not handled.");
	}
}
