using System;
using System.Runtime.Serialization;

namespace Langly {
	/// <summary>
	/// Thrown when two objects are unequal, but should be.
	/// </summary>
	[Serializable]
	public class ArgumentNotEqualException : ArgumentValueException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentNotEqualException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentNotEqualException(Object value, String name, String message) : base(value, name, message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ArgumentNotEqualException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Initializes a <see cref="ArgumentNotEqualException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <typeparam name="TRequired">The type of the <paramref name="required"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <param name="required">The value the argument must not equal.</param>
		/// <returns>An <see cref="ArgumentNotEqualException"/> instance.</returns>
		public static ArgumentNotEqualException With<TValue, TRequired>(TValue value, String name, TRequired required) => new ArgumentNotEqualException(value, name, $"Value must equal '{required}'.");
	}
}
