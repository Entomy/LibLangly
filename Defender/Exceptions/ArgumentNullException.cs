using System;
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
using System.Runtime.Serialization;
#endif

namespace Defender {
	/// <summary>
	/// Thrown when an object is null, but shouldn't be.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public class ArgumentNullException : ArgumentException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentNullException"/>.
		/// </summary>
		/// <param name="name">The name of the argument responsible.</param>
		public ArgumentNullException(String name) : base(null, name, $"The object must not be null.") { }

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		protected ArgumentNullException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}
}
