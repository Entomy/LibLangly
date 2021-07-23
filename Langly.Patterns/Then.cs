using System;

namespace Langly.Patterns {
	/// <summary>
	/// Represents the <c>then</c> operator.
	/// </summary>
	public sealed partial class Then : Token, IOperator {
		/// <summary>
		/// Initializes a new <see cref="Then"/>.
		/// </summary>
		/// <param name="location">The location in the source this <c>then</c> was found.</param>
		public Then(Int32 location) : base(location, 4) { }

		/// <inheritdoc/>
		public override Boolean IsStatic => true;
	}
}
