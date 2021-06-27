using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type contains an index.
	/// </summary>
	public interface IIndex<out TIndex> {
		/// <summary>
		/// The index contained in this instance.
		/// </summary>
		[NotNull]
		TIndex Index { get; }
	}
}
