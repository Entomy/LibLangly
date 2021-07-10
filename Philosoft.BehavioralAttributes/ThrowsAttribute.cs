namespace System.Diagnostics.CodeAnalysis {
	/// <summary>
	/// Specifies that the operation throws an <see cref="Exception"/>.
	/// </summary>
	[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
	public sealed class ThrowsAttribute : Attribute {
		/// <summary>
		/// Initializes a new <see cref="ThrowsAttribute"/>.
		/// </summary>
		/// <param name="type">The type of the <see cref="Exception"/> that will be thrown.</param>
		public ThrowsAttribute(Type type) => Type = type;

		/// <summary>
		/// The type of the <see cref="Exception"/> that will be thrown.
		/// </summary>
		public Type Type { get; }
	}
}
