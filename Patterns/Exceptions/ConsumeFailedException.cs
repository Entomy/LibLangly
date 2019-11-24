using System;
using System.Runtime.Serialization;

namespace Stringier.Patterns {
	/// <summary>
	/// Thrown when a Consume failed to match
	/// </summary>
	[Serializable]
	public sealed class ConsumeFailedException : ParserException {
		public ConsumeFailedException() { }

		public ConsumeFailedException(String message) : base(message) { }

		public ConsumeFailedException(String message, Exception inner) : base(message, inner) { }

		private ConsumeFailedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
