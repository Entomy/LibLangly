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
		/// <param name="length">The length of this lexeme in the source.</param>
		protected Expression(Int32 location, Int32 length) : base(location, length) { }
	}
}
