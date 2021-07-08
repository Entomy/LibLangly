namespace System.Diagnostics.CodeAnalysis {
	/// <summary>
	/// Specifies that the operation might unlink a node, freeing it up for garbage collection.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
	public sealed class MaybeUnlinksNodeAttribute : Attribute {
		/// <inheritdoc/>
		public MaybeUnlinksNodeAttribute() { }
	}
}
