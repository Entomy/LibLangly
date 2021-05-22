using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a <see cref="Ranger"/> which supports nesting of the range.
	/// </summary>
	internal sealed class NestedRanger : Ranger {
		/// <summary>
		/// The current nesting level.
		/// </summary>
		private Int32 Level;

		/// <summary>
		/// Initialize a new <see cref="NestedRanger"/> with the given <paramref name="from"/> and <paramref name="to"/>
		/// </summary>
		/// <param name="from">The <see cref="Pattern"/> to start from.</param>
		/// <param name="to">The <see cref="Pattern"/> to read to.</param>
		internal NestedRanger([DisallowNull] Pattern from, [DisallowNull] Pattern to) : base(from, to) => Level = 0;
	}
}
