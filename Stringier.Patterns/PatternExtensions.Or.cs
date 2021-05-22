using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Stringier.Patterns {
	public static partial class PatternExtensions {
		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="char">The char literal pattern.</param>
		/// <param name="other">The <see cref="Pattern"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> or <paramref name="other"/>.</returns>
		[return: NotNull]
		public static Pattern Or(this Char @char, [AllowNull] Pattern other) => new CharLiteral(@char).Or(other);

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="char">The char literal pattern.</param>
		/// <param name="other">The <see cref="Char"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> or <paramref name="other"/>.</returns>
		[return: NotNull]
		public static Pattern Or(this Char @char, Char other) => new CharLiteral(@char).Or(other);

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="char">The char literal pattern.</param>
		/// <param name="other">The <see cref="Rune"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> or <paramref name="other"/>.</returns>
		[return: NotNull]
		public static Pattern Or(this Char @char, Rune other) => new CharLiteral(@char).Or(other);

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="char">The char literal pattern.</param>
		/// <param name="other">The <see cref="String"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> or <paramref name="other"/>.</returns>
		[return: NotNull]
		public static Pattern Or(this Char @char, [AllowNull] String other) => new CharLiteral(@char).Or(other);

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="rune">The rune literal pattern.</param>
		/// <param name="other">The <see cref="Pattern"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> or <paramref name="other"/>.</returns>
		[return: NotNull]
		public static Pattern Or(this Rune rune, [AllowNull] Pattern other) => new RuneLiteral(rune).Or(other);

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="rune">The rune literal pattern.</param>
		/// <param name="other">The <see cref="Char"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> or <paramref name="other"/>.</returns>
		[return: NotNull]
		public static Pattern Or(this Rune rune, Char other) => new RuneLiteral(rune).Or(other);

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="rune">The rune literal pattern.</param>
		/// <param name="other">The <see cref="Rune"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> or <paramref name="other"/>.</returns>
		[return: NotNull]
		public static Pattern Or(this Rune rune, Rune other) => new RuneLiteral(rune).Or(other);

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="rune">The rune literal pattern.</param>
		/// <param name="other">The <see cref="String"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> or <paramref name="other"/>.</returns>
		[return: NotNull]
		public static Pattern Or(this Rune rune, [AllowNull] String other) => new RuneLiteral(rune).Or(other);

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="rune">The string literal pattern.</param>
		/// <param name="other">The <see cref="Pattern"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> or <paramref name="other"/>.</returns>
		[return: NotNull]
		public static Pattern Or([DisallowNull] this String rune, [AllowNull] Pattern other) => new StringLiteral(rune).Or(other);

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="rune">The string literal pattern.</param>
		/// <param name="other">The <see cref="Char"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> or <paramref name="other"/>.</returns>
		[return: NotNull]
		public static Pattern Or([DisallowNull] this String rune, Char other) => new StringLiteral(rune).Or(other);

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="rune">The string literal pattern.</param>
		/// <param name="other">The <see cref="Rune"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> or <paramref name="other"/>.</returns>
		[return: NotNull]
		public static Pattern Or([DisallowNull] this String rune, Rune other) => new StringLiteral(rune).Or(other);

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="string">The string literal pattern.</param>
		/// <param name="other">The <see cref="String"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> or <paramref name="other"/>.</returns>
		[return: NotNull]
		public static Pattern Or([DisallowNull] this String @string, [AllowNull] String other) => new StringLiteral(@string).Or(other);
	}
}
