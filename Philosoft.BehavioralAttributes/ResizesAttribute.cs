namespace System.Diagnostics.CodeAnalysis {
	/// <summary>
	/// Specifies that the operation resizes an internal buffer.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
	public sealed class ResizesAttribute : Attribute {
		/// <inheritdoc/>
		public ResizesAttribute() { }
	}
}
