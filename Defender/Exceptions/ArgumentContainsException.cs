using System;
using System.Runtime.Serialization;

namespace Langly {
	/// <summary>
	/// Thrown when a collection contains an item, but shouldn't.
	/// </summary>
	[Serializable]
	public class ArgumentContainsException : ArgumentException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentContainsException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentContainsException(Object value, String name, String message) : base(value, name, message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ArgumentContainsException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Initializes a <see cref="ArgumentContainsException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <typeparam name="TExcluded">The type of the <paramref name="excluded"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <param name="excluded">The value to exclude from the argument.</param>
		/// <returns>An <see cref="ArgumentContainsException"/> instance.</returns>
		public static ArgumentContainsException With<TValue, TExcluded>(TValue value, String name, TExcluded excluded) => new ArgumentContainsException(value, name, $"{typeof(TValue).Name} must not contain '{excluded}'.");
	}
}
