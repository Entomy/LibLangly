using System;
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
using System.Runtime.Serialization;
#endif

namespace Defender {
	/// <summary>
	/// Thrown when a valid should be within a range, but isn't.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public abstract class ArgumentNotWithinException : ArgumentException {
		/// <inheritdoc/>
		protected ArgumentNotWithinException(Object value, String name, String message) : base(value, name, message) { }

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		protected ArgumentNotWithinException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}

	/// <summary>
	/// Thrown when a valid should be within a range, but isn't.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public class ArgumentNotWithinException<T> : ArgumentNotWithinException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentNotWithinException{T}"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		public ArgumentNotWithinException(T value, String name, T lower, T upper) : base(value, name, $"Value '{value}' must be within {lower}..{upper}, inclusive.") { }

#if !NETSTANDARD1_0 && !NETSTANDARD1_1 && !NETSTANDARD2_0
		/// <summary>
		/// Initialize a new <see cref="ArgumentNotWithinException{T}"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="range">The range.</param>
		public ArgumentNotWithinException(T value, String name, Range range) : base(value, name, $"Value '{value}' must be within {range}, inclusive.") { }
#endif

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		protected ArgumentNotWithinException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}
}
