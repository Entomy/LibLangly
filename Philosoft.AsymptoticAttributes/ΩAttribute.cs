namespace System.Diagnostics.CodeAnalysis {
	/// <summary>
	/// Annotates the best-case asymptotic complexity of an operation.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
	public sealed class ΩAttribute : Attribute {
		/// <summary>
		/// The best-case asymptotic complexity.
		/// </summary>
		private readonly Complexity Complexity;

		/// <summary>
		/// Initializes a new <see cref="ΩAttribute"/>.
		/// </summary>
		public ΩAttribute(Int32 complexity) => Complexity = Complexity.One;

		/// <summary>
		/// Initializes a new <see cref="ΩAttribute"/>.
		/// </summary>
		public ΩAttribute(Complexity complexity) => Complexity = complexity;
	}
}
