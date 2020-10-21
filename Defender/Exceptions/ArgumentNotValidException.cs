using System;
using System.Runtime.Serialization;

namespace Defender.Exceptions {
	/// <summary>
	/// Thrown when an object is in an invalid state.
	/// </summary>
	[Serializable]
	public class ArgumentNotValidException : ArgumentValueException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentNotValidException(Object value, String name, String message) : base(value, name, message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ArgumentNotValidException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Initializes a <see cref="ArgumentNotValidException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TEnum">The type of the <paramref name="value"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <returns>An <see cref="ArgumentNotValidException"/> instance.</returns>
		public static ArgumentNotValidException With<TEnum>(TEnum value, String name) where TEnum : struct, Enum => new ArgumentNotValidException(value, name, $"{typeof(TEnum).Name} must be a defined value.");
	}
}