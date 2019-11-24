using System;
using System.Runtime.Serialization;

namespace Stringier.Patterns {
	/// <summary>
	/// Thrown when a Neglect failed to match
	/// </summary>
	[Serializable]
	public sealed class NeglectFailedException : ParserException {
		public NeglectFailedException() { }

		public NeglectFailedException(String message) : base(message) { }

		public NeglectFailedException(String message, Exception inner) : base(message, inner) { }

		private NeglectFailedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
