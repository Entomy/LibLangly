using System;

namespace Langly {
	/// <summary>
	/// Indicates the type is a literal.
	/// </summary>
	public partial interface ILiteral : ILexeme {
		/// <inheritdoc/>
		Boolean ILexeme.Static => true;
	}
}
