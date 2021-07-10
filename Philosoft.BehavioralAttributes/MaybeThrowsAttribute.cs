namespace System.Diagnostics.CodeAnalysis {
	/// <summary>
	/// Specifies that the operation might throw an <see cref="Exception"/>.
	/// </summary>
	[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
	public sealed class MaybeThrowsAttribute : Attribute {
		/// <summary>
		/// Initializes a new <see cref="MaybeThrowsAttribute"/>.
		/// </summary>
		/// <param name="type">The type of the <see cref="Exception"/> that might be thrown.</param>
		/// <param name="condition">A description of the condition that will cause the exception to be thrown.</param>
		public MaybeThrowsAttribute(Type type, String condition) {
			Type = type;
			Condition = condition;
		}

		/// <summary>
		/// The type of the <see cref="Exception"/> that might be thrown.
		/// </summary>
		public Type Type { get; }

		/// <summary>
		/// A description of the condition that will cause the exception to be thrown.
		/// </summary>
		public String Condition { get; }
	}
}
