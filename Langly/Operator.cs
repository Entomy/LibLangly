using System;

namespace Langly {
	/// <summary>
	/// Represents any operator.
	/// </summary>
	public abstract partial class Operator : Lexeme {
		/// <summary>
		/// Initializes a new <see cref="Operator"/>.
		/// </summary>
		/// <param name="location">The location in the source this operator was found.</param>
		protected Operator(Int32 location) : base(location) { }

		/// <inheritdoc/>
		public sealed override Boolean Static => true;
	}
}
