using System;
using System.Runtime.Serialization;

namespace Defender.Exceptions {
	/// <summary>
	/// Thrown when a collection doesn't contain an item, but should.
	/// </summary>
	[Serializable]
	public class ArgumentNotContainsException : ArgumentException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentContainsException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentNotContainsException(Object value, String name, String message) : base(value, name, message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ArgumentNotContainsException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Initializes a <see cref="ArgumentNotContainsException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <typeparam name="TRequired">The type of the <paramref name="required"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <param name="required">The value to require in the argument.</param>
		/// <returns>An <see cref="ArgumentNotContainsException"/> instance.</returns>
		public static ArgumentNotContainsException With<TValue, TRequired>(TValue value, String name, TRequired required) => new ArgumentNotContainsException(value, name, $"{typeof(TValue).Name} must contain '{required}'.");
	}
}
