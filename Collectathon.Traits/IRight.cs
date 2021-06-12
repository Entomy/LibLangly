using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type can move to a righthand instance.
	/// </summary>
	/// <remarks>
	/// This would be like the righthand child node in a tree.
	/// </remarks>
	public interface IRight<out TSelf> {
		/// <summary>
		/// The righthand node in the collection.
		/// </summary>
		[MaybeNull]
		TSelf Right { get; }
	}
}
