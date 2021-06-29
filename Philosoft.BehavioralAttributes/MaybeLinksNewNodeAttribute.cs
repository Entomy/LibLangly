namespace System.Diagnostics.CodeAnalysis {
	/// <summary>
	/// Specifies that the operation might allocate and link a new node.
	/// </summary>
	[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
	public sealed class MaybeLinksNewNodeAttribute : Attribute {
		/// <inheritdoc/>
		public MaybeLinksNewNodeAttribute() => NodeSlots = -1;

		/// <inheritdoc/>
		/// <param name="nodeSlots">The amount of slots in the node.</param>
		public MaybeLinksNewNodeAttribute(Int32 nodeSlots) => NodeSlots = nodeSlots;

		/// <summary>
		/// The amount of slots in the node.
		/// </summary>
		public Int32 NodeSlots { get; }
	}
}
