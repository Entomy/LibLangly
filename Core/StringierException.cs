using System;
#if !NETSTANDARD1_6
using System.Runtime.Serialization;
#endif

namespace Stringier {
	/// <summary>
	/// Represents any possible Stringier specific exception
	/// </summary>
#if !NETSTANDARD1_6
	[Serializable]
#endif
	public abstract class StringierException : Exception {
		protected StringierException() { }
		protected StringierException(String message) : base(message) { }
		protected StringierException(String message, Exception inner) : base(message, inner) { }
#if !NETSTANDARD1_6
		protected StringierException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}
}
