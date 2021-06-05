using System;
using System.Diagnostics.CodeAnalysis;
#if NETCOREAPP3_0_OR_GREATER
using System.Text;
#endif

namespace Stringier.Patterns {
	public static partial class PatternExtensions {
		/// <summary>
		/// Create a pattern representing the range from this <see cref="Pattern"/> until <paramref name="to"/>.
		/// </summary>
		/// <param name="char">The char literal pattern.</param>
		/// <param name="to">The ending <see cref="Pattern"/>.</param>
		[return: NotNull]
		public static Pattern To(this Char @char, [DisallowNull] Pattern to) => new Ranger(@char, to);

		/// <summary>
		/// Create a pattern representing the range from this <see cref="Pattern"/> until <paramref name="to"/>, allowing an <paramref name="escape"/>.
		/// </summary>
		/// <param name="char">The char literal pattern.</param>
		/// <param name="to">The ending <see cref="Pattern"/>.</param>
		/// <param name="escape">The escape <see cref="Pattern"/>./</param>
		/// <remarks>
		/// If <paramref name="escape"/> is <see langword="null"/> this does the same as <see cref="To(Char, Pattern)"/>.
		/// </remarks>
		[return: NotNull]
		public static Pattern To(this Char @char, [DisallowNull] Pattern to, [AllowNull] Pattern escape) => escape is not null ? new EscapedRanger(@char, to, escape) : new Ranger(@char, to);

		/// <summary>
		/// Create a pattern representing the range from this <see cref="Pattern"/> until <paramref name="to"/>, that allows nesting of this pattern inside of itself.
		/// </summary>
		/// <remarks>
		/// The easiest way to explain this is that is shows up a lot in programming, with things like if-then-else statements which can contain other if-then-else statements.
		/// </remarks>
		/// <param name="char">The char literal pattern.</param>
		/// <param name="to">The ending <see cref="Pattern"/>.</param>
		[return: NotNull]
		public static Pattern ToNested(this Char @char, [DisallowNull] Pattern to) => new NestedRanger(@char, to);

#if NETCOREAPP3_0_OR_GREATER
		/// <summary>
		/// Create a pattern representing the range from this <see cref="Pattern"/> until <paramref name="to"/>.
		/// </summary>
		/// <param name="rune">The rune literal pattern.</param>
		/// <param name="to">The ending <see cref="Pattern"/>.</param>
		[return: NotNull]
		public static Pattern To(this Rune rune, [DisallowNull] Pattern to) => new Ranger(rune, to);

		/// <summary>
		/// Create a pattern representing the range from this <see cref="Pattern"/> until <paramref name="to"/>, allowing an <paramref name="escape"/>.
		/// </summary>
		/// <param name="rune">The rune literal pattern.</param>
		/// <param name="to">The ending <see cref="Pattern"/>.</param>
		/// <param name="escape">The escape <see cref="Pattern"/>./</param>
		/// <remarks>
		/// If <paramref name="escape"/> is <see langword="null"/> this does the same as <see cref="To(Rune, Pattern)"/>.
		/// </remarks>
		[return: NotNull]
		public static Pattern To(this Rune rune, [DisallowNull] Pattern to, [AllowNull] Pattern escape) => escape is not null ? new EscapedRanger(rune, to, escape) : new Ranger(rune, to);

		/// <summary>
		/// Create a pattern representing the range from this <see cref="Pattern"/> until <paramref name="to"/>, that allows nesting of this pattern inside of itself.
		/// </summary>
		/// <remarks>
		/// The easiest way to explain this is that is shows up a lot in programming, with things like if-then-else statements which can contain other if-then-else statements.
		/// </remarks>
		/// <param name="rune">The rune literal pattern.</param>
		/// <param name="to">The ending <see cref="Pattern"/>.</param>
		[return: NotNull]
		public static Pattern ToNested(this Rune rune, [DisallowNull] Pattern to) => new NestedRanger(rune, to);
#endif

		/// <summary>
		/// Create a pattern representing the range from this <see cref="Pattern"/> until <paramref name="to"/>.
		/// </summary>
		/// <param name="string">The string literal pattern.</param>
		/// <param name="to">The ending <see cref="Pattern"/>.</param>
		[return: NotNull]
		public static Pattern To(this String @string, [DisallowNull] Pattern to) => new Ranger(@string, to);

		/// <summary>
		/// Create a pattern representing the range from this <see cref="Pattern"/> until <paramref name="to"/>, allowing an <paramref name="escape"/>.
		/// </summary>
		/// <param name="string">The string literal pattern.</param>
		/// <param name="to">The ending <see cref="Pattern"/>.</param>
		/// <param name="escape">The escape <see cref="Pattern"/>./</param>
		/// <remarks>
		/// If <paramref name="escape"/> is <see langword="null"/> this does the same as <see cref="To(Char, Pattern)"/>.
		/// </remarks>
		[return: NotNull]
		public static Pattern To(this String @string, [DisallowNull] Pattern to, [AllowNull] Pattern escape) => escape is not null ? new EscapedRanger(@string, to, escape) : new Ranger(@string, to);

		/// <summary>
		/// Create a pattern representing the range from this <see cref="Pattern"/> until <paramref name="to"/>, that allows nesting of this pattern inside of itself.
		/// </summary>
		/// <remarks>
		/// The easiest way to explain this is that is shows up a lot in programming, with things like if-then-else statements which can contain other if-then-else statements.
		/// </remarks>
		/// <param name="string">The string literal pattern.</param>
		/// <param name="to">The ending <see cref="Pattern"/>.</param>
		[return: NotNull]
		public static Pattern ToNested(this String @string, [DisallowNull] Pattern to) => new NestedRanger(@string, to);
	}
}
