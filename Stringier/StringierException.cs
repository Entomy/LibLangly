namespace System {
	/// <summary>
	/// Represents any possible Stringier specific exception
	/// </summary>
	#if NETSTANDARD2_0 || NETSTANDARD2_1
	[Serializable]
#endif
	public abstract class StringierException : Exception {
		protected StringierException() { }
		protected StringierException(String message) : base(message) { }
		protected StringierException(String message, Exception inner) : base(message, inner) { }

#if NETSTANDARD2_0 || NETSTANDARD2_1
		protected StringierException(
		  Runtime.Serialization.SerializationInfo info,
		  Runtime.Serialization.StreamingContext context) : base(info, context) { }
#endif
	}
}
