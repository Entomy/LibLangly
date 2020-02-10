//! This exists to backport Rune to older runtimes, since we're going to take advantage of it throughout the entire project, so it must exist. By conditionally including it, and multitargeting both runtimes without and with the Rune type, it can be provided without colliding.
//! This (public) API must match the official one exactly. As such, copyright belongs to the .NET Foundation. The internals can be implemented using existing API's in Core.
//! This has to be handled specially. The methods provided here are provided in extension methods in a static class that already exists or directly in the class they dispatch from. As such, providing them is not as simple as it would normally be.

#if NETSTANDARD2_0
using System.Buffers;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using Defender;
using Stringier;

namespace System {
	/// <summary>
	/// Implements various <see cref="Rune"/> related methods that aren't directly part of <see cref="Rune"/>.
	/// </summary>
	public static class RuneExtensions {
		/// <summary>
		/// Returns an enumeration of <see cref="Rune"/> from this string.
		/// </summary>
		/// <remarks>
		/// Invalid sequences will be represented in the enumeration by <see cref="Rune.ReplacementChar"/>.
		/// </remarks>
		public static StringRuneEnumerator EnumerateRunes(this String @string) => new StringRuneEnumerator(@string);

		/// <summary>
		/// Returns an enumeration of <see cref="Rune"/> from the provided span.
		/// </summary>
		/// <remarks>
		/// Invalid sequences will be represented in the enumeration by <see cref="Rune.ReplacementChar"/>.
		/// </remarks>
		public static SpanRuneEnumerator EnumerateRunes(this ReadOnlySpan<Char> span) => new SpanRuneEnumerator(span);

		/// <summary>
		/// Returns an enumeration of <see cref="Rune"/> from the provided span.
		/// </summary>
		/// <remarks>
		/// Invalid sequences will be represented in the enumeration by <see cref="Rune.ReplacementChar"/>.
		/// </remarks>
		public static SpanRuneEnumerator EnumerateRunes(this Span<Char> span) => new SpanRuneEnumerator(span);
	}
}
#endif