using System;
using System.Runtime.Serialization;

namespace Langly.Exceptions {
	/// <summary>
	/// Thrown when a collection is smaller than a bound, but shouldn't be.
	/// </summary>
	[Serializable]
	public class ArgumentSmallerThanException : ArgumentSizeException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentSmallerThanException"/>
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentSmallerThanException(System.Object value, String name, String message) : base(value, name, message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ArgumentSmallerThanException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Initializes a <see cref="ArgumentSmallerThanException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <typeparam name="TBound">The type of the <paramref name="bound"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <param name="bound">The upper bound.</param>
		/// <returns>An <see cref="ArgumentSmallerThanException"/> instance.</returns>
		new public static ArgumentSmallerThanException With<TValue, TBound>(TValue value, String name, TBound bound) => new ArgumentSmallerThanException(value, name, $"{typeof(TValue).Name} must not be larger than '{bound}'.");

		/// <summary>
		/// Initializes a <see cref="ArgumentSmallerThanException"/> with the provided values.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the span.</typeparam>
		/// <typeparam name="TBound">The type of the <paramref name="bound"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <param name="bound">The upper bound.</param>
		/// <returns>An <see cref="ArgumentSmallerThanException"/> instance.</returns>
		public static ArgumentSmallerThanException With<T, TBound>(Span<T> value, String name, TBound bound) => new ArgumentSmallerThanException(value.ToArray(), name, $"{typeof(Span<T>).Name} must not be larger than '{bound}'.");

		/// <summary>
		/// Initializes a <see cref="ArgumentSmallerThanException"/> with the provided values.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the span.</typeparam>
		/// <typeparam name="TBound">The type of the <paramref name="bound"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <param name="bound">The upper bound.</param>
		/// <returns>An <see cref="ArgumentSmallerThanException"/> instance.</returns>
		public static ArgumentSmallerThanException With<T, TBound>(ReadOnlySpan<T> value, String name, TBound bound) => new ArgumentSmallerThanException(value.ToArray(), name, $"{typeof(ReadOnlySpan<T>).Name} must not be larger than '{bound}'.");
	}
}
