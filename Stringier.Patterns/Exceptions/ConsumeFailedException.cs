namespace System.Text.Patterns {
	/// <summary>
	/// Thrown when a Consume failed to match
	/// </summary>
	[Serializable]
	public class ConsumeFailedException : ParserException {
		public ConsumeFailedException() { }

		public ConsumeFailedException(String message) : base(message) { }

		public ConsumeFailedException(String message, Exception inner) : base(message, inner) { }

		protected ConsumeFailedException(
		  Runtime.Serialization.SerializationInfo info,
		  Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
