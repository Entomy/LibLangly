namespace System.Diagnostics.CodeAnalysis {
	/// <summary>
	/// Specifies that the operation shifts internals, like shifting the positions inside of an array.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
	public sealed class ShiftsAttribute : Attribute {
		/// <inheritdoc/>
		public ShiftsAttribute() { }
	}
}
