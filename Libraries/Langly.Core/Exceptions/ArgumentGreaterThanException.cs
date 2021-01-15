using System;
using System.Runtime.Serialization;

namespace Langly.Exceptions {
	/// <summary>
	/// Thrown when a value is greater than a bound, but shouldn't be.
	/// </summary>
	[Serializable]
	public class ArgumentGreaterThanException : ArgumentValueException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentGreaterThanException"/>
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentGreaterThanException(System.Object value, String name, String message) : base(value, name, message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ArgumentGreaterThanException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Initializes a <see cref="ArgumentGreaterThanException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <typeparam name="TBound">The type of the <paramref name="bound"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <param name="bound">The upper bound.</param>
		/// <returns>An <see cref="ArgumentGreaterThanException"/> instance.</returns>
		public static ArgumentGreaterThanException With<TValue, TBound>(TValue value, String name, TBound bound) => new ArgumentGreaterThanException(value, name, $"Value must be lesser than or equal to the upper bound '{bound}'.");
	}
}
