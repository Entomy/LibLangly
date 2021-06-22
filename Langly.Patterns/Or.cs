using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.Patterns {
	/// <summary>
	/// Represents the <c>or</c> keyword.
	/// </summary>
	public sealed partial class Or : Operator {
		/// <summary>
		/// Initializes a new <see cref="Or"/>.
		/// </summary>
		/// <param name="location">The location in the source this <c>or</c> was found.</param>
		public Or(Int32 location) : base(location) { }

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => "or";
	}
}
