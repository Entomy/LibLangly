namespace System.Diagnostics.CodeAnalysis {
	/// <summary>
	/// Annotates the average-case asymptotic complexity of an operation.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
	public sealed class ΘAttribute : Attribute {
		/// <summary>
		/// The average-case asymptotic complexity.
		/// </summary>
		private readonly Complexity Complexity;

		/// <summary>
		/// Initializes a new <see cref="ΘAttribute"/>.
		/// </summary>
		public ΘAttribute(Int32 complexity) => Complexity = Complexity.One;

		/// <summary>
		/// Initializes a new <see cref="ΘAttribute"/>.
		/// </summary>
		public ΘAttribute(Complexity complexity) => Complexity = complexity;
	}
}
