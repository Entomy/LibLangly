using System;
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
using System.Runtime.Serialization;
#endif

namespace Defender {
	/// <summary>
	/// The exception that is thrown when an object is passed to a method that expects a specific type, but is not of that type.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public class ArgumentNotTypeException : ArgumentException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentNotTypeException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		/// <param name="type">The type the argument was supposed to be.</param>
		public ArgumentNotTypeException(Object value, String name, Type type) : base(value, name, $"Argument not of type '{type}'.") { }

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		protected ArgumentNotTypeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}
}