namespace System.Text.Patterns {
	/// <summary>
	/// Thrown during errors in parser construction
	/// </summary>
	[Serializable]
	public sealed class PatternConstructionException : PatternException {
		public PatternConstructionException() { }

		public PatternConstructionException(String message) : base(message) { }

		public PatternConstructionException(String message, Exception inner) : base(message, inner) { }

		public PatternConstructionException(
		  Runtime.Serialization.SerializationInfo info,
		  Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
