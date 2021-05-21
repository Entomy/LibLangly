using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier {
	public partial class Pattern {
		/// <summary>
		/// Creates a pattern representing a line comment introduced by the <paramref name="from"/> and ended by the <paramref name="to"/> delimiters.
		/// </summary>
		/// <param name="from">The token delimiting the start of a block comment.</param>
		/// <param name="to">The token delimiting the stop of a block comment.</param>
		/// <returns>A pattern representing a block comment.</returns>
		[return: NotNull]
		public static Pattern BlockComment([DisallowNull] String from, [DisallowNull] String to) {
			if (from is null) {
				throw new ArgumentNullException(nameof(from));
			} else if (to is null) {
				throw new ArgumentNullException(nameof(to));
			}
			return from.ToNested(to);
		}

		/// <summary>
		/// Creates a pattern representing a line comment introduced by the <paramref name="delimiter"/>.
		/// </summary>
		/// <param name="delimiter">The token delimiting the start of a line comment.</param>
		/// <returns>A pattern representing a line comment.</returns>
		[return: MaybeNull, NotNullIfNotNull("delimiter")]
		public static Pattern LineComment([DisallowNull] String delimiter) => delimiter is not null ? delimiter & +!EndOfLine : null;

		/// <summary>
		/// Creates a pattern representing a string literal contained by the <paramref name="delimiter"/>.
		/// </summary>
		/// <param name="delimiter">The token delimiting the start and end of the literal.</param>
		/// <returns>A pattern representing a string literal.</returns>
		[return: MaybeNull, NotNullIfNotNull("delimiter")]
		public static Pattern StringLiteral([DisallowNull] String delimiter) => delimiter is not null ? delimiter.To(delimiter) : null;

		/// <summary>
		/// Creates a pattern representing a string literal contained by the <paramref name="delimiter"/>.
		/// </summary>
		/// <param name="delimiter">The token delimiting the start and end of the literal.</param>
		/// <param name="escape">The token escaping the <paramref name="delimiter"/>.</param>
		/// <returns>A pattern representing a string literal.</returns>
		[return: MaybeNull, NotNullIfNotNull("delimiter")]
		public static Pattern StringLiteral([DisallowNull] String delimiter, [DisallowNull] String escape) {
			if (escape is null || escape.Length == 0) {
				return delimiter.To(delimiter);
			} else {
				return delimiter.To(delimiter, escape);
			}
		}
	}
}
