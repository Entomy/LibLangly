using System;
using System.Collections;
using System.Collections.Generic;
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
using System.Runtime.Serialization;
#endif

namespace Defender {
	/// <summary>
	/// Thrown when a collection should be empty, but isn't.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public class ArgumentNotEmptyException : ArgumentException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentNotEmptyException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		public ArgumentNotEmptyException(String value, String name) : base(value, name, $"String must be empty.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentNotEmptyException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		public ArgumentNotEmptyException(Array value, String name) : base(value, name, $"Array must be empty.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentNotEmptyException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		public ArgumentNotEmptyException(ICollection value, String name) : base(value, name, $"Collection must be empty.") { }

		/// <inheritdoc/>
		protected ArgumentNotEmptyException(Object value, String name, String message) : base(value, name, message) { }

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		protected ArgumentNotEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}

	/// <summary>
	/// Thrown when a collection should be empty, but isn't.
	/// </summary>
	/// <typeparam name="T">The type held within the collection.</typeparam>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public sealed class ArgumentNotEmptyException<T> : ArgumentNotEmptyException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentNotEmptyException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		public ArgumentNotEmptyException(ICollection<T> value, String name) : base(value, name, $"Collection must be empty.") { }

#if !NETSTANDARD1_0
		/// <summary>
		/// Initialize a new <see cref="ArgumentNotEmptyException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		public ArgumentNotEmptyException(Span<T> value, String name) : base(value.ToArray(), name, $"Span must be empty.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentNotEmptyException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		public ArgumentNotEmptyException(ReadOnlySpan<T> value, String name) : base(value.ToArray(), name, $"Span must be empty.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentNotEmptyException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		public ArgumentNotEmptyException(Memory<T> value, String name) : base(value, name, $"Memory must be empty.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentNotEmptyException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		public ArgumentNotEmptyException(ReadOnlyMemory<T> value, String name) : base(value, name, $"Memory must be empty.") { }
#endif

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		private ArgumentNotEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}
}
