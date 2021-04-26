using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Parses a <typeparamref name="TElement"/> from the <paramref name="source"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements being parsed.</typeparam>
		/// <param name="parser">This parser.</param>
		/// <param name="source">The source to parse.</param>
		/// <param name="pos">The position within the <paramref name="source"/>.</param>
		/// <returns>The element that was parsed.</returns>
		/// <remarks>
		/// When this call occurs <paramref name="pos"/> is the index at which to begin parsing. As this method executes <paramref name="pos"/> is updated such that when this call returns <paramref name="pos"/> is after the parsed value. This allows for continually parsing elements from the <paramref name="source"/>.
		/// </remarks>
		[return: MaybeNull]
		public static TElement Parse<TElement>([AllowNull] this IParse<TElement> parser, [AllowNull] String source, ref Int32 pos) => parser is not null ? parser.Parse(source, ref pos) : default;

		/// <summary>
		/// Parses a <typeparamref name="TElement"/> from the <paramref name="source"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements being parsed.</typeparam>
		/// <param name="parser">This parser.</param>
		/// <param name="source">The source to parse.</param>
		/// <param name="pos">The position within the <paramref name="source"/>.</param>
		/// <returns>The element that was parsed.</returns>
		/// <remarks>
		/// When this call occurs <paramref name="pos"/> is the index at which to begin parsing. As this method executes <paramref name="pos"/> is updated such that when this call returns <paramref name="pos"/> is after the parsed value. This allows for continually parsing elements from the <paramref name="source"/>.
		/// </remarks>
		[return: MaybeNull]
		public static TElement Parse<TElement>([AllowNull] this IParse<TElement> parser, [AllowNull] Char[] source, ref Int32 pos) => parser is not null ? parser.Parse(source, ref pos) : default;

		/// <summary>
		/// Parses a <typeparamref name="TElement"/> from the <paramref name="source"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements being parsed.</typeparam>
		/// <param name="parser">This parser.</param>
		/// <param name="source">The source to parse.</param>
		/// <param name="pos">The position within the <paramref name="source"/>.</param>
		/// <returns>The element that was parsed.</returns>
		/// <remarks>
		/// When this call occurs <paramref name="pos"/> is the index at which to begin parsing. As this method executes <paramref name="pos"/> is updated such that when this call returns <paramref name="pos"/> is after the parsed value. This allows for continually parsing elements from the <paramref name="source"/>.
		/// </remarks>
		[return: MaybeNull]
		public static TElement Parse<TElement>([AllowNull] this IParse<TElement> parser, Memory<Char> source, ref Int32 pos) => parser is not null ? parser.Parse(source, ref pos) : default;

		/// <summary>
		/// Parses a <typeparamref name="TElement"/> from the <paramref name="source"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements being parsed.</typeparam>
		/// <param name="parser">This parser.</param>
		/// <param name="source">The source to parse.</param>
		/// <param name="pos">The position within the <paramref name="source"/>.</param>
		/// <returns>The element that was parsed.</returns>
		/// <remarks>
		/// When this call occurs <paramref name="pos"/> is the index at which to begin parsing. As this method executes <paramref name="pos"/> is updated such that when this call returns <paramref name="pos"/> is after the parsed value. This allows for continually parsing elements from the <paramref name="source"/>.
		/// </remarks>
		[return: MaybeNull]
		public static TElement Parse<TElement>([AllowNull] this IParse<TElement> parser, ReadOnlyMemory<Char> source, ref Int32 pos) => parser is not null ? parser.Parse(source, ref pos) : default;

		/// <summary>
		/// Parses a <typeparamref name="TElement"/> from the <paramref name="source"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements being parsed.</typeparam>
		/// <param name="parser">This parser.</param>
		/// <param name="source">The source to parse.</param>
		/// <param name="pos">The position within the <paramref name="source"/>.</param>
		/// <returns>The element that was parsed.</returns>
		/// <remarks>
		/// When this call occurs <paramref name="pos"/> is the index at which to begin parsing. As this method executes <paramref name="pos"/> is updated such that when this call returns <paramref name="pos"/> is after the parsed value. This allows for continually parsing elements from the <paramref name="source"/>.
		/// </remarks>
		[return: MaybeNull]
		public static TElement Parse<TElement>([AllowNull] this IParse<TElement> parser, Span<Char> source, ref Int32 pos) => parser is not null ? parser.Parse(source, ref pos) : default;

		/// <summary>
		/// Parses a <typeparamref name="TElement"/> from the <paramref name="source"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements being parsed.</typeparam>
		/// <param name="parser">This parser.</param>
		/// <param name="source">The source to parse.</param>
		/// <param name="pos">The position within the <paramref name="source"/>.</param>
		/// <returns>The element that was parsed.</returns>
		/// <remarks>
		/// When this call occurs <paramref name="pos"/> is the index at which to begin parsing. As this method executes <paramref name="pos"/> is updated such that when this call returns <paramref name="pos"/> is after the parsed value. This allows for continually parsing elements from the <paramref name="source"/>.
		/// </remarks>
		[return: MaybeNull]
		public static TElement Parse<TElement>([AllowNull] this IParse<TElement> parser, ReadOnlySpan<Char> source, ref Int32 pos) => parser is not null ? parser.Parse(source, ref pos) : default;

		/// <summary>
		/// Parses a <typeparamref name="TElement"/> from the <paramref name="source"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements being parsed.</typeparam>
		/// <param name="parser">This parser.</param>
		/// <param name="source">The source to parse.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="pos">The position within the <paramref name="source"/>.</param>
		/// <returns>The element that was parsed.</returns>
		/// <remarks>
		/// When this call occurs <paramref name="pos"/> is the index at which to begin parsing. As this method executes <paramref name="pos"/> is updated such that when this call returns <paramref name="pos"/> is after the parsed value. This allows for continually parsing elements from the <paramref name="source"/>.
		/// </remarks>
		[CLSCompliant(false)]
		[return: MaybeNull]
		public static unsafe TElement Parse<TElement>([AllowNull] this IParseUnsafe<TElement> parser, [AllowNull] Char* source, Int32 length, ref Int32 pos) => parser is not null ? parser.Parse(source, length, ref pos) : default;
	}
}
