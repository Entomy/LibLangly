using System;
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
using System.Runtime.Serialization;
#endif

namespace Defender {
	/// <summary>
	/// Thrown when an object is in an invalid state.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public class ArgumentNotValidException : ArgumentException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentContainsException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		public ArgumentNotValidException(Object value, String name) : base(value, name, $"Object must be in a valid state.") { }

		/// <inheritdoc/>
		protected ArgumentNotValidException(Object value, String name, String message) : base(value, name, message) { }

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		protected ArgumentNotValidException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}

	/// <summary>
	/// Thrown when an enumeration value is undefined.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public sealed class ArgumentNotValidException<E> : ArgumentNotValidException where E : struct, Enum {
		/// <summary>
		/// Initialize a new <see cref="ArgumentContainsException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		public ArgumentNotValidException(E value, String name) : base(value, name, $"Value must be a defined '{typeof(E)}' value.") { }

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		protected ArgumentNotValidException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}
}
