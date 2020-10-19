using System;
using System.Collections;
using System.Collections.Generic;
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
using System.Runtime.Serialization;
#endif

namespace Defender {
	/// <summary>
	/// Thrown when an index is not of a valid value.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public class ArgumentIndexNotValidException : ArgumentNotValidException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentIndexNotValidException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="collection">The collection being indexed.</param>
		public ArgumentIndexNotValidException(Int32 value, String name, String collection) : base(value, name, $"Index must be at least 0, and less than the length of the string '{collection.Length}'.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentIndexNotValidException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="collection">The collection being indexed.</param>
		public ArgumentIndexNotValidException(Int32 value, String name, Array collection) : base(value, name, $"Index must be at least 0, and less than the length of the array '{collection.Length}'.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentIndexNotValidException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="collection">The collection being indexed.</param>
		public ArgumentIndexNotValidException(Int32 value, String name, ICollection collection) : base(value, name, $"Index must be at least 0, and less than the length of the collection '{collection.Count}'.") { }


		/// <inheritdoc/>
		protected ArgumentIndexNotValidException(Object value, String name, String message) : base(value, name, message) { }

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		protected ArgumentIndexNotValidException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}

	/// <summary>
	/// Thrown when an index is not of a valid value.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public sealed class ArgumentIndexNotValidException<T> : ArgumentIndexNotValidException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentIndexNotValidException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="collection">The collection being indexed.</param>
		public ArgumentIndexNotValidException(Int32 value, String name, ICollection<T> collection) : base(value, name, $"Index must be at least 0, and less than the length of the collection '{collection.Count}'.") { }

#if !NETSTANDARD1_0
		/// <summary>
		/// Initialize a new <see cref="ArgumentIndexNotValidException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="collection">The collection being indexed.</param>
		public ArgumentIndexNotValidException(Int32 value, String name, Span<T> collection) : base(value, name, $"Index must be at least 0, and less than the length of the span '{collection.Length}'.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentIndexNotValidException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="collection">The collection being indexed.</param>
		public ArgumentIndexNotValidException(Int32 value, String name, ReadOnlySpan<T> collection) : base(value, name, $"Index must be at least 0, and less than the length of the span '{collection.Length}'.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentIndexNotValidException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="collection">The collection being indexed.</param>
		public ArgumentIndexNotValidException(Int32 value, String name, Memory<T> collection) : base(value, name, $"Index must be at least 0, and less than the length of the memory '{collection.Length}'.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentIndexNotValidException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="collection">The collection being indexed.</param>
		public ArgumentIndexNotValidException(Int32 value, String name, ReadOnlyMemory<T> collection) : base(value, name, $"Index must be at least 0, and less than the length of the memory '{collection.Length}'.") { }
#endif

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		private ArgumentIndexNotValidException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}
}