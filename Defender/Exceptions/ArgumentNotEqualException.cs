using System;
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
using System.Runtime.Serialization;
#endif

namespace Defender {
	/// <summary>
	/// Thrown when two objects are unequal, but should be.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public class ArgumentNotEqualException : ArgumentException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentNotEqualException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="expected">The expected value.</param>
		public ArgumentNotEqualException(Object value, String name, Object expected) : base(value, name, $"Value '{value}' must equal '{expected}'.") { }

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		protected ArgumentNotEqualException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}
}
