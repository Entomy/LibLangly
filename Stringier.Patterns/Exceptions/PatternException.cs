using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Patterns {
	/// <summary>
	/// Represents any possible pattern related exception
	/// </summary>
	[Serializable]
	public abstract class PatternException : StringierException {
		protected PatternException() { }
		protected PatternException(string message) : base(message) { }
		protected PatternException(string message, Exception inner) : base(message, inner) { }
		protected PatternException(
		  Runtime.Serialization.SerializationInfo info,
		  Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
