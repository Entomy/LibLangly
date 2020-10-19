using System;
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
using System.Runtime.Serialization;
#endif

namespace Defender {
	/// <summary>
	/// Thrown when a value is greater than a bound, but shouldn't be.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public class ArgumentGreaterThanException : ArgumentException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentGreaterThanException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="bound">The bound.</param>
		public ArgumentGreaterThanException(Object value, String name, Object bound) : base(value, name, $"Value '{value}' must be lesser than the upper bound '{bound}'.") { }

		/// <summary>
		/// Initialize a new <see cref="ArgumentGreaterThanException"/>
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="message">The message that describes the error.</param>
		protected ArgumentGreaterThanException(Object value, String name, String message) : base(value, name, message) { }

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		protected ArgumentGreaterThanException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}
}
