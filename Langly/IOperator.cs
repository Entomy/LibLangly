using System;

namespace Langly {
	/// <summary>
	/// Indicates the type is an operator.
	/// </summary>
	public partial interface IOperator : ILexeme {
		/// <inheritdoc/>
		Boolean ILexeme.IsStatic => true;
	}
}
