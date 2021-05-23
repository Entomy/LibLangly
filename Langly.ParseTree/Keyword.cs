using System;

namespace Langly {
	/// <summary>
	/// Represents any keyword.
	/// </summary>
	public abstract class Keyword : Lexeme {
		/// <summary>
		/// Initializes a new <see cref="Keyword"/>.
		/// </summary>
		/// <param name="location">The location in the source this lexeme was found.</param>
		protected Keyword(Int32 location) : base(location) { }
	}
}
