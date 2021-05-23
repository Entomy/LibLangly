using System;

namespace Langly {
	/// <summary>
	/// Represents any literal.
	/// </summary>
	public abstract class Literal : Lexeme {
		/// <summary>
		/// Initializes a new <see cref="Literal"/>.
		/// </summary>
		/// <param name="location">The location in the source this lexeme was found.</param>
		protected Literal(Int32 location) : base(location) { }
	}
}
