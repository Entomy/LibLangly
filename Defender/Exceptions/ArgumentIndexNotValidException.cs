using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Langly;

namespace Defender.Exceptions {
	/// <summary>
	/// Thrown when an index is not of a valid value.
	/// </summary>
	[Serializable]
	public class ArgumentIndexNotValidException : ArgumentNotValidException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentIndexNotValidException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentIndexNotValidException(Object value, String name, String message) : base(value, name, message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ArgumentIndexNotValidException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Initializes a <see cref="ArgumentIndexNotValidException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <param name="value">The index value.</param>
		/// <param name="name">The index name.</param>
		/// <param name="collection">The collection being indexed.</param>
		/// <returns>An <see cref="ArgumentIndexNotValidException"/> instance.</returns>
		public static ArgumentIndexNotValidException With<TValue>(TValue value, String name, String collection) => new ArgumentIndexNotValidException(value, name, $"Index must be at least 0 and less than the length of the {typeof(String).Name} '{collection.Length}");

		/// <summary>
		/// Initializes a <see cref="ArgumentIndexNotValidException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <typeparam name="T">The type of elements in the <paramref name="collection"/>.</typeparam>
		/// <param name="value">The index value.</param>
		/// <param name="name">The index name.</param>
		/// <param name="collection">The collection being indexed.</param>
		/// <returns>An <see cref="ArgumentIndexNotValidException"/> instance.</returns>
		public static ArgumentIndexNotValidException With<TValue, T>(TValue value, String name, T[] collection) => new ArgumentIndexNotValidException(value, name, $"Index must be at least 0 and less than the length of the {typeof(T[]).Name} '{collection.Length}");

		/// <summary>
		/// Initializes a <see cref="ArgumentIndexNotValidException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <typeparam name="T">The type of elements in the <paramref name="collection"/>.</typeparam>
		/// <param name="value">The index value.</param>
		/// <param name="name">The index name.</param>
		/// <param name="collection">The collection being indexed.</param>
		/// <returns>An <see cref="ArgumentIndexNotValidException"/> instance.</returns>
		public static ArgumentIndexNotValidException With<TValue, T>(TValue value, String name, Span<T> collection) => new ArgumentIndexNotValidException(value, name, $"Index must be at least 0 and less than the length of the {typeof(Span<T>).Name} '{collection.Length}");

		/// <summary>
		/// Initializes a <see cref="ArgumentIndexNotValidException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <typeparam name="T">The type of elements in the <paramref name="collection"/>.</typeparam>
		/// <param name="value">The index value.</param>
		/// <param name="name">The index name.</param>
		/// <param name="collection">The collection being indexed.</param>
		/// <returns>An <see cref="ArgumentIndexNotValidException"/> instance.</returns>
		public static ArgumentIndexNotValidException With<TValue, T>(TValue value, String name, ReadOnlySpan<T> collection) => new ArgumentIndexNotValidException(value, name, $"Index must be at least 0 and less than the length of the {typeof(ReadOnlySpan<T>).Name} '{collection.Length}");

		/// <summary>
		/// Initializes a <see cref="ArgumentIndexNotValidException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <typeparam name="T">The type of elements in the <paramref name="collection"/>.</typeparam>
		/// <param name="value">The index value.</param>
		/// <param name="name">The index name.</param>
		/// <param name="collection">The collection being indexed.</param>
		/// <returns>An <see cref="ArgumentIndexNotValidException"/> instance.</returns>
		public static ArgumentIndexNotValidException With<TValue, T>(TValue value, String name, Memory<T> collection) => new ArgumentIndexNotValidException(value, name, $"Index must be at least 0 and less than the length of the {typeof(Memory<T>).Name} '{collection.Length}");

		/// <summary>
		/// Initializes a <see cref="ArgumentIndexNotValidException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <typeparam name="T">The type of elements in the <paramref name="collection"/>.</typeparam>
		/// <param name="value">The index value.</param>
		/// <param name="name">The index name.</param>
		/// <param name="collection">The collection being indexed.</param>
		/// <returns>An <see cref="ArgumentIndexNotValidException"/> instance.</returns>
		public static ArgumentIndexNotValidException With<TValue, T>(TValue value, String name, ReadOnlyMemory<T> collection) => new ArgumentIndexNotValidException(value, name, $"Index must be at least 0 and less than the length of the {typeof(ReadOnlyMemory<T>).Name} '{collection.Length}");

		/// <summary>
		/// Initializes a <see cref="ArgumentIndexNotValidException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <param name="value">The index value.</param>
		/// <param name="name">The index name.</param>
		/// <param name="collection">The collection being indexed.</param>
		/// <returns>An <see cref="ArgumentIndexNotValidException"/> instance.</returns>
		public static ArgumentIndexNotValidException With<TValue>(TValue value, String name, ICollection collection) => new ArgumentIndexNotValidException(value, name, $"Index must be at least 0 and less than the length of the {typeof(TValue).Name} '{collection.Count}");

		/// <summary>
		/// Initializes a <see cref="ArgumentIndexNotValidException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <typeparam name="T">The type of elements in the <paramref name="collection"/>.</typeparam>
		/// <param name="value">The index value.</param>
		/// <param name="name">The index name.</param>
		/// <param name="collection">The collection being indexed.</param>
		/// <returns>An <see cref="ArgumentIndexNotValidException"/> instance.</returns>
		public static ArgumentIndexNotValidException With<TValue, T>(TValue value, String name, ICollection<T> collection) => new ArgumentIndexNotValidException(value, name, $"Index must be at least 0 and less than the length of the {typeof(TValue).Name} '{collection.Count}");

		/// <summary>
		/// Initializes a new <see cref="ArgumentIndexNotValidException"/> with the provided values.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <typeparam name="T">The type of elements in the <paramref name="collection"/>.</typeparam>
		/// <param name="value">The index value.</param>
		/// <param name="name">The index name.</param>
		/// <param name="collection">The collection being indexed.</param>
		/// <returns>An <see cref="ArgumentIndexNotValidException"/> instance.</returns>
		public static ArgumentIndexNotValidException With<TValue, T>(TValue value, String name, IIndexable<T> collection) => new ArgumentIndexNotValidException(value, name, $"Index must be at least 0 and less than the length of the {typeof(TValue).Name} '{collection.Count}");

		/// <summary>
		/// Initializes a new <see cref="ArgumentIndexNotValidException"/>.
		/// </summary>
		/// <typeparam name="TIndex">The type of the indicies.</typeparam>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="value">The index value.</param>
		/// <param name="name">The index name.</param>
		/// <param name="collection">The collection being indexed.</param>
		/// <returns>An <see cref="ArgumentIndexNotValidException"/> instance.</returns>
		public static ArgumentIndexNotValidException With<TIndex, TElement>(TIndex value, String name, IIndexable<TIndex, TElement> collection) => new ArgumentIndexNotValidException(value, name, $"Index must be one of the indicies present in the collection.");
	}
}
