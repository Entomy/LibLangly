namespace System.Diagnostics.CodeAnalysis {
	/// <summary>
	/// Specifies that the operation might resize an internal buffer.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
	public sealed class MaybeResizesAttribute : Attribute {
		/// <inheritdoc/>
		public MaybeResizesAttribute() {}
	}
}
