using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Stringier {
	public static partial class PatternExtensions {
		/// <summary>
		/// Marks this <see cref="Pattern"/> as optional.
		/// </summary>
		/// <param name="char">The char literal pattern.</param>
		/// <returns>A new <see cref="Pattern"/> which may or may not be present in order to match.</returns>
		[return: NotNull]
		public static Pattern Maybe(this Char @char) => new CharLiteral(@char).Maybe();

		/// <summary>
		/// Marks this <see cref="Pattern"/> as optional.
		/// </summary>
		/// <param name="rune">The rune literal pattern.</param>
		/// <returns>A new <see cref="Pattern"/> which may or may not be present in order to match.</returns>
		[return: NotNull]
		public static Pattern Maybe(this Rune rune) => new RuneLiteral(rune).Maybe();

		/// <summary>
		/// Marks this <see cref="Pattern"/> as optional.
		/// </summary>
		/// <param name="string">The string literal pattern.</param>
		/// <returns>A new <see cref="Pattern"/> which may or may not be present in order to match.</returns>
		[return: NotNull]
		public static Pattern Maybe(this String @string) => new StringLiteral(@string).Maybe();
	}
}
