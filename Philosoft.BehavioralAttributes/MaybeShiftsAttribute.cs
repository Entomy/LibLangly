namespace System.Diagnostics.CodeAnalysis {
	/// <summary>
	/// Specifies that the operation might shift internals, like shifting the positions inside of an array.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
	public sealed class MaybeShiftsAttribute : Attribute {
		/// <inheritdoc/>
		public MaybeShiftsAttribute() { }
	}
}
