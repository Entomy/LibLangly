using System;
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
using System.Runtime.Serialization;
#endif

namespace Defender {
	/// <summary>
	/// Thrown when two objects are equal, but should not be.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public class ArgumentEqualException : ArgumentException {
		/// <summary>
		/// Intialize a new <see cref="ArgumentEqualException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="excluded">The excluded value.</param>
		public ArgumentEqualException(Object value, String name, Object excluded) : base(value, name, $"Value '{value}' must not equal '{excluded}'.") { }

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		protected ArgumentEqualException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}
}
