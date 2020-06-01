using System;
using System.Runtime.Serialization;

namespace Stringier {
	/// <summary>
	/// Represents any possible Stringier specific exception
	/// </summary>
	[Serializable]
	public abstract class StringierException : Exception {
		/// <inheritdoc/>
		protected StringierException() { }

		/// <inheritdoc/>
		protected StringierException(String message) : base(message) { }

		/// <inheritdoc/>
		protected StringierException(String message, Exception inner) : base(message, inner) { }

		/// <inheritdoc/>
		protected StringierException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
