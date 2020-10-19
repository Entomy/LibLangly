using System;
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
using System.Runtime.Serialization;
#endif

namespace Defender {
	/// <summary>
	/// Thrown when an object is not null, but should be.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public class ArgumentNotNullException : ArgumentException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentNotNullException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		public ArgumentNotNullException(Object value, String name) : base(value, name, $"The object must be null.") { }

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		protected ArgumentNotNullException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}
}
