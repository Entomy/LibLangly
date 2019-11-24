using System;
using System.Runtime.Serialization;

namespace Stringier.Patterns {
	/// <summary>
	/// Thrown when at the end of source, but still trying to parse
	/// </summary>
	[Serializable]
	public sealed class EndOfSourceException : ParserException {
		public EndOfSourceException() { }

		public EndOfSourceException(String message) : base(message) { }

		public EndOfSourceException(String message, Exception inner) : base(message, inner) { }

		private EndOfSourceException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
