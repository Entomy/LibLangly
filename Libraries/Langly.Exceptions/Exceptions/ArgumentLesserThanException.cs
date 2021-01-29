using System;
using System.Runtime.Serialization;

namespace Langly.Exceptions {
	/// <summary>
	/// Thrown when a value is lesser than a bound, but shouldn't be.
	/// </summary>
	[Serializable]
	public class ArgumentLesserThanException : ArgumentValueException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentLesserThanException"/>
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentLesserThanException(System.Object value, String name, String message) : base(value, name, message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ArgumentLesserThanException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Initializes a <see cref="ArgumentLesserThanException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <typeparam name="TBound">The type of the <paramref name="bound"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <param name="bound">The lower bound.</param>
		/// <returns>An <see cref="ArgumentLesserThanException"/> instance.</returns>
		public static ArgumentLesserThanException With<TValue, TBound>(TValue value, String name, TBound bound) => new ArgumentLesserThanException(value, name, $"Value must be greater than or equal to the lower bound '{bound}'.");
	}
}
