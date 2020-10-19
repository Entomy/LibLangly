using System;
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
using System.Runtime.Serialization;
#endif

namespace Defender {
	/// <summary>
	/// Thrown when a value is lesser than a bound, but shouldn't be.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public class ArgumentLesserThanException : ArgumentException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentLesserThanException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="bound">The bound.</param>
		public ArgumentLesserThanException(Object value, String name, Object bound) : base(value, name, $"Value '{value}' must be greater than the lower bound '{bound}'.") { }

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		protected ArgumentLesserThanException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}
}
