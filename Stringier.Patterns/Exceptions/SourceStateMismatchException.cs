namespace System.Text.Patterns {
	/// <summary>
	/// Thrown when a <see cref="SourceState"/> does not match the <see cref="Source"/>.
	/// </summary>
#if NETSTANDARD2_0 || NETSTANDARD2_1
	[Serializable]
#endif
	public class SourceStateMismatchException : StringierException {
		public SourceStateMismatchException() { }

		public SourceStateMismatchException(String message) : base(message) { }

		public SourceStateMismatchException(String message, Exception inner) : base(message, inner) { }

#if NETSTANDARD2_0 || NETSTANDARD2_1
		protected SourceStateMismatchException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
#endif
	}
}
