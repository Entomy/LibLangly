using System;
using System.Collections;
using System.Collections.Generic;
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
using System.Runtime.Serialization;
#endif

namespace Defender {
	/// <summary>
	/// Thrown when a collection is smaller than a bound, but shouldn't be.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public class ArgumentSmallerThanException : ArgumentLesserThanException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentSmallerThanException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="bound">The bound.</param>
		public ArgumentSmallerThanException(Array value, String name, Object bound) : base(value, name, $"Array must be larger than the lower bound '{bound}'.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentSmallerThanException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="bound">The bound.</param>
		public ArgumentSmallerThanException(ICollection value, String name, Object bound) : base(value, name, $"Collection must be larger than the lower bound '{bound}'.") { }

		/// <inheritdoc/>
		protected ArgumentSmallerThanException(Object value, String name, String message) : base(value, name, message) { }

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		protected ArgumentSmallerThanException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}

	/// <summary>
	/// Thrown when a collection is smaller than a bound, but shouldn't be.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public sealed class ArgumentSmallerThanException<T> : ArgumentSmallerThanException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentSmallerThanException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="bound">The bound.</param>
		public ArgumentSmallerThanException(ICollection<T> value, String name, Object bound) : base(value, name, $"Collection must be larger than the lower bound '{bound}'.") { }

#if !NETSTANDARD1_0
		/// <summary>
		/// Initialize a new <see cref="ArgumentSmallerThanException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="bound">The bound.</param>
		public ArgumentSmallerThanException(Span<T> value, String name, Object bound) : base(value.ToArray(), name, message: $"Span must be larger than the lower bound '{bound}'.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentSmallerThanException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="bound">The bound.</param>
		public ArgumentSmallerThanException(ReadOnlySpan<T> value, String name, Object bound) : base(value.ToArray(), name, message: $"Span must be larger than the lower bound '{bound}'.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentSmallerThanException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="bound">The bound.</param>
		public ArgumentSmallerThanException(Memory<T> value, String name, Object bound) : base(value, name, $"Memory must be larger than the lower bound '{bound}'.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentSmallerThanException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="bound">The bound.</param>
		public ArgumentSmallerThanException(ReadOnlyMemory<T> value, String name, Object bound) : base(value, name, $"Memory must be larger than the lower bound '{bound}'.") { }

#endif

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		private ArgumentSmallerThanException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}
}
