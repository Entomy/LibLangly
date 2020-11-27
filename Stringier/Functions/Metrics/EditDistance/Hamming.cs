using System;
using System.Text;

namespace Langly {
	public static partial class EditDistance {
		#region Hamming(Text, String, Level)
		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="other">The other text.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(String text, String other, Level level) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Hamming(text.AsSpan(), other.AsSpan(), level);
		}

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="other">The other text.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Char[] text, String other, Level level) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Hamming(text.AsSpan(), other.AsSpan(), level);
		}

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="other">The other text.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlySpan<Char> text, String other, Level level) {
			Guard.NotNull(other, nameof(other));
			return Hamming(text, other.AsSpan(), level);
		}

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The other text.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming(Char* text, Int32 length, String other, Level level) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Hamming(new ReadOnlySpan<Char>(text, length), other.AsSpan(), level);
		}
		#endregion

		#region Hamming(Text, Char[], Level)
		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="other">The other text.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(String text, Char[] other, Level level) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Hamming(text.AsSpan(), other.AsSpan(), level);
		}

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="other">The other text.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Char[] text, Char[] other, Level level) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Hamming(text.AsSpan(), other.AsSpan(), level);
		}

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="other">The other text.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlySpan<Char> text, Char[] other, Level level) {
			Guard.NotNull(other, nameof(other));
			return Hamming(text, other.AsSpan(), level);
		}

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The other text.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming(Char* text, Int32 length, Char[] other, Level level) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Hamming(new ReadOnlySpan<Char>(text, length), other.AsSpan(), level);
		}
		#endregion

		#region Hamming(Text, ReadOnlySpan<Char>, Level)
		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="other">The other text.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(String text, ReadOnlySpan<Char> other, Level level) {
			Guard.NotNull(text, nameof(text));
			return Hamming(text.AsSpan(), other, level);
		}

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="other">The other text.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(Char[] text, ReadOnlySpan<Char> other, Level level) {
			Guard.NotNull(text, nameof(text));
			return Hamming(text.AsSpan(), other, level);
		}

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="other">The other text.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		public static Int32 Hamming(ReadOnlySpan<Char> text, ReadOnlySpan<Char> other, Level level) {
			switch (level) {
			case Level.Char:
				return HammingChar(text, other);
			case Level.Rune:
				return HammingRune(text, other);
			case Level.Glyph:
				return HammingGlyph(text, other);
			default:
				throw Guard.Default(level, nameof(level));
			}
		}

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The other text.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming(Char* text, Int32 length, ReadOnlySpan<Char> other, Level level) {
			Guard.NotNull(text, nameof(text));
			return Hamming(new ReadOnlySpan<Char>(text, length), other, level);
		}
		#endregion

		#region Hamming(Text, Char*, Level)
		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="other">The other text.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming(String text, Char* other, Int32 length, Level level) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Hamming(text.AsSpan(), new ReadOnlySpan<Char>(other, length), level);
		}

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="other">The other text.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming(Char[] text, Char* other, Int32 length, Level level) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Hamming(text.AsSpan(), new ReadOnlySpan<Char>(other, length), level);
		}

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="other">The other text.</param>
		/// <param name="length">The length of the <paramref name="other"/>.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming(ReadOnlySpan<Char> text, Char* other, Int32 length, Level level) {
			Guard.NotNull(other, nameof(other));
			return Hamming(text, new ReadOnlySpan<Char>(other, length), level);
		}

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="text"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="text">The first text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="other">The other text.</param>
		/// <param name="otherLength">The length of the <paramref name="other"/>.</param>
		/// <param name="level">The <see cref="Level"/> of text elements to measure.</param>
		/// <returns>The number of edits to get from <paramref name="text"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// Hamming edit-distance measures the amount of substitutions between two texts. Because it does not handle insertions or deletions, the two texts are required to be the same length. It also does not handle transpositions, so a transposition will be counted as two substitutions. This is the simplest of all <see cref="EditDistance"/> algorithms, and is fast, but limited.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Hamming(Char* text, Int32 length, Char* other, Int32 otherLength, Level level) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(other, nameof(other));
			return Hamming(new ReadOnlySpan<Char>(text, length), new ReadOnlySpan<Char>(other, otherLength), level);
		}
		#endregion

		private static Int32 HammingChar(ReadOnlySpan<Char> text, ReadOnlySpan<Char> other) {
			Int32 d = 0;
			for (Int32 i = 0; i < text.Length; i++) {
				if (!text[i].Equals(other[i])) {
					d++;
				}
			}
			return d;
		}

		private static Int32 HammingRune(ReadOnlySpan<Char> text, ReadOnlySpan<Char> other) {
			Int32 d = 0;
			Int32 iT = 0;
			Rune rT;
			Int32 iO = 0;
			Rune rO;
			while (iT < text.Length && iO < other.Length) {
				rT = text.GetRuneAt(iT, out iT);
				rO = other.GetRuneAt(iO, out iO);
				if (rT != rO) {
					d++;
				}
			}
			return d;
		}

		private static Int32 HammingGlyph(ReadOnlySpan<Char> text, ReadOnlySpan<Char> other) {
			Int32 d = 0;
			Int32 iT = 0;
			Glyph gT;
			Int32 iO = 0;
			Glyph gO;
			while (iT < text.Length && iO < other.Length) {
				gT = text.GetGlyphAt(iT, out iT);
				gO = other.GetGlyphAt(iO, out iO);
				if (gT != gO) {
					d++;
				}
			}
			return d;
		}
	}
}
