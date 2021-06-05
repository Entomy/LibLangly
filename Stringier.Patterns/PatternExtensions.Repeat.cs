using System;
using System.Diagnostics.CodeAnalysis;
#if NETCOREAPP3_0_OR_GREATER
using System.Text;
#endif

namespace Stringier.Patterns {
	public static partial class PatternExtensions {
		/// <summary>
		/// Marks this <see cref="Pattern"/> as repeating <paramref name="count"/> times.
		/// </summary>
		/// <param name="char">The char literal pattern.</param>
		/// <param name="count">The amount of times to repeat.</param>
		/// <returns>A new <see cref="Pattern"/> repeated <paramref name="count"/> times.</returns>
		[return: NotNull]
		public static Pattern Repeat(this Char @char, Int32 count) => new CharLiteral(@char).Repeat(count);

#if NETCOREAPP3_0_OR_GREATER
		/// <summary>
		/// Marks this <see cref="Pattern"/> as repeating <paramref name="count"/> times.
		/// </summary>
		/// <param name="rune">The rune literal pattern.</param>
		/// <param name="count">The amount of times to repeat.</param>
		/// <returns>A new <see cref="Pattern"/> repeated <paramref name="count"/> times.</returns>
		[return: NotNull]
		public static Pattern Repeat(this Rune rune, Int32 count) => new RuneLiteral(rune).Repeat(count);
#endif

		/// <summary>
		/// Marks this <see cref="Pattern"/> as repeating <paramref name="count"/> times.
		/// </summary>
		/// <param name="string">The char literal pattern.</param>
		/// <param name="count">The amount of times to repeat.</param>
		/// <returns>A new <see cref="Pattern"/> repeated <paramref name="count"/> times.</returns>
		[return: NotNull]
		public static Pattern Repeat([DisallowNull] this String @string, Int32 count) => new MemoryLiteral(@string).Repeat(count);
	}
}
