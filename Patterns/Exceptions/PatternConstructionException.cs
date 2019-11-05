using System;
using System.Runtime.Serialization;

namespace Stringier.Patterns {
	/// <summary>
	/// Thrown during errors in parser construction
	/// </summary>
	[Serializable]
	public sealed class PatternConstructionException : PatternException {
		public PatternConstructionException() { }

		public PatternConstructionException(String message) : base(message) { }

		public PatternConstructionException(String message, Exception inner) : base(message, inner) { }

		private PatternConstructionException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
