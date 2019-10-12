namespace System.Text.Patterns {
	/// <summary>
	/// Thrown when a Consume failed to match
	/// </summary>
#if NETSTANDARD2_0 || NETSTANDARD2_1
	[Serializable]
#endif
	public class ConsumeFailedException : ParserException {
		public ConsumeFailedException() { }

		public ConsumeFailedException(String message) : base(message) { }

		public ConsumeFailedException(String message, Exception inner) : base(message, inner) { }

		#if NETSTANDARD2_0 || NETSTANDARD2_1
		protected ConsumeFailedException(
		  Runtime.Serialization.SerializationInfo info,
		  Runtime.Serialization.StreamingContext context) : base(info, context) { }
#endif
	}
}
