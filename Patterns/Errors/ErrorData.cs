using System;

namespace Stringier.Patterns.Errors {
	/// <summary>
	/// The type of data the <see cref="Error"/> holds.
	/// </summary>
	/// <remarks>
	/// <see cref="Error"/> uses a packed struct in which multiple types live in the same location. This differentiates what the actual type of the data is.
	/// </remarks>
	internal enum ErrorData : Byte {
		None = 0,
		Char,
		Pattern,
		String,
	}
}
