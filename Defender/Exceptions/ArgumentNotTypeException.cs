using System;
using System.Runtime.Serialization;

namespace Langly {
	/// <summary>
	/// The exception that is thrown when an object is passed to a method that expects a specific type, but is not of that type.
	/// </summary>
	[Serializable]
	public class ArgumentNotTypeException : ArgumentException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentNotTypeException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentNotTypeException(Object value, String name, String message) : base(value, name, message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ArgumentNotTypeException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Initializes a <see cref="ArgumentNotTypeException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TType">The type the argument must be.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <returns>An <see cref="ArgumentNotTypeException"/> instance.</returns>
		public static ArgumentNotTypeException With<TType>(Object value, String name) => new ArgumentNotTypeException(value?.GetType().Name, name, $"Argument not of type '{typeof(TType).Name}'.");
	}
}