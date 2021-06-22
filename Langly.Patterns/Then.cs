using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.Patterns {
	/// <summary>
	/// Represents the <c>then</c> keyword.
	/// </summary>
	public sealed partial class Then : Operator {
		/// <summary>
		/// Initializes a new <see cref="Then"/>.
		/// </summary>
		/// <param name="location">The location in the source this <c>then</c> was found.</param>
		public Then(Int32 location) : base(location) { }

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => "then";
	}
}
