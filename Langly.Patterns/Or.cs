using System;

namespace Langly.Patterns {
	/// <summary>
	/// Represents the <c>or</c> operator.
	/// </summary>
	public sealed partial class Or : Token, IOperator {
		/// <summary>
		/// Initializes a new <see cref="Or"/>.
		/// </summary>
		/// <param name="location">The location in the source this <c>or</c> was found.</param>
		public Or(Int32 location) : base(location, 2) { }

		/// <inheritdoc/>
		public override Boolean IsStatic => true;
	}
}
