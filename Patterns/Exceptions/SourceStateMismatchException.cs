using System;
using System.Runtime.Serialization;

namespace Stringier.Patterns {
	/// <summary>
	/// Thrown when a <see cref="SourceState"/> does not match the <see cref="Source"/>.
	/// </summary>
	[Serializable]
	public class SourceStateMismatchException : StringierException {
		public SourceStateMismatchException() { }

		public SourceStateMismatchException(String message) : base(message) { }

		public SourceStateMismatchException(String message, Exception inner) : base(message, inner) { }

		protected SourceStateMismatchException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}