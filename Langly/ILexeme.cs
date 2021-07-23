using System;

namespace Langly {
	/// <summary>
	/// Indicates the type is a lexeme.
	/// </summary>
	public partial interface ILexeme {
		/// <summary>
		/// The length of this lexeme in the source.
		/// </summary>
		Int32 Length { get; set; }

		/// <summary>
		/// The location in the source this lexeme was found.
		/// </summary>
		Int32 Location { get; set; }

		/// <summary>
		/// Can this lexeme be statically evaluated?
		/// </summary>
		Boolean IsStatic { get; }
	}
}
