using System;
using Langly.DataStructures.Filters;

namespace Langly.DataStructures {
	/// <summary>
	/// Indicates the <see cref="Filter{TIndex, TElement}"/> that should be set up for the data structure.
	/// </summary>
	/// <remarks>
	/// This only exposes filters that are suitable for downstream designation. Certain filters are used internally to synthesize behaviors, and require more information than this enum can provide.
	/// </remarks>
	[Flags]
	public enum Filter {
		/// <summary>
		/// No filtration; default behavior.
		/// </summary>
		None = 0,

		/// <summary>
		/// Sparse filtration; accessing not-present indicies returns the default value.
		/// </summary>
		Sparse = 1 << 0,
	}
}
