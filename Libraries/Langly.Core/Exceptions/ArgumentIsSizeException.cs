using System;
using System.Runtime.Serialization;

namespace Langly.Exceptions {
	/// <summary>
	/// Thrown when a collection is a particular size, but should not be.
	/// </summary>
	[Serializable]
	public class ArgumentIsSizeException : ArgumentSizeException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentIsSizeException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentIsSizeException(System.Object value, String name, String message) : base(value, name, message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ArgumentIsSizeException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Initializes a <see cref="ArgumentIsSizeException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <typeparam name="TExcluded">The type of the <paramref name="excluded"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <param name="excluded">The excluded size.</param>
		/// <returns>An <see cref="ArgumentIsSizeException"/> instance.</returns>
		new public static ArgumentIsSizeException With<TValue, TExcluded>(TValue value, String name, TExcluded excluded) => new ArgumentIsSizeException(value, name, $"{typeof(TValue).Name} must not be of size '{excluded}'.");

		/// <summary>
		/// Initializes a <see cref="ArgumentIsSizeException"/> with the provided values.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the span.</typeparam>
		/// <typeparam name="TExcluded">The type of the <paramref name="excluded"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <param name="excluded">The excluded size.</param>
		/// <returns>An <see cref="ArgumentIsSizeException"/> instance.</returns>
		public static ArgumentIsSizeException With<T, TExcluded>(Span<T> value, String name, TExcluded excluded) => new ArgumentIsSizeException(value.ToArray(), name, $"{typeof(Span<T>).Name} must not be of size '{excluded}'.");

		/// <summary>
		/// Initializes a <see cref="ArgumentIsSizeException"/> with the provided values.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the span.</typeparam>
		/// <typeparam name="TExcluded">The type of the <paramref name="excluded"/>.</typeparam>
		/// <param name="value">The argument value.</param>
		/// <param name="name">The argument name.</param>
		/// <param name="excluded">The excluded size.</param>
		/// <returns>An <see cref="ArgumentIsSizeException"/> instance.</returns>
		public static ArgumentIsSizeException With<T, TExcluded>(ReadOnlySpan<T> value, String name, TExcluded excluded) => new ArgumentIsSizeException(value.ToArray(), name, $"{typeof(ReadOnlySpan<T>).Name} must not be of size '{excluded}'.");
	}
}
