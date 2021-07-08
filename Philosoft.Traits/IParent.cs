using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type can move to a parent instance.
	/// </summary>
	/// <remarks>
	/// This would be like the parent node in a tree.
	/// </remarks>
	public interface IParent<out TSelf> {
		/// <summary>
		/// The parent node in the collection.
		/// </summary>
		[MaybeNull]
		TSelf Parent { get; }
	}
}
