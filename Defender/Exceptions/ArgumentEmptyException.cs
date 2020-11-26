using System;
using System.Runtime.Serialization;

namespace Langly {
	/// <summary>
	/// Thrown when a collection shouldn't be empty, but is.
	/// </summary>
	[Serializable]
	public class ArgumentEmptyException : ArgumentIsSizeException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentEmptyException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentEmptyException(Object value, String name, String message) : base(value, name, message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ArgumentEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Initializes a <see cref="ArgumentEmptyException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <returns>An <see cref="ArgumentEmptyException"/> instance.</returns>
		public static ArgumentEmptyException With<TValue>(TValue value, String name) => new ArgumentEmptyException(value, name, $"{typeof(TValue).Name} must not be empty.");

		/// <summary>
		/// Initializes a <see cref="ArgumentEmptyException"/> with the provided values.
		/// </summary>
		/// <typeparam name="T">The type of element in the span.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <returns>An <see cref="ArgumentEmptyException"/> instance.</returns>
		public static ArgumentEmptyException With<T>(Span<T> value, String name) => new ArgumentEmptyException(value.ToArray(), name, $"{typeof(Span<T>).Name} must not be empty.");

		/// <summary>
		/// Initializes a <see cref="ArgumentEmptyException"/> with the provided values.
		/// </summary>
		/// <typeparam name="T">The type of element in the span.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <returns>An <see cref="ArgumentEmptyException"/> instance.</returns>
		public static ArgumentEmptyException With<T>(ReadOnlySpan<T> value, String name) => new ArgumentEmptyException(value.ToArray(), name, $"{typeof(ReadOnlySpan<T>).Name} must not be empty.");
	}
}
