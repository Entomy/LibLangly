using System;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type is capable of parsing elements from a source.
	/// </summary>
	/// <typeparam name="TElement">The type of elements being parsed.</typeparam>
	[CLSCompliant(false)]
	public interface IParseUnsafe<out TElement> : IParse<TElement> {
		/// <summary>
		/// Parses a <typeparamref name="TElement"/> from the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The source to parse.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="pos">The position within the <paramref name="source"/>.</param>
		/// <returns>The element that was parsed.</returns>
		/// <remarks>
		/// When this call occurs <paramref name="pos"/> is the index at which to begin parsing. As this method executes <paramref name="pos"/> is updated such that when this call returns <paramref name="pos"/> is after the parsed value. This allows for continually parsing elements from the <paramref name="source"/>.
		/// </remarks>
		[return: MaybeNull]
		unsafe TElement Parse([AllowNull] Char* source, Int32 length, ref Int32 pos) => Parse(new ReadOnlySpan<Char>(source, length), ref pos);
	}
}
