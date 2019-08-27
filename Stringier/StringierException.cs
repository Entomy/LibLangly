using System;
using System.Collections.Generic;
using System.Text;

namespace System {
	/// <summary>
	/// Represents any possible Stringier specific exception
	/// </summary>
	[Serializable]
	public abstract class StringierException : Exception {
		public StringierException() { }
		public StringierException(string message) : base(message) { }
		public StringierException(string message, Exception inner) : base(message, inner) { }
		protected StringierException(
		  Runtime.Serialization.SerializationInfo info,
		  Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
