using System;
using Defender;

namespace Stringier {
	public static partial class EditDistance {
		#region Levenshtein(Text, String, Level)
		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="other">The other text.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(String text, String other, Level level) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Levenshtein(text.AsSpan(), other.AsSpan(), level);
		}

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="other">The other text.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(Char[] text, String other, Level level) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Levenshtein(text.AsSpan(), other.AsSpan(), level);
		}

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="other">The other text.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(ReadOnlySpan<Char> text, String other, Level level) {
			Guard.NotNull(other, nameof(other));
			return Levenshtein(text, other.AsSpan(), level);
		}

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The other text.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Levenshtein(Char* text, Int32 length, String other, Level level) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Levenshtein(new ReadOnlySpan<Char>(text, length), other.AsSpan(), level);
		}
		#endregion

		#region Levenshtein(Text, Char[], Level)
		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="other">The other text.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(String text, Char[] other, Level level) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Levenshtein(text.AsSpan(), other.AsSpan(), level);
		}

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="other">The other text.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(Char[] text, Char[] other, Level level) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Levenshtein(text.AsSpan(), other.AsSpan(), level);
		}

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="other">The other text.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(ReadOnlySpan<Char> text, Char[] other, Level level) {
			Guard.NotNull(other, nameof(other));
			return Levenshtein(text, other.AsSpan(), level);
		}

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The other text.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Levenshtein(Char* text, Int32 length, Char[] other, Level level) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Levenshtein(new ReadOnlySpan<Char>(text, length), other.AsSpan(), level);
		}
		#endregion

		#region Levenshtein(Text, ReadOnlySpan<Char>, Level)
		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="other">The other text.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(String text, ReadOnlySpan<Char> other, Level level) {
			Guard.NotNull(text, nameof(text));
			return Levenshtein(text.AsSpan(), other, level);
		}

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="other">The other text.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(Char[] text, ReadOnlySpan<Char> other, Level level) {
			Guard.NotNull(text, nameof(text));
			return Levenshtein(text.AsSpan(), other, level);
		}

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="other">The other text.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		public static Int32 Levenshtein(ReadOnlySpan<Char> text, ReadOnlySpan<Char> other, Level level) {
			switch (level) {
			case Level.Char:
				return LevenshteinChar(text, other);
			case Level.Rune:
				return LevenshteinRune(text, other);
			case Level.Glyph:
				return LevenshteinGlyph(text, other);
			default:
				throw Guard.Default(level, nameof(level));
			}
		}

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The other text.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Levenshtein(Char* text, Int32 length, ReadOnlySpan<Char> other, Level level) {
			Guard.NotNull(text, nameof(text));
			return Levenshtein(new ReadOnlySpan<Char>(text, length), other, level);
		}
		#endregion

		#region Levenshtein(Text, Char*, Level)
		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="other">The other text.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Levenshtein(String text, Char* other, Int32 length, Level level) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Levenshtein(text.AsSpan(), new ReadOnlySpan<Char>(other, length), level);
		}

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="other">The other text.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Levenshtein(Char[] text, Char* other, Int32 length, Level level) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Levenshtein(text.AsSpan(), new ReadOnlySpan<Char>(other, length), level);
		}

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="other">The other text.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Levenshtein(ReadOnlySpan<Char> text, Char* other, Int32 length, Level level) {
			Guard.NotNull(other, nameof(other));
			return Levenshtein(text, new ReadOnlySpan<Char>(other, length), level);
		}

		/// <summary>
		/// Calculates the Levenshtein edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The other text.</param>
		/// <param name="otherLength">The length of the <paramref name="other"/>.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Levenshtein edit-distance measures the amount of insertions, deletions, and substitutions, between two texts. Because it does not handle transpositions, a transposition will be counted as two substitutions. It can handle two texts of different lengths.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Levenshtein(Char* text, Int32 length, Char* other, Int32 otherLength, Level level) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Levenshtein(new ReadOnlySpan<Char>(text, length), new ReadOnlySpan<Char>(other, otherLength), level);
		}
		#endregion

		private static Int32 LevenshteinChar(ReadOnlySpan<Char> text, ReadOnlySpan<Char> other) {
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

		private static Int32 LevenshteinRune(ReadOnlySpan<Char> text, ReadOnlySpan<Char> other) {
			throw new NotImplementedException();
		}

		private static Int32 LevenshteinGlyph(ReadOnlySpan<Char> text, ReadOnlySpan<Char> other) {
			throw new NotImplementedException();
		}
	}
}
