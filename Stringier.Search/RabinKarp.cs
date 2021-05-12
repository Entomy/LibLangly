using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier {
	public static partial class Search {
		#region RabinKarp(Text, String)
		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp([AllowNull] String source, [AllowNull] String search) => RabinKarpKernel(source.AsSpan(), search.AsSpan());

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp([AllowNull] Char[] source, [AllowNull] String search) => RabinKarpKernel(source, search.AsSpan());

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(Memory<Char> source, [AllowNull] String search) => RabinKarpKernel(source.Span, search.AsSpan());

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(ReadOnlyMemory<Char> source, [AllowNull] String search) => RabinKarpKernel(source.Span, search.AsSpan());

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(Span<Char> source, [AllowNull] String search) => RabinKarpKernel(source, search.AsSpan());

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(ReadOnlySpan<Char> source, [AllowNull] String search) => RabinKarpKernel(source, search.AsSpan());

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 RabinKarp([AllowNull] Char* source, Int32 length, [AllowNull] String search) => RabinKarpKernel(new ReadOnlySpan<Char>(source, length), search.AsSpan());
		#endregion

		#region RabinKarp(Text, Char[])
		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp([AllowNull] String source, [AllowNull] Char[] search) => RabinKarpKernel(source.AsSpan(), search.AsSpan());

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp([AllowNull] Char[] source, [AllowNull] Char[] search) => RabinKarpKernel(source, search);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(Memory<Char> source, [AllowNull] Char[] search) => RabinKarpKernel(source.Span, search);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(ReadOnlyMemory<Char> source, [AllowNull] Char[] search) => RabinKarpKernel(source.Span, search);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(Span<Char> source, [AllowNull] Char[] search) => RabinKarpKernel(source, search);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(ReadOnlySpan<Char> source, [AllowNull] Char[] search) => RabinKarpKernel(source, search);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 RabinKarp([AllowNull] Char* source, Int32 length, [AllowNull] Char[] search) => RabinKarpKernel(new ReadOnlySpan<Char>(source, length), search);
		#endregion

		#region RabinKarp(Text, Memory<Char>)
		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp([AllowNull] String source, Memory<Char> search) => RabinKarpKernel(source.AsSpan(), search.Span);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp([AllowNull] Char[] source, Memory<Char> search) => RabinKarpKernel(source, search.Span);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(Memory<Char> source, Memory<Char> search) => RabinKarpKernel(source.Span, search.Span);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(ReadOnlyMemory<Char> source, Memory<Char> search) => RabinKarpKernel(source.Span, search.Span);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(Span<Char> source, Memory<Char> search) => RabinKarpKernel(source, search.Span);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(ReadOnlySpan<Char> source, Memory<Char> search) => RabinKarpKernel(source, search.Span);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 RabinKarp([AllowNull] Char* source, Int32 length, Memory<Char> search) => RabinKarpKernel(new ReadOnlySpan<Char>(source, length), search.Span);
		#endregion

		#region RabinKarp(Text, ReadOnlyMemory<Char>)
		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp([AllowNull] String source, ReadOnlyMemory<Char> search) => RabinKarpKernel(source.AsSpan(), search.Span);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp([AllowNull] Char[] source, ReadOnlyMemory<Char> search) => RabinKarpKernel(source, search.Span);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(Memory<Char> source, ReadOnlyMemory<Char> search) => RabinKarpKernel(source.Span, search.Span);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(ReadOnlyMemory<Char> source, ReadOnlyMemory<Char> search) => RabinKarpKernel(source.Span, search.Span);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(Span<Char> source, ReadOnlyMemory<Char> search) => RabinKarpKernel(source, search.Span);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(ReadOnlySpan<Char> source, ReadOnlyMemory<Char> search) => RabinKarpKernel(source, search.Span);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 RabinKarp([AllowNull] Char* source, Int32 length, ReadOnlyMemory<Char> search) => RabinKarpKernel(new ReadOnlySpan<Char>(source, length), search.Span);
		#endregion

		#region RabinKarp(Text, Span<Char>)
		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp([AllowNull] String source, Span<Char> search) => RabinKarpKernel(source.AsSpan(), search);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp([AllowNull] Char[] source, Span<Char> search) => RabinKarpKernel(source, search);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(Memory<Char> source, Span<Char> search) => RabinKarpKernel(source.Span, search);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(ReadOnlyMemory<Char> source, Span<Char> search) => RabinKarpKernel(source.Span, search);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(Span<Char> source, Span<Char> search) => RabinKarpKernel(source, search);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(ReadOnlySpan<Char> source, Span<Char> search) => RabinKarpKernel(source, search);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 RabinKarp([AllowNull] Char* source, Int32 length, Span<Char> search) => RabinKarpKernel(new ReadOnlySpan<Char>(source, length), search);
		#endregion

		#region RabinKarp(Text, ReadOnlySpan<Char>)
		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp([AllowNull] String source, ReadOnlySpan<Char> search) => RabinKarpKernel(source.AsSpan(), search);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp([AllowNull] Char[] source, ReadOnlySpan<Char> search) => RabinKarpKernel(source, search);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(Memory<Char> source, ReadOnlySpan<Char> search) => RabinKarpKernel(source.Span, search);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(ReadOnlyMemory<Char> source, ReadOnlySpan<Char> search) => RabinKarpKernel(source.Span, search);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(Span<Char> source, ReadOnlySpan<Char> search) => RabinKarpKernel(source, search);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(ReadOnlySpan<Char> source, ReadOnlySpan<Char> search) => RabinKarpKernel(source, search);

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 RabinKarp([AllowNull] Char* source, Int32 length, ReadOnlySpan<Char> search) => RabinKarpKernel(new ReadOnlySpan<Char>(source, length), search);
		#endregion

		#region RabinKarp(Text, Char*, Int32)
		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 RabinKarp([AllowNull] String source, [AllowNull] Char* search, Int32 length) => RabinKarpKernel(source.AsSpan(), new ReadOnlySpan<Char>(search, length));

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 RabinKarp([AllowNull] Char[] source, [AllowNull] Char* search, Int32 length) => RabinKarpKernel(source, new ReadOnlySpan<Char>(search, length));

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 RabinKarp(Memory<Char> source, [AllowNull] Char* search, Int32 length) => RabinKarpKernel(source.Span, new ReadOnlySpan<Char>(search, length));

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 RabinKarp(ReadOnlyMemory<Char> source, [AllowNull] Char* search, Int32 length) => RabinKarpKernel(source.Span, new ReadOnlySpan<Char>(search, length));

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 RabinKarp(Span<Char> source, [AllowNull] Char* search, Int32 length) => RabinKarpKernel(source, new ReadOnlySpan<Char>(search, length));

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 RabinKarp(ReadOnlySpan<Char> source, [AllowNull] Char* search, Int32 length) => RabinKarpKernel(source, new ReadOnlySpan<Char>(search, length));

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="sourceLength">The length of the <paramref name="source"/>.</param>
		/// <param name="search">The text to search for.</param>
		/// <param name="searchLength">The length of the <paramref name="search"/>.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 RabinKarp([AllowNull] Char* source, Int32 sourceLength, [AllowNull] Char* search, Int32 searchLength) => RabinKarpKernel(new ReadOnlySpan<Char>(source, sourceLength), new ReadOnlySpan<Char>(search, searchLength));
		#endregion

		private static Int32 RabinKarpKernel(ReadOnlySpan<Char> source, ReadOnlySpan<Char> search) {
			Int32 siga = 0;
			Int32 sigb = 0;
			const Int32 Q = 100007;
			const Int32 D = 256;
			for (Int32 i = 0; i < search.Length; i++) {
				siga = ((siga * D) + source[i]) % Q;
				sigb = ((sigb * D) + search[i]) % Q;
			}
			if (siga == sigb) {
				return 0;
			}
			Int32 pow = 1;
			for (Int32 k = 1; k <= search.Length - 1; k++) {
				pow = pow * D % Q;
			}
			for (Int32 j = 1; j <= source.Length - search.Length; j++) {
				siga = (siga + Q - (pow * source[j - 1] % Q)) % Q;
				siga = ((siga * D) + source[j + search.Length - 1]) % Q;
				if (siga == sigb && source.Slice(j, search.Length).Equals(search, StringComparison.Ordinal)) {
					return j;
				}
			}
			return -1;
		}
	}
}
