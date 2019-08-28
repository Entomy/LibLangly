using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Patterns {
	/// <summary>
	/// Represents any possible pattern related exception
	/// </summary>
	[Serializable]
	public abstract class PatternException : StringierException {
		public PatternException() { }
		public PatternException(string message) : base(message) { }
		public PatternException(string message, Exception inner) : base(message, inner) { }
		protected PatternException(
		  Runtime.Serialization.SerializationInfo info,
		  Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
