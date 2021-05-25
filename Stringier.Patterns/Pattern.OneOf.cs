using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Stringier.Patterns {
	public partial class Pattern {
		/// <summary>
		/// Declares the <paramref name="patterns"/> to be alternates of each other; one of them will match.
		/// </summary>
		/// <param name="patterns">The set of <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> alternating all of the <paramref name="patterns"/>.</returns>
		[return: MaybeNull]
		public static Pattern OneOf([AllowNull] params Pattern[] patterns) => (patterns is not null && patterns.Length > 0) ? new ChainAlternator(patterns) : null;

		///// <summary>
		///// Declares the <paramref name="patterns"/> to be alternates of each other; one of them will match.
		///// </summary>
		///// <param name="patterns">The set of <see cref="Char"/>.</param>
		///// <returns>A new <see cref="Pattern"/> alternating all of the <paramref name="patterns"/>.</returns>
		//[return: MaybeNull]
		//public static Pattern OneOf([AllowNull] params Char[] patterns) => OneOf(default, patterns);

		///// <summary>
		///// Declares the <paramref name="patterns"/> to be alternates of each other; one of them will match.
		///// </summary>
		///// <param name="casing">The <see cref="Case"/> to use for all <paramref name="patterns"/>.</param>
		///// <param name="patterns">The set of <see cref="Char"/>.</param>
		///// <returns>A new <see cref="Pattern"/> alternating all of the <paramref name="patterns"/>.</returns>
		//[return: MaybeNull]
		//public static Pattern OneOf(Case casing, [AllowNull] params Char[] patterns) => throw new NotImplementedException();

		///// <summary>
		///// Declares the <paramref name="patterns"/> to be alternates of each other; one of them will match.
		///// </summary>
		///// <param name="patterns">The set of <see cref="Rune"/>.</param>
		///// <returns>A new <see cref="Pattern"/> alternating all of the <paramref name="patterns"/>.</returns>
		//[return: MaybeNull]
		//public static Pattern OneOf([AllowNull] params Rune[] patterns) => OneOf(default, patterns);

		///// <summary>
		///// Declares the <paramref name="patterns"/> to be alternates of each other; one of them will match.
		///// </summary>
		///// <param name="casing">The <see cref="Case"/> to use for all <paramref name="patterns"/>.</param>
		///// <param name="patterns">The set of <see cref="Rune"/>.</param>
		///// <returns>A new <see cref="Pattern"/> alternating all of the <paramref name="patterns"/>.</returns>
		//[return: MaybeNull]
		//public static Pattern OneOf(Case casing, [AllowNull] params Rune[] patterns) => throw new NotImplementedException();

		///// <summary>
		///// Declares the <paramref name="patterns"/> to be alternates of each other; one of them will match.
		///// </summary>
		///// <param name="patterns">The set of <see cref="String"/>.</param>
		///// <returns>A new <see cref="Pattern"/> alternating all of the <paramref name="patterns"/>.</returns>
		//[return: MaybeNull]
		//public static Pattern OneOf([AllowNull] params String[] patterns) => OneOf(default, patterns);

		///// <summary>
		///// Declares the <paramref name="patterns"/> to be alternates of each other; one of them will match.
		///// </summary>
		///// <param name="casing">The <see cref="Case"/> to use for all <paramref name="patterns"/>.</param>
		///// <param name="patterns">The set of <see cref="String"/>.</param>
		///// <returns>A new <see cref="Pattern"/> alternating all of the <paramref name="patterns"/>.</returns>
		//[return: MaybeNull]
		//public static Pattern OneOf(Case casing, [AllowNull] params String[] patterns) => throw new NotImplementedException();

#if !NETSTANDARD1_3
		/// <summary>
		/// Declares the names of <typeparamref name="E"/> to be alternates of each other; one of them will match.
		/// </summary>
		/// <typeparam name="E">The <see cref="Enum"/> providing names.</typeparam>
		/// <returns>A new <see cref="Pattern"/> alternating all the names of <typeparamref name="E"/>.</returns>
		[return: MaybeNull]
		public static Pattern OneOf<E>() where E : struct, Enum => OneOf<E>(default);

		/// <summary>
		/// Declares the names of <typeparamref name="TEnum"/> to be alternates of each other; one of them should match.
		/// </summary>
		/// <param name="casing">The <see cref="Case"/> to use for all <typeparamref name="TEnum"/>.</param>
		/// <typeparam name="TEnum">The <see cref="Enum"/> providing names.</typeparam>
		/// <returns>A new <see cref="Pattern"/> alternating all the names of <typeparamref name="TEnum"/>.</returns>
		[return: MaybeNull]
		public static Pattern OneOf<TEnum>(Case casing) where TEnum : struct, Enum => new ChainEnumAlternator<TEnum>(casing);
#endif
	}
}
