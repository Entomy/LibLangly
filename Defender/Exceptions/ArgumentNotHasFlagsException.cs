using System;
using System.Runtime.Serialization;

namespace Langly {
	/// <summary>
	/// Thrown when a flags enum is required to have certain flags set, but doesn't.
	/// </summary>
	[Serializable]
	public class ArgumentNotHasFlagsException : ArgumentNotValidException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentNotHasFlagsException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentNotHasFlagsException(Object value, String name, String message) : base(value, name, message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ArgumentNotHasFlagsException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Initializes a <see cref="ArgumentNotHasFlagsException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TEnum">The type of the <paramref name="value"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <param name="flags">The required flags.</param>
		/// <returns>An <see cref="ArgumentNotHasFlagsException"/> instance.</returns>
		public static ArgumentNotHasFlagsException With<TEnum>(TEnum value, String name, TEnum flags) where TEnum : struct, Enum => new ArgumentNotHasFlagsException(value, name, $"{typeof(TEnum).Name} must contain the flags '{flags}'.");

	}
}
