using System;
using System.Collections;
using System.Collections.Generic;
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
using System.Runtime.Serialization;
#endif

namespace Defender {
	/// <summary>
	/// Thrown when a collection is larger than a bound, but shouldn't be.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public class ArgumentLargerThanException : ArgumentGreaterThanException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentLargerThanException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="bound">The bound.</param>
		public ArgumentLargerThanException(Array value, String name, Object bound) : base(value, name, $"Array must be larger than the lower bound '{bound}'.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentLargerThanException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="bound">The bound.</param>
		public ArgumentLargerThanException(ICollection value, String name, Object bound) : base(value, name, $"Collection must be larger than the lower bound '{bound}'.") { }

		/// <inheritdoc/>
		protected ArgumentLargerThanException(Object value, String name, String message) : base(value, name, message) { }


#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		protected ArgumentLargerThanException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}

	/// <summary>
	/// Thrown when a collection is larger than a bound, but shouldn't be.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public sealed class ArgumentLargerThanException<T> : ArgumentLargerThanException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentLargerThanException{T}"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="bound">The bound.</param>
		public ArgumentLargerThanException(ICollection<T> value, String name, Object bound) : base(value, name, $"Collection must be larger than the lower bound '{bound}'.") { }

#if !NETSTANDARD1_0
		/// <summary>
		/// Initialize a new <see cref="ArgumentLargerThanException{T}"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="bound">The bound.</param>
		public ArgumentLargerThanException(Span<T> value, String name, Object bound) : base(value.ToArray(), name, message: $"Span must be larger than the lower bound '{bound}'.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentLargerThanException{T}"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="bound">The bound.</param>
		public ArgumentLargerThanException(ReadOnlySpan<T> value, String name, Object bound) : base(value.ToArray(), name, message: $"Span must be larger than the lower bound '{bound}'.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentLargerThanException{T}"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="bound">The bound.</param>
		public ArgumentLargerThanException(Memory<T> value, String name, Object bound) : base(value, name, $"Memory must be larger than the lower bound '{bound}'.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentLargerThanException{T}"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="bound">The bound.</param>
		public ArgumentLargerThanException(ReadOnlyMemory<T> value, String name, Object bound) : base(value, name, $"Memory must be larger than the lower bound '{bound}'.") { }
#endif

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		private ArgumentLargerThanException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}
}
