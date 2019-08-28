namespace System.Text.Patterns {
	[Serializable]
	public class NeglectFailedException : ParserException {
		public NeglectFailedException() { }

		public NeglectFailedException(String message) : base(message) { }

		public NeglectFailedException(String message, Exception inner) : base(message, inner) { }

		protected NeglectFailedException(
		  Runtime.Serialization.SerializationInfo info,
		  Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
