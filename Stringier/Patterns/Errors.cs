using System;

namespace Langly.Patterns {
	/// <summary>
	/// Specifies the errors that occured.
	/// </summary>
	[Flags]
	public enum Errors {
		/// <summary>
		/// No error has occured.
		/// </summary>
		None = 0,

		/// <summary>
		/// A parse was attempted at the end of the source.
		/// </summary>
		EndOfSource = 1 << 0,

		/// <summary>
		/// A parser was attempted with an undefined pattern.
		/// </summary>
		PatternUndefined = 1 << 1,

		/// <summary>
		/// The parser failed to match the specified pattern.
		/// </summary>
		NoMatch = 1 << 2,
	}
}
