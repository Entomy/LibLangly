namespace System.Text.Patterns {
	/// <summary>
	/// Thrown when a Neglect failed to match
	/// </summary>
#if NETSTANDARD2_0 || NETSTANDARD2_1
	[Serializable]
#endif
	public class NeglectFailedException : ParserException {
		public NeglectFailedException() { }

		public NeglectFailedException(String message) : base(message) { }

		public NeglectFailedException(String message, Exception inner) : base(message, inner) { }

#if NETSTANDARD2_0 || NETSTANDARD2_1
		protected NeglectFailedException(
		  Runtime.Serialization.SerializationInfo info,
		  Runtime.Serialization.StreamingContext context) : base(info, context) { }
#endif
	}
}
