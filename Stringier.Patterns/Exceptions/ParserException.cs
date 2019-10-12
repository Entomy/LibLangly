namespace System.Text.Patterns {
	/// <summary>
	/// Represents any possible parser related exception
	/// </summary>
#if NETSTANDARD2_0 || NETSTANDARD2_1
	[Serializable]
#endif
	public abstract class ParserException : StringierException {
		protected ParserException() { }

		protected ParserException(String message) : base(message) { }

		protected ParserException(String message, Exception inner) : base(message, inner) { }

		#if NETSTANDARD2_0 || NETSTANDARD2_1
		protected ParserException(
		  Runtime.Serialization.SerializationInfo info,
		  Runtime.Serialization.StreamingContext context) : base(info, context) { }
#endif
	}
}
