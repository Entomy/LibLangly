using System;
using System.Runtime.Serialization;

namespace Stringier.Patterns.Parser {
	[Serializable]
	public class ExpressionEvaluationException : StringierException {
		public ExpressionEvaluationException() { }
		public ExpressionEvaluationException(String message) : base(message) { }
		public ExpressionEvaluationException(String message, Exception inner) : base(message, inner) { }
		protected ExpressionEvaluationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
