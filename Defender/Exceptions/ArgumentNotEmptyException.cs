using System;
using System.Runtime.Serialization;

namespace Defender.Exceptions {
	/// <summary>
	/// Thrown when a collection should be empty, but isn't.
	/// </summary>
	[Serializable]
	public class ArgumentNotEmptyException : ArgumentIsNotSizeException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentNotEmptyException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentNotEmptyException(Object value, String name, String message) : base(value, name, message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ArgumentNotEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Initializes a <see cref="ArgumentNotEmptyException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <returns>An <see cref="ArgumentNotEmptyException"/> instance.</returns>
		public static ArgumentNotEmptyException With<TValue>(TValue value, String name) => new ArgumentNotEmptyException(value, name, $"{typeof(TValue).Name} must be empty.");

		/// <summary>
		/// Initializes a <see cref="ArgumentNotEmptyException"/> with the provided values.
		/// </summary>
		/// <typeparam name="T">The type of element in the span.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <returns>An <see cref="ArgumentNotEmptyException"/> instance.</returns>
		public static ArgumentNotEmptyException With<T>(Span<T> value, String name) => new ArgumentNotEmptyException(value.ToArray(), name, $"{typeof(Span<T>).Name} must be empty.");

		/// <summary>
		/// Initializes a <see cref="ArgumentNotEmptyException"/> with the provided values.
		/// </summary>
		/// <typeparam name="T">The type of element in the span.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <returns>An <see cref="ArgumentNotEmptyException"/> instance.</returns>
		public static ArgumentNotEmptyException With<T>(ReadOnlySpan<T> value, String name) => new ArgumentNotEmptyException(value.ToArray(), name, $"{typeof(ReadOnlySpan<T>).Name} must be empty.");
	}
}
