namespace System.Text.Patterns {
	/// <summary>
	/// Thrown when at the end of source, but still trying to parse
	/// </summary>
#if NETSTANDARD2_0 || NETSTANDARD2_1
	[Serializable]
#endif
	public class EndOfSourceException : ParserException {
		public EndOfSourceException() { }

		public EndOfSourceException(String message) : base(message) { }

		public EndOfSourceException(String message, Exception inner) : base(message, inner) { }

#if NETSTANDARD2_0 || NETSTANDARD2_1
		protected EndOfSourceException(
			Runtime.Serialization.SerializationInfo info,
			Runtime.Serialization.StreamingContext context) : base(info, context) { }
#endif
	}
}
