using System;
using System.Runtime.Serialization;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents any possible pattern related exception
	/// </summary>
	[Serializable]
	public abstract class PatternException : StringierException {
		protected PatternException() { }
		protected PatternException(String message) : base(message) { }
		protected PatternException(String message, Exception inner) : base(message, inner) { }
		protected PatternException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
