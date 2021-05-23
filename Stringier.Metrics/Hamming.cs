using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier {
	public static partial class EditDistance {
		#region Hamming(Text, String)
		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming([AllowNull] String first, [AllowNull] String second) => HammingKernel(first.AsSpan(), second.AsSpan());

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming([AllowNull] Char[] first, [AllowNull] String second) => HammingKernel(first, second.AsSpan());

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Memory<Char> first, [AllowNull] String second) => HammingKernel(first.Span, second.AsSpan());

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlyMemory<Char> first, [AllowNull] String second) => HammingKernel(first.Span, second.AsSpan());

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Span<Char> first, [AllowNull] String second) => HammingKernel(first, second.AsSpan());

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlySpan<Char> first, [AllowNull] String second) => HammingKernel(first, second.AsSpan());

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="length">The length of the <paramref name="first"/>.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming([AllowNull] Char* first, Int32 length, [AllowNull] String second) => HammingKernel(new ReadOnlySpan<Char>(first, length), second.AsSpan());
		#endregion

		#region Hamming(Text, String, Case)
		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming([AllowNull] String first, [AllowNull] String second, Case casing) => HammingKernel(first.AsSpan(), second.AsSpan(), casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming([AllowNull] Char[] first, [AllowNull] String second, Case casing) => HammingKernel(first, second.AsSpan(), casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Memory<Char> first, [AllowNull] String second, Case casing) => HammingKernel(first.Span, second.AsSpan(), casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlyMemory<Char> first, [AllowNull] String second, Case casing) => HammingKernel(first.Span, second.AsSpan(), casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Span<Char> first, [AllowNull] String second, Case casing) => HammingKernel(first, second.AsSpan(), casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlySpan<Char> first, [AllowNull] String second, Case casing) => HammingKernel(first, second.AsSpan(), casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="length">The length of the <paramref name="first"/>.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming([AllowNull] Char* first, Int32 length, [AllowNull] String second, Case casing) => HammingKernel(new ReadOnlySpan<Char>(first, length), second.AsSpan(), casing);
		#endregion

		#region Hamming(Text, Char[])
		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming([AllowNull] String first, [AllowNull] Char[] second) => HammingKernel(first.AsSpan(), second);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming([AllowNull] Char[] first, [AllowNull] Char[] second) => HammingKernel(first, second);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Memory<Char> first, [AllowNull] Char[] second) => HammingKernel(first.Span, second);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlyMemory<Char> first, [AllowNull] Char[] second) => HammingKernel(first.Span, second);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Span<Char> first, [AllowNull] Char[] second) => HammingKernel(first, second);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlySpan<Char> first, [AllowNull] Char[] second) => HammingKernel(first, second);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="length">The length of the <paramref name="first"/>.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming([AllowNull] Char* first, Int32 length, [AllowNull] Char[] second) => HammingKernel(new ReadOnlySpan<Char>(first, length), second);
		#endregion

		#region Hamming(Text, Char[], Case)
		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming([AllowNull] String first, [AllowNull] Char[] second, Case casing) => HammingKernel(first.AsSpan(), second, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming([AllowNull] Char[] first, [AllowNull] Char[] second, Case casing) => HammingKernel(first, second, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Memory<Char> first, [AllowNull] Char[] second, Case casing) => HammingKernel(first.Span, second, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlyMemory<Char> first, [AllowNull] Char[] second, Case casing) => HammingKernel(first.Span, second, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Span<Char> first, [AllowNull] Char[] second, Case casing) => HammingKernel(first, second, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlySpan<Char> first, [AllowNull] Char[] second, Case casing) => HammingKernel(first, second, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="length">The length of the <paramref name="first"/>.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming([AllowNull] Char* first, Int32 length, [AllowNull] Char[] second, Case casing) => HammingKernel(new ReadOnlySpan<Char>(first, length), second, casing);
		#endregion

		#region Hamming(Text, Memory<Char>)
		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming([AllowNull] String first, Memory<Char> second) => HammingKernel(first.AsSpan(), second.Span);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming([AllowNull] Char[] first, Memory<Char> second) => HammingKernel(first, second.Span);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Memory<Char> first, Memory<Char> second) => HammingKernel(first.Span, second.Span);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlyMemory<Char> first, Memory<Char> second) => HammingKernel(first.Span, second.Span);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Span<Char> first, Memory<Char> second) => HammingKernel(first, second.Span);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlySpan<Char> first, Memory<Char> second) => HammingKernel(first, second.Span);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="length">The length of the <paramref name="first"/>.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming([AllowNull] Char* first, Int32 length, Memory<Char> second) => HammingKernel(new ReadOnlySpan<Char>(first, length), second.Span);
		#endregion

		#region Hamming(Text, Memory<Char>, Case)
		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming([AllowNull] String first, Memory<Char> second, Case casing) => HammingKernel(first.AsSpan(), second.Span, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming([AllowNull] Char[] first, Memory<Char> second, Case casing) => HammingKernel(first, second.Span, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Memory<Char> first, Memory<Char> second, Case casing) => HammingKernel(first.Span, second.Span, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlyMemory<Char> first, Memory<Char> second, Case casing) => HammingKernel(first.Span, second.Span, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Span<Char> first, Memory<Char> second, Case casing) => HammingKernel(first, second.Span, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlySpan<Char> first, Memory<Char> second, Case casing) => HammingKernel(first, second.Span, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="length">The length of the <paramref name="first"/>.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming([AllowNull] Char* first, Int32 length, Memory<Char> second, Case casing) => HammingKernel(new ReadOnlySpan<Char>(first, length), second.Span, casing);
		#endregion

		#region Hamming(Text, ReadOnlyMemory<Char>)
		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming([AllowNull] String first, ReadOnlyMemory<Char> second) => HammingKernel(first.AsSpan(), second.Span);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming([AllowNull] Char[] first, ReadOnlyMemory<Char> second) => HammingKernel(first, second.Span);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Memory<Char> first, ReadOnlyMemory<Char> second) => HammingKernel(first.Span, second.Span);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlyMemory<Char> first, ReadOnlyMemory<Char> second) => HammingKernel(first.Span, second.Span);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Span<Char> first, ReadOnlyMemory<Char> second) => HammingKernel(first, second.Span);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlySpan<Char> first, ReadOnlyMemory<Char> second) => HammingKernel(first, second.Span);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="length">The length of the <paramref name="first"/>.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming([AllowNull] Char* first, Int32 length, ReadOnlyMemory<Char> second) => HammingKernel(new ReadOnlySpan<Char>(first, length), second.Span);
		#endregion

		#region Hamming(Text, ReadOnlyMemory<Char>, Case)
		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming([AllowNull] String first, ReadOnlyMemory<Char> second, Case casing) => HammingKernel(first.AsSpan(), second.Span, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming([AllowNull] Char[] first, ReadOnlyMemory<Char> second, Case casing) => HammingKernel(first, second.Span, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Memory<Char> first, ReadOnlyMemory<Char> second, Case casing) => HammingKernel(first.Span, second.Span, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlyMemory<Char> first, ReadOnlyMemory<Char> second, Case casing) => HammingKernel(first.Span, second.Span, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Span<Char> first, ReadOnlyMemory<Char> second, Case casing) => HammingKernel(first, second.Span, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlySpan<Char> first, ReadOnlyMemory<Char> second, Case casing) => HammingKernel(first, second.Span, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="length">The length of the <paramref name="first"/>.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming([AllowNull] Char* first, Int32 length, ReadOnlyMemory<Char> second, Case casing) => HammingKernel(new ReadOnlySpan<Char>(first, length), second.Span, casing);
		#endregion

		#region Hamming(Text, Span<Char>)
		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming([AllowNull] String first, Span<Char> second) => HammingKernel(first.AsSpan(), second);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming([AllowNull] Char[] first, Span<Char> second) => HammingKernel(first, second);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Memory<Char> first, Span<Char> second) => HammingKernel(first.Span, second);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlyMemory<Char> first, Span<Char> second) => HammingKernel(first.Span, second);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Span<Char> first, Span<Char> second) => HammingKernel(first, second);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlySpan<Char> first, Span<Char> second) => HammingKernel(first, second);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="length">The length of the <paramref name="first"/>.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming([AllowNull] Char* first, Int32 length, Span<Char> second) => HammingKernel(new ReadOnlySpan<Char>(first, length), second);
		#endregion

		#region Hamming(Text, Span<Char>, Case)
		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming([AllowNull] String first, Span<Char> second, Case casing) => HammingKernel(first.AsSpan(), second, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming([AllowNull] Char[] first, Span<Char> second, Case casing) => HammingKernel(first, second, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Memory<Char> first, Span<Char> second, Case casing) => HammingKernel(first.Span, second, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlyMemory<Char> first, Span<Char> second, Case casing) => HammingKernel(first.Span, second, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Span<Char> first, Span<Char> second, Case casing) => HammingKernel(first, second, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlySpan<Char> first, Span<Char> second, Case casing) => HammingKernel(first, second, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="length">The length of the <paramref name="first"/>.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming([AllowNull] Char* first, Int32 length, Span<Char> second, Case casing) => HammingKernel(new ReadOnlySpan<Char>(first, length), second, casing);
		#endregion

		#region Hamming(Text, ReadOnlySpan<Char>)
		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming([AllowNull] String first, ReadOnlySpan<Char> second) => HammingKernel(first.AsSpan(), second);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming([AllowNull] Char[] first, ReadOnlySpan<Char> second) => HammingKernel(first, second);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Memory<Char> first, ReadOnlySpan<Char> second) => HammingKernel(first.Span, second);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlyMemory<Char> first, ReadOnlySpan<Char> second) => HammingKernel(first.Span, second);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Span<Char> first, ReadOnlySpan<Char> second) => HammingKernel(first, second);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlySpan<Char> first, ReadOnlySpan<Char> second) => HammingKernel(first, second);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="length">The length of the <paramref name="first"/>.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming([AllowNull] Char* first, Int32 length, ReadOnlySpan<Char> second) => HammingKernel(new ReadOnlySpan<Char>(first, length), second);
		#endregion

		#region Hamming(Text, ReadOnlySpan<Char>, Case)
		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming([AllowNull] String first, ReadOnlySpan<Char> second, Case casing) => HammingKernel(first.AsSpan(), second, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming([AllowNull] Char[] first, ReadOnlySpan<Char> second, Case casing) => HammingKernel(first, second, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Memory<Char> first, ReadOnlySpan<Char> second, Case casing) => HammingKernel(first.Span, second, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlyMemory<Char> first, ReadOnlySpan<Char> second, Case casing) => HammingKernel(first.Span, second, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Span<Char> first, ReadOnlySpan<Char> second, Case casing) => HammingKernel(first, second, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlySpan<Char> first, ReadOnlySpan<Char> second, Case casing) => HammingKernel(first, second, casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="length">The length of the <paramref name="first"/>.</param>
		/// <param name="second">The second text.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming([AllowNull] Char* first, Int32 length, ReadOnlySpan<Char> second, Case casing) => HammingKernel(new ReadOnlySpan<Char>(first, length), second, casing);
		#endregion

		#region Hamming(Text, Char*, Int32)
		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="length">The length of the <paramref name="second"/>.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming([AllowNull] String first, [AllowNull] Char* second, Int32 length) => HammingKernel(first.AsSpan(), new ReadOnlySpan<Char>(second, length));

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="length">The length of the <paramref name="second"/>.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming([AllowNull] Char[] first, [AllowNull] Char* second, Int32 length) => HammingKernel(first, new ReadOnlySpan<Char>(second, length));

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="length">The length of the <paramref name="second"/>.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming(Memory<Char> first, [AllowNull] Char* second, Int32 length) => HammingKernel(first.Span, new ReadOnlySpan<Char>(second, length));

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="length">The length of the <paramref name="second"/>.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming(ReadOnlyMemory<Char> first, [AllowNull] Char* second, Int32 length) => HammingKernel(first.Span, new ReadOnlySpan<Char>(second, length));

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="length">The length of the <paramref name="second"/>.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming(Span<Char> first, [AllowNull] Char* second, Int32 length) => HammingKernel(first, new ReadOnlySpan<Char>(second, length));

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="length">The length of the <paramref name="second"/>.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming(ReadOnlySpan<Char> first, [AllowNull] Char* second, Int32 length) => HammingKernel(first, new ReadOnlySpan<Char>(second, length));

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="firstLength">The length of the <paramref name="first"/>.</param>
		/// <param name="second">The second text.</param>
		/// <param name="secondLength">The length of the <paramref name="second"/>.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming([AllowNull] Char* first, Int32 firstLength, [AllowNull] Char* second, Int32 secondLength) => HammingKernel(new ReadOnlySpan<Char>(first, firstLength), new ReadOnlySpan<Char>(second, secondLength));
		#endregion

		#region Hamming(Text, Char*, Int32, Case)
		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="length">The length of the <paramref name="second"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming([AllowNull] String first, [AllowNull] Char* second, Int32 length, Case casing) => HammingKernel(first.AsSpan(), new ReadOnlySpan<Char>(second, length), casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="length">The length of the <paramref name="second"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming([AllowNull] Char[] first, [AllowNull] Char* second, Int32 length, Case casing) => HammingKernel(first, new ReadOnlySpan<Char>(second, length), casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="length">The length of the <paramref name="second"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming(Memory<Char> first, [AllowNull] Char* second, Int32 length, Case casing) => HammingKernel(first.Span, new ReadOnlySpan<Char>(second, length), casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="length">The length of the <paramref name="second"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming(ReadOnlyMemory<Char> first, [AllowNull] Char* second, Int32 length, Case casing) => HammingKernel(first.Span, new ReadOnlySpan<Char>(second, length), casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="length">The length of the <paramref name="second"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming(Span<Char> first, [AllowNull] Char* second, Int32 length, Case casing) => HammingKernel(first, new ReadOnlySpan<Char>(second, length), casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="length">The length of the <paramref name="second"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming(ReadOnlySpan<Char> first, [AllowNull] Char* second, Int32 length, Case casing) => HammingKernel(first, new ReadOnlySpan<Char>(second, length), casing);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="firstLength">The length of the <paramref name="first"/>.</param>
		/// <param name="second">The second text.</param>
		/// <param name="secondLength">The length of the <paramref name="second"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming([AllowNull] Char* first, Int32 firstLength, [AllowNull] Char* second, Int32 secondLength, Case casing) => HammingKernel(new ReadOnlySpan<Char>(first, firstLength), new ReadOnlySpan<Char>(second, secondLength), casing);
		#endregion

		private static Int32 HammingKernel(ReadOnlySpan<Char> first, ReadOnlySpan<Char> second) => HammingKernel(first, second, Case.Sensitive);

		private static Int32 HammingKernel(ReadOnlySpan<Char> first, ReadOnlySpan<Char> second, Case casing) {
			Int32 d = 0;
			for (Int32 i = 0; i < first.Length; i++) {
				if (!Text.Equals(first[i], second[i], casing)) {
					d++;
				}
			}
			return d;
		}
	}
}
