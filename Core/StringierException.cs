using System;
#if !NETSTANDARD1_3
using System.Runtime.Serialization;
#endif

namespace Stringier {
	/// <summary>
	/// Represents any possible Stringier specific exception
	/// </summary>
#if !NETSTANDARD1_3
	[Serializable]
#endif
	public abstract class StringierException : Exception {
		/// <inheritdoc/>
		protected StringierException() { }

		/// <inheritdoc/>
		protected StringierException(String message) : base(message) { }

		/// <inheritdoc/>
		protected StringierException(String message, Exception inner) : base(message, inner) { }

#if !NETSTANDARD1_3
		/// <inheritdoc/>
		protected StringierException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
	}
}
