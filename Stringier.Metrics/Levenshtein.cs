using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier {
	public static partial class EditDistance {
		#region Levenshtein(Text, String)
		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein([AllowNull] String first, [AllowNull] String second) => LevenshteinKernel(first.AsSpan(), second.AsSpan());

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein([AllowNull] Char[] first, [AllowNull] String second) => LevenshteinKernel(first, second.AsSpan());

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(Memory<Char> first, [AllowNull] String second) => LevenshteinKernel(first.Span, second.AsSpan());

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(ReadOnlyMemory<Char> first, [AllowNull] String second) => LevenshteinKernel(first.Span, second.AsSpan());

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(Span<Char> first, [AllowNull] String second) => LevenshteinKernel(first, second.AsSpan());

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(ReadOnlySpan<Char> first, [AllowNull] String second) => LevenshteinKernel(first, second.AsSpan());

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="length">The length of the <paramref name="first"/>.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Levenshtein([AllowNull] Char* first, Int32 length, [AllowNull] String second) => LevenshteinKernel(new ReadOnlySpan<Char>(first, length), second.AsSpan());
		#endregion

		#region Levenshtein(Text, Char[])
		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein([AllowNull] String first, [AllowNull] Char[] second) => LevenshteinKernel(first.AsSpan(), second);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein([AllowNull] Char[] first, [AllowNull] Char[] second) => LevenshteinKernel(first, second);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(Memory<Char> first, [AllowNull] Char[] second) => LevenshteinKernel(first.Span, second);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(ReadOnlyMemory<Char> first, [AllowNull] Char[] second) => LevenshteinKernel(first.Span, second);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(Span<Char> first, [AllowNull] Char[] second) => LevenshteinKernel(first, second);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(ReadOnlySpan<Char> first, [AllowNull] Char[] second) => LevenshteinKernel(first, second);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="length">The length of the <paramref name="first"/>.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Levenshtein([AllowNull] Char* first, Int32 length, [AllowNull] Char[] second) => LevenshteinKernel(new ReadOnlySpan<Char>(first, length), second);
		#endregion

		#region Levenshtein(Text, Memory<Char>)
		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein([AllowNull] String first, Memory<Char> second) => LevenshteinKernel(first.AsSpan(), second.Span);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein([AllowNull] Char[] first, Memory<Char> second) => LevenshteinKernel(first, second.Span);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(Memory<Char> first, Memory<Char> second) => LevenshteinKernel(first.Span, second.Span);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(ReadOnlyMemory<Char> first, Memory<Char> second) => LevenshteinKernel(first.Span, second.Span);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(Span<Char> first, Memory<Char> second) => LevenshteinKernel(first, second.Span);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(ReadOnlySpan<Char> first, Memory<Char> second) => LevenshteinKernel(first, second.Span);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="length">The length of the <paramref name="first"/>.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Levenshtein([AllowNull] Char* first, Int32 length, Memory<Char> second) => LevenshteinKernel(new ReadOnlySpan<Char>(first, length), second.Span);
		#endregion

		#region Levenshtein(Text, ReadOnlyMemory<Char>)
		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein([AllowNull] String first, ReadOnlyMemory<Char> second) => LevenshteinKernel(first.AsSpan(), second.Span);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein([AllowNull] Char[] first, ReadOnlyMemory<Char> second) => LevenshteinKernel(first, second.Span);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(Memory<Char> first, ReadOnlyMemory<Char> second) => LevenshteinKernel(first.Span, second.Span);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(ReadOnlyMemory<Char> first, ReadOnlyMemory<Char> second) => LevenshteinKernel(first.Span, second.Span);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(Span<Char> first, ReadOnlyMemory<Char> second) => LevenshteinKernel(first, second.Span);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(ReadOnlySpan<Char> first, ReadOnlyMemory<Char> second) => LevenshteinKernel(first, second.Span);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="length">The length of the <paramref name="first"/>.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Levenshtein([AllowNull] Char* first, Int32 length, ReadOnlyMemory<Char> second) => LevenshteinKernel(new ReadOnlySpan<Char>(first, length), second.Span);
		#endregion

		#region Levenshtein(Text, Span<Char>)
		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein([AllowNull] String first, Span<Char> second) => LevenshteinKernel(first.AsSpan(), second);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein([AllowNull] Char[] first, Span<Char> second) => LevenshteinKernel(first, second);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(Memory<Char> first, Span<Char> second) => LevenshteinKernel(first.Span, second);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(ReadOnlyMemory<Char> first, Span<Char> second) => LevenshteinKernel(first.Span, second);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(Span<Char> first, Span<Char> second) => LevenshteinKernel(first, second);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(ReadOnlySpan<Char> first, Span<Char> second) => LevenshteinKernel(first, second);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="length">The length of the <paramref name="first"/>.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Levenshtein([AllowNull] Char* first, Int32 length, Span<Char> second) => LevenshteinKernel(new ReadOnlySpan<Char>(first, length), second);
		#endregion

		#region Levenshtein(Text, ReadOnlySpan<Char>)
		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein([AllowNull] String first, ReadOnlySpan<Char> second) => LevenshteinKernel(first.AsSpan(), second);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein([AllowNull] Char[] first, ReadOnlySpan<Char> second) => LevenshteinKernel(first, second);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(Memory<Char> first, ReadOnlySpan<Char> second) => LevenshteinKernel(first.Span, second);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(ReadOnlyMemory<Char> first, ReadOnlySpan<Char> second) => LevenshteinKernel(first.Span, second);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(Span<Char> first, ReadOnlySpan<Char> second) => LevenshteinKernel(first, second);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(ReadOnlySpan<Char> first, ReadOnlySpan<Char> second) => LevenshteinKernel(first, second);

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="length">The length of the <paramref name="first"/>.</param>
		/// <param name="second">The second text.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Levenshtein([AllowNull] Char* first, Int32 length, ReadOnlySpan<Char> second) => LevenshteinKernel(new ReadOnlySpan<Char>(first, length), second);
		#endregion

		#region Levenshtein(Text, Char*, Int32)
		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="length">The length of the <paramref name="second"/>.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Levenshtein([AllowNull] String first, [AllowNull] Char* second, Int32 length) => LevenshteinKernel(first.AsSpan(), new ReadOnlySpan<Char>(second, length));

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="length">The length of the <paramref name="second"/>.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Levenshtein([AllowNull] Char[] first, [AllowNull] Char* second, Int32 length) => LevenshteinKernel(first, new ReadOnlySpan<Char>(second, length));

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="length">The length of the <paramref name="second"/>.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Levenshtein(Memory<Char> first, [AllowNull] Char* second, Int32 length) => LevenshteinKernel(first.Span, new ReadOnlySpan<Char>(second, length));

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="length">The length of the <paramref name="second"/>.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Levenshtein(ReadOnlyMemory<Char> first, [AllowNull] Char* second, Int32 length) => LevenshteinKernel(first.Span, new ReadOnlySpan<Char>(second, length));

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="length">The length of the <paramref name="second"/>.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Levenshtein(Span<Char> first, [AllowNull] Char* second, Int32 length) => LevenshteinKernel(first, new ReadOnlySpan<Char>(second, length));

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="second">The second text.</param>
		/// <param name="length">The length of the <paramref name="second"/>.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Levenshtein(ReadOnlySpan<Char> first, [AllowNull] Char* second, Int32 length) => LevenshteinKernel(first, new ReadOnlySpan<Char>(second, length));

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="first"/> and <paramref name="second"/>.
		/// </summary>
		/// <param name="first">The first text.</param>
		/// <param name="firstLength">The length of the <paramref name="first"/>.</param>
		/// <param name="second">The second text.</param>
		/// <param name="secondLength">The length of the <paramref name="second"/>.</param>
		/// <returns>The number of edits to get from <paramref name="first"/> to <paramref name="second"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Levenshtein([AllowNull] Char* first, Int32 firstLength, [AllowNull] Char* second, Int32 secondLength) => LevenshteinKernel(new ReadOnlySpan<Char>(first, firstLength), new ReadOnlySpan<Char>(second, secondLength));
		#endregion

		private static Int32 LevenshteinKernel(ReadOnlySpan<Char> text, ReadOnlySpan<Char> other) {
			Int32 n = text.Length;
			Int32 m = other.Length;

			if (n == 0) {
				return m;
			} else if (m == 0) {
				return n;
			} else {
				Int32[,] d = new Int32[n + 1, m + 1];
				for (Int32 i = 0; i <= n; d[i, 0] = i++) { /* Prework */ }
				for (Int32 j = 0; j <= m; d[0, j] = j++) { /* Prework */ }

				Int32 c;
				for (Int32 i = 1; i <= n; i++) {
					for (Int32 j = 1; j <= m; j++) {
						c = other[j - 1].Equals(text[i - 1]) ? 0 : 1;
						d[i, j] = Math.Min(
							Math.Min(
								d[i - 1, j] + 1,
								d[i, j - 1] + 1),
							d[i - 1, j - 1] + c);
					}
				}
				return d[n, m];
			}
		}
	}
}
