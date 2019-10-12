namespace System.Text.Patterns {
	/// <summary>
	/// Thrown during errors in parser construction
	/// </summary>
#if NETSTANDARD2_0 || NETSTANDARD2_1
	[Serializable]
#endif
	public sealed class PatternConstructionException : PatternException {
		public PatternConstructionException() { }

		public PatternConstructionException(String message) : base(message) { }

		public PatternConstructionException(String message, Exception inner) : base(message, inner) { }

		#if NETSTANDARD2_0 || NETSTANDARD2_1
		public PatternConstructionException(
		  Runtime.Serialization.SerializationInfo info,
		  Runtime.Serialization.StreamingContext context) : base(info, context) { }
#endif
	}
}
