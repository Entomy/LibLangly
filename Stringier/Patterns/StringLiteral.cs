using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.Patterns {
	/// <summary>
	/// Represents a string literal, a <see cref="Literal"/> <see cref="Pattern"/> matching this exact <see cref="String"/>.
	/// </summary>
	internal sealed class StringLiteral : Literal {
		/// <summary>
		/// The actual <see cref="String"/> being matched.
		/// </summary>
		[DisallowNull] private readonly String Pattern;

		/// <summary>
		/// Initializes a new <see cref="StringLiteral"/> with the given <paramref name="pattern"/>.
		/// </summary>
		/// <param name="pattern">The pattern to match.</param>
		internal StringLiteral([DisallowNull] String pattern) => Pattern = pattern;
	}
}
