using System;

namespace Stringier.Patterns.Errors {
	/// <summary>
	/// Specifies the type of <see cref="Error"/> that occured.
	/// </summary>
	/// <remarks>
	/// This is used to map to the equivalent <see cref="Exception"/> when the <see cref="Error"/> is thrown.
	/// </remarks>
	internal enum ErrorType : Byte {
		None = 0,
		ConsumeFailed,
		NeglectFailed,
		EndOfSource,
	}
}
