using System;
using System.Runtime.Serialization;

namespace Langly {
	/// <summary>
	/// Thrown when a collection is not a particular size, but should be.
	/// </summary>
	[Serializable]
	public class ArgumentIsNotSizeException : ArgumentSizeException {
		/// <summary>
		/// Initializes a new <see cref="ArgumentIsNotSizeException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentIsNotSizeException(Object value, String name, String message) : base(value, name, message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ArgumentIsNotSizeException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Initializes a <see cref="ArgumentIsNotSizeException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <typeparam name="TRequired">The type of the <paramref name="required"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <param name="required">The required size..</param>
		/// <returns>An <see cref="ArgumentIsNotSizeException"/> instance.</returns>
		public static ArgumentIsNotSizeException With<TValue, TRequired>(TValue value, String name, TRequired required) => new ArgumentIsNotSizeException(value, name, $"{typeof(TValue).Name} must be of size '{required}'.");

		/// <summary>
		/// Initializes a <see cref="ArgumentIsNotSizeException"/> with the provided values.
		/// </summary>
		/// <typeparam name="T">The type of the element in the span.</typeparam>
		/// <typeparam name="TRequired">The type of the <paramref name="required"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <param name="required">The required size..</param>
		/// <returns>An <see cref="ArgumentIsNotSizeException"/> instance.</returns>
		public static ArgumentIsNotSizeException With<T, TRequired>(Span<T> value, String name, TRequired required) => new ArgumentIsNotSizeException(value.ToArray(), name, $"{typeof(Span<T>).Name} must be of size '{required}'.");

		/// <summary>
		/// Initializes a <see cref="ArgumentIsNotSizeException"/> with the provided values.
		/// </summary>
		/// <typeparam name="T">The type of the element in the span.</typeparam>
		/// <typeparam name="TRequired">The type of the <paramref name="required"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <param name="required">The required size..</param>
		/// <returns>An <see cref="ArgumentIsNotSizeException"/> instance.</returns>
		public static ArgumentIsNotSizeException With<T, TRequired>(ReadOnlySpan<T> value, String name, TRequired required) => new ArgumentIsNotSizeException(value.ToArray(), name, $"{typeof(ReadOnlySpan<T>).Name} must be of size '{required}'.");

		/// <summary>
		/// Initializes a <see cref="ArgumentIsNotSizeException"/> with the provided values.
		/// </summary>
		/// <typeparam name="T">The type of the element in the span.</typeparam>
		/// <typeparam name="TRequired">The type of the <paramref name="required"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <param name="required">The required size..</param>
		/// <returns>An <see cref="ArgumentIsNotSizeException"/> instance.</returns>
		public static ArgumentIsNotSizeException With<T, TRequired>(Memory<T> value, String name, TRequired required) => new ArgumentIsNotSizeException(value.ToArray(), name, $"{typeof(Memory<T>).Name} must be of size '{required}'.");

		/// <summary>
		/// Initializes a <see cref="ArgumentIsNotSizeException"/> with the provided values.
		/// </summary>
		/// <typeparam name="T">The type of the element in the span.</typeparam>
		/// <typeparam name="TRequired">The type of the <paramref name="required"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <param name="required">The required size..</param>
		/// <returns>An <see cref="ArgumentIsNotSizeException"/> instance.</returns>
		public static ArgumentIsNotSizeException With<T, TRequired>(ReadOnlyMemory<T> value, String name, TRequired required) => new ArgumentIsNotSizeException(value.ToArray(), name, $"{typeof(ReadOnlyMemory<T>).Name} must be of size '{required}'.");
	}
}
