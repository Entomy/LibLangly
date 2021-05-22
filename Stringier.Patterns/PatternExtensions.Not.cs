using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Stringier.Patterns {
	public static partial class PatternExtensions {
		/// <summary>
		/// Marks this <see cref="Pattern"/> as negated.
		/// </summary>
		/// <param name="char">The char literal pattern.</param>
		/// <returns>A new <see cref="Pattern"/> which matches the negation of this <see cref="Pattern"/>.</returns>
		[return: NotNull]
		public static Pattern Not(this Char @char) => new CharLiteral(@char).Not();

		/// <summary>
		/// Marks this <see cref="Pattern"/> as negated.
		/// </summary>
		/// <param name="rune">The rune literal pattern.</param>
		/// <returns>A new <see cref="Pattern"/> which matches the negation of this <see cref="Pattern"/>.</returns>
		[return: NotNull]
		public static Pattern Not(this Rune rune) => new RuneLiteral(rune).Not();

		/// <summary>
		/// Marks this <see cref="Pattern"/> as negated.
		/// </summary>
		/// <param name="string">The string literal pattern.</param>
		/// <returns>A new <see cref="Pattern"/> which matches the negation of this <see cref="Pattern"/>.</returns>
		[return: NotNull]
		public static Pattern Not([DisallowNull] this String @string) => new StringLiteral(@string).Not();
	}
}
