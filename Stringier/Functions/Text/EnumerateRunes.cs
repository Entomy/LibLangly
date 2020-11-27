using System;
using System.Text;

namespace Langly {
	public static partial class Text {
		/// <summary>
		/// Returns an enumeration of <see cref="Rune"/> from this string.
		/// </summary>
		/// <remarks>
		/// Invalid sequences will be represented in the enumeration by <see cref="Rune.ReplacementChar"/>.
		/// </remarks>
		public static StringRuneEnumerator EnumerateRunes(this String @string) =>
#if NETSTANDARD1_3
			new StringRuneEnumerator(@string);
#else
			@string.EnumerateRunes();
#endif

		/// <summary>
		/// Returns an enumeration of <see cref="Rune"/> from this array.
		/// </summary>
		/// <remarks>
		/// Invalid sequences will be represented in the enumeration by <see cref="Rune.ReplacementChar"/>.
		/// </remarks>
		public static SpanRuneEnumerator EnumerateRunes(this Char[] array) =>
#if NETSTANDARD1_3
			new SpanRuneEnumerator(array.AsSpan());
#else
			MemoryExtensions.EnumerateRunes(array.AsSpan());
#endif

		/// <summary>
		/// Returns an enumeration of <see cref="Rune"/> from the provided span.
		/// </summary>
		/// <remarks>
		/// Invalid sequences will be represented in the enumeration by <see cref="Rune.ReplacementChar"/>.
		/// </remarks>
		public static SpanRuneEnumerator EnumerateRunes(this ReadOnlyMemory<Char> memory) =>
#if NETSTANDARD1_3
			new SpanRuneEnumerator(span);
#else
			MemoryExtensions.EnumerateRunes(memory.Span);
#endif

		/// <summary>
		/// Returns an enumeration of <see cref="Rune"/> from the provided span.
		/// </summary>
		/// <remarks>
		/// Invalid sequences will be represented in the enumeration by <see cref="Rune.ReplacementChar"/>.
		/// </remarks>
		public static SpanRuneEnumerator EnumerateRunes(this Memory<Char> memory) =>
#if NETSTANDARD1_3
			new SpanRuneEnumerator(span);
#else
			MemoryExtensions.EnumerateRunes(memory.Span);
#endif

		/// <summary>
		/// Returns an enumeration of <see cref="Rune"/> from the provided span.
		/// </summary>
		/// <remarks>
		/// Invalid sequences will be represented in the enumeration by <see cref="Rune.ReplacementChar"/>.
		/// </remarks>
		public static SpanRuneEnumerator EnumerateRunes(this ReadOnlySpan<Char> span) =>
#if NETSTANDARD1_3
			new SpanRuneEnumerator(span);
#else
			MemoryExtensions.EnumerateRunes(span);
#endif


		/// <summary>
		/// Returns an enumeration of <see cref="Rune"/> from the provided span.
		/// </summary>
		/// <remarks>
		/// Invalid sequences will be represented in the enumeration by <see cref="Rune.ReplacementChar"/>.
		/// </remarks>
		public static SpanRuneEnumerator EnumerateRunes(this Span<Char> span) =>
#if NETSTANDARD1_3
			new SpanRuneEnumerator(span);
#else
			MemoryExtensions.EnumerateRunes(span);
#endif
	}
}
