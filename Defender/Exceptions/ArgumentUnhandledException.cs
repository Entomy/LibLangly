using System;
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
using System.Runtime.Serialization;
#endif

namespace Defender {
	/// <summary>
	/// Thrown when an argument was unhandled, but should have been.
	/// </summary>
#if !NETSTANDARD1_0 && !NETSTANDARD1_1
	[Serializable]
#endif
	public class ArgumentUnhandledException : ArgumentException {
		/// <summary>
		/// Initialize a new <see cref="ArgumentUnhandledException"/>.
		/// </summary>
		/// <param name="value">The value of the argument responsible.</param>
		/// <param name="name">The name of the argument responsible.</param>
		public ArgumentUnhandledException(Object value, String name) : base(value, name, $"Case '{value}' was not handled.") { }

#if !NETSTANDARD1_0 && !NETSTANDARD1_1
		private ArgumentUnhandledException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}
}
