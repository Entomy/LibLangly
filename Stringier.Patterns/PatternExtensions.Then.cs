using System;
using System.Diagnostics.CodeAnalysis;
#if NETCOREAPP3_0_OR_GREATER
using System.Text;
#endif

namespace Stringier.Patterns {
	public static partial class PatternExtensions {
		/// <summary>
		/// Concatenates the nodes so that this <see cref="Pattern"/> comes before the <paramref name="other"/> <see cref="Pattern"/>.
		/// </summary>
		/// <param name="char">The char literal pattern.</param>
		/// <param name="other">The succeeding <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> then <paramref name="other"/>.</returns>
		[return: NotNull]
		public static Pattern Then(this Char @char, [AllowNull] Pattern other) => new CharLiteral(@char).Then(other);

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="char">The char literal pattern.</param>
		/// <param name="other">The succeeding <see cref="Char"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		[return: NotNull]
		public static Pattern Then(this Char @char, Char other) => new CharLiteral(@char).Then(other);

#if NETCOREAPP3_0_OR_GREATER
		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="char">The char literal pattern.</param>
		/// <param name="other">The succeeding <see cref="Rune"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		[return: NotNull]
		public static Pattern Then(this Char @char, Rune other) => new CharLiteral(@char).Then(other);
#endif

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Pattern"/> comes before the <paramref name="other"/> <see cref="String"/>.
		/// </summary>
		/// <param name="char">The char literal pattern.</param>
		/// <param name="other">The succeeding <see cref="String"/>.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> then <paramref name="other"/>.</returns>
		[return: NotNull]
		public static Pattern Then(this Char @char, [AllowNull] String other) => new CharLiteral(@char).Then(other);

#if NETCOREAPP3_0_OR_GREATER
		/// <summary>
		/// Concatenates the nodes so that this <see cref="Pattern"/> comes before the <paramref name="other"/> <see cref="Pattern"/>.
		/// </summary>
		/// <param name="rune">The rune literal pattern.</param>
		/// <param name="other">The succeeding <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> then <paramref name="other"/>.</returns>
		[return: NotNull]
		public static Pattern Then(this Rune rune, [AllowNull] Pattern other) => new RuneLiteral(rune).Then(other);

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="rune">The rune literal pattern.</param>
		/// <param name="other">The succeeding <see cref="Char"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		[return: NotNull]
		public static Pattern Then(this Rune rune, Char other) => new RuneLiteral(rune).Then(other);

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="rune">The rune literal pattern.</param>
		/// <param name="other">The succeeding <see cref="Rune"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		[return: NotNull]
		public static Pattern Then(this Rune rune, Rune other) => new RuneLiteral(rune).Then(other);

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Pattern"/> comes before the <paramref name="other"/> <see cref="String"/>.
		/// </summary>
		/// <param name="rune">The rune literal pattern.</param>
		/// <param name="other">The succeeding <see cref="String"/>.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> then <paramref name="other"/>.</returns>
		[return: NotNull]
		public static Pattern Then(this Rune rune, [AllowNull] String other) => new RuneLiteral(rune).Then(other);
#endif

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Pattern"/> comes before the <paramref name="other"/> <see cref="Pattern"/>.
		/// </summary>
		/// <param name="char">The string literal pattern.</param>
		/// <param name="other">The succeeding <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> then <paramref name="other"/>.</returns>
		[return: NotNull]
		public static Pattern Then([DisallowNull] this String @char, [AllowNull] Pattern other) => new MemoryLiteral(@char).Then(other);

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="char">The string literal pattern.</param>
		/// <param name="other">The succeeding <see cref="Char"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		[return: NotNull]
		public static Pattern Then([DisallowNull] this String @char, Char other) => new MemoryLiteral(@char).Then(other);

#if NETCOREAPP3_0_OR_GREATER
		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="char">The string literal pattern.</param>
		/// <param name="other">The succeeding <see cref="Rune"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		[return: NotNull]
		public static Pattern Then([DisallowNull] this String @char, Rune other) => new MemoryLiteral(@char).Then(other);
#endif

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Pattern"/> comes before the <paramref name="other"/> <see cref="String"/>.
		/// </summary>
		/// <param name="char">The string literal pattern.</param>
		/// <param name="other">The succeeding <see cref="String"/>.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> then <paramref name="other"/>.</returns>
		[return: NotNull]
		public static Pattern Then([DisallowNull] this String @char, [AllowNull] String other) => new MemoryLiteral(@char).Then(other);
	}
}
