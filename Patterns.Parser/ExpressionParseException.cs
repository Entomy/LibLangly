using System;
using System.Runtime.Serialization;

namespace Stringier.Patterns.Parser {
	[Serializable]
	public sealed class ExpressionParseException : StringierException {
		public ExpressionParseException() { }
		public ExpressionParseException(String message) : base(message) { }
		public ExpressionParseException(String message, Exception inner) : base(message, inner) { }
		protected ExpressionParseException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
