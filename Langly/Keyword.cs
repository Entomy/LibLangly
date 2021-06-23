using System;

namespace Langly {
	/// <summary>
	/// Represents any keyword.
	/// </summary>
	public abstract class Keyword : Lexeme {
		/// <summary>
		/// Initializes a new <see cref="Keyword"/>.
		/// </summary>
		/// <param name="location">The location in the source this keyword was found.</param>
		/// <param name="length">The length of this lexeme in the source.</param>
		protected Keyword(Int32 location, Int32 length) : base(location, length) { }
	}
}
