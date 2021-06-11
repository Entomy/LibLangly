using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type can move to a previous instance.
	/// </summary>
	/// <remarks>
	/// This would be like the previous node in a list.
	/// </remarks>
	public interface IPrevious<out TSelf> {
		/// <summary>
		/// The next node in the collection.
		/// </summary>
		[AllowNull]
		TSelf Previous { get; }
	}
}
