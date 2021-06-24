using System;

namespace Langly {
	/// <summary>
	/// Represents any token; any lexical unit.
	/// </summary>
	public abstract class Token : ILexeme {
		/// <summary>
		/// Initializes a new <see cref="Token"/>.
		/// </summary>
		/// <param name="location">The location in the source this lexeme was found.</param>
		/// <param name="length">The length of this lexeme in the source.</param>
		protected Token(Int32 location, Int32 length) {
			Location = location;
			Length = length;
		}

		/// <inheritdoc/>
		public Int32 Length { get; set; }

		/// <inheritdoc/>
		public Int32 Location { get; set; }

		/// <inheritdoc/>
		public abstract Boolean Static { get; }
	}
}
