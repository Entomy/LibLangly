using System;
using Defender;

namespace Stringier.Patterns {
	public abstract partial class Pattern {
		/// <summary>
		/// Creates a pattern representing a line comment introduced by the <paramref name="delimiter"/>.
		/// </summary>
		/// <param name="delimiter">The token delimiting the start of a line comment.</param>
		/// <returns>A pattern representing a line comment.</returns>
		public static Pattern LineComment(String delimiter) {
			Guard.NotNull(delimiter, nameof(delimiter));
			if (delimiter.Length == 0) {
				throw new ArgumentException("Line comment delimiter can not be empty", nameof(delimiter));
			} else {
				return delimiter.Then(Many(Not(LineTerminator)));
			}
		}

		/// <summary>
		/// Creates a pattern representing a string literal contained by the <paramref name="delimiter"/>.
		/// </summary>
		/// <param name="delimiter">The token delimiting the start and end of the literal.</param>
		/// <returns>A pattern representing a string literal.</returns>
		public static Pattern StringLiteral(String delimiter) {
			Guard.NotNull(delimiter, nameof(delimiter));
			if (delimiter.Length == 0) {
				throw new ArgumentException("String literal delimiter can not be empty", nameof(delimiter));
			} else {
				return Range(delimiter, delimiter);
			}
		}

		/// <summary>
		/// Creates a pattern representing a string literal contained by the <paramref name="delimiter"/>.
		/// </summary>
		/// <param name="delimiter">The token delimiting the start and end of the literal.</param>
		/// <param name="escape">The token escaping the <paramref name="delimiter"/>.</param>
		/// <returns>A pattern representing a string literal.</returns>
		public static Pattern StringLiteral(String delimiter, String escape) {
			Guard.NotNull(delimiter, nameof(delimiter));
			Guard.NotNull(escape, nameof(escape));
			if (delimiter.Length == 0) {
				throw new ArgumentException("String literal delimiter can not be empty", nameof(delimiter));
			} else if (escape.Length == 0) {
				return Range(delimiter, delimiter);
			} else {
				return Range(delimiter, delimiter, escape);
			}
		}
	}
}
