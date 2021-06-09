namespace System.Diagnostics.CodeAnalysis {
	/// <summary>
	/// Annotates the worst-case asymptotic complexity of an operation.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
	public sealed class OAttribute : Attribute {
		/// <summary>
		/// The worst-case asymptotic complexity.
		/// </summary>
		private readonly Complexity Complexity;

		/// <summary>
		/// Initializes a new <see cref="OAttribute"/>.
		/// </summary>
		public OAttribute(Int32 complexity) => Complexity = Complexity.One;

		/// <summary>
		/// Initializes a new <see cref="OAttribute"/>.
		/// </summary>
		public OAttribute(Complexity complexity) => Complexity = complexity;
	}
}
