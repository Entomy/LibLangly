using System;
using System.Collections;
using System.Collections.Generic;
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
using System.Runtime.Serialization;
#endif

namespace Defender {
	/// <summary>
	/// Thrown when a collection shouldn't be empty, but is.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public class ArgumentEmptyException : ArgumentException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentEmptyException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		public ArgumentEmptyException(String value, String name) : base(value, name, $"String must not be empty.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentEmptyException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		public ArgumentEmptyException(Array value, String name) : base(value, name, $"Array must not be empty.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentEmptyException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		public ArgumentEmptyException(ICollection value, String name) : base(value, name, $"Collection must not be empty.") { }

		/// <inheritdoc/>
		protected ArgumentEmptyException(Object value, String name, String message) : base(value, name, message) { }

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		protected ArgumentEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}

	/// <summary>
	/// Thrown when a collection shouldn't be empty, but is.
	/// </summary>
	/// <typeparam name="T">The type held within the collection.</typeparam>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public sealed class ArgumentEmptyException<T> : ArgumentEmptyException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentEmptyException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		public ArgumentEmptyException(ICollection<T> value, String name) : base(value, name, $"Collection must not be empty.") { }

#if !NETSTANDARD1_0
		/// <summary>
		/// Initialize a new <see cref="ArgumentEmptyException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		public ArgumentEmptyException(Span<T> value, String name) : base(value.ToArray(), name, $"Span must not be empty.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentEmptyException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		public ArgumentEmptyException(ReadOnlySpan<T> value, String name) : base(value.ToArray(), name, $"Span must not be empty.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentEmptyException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		public ArgumentEmptyException(Memory<T> value, String name) : base(value, name, $"Memory must not be empty.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentEmptyException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		public ArgumentEmptyException(ReadOnlyMemory<T> value, String name) : base(value, name, $"Memory must not be empty.") { }
#endif

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		private ArgumentEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}
}
