using System;
using System.Runtime.Serialization;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents any possible parser related exception
	/// </summary>
	[Serializable]
	public abstract class ParserException : StringierException {
		protected ParserException() { }

		protected ParserException(String message) : base(message) { }

		protected ParserException(String message, Exception inner) : base(message, inner) { }

		protected ParserException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
