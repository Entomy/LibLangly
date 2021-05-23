using System;

namespace Langly {
	/// <summary>
	/// Represents any operator.
	/// </summary>
	public abstract class Operator : Lexeme {
		/// <summary>
		/// Initializes a new <see cref="Operator"/>.
		/// </summary>
		/// <param name="location">The location in the source this lexeme was found.</param>
		protected Operator(Int32 location) : base(location) { }
	}
}
