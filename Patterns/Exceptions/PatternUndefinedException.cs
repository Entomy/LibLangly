using System;
using System.Runtime.Serialization;

namespace Stringier.Patterns {
	/// <summary>
	/// Thrown when a pattern is attempted to be used when it hasn't been defined yet.
	/// </summary>
	[Serializable]
	public sealed class PatternUndefinedException : PatternException {
		public PatternUndefinedException() { }
		public PatternUndefinedException(String message) : base(message) { }
		public PatternUndefinedException(String message, Exception inner) : base(message, inner) { }
		private PatternUndefinedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
