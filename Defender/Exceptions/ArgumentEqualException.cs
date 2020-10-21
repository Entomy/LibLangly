using System;
using System.Runtime.Serialization;

namespace Defender.Exceptions {
	/// <summary>
	/// Thrown when two objects are equal, but should not be.
	/// </summary>
	[Serializable]
	public class ArgumentEqualException : ArgumentException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentEqualException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentEqualException(Object value, String name, String message) : base(value, name, message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ArgumentEqualException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Initializes a <see cref="ArgumentEqualException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <typeparam name="TExcluded">The type of the <paramref name="excluded"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <param name="excluded">The value the argument must not equal.</param>
		/// <returns>An <see cref="ArgumentEqualException"/> instance.</returns>
		public static ArgumentEqualException With<TValue, TExcluded>(TValue value, String name, TExcluded excluded) => new ArgumentEqualException(value, name, $"Value must not equal '{excluded}'.");
	}
}
