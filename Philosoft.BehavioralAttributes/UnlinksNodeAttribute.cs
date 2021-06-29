namespace System.Diagnostics.CodeAnalysis {
	/// <summary>
	/// Specifies that the operation unlinks a node, freeing it up for garbage collection.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
	public sealed class UnlinksNodeAttribute : Attribute {
		/// <inheritdoc/>
		public UnlinksNodeAttribute() { }
	}
}
