using System;
using System.Runtime.Serialization;

namespace Langly {
	/// <summary>
	/// Thrown when a collection is larger than a bound, but shouldn't be.
	/// </summary>
	[Serializable]
	public class ArgumentLargerThanException : ArgumentSizeException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentLargerThanException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentLargerThanException(Object value, String name, String message) : base(value, name, message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ArgumentLargerThanException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Initializes a <see cref="ArgumentLargerThanException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <typeparam name="TBound">The type of the <paramref name="bound"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <param name="bound">The upper bound.</param>
		/// <returns>An <see cref="ArgumentLargerThanException"/> instance.</returns>
		new public static ArgumentLargerThanException With<TValue, TBound>(TValue value, String name, TBound bound) => new ArgumentLargerThanException(value, name, $"{typeof(TValue).Name} must not be larger than '{bound}'.");

		/// <summary>
		/// Initializes a <see cref="ArgumentLargerThanException"/> with the provided values.
		/// </summary>
		/// <typeparam name="T">The type of elements in the span.</typeparam>
		/// <typeparam name="TBound">The type of the <paramref name="bound"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <param name="bound">The upper bound.</param>
		/// <returns>An <see cref="ArgumentLargerThanException"/> instance.</returns>
		public static ArgumentLargerThanException With<T, TBound>(Span<T> value, String name, TBound bound) => new ArgumentLargerThanException(value.ToArray(), name, $"{typeof(Span<T>).Name} must not be larger than '{bound}'.");

		/// <summary>
		/// Initializes a <see cref="ArgumentLargerThanException"/> with the provided values.
		/// </summary>
		/// <typeparam name="T">The type of elements in the span.</typeparam>
		/// <typeparam name="TBound">The type of the <paramref name="bound"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <param name="bound">The upper bound.</param>
		/// <returns>An <see cref="ArgumentLargerThanException"/> instance.</returns>
		public static ArgumentLargerThanException With<T, TBound>(ReadOnlySpan<T> value, String name, TBound bound) => new ArgumentLargerThanException(value.ToArray(), name, $"{typeof(ReadOnlySpan<T>).Name} must not be larger than '{bound}'.");
	}
}
