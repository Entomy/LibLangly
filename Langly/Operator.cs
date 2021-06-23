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
		/// <param name="length">The length of this lexeme in the source.</param>
		protected Operator(Int32 location, Int32 length) : base(location, length) { }

		/// <inheritdoc/>
		public sealed override Boolean Static => true;
	}
}
