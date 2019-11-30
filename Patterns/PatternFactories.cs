using System;

namespace Stringier.Patterns {
	public sealed partial class Pattern {
		/// <summary>
		/// Creates a pattern representing a line comment introduced by the <paramref name="delimiter"/>.
		/// </summary>
		/// <param name="delimiter">The token delimiting the start of a line comment.</param>
		/// <returns>A pattern representing a line comment.</returns>
		public static Pattern LineComment(String delimiter) => delimiter & +!LineTerminator;

		/// <summary>
		/// Creates a pattern representing a string literal contained by the <paramref name="delimiter"/>.
		/// </summary>
		/// <param name="delimiter">The token delimiting the start and end of the literal.</param>
		/// <returns>A pattern representing a string literal.</returns>
		public static Pattern StringLiteral(String delimiter) => Range(delimiter, delimiter);

		/// <summary>
		/// Creates a pattern representing a string literal contained by the <paramref name="delimiter"/>.
		/// </summary>
		/// <param name="delimiter">The token delimiting the start and end of the literal.</param>
		/// <param name="escape">The token escaping the <paramref name="delimiter"/>.</param>
		/// <returns>A pattern representing a string literal.</returns>
		public static Pattern StringLiteral(String delimiter, String escape) => Range(delimiter, delimiter, escape);
	}
}
