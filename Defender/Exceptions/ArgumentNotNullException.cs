using System;
using System.Runtime.Serialization;

namespace Langly {
	/// <summary>
	/// Thrown when an object is not null, but should be.
	/// </summary>
	[Serializable]
	public class ArgumentNotNullException : ArgumentValueException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentNotNullException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentNotNullException(Object value, String name, String message) : base(value, name, message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ArgumentNotNullException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Initializes a <see cref="ArgumentNotNullException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <returns>An <see cref="ArgumentNotNullException"/> instance.</returns>
		public static ArgumentNotNullException With<TValue>(TValue value, String name) => new ArgumentNotNullException(value, name, $"{typeof(TValue).Name} must be null.");

		/// <summary>
		/// Initializes a <see cref="ArgumentNotNullException"/> with the provided values.
		/// </summary>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <returns>An <see cref="ArgumentNotNullException"/> instance.</returns>
		/// <remarks>
		/// Because of restrictions with pointers in .NET languages, this method can not put the actual value of <paramref name="value"/> into the error message. It will, instead, always report <see langword="null"/>.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe ArgumentNotNullException With(void* value, String name) => new ArgumentNotNullException(null, name, $"{typeof(void*).Name} must be null.");
	}
}
