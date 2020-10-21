using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Defender.Exceptions {
	/// <summary>
	/// Thrown when an object is null, but shouldn't be.
	/// </summary>
	[Serializable]
	public class ArgumentNullException : ArgumentException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentNullException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentNullException(Object value, String name, String message) : base(value, name, message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ArgumentNullException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Initializes a <see cref="ArgumentNullException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <returns>An <see cref="ArgumentNullException"/> instance.</returns>
		public static ArgumentNullException With<TValue>(TValue value, String name) => new ArgumentNullException(value, name, $"{typeof(TValue).Name} must not be null.");

		/// <summary>
		/// Initializes a <see cref="ArgumentNullException"/> with the provided values.
		/// </summary>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <returns>An <see cref="ArgumentNullException"/> instance.</returns>
		[CLSCompliant(false)]
		public static unsafe ArgumentNullException With(void* value, String name) => new ArgumentNullException(null, name, $"{typeof(void*).Name} must not be null.");
	}
}
