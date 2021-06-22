using System;

namespace Langly {
	/// <summary>
	/// Represents any expression.
	/// </summary>
	public abstract class Expression : Lexeme {
		/// <summary>
		/// Initializes a new <see cref="Expression"/>.
		/// </summary>
		/// <param name="location">The location in the source this expression was found.</param>
		protected Expression(Int32 location) : base(location) { }
	}
}
