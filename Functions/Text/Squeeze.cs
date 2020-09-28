using System;
using System.Globalization;
using System.Text;
using Defender;
using Stringier.Encodings;
using Stringier.Categories;

namespace Stringier {
	public static partial class Text {
		#region Squeeze(Text)
		/// <summary>
		/// Squeezes the <paramref name="text"/>, collapsing all adjacent identical characters to single characters.
		/// </summary>
		/// <param name="text">The text to squeeze.</param>
		/// <returns>The squeezed <paramref name="text"/>.</returns>
		public static ReadOnlySpan<Char> Squeeze(this String text) {
			Guard.NotNull(text, nameof(text));
			return Squeeze(text.AsSpan());
		}

		/// <summary>
		/// Squeezes the <paramref name="text"/>, collapsing all adjacent identical characters to single characters.
		/// </summary>
		/// <param name="text">The text to squeeze.</param>
		/// <returns>The squeezed <paramref name="text"/>.</returns>
		public static ReadOnlySpan<Char> Squeeze(this Char[] text) {
			Guard.NotNull(text, nameof(text));
			return Squeeze(text.AsSpan());
		}

		/// <summary>
		/// Squeezes the <paramref name="text"/>, collapsing all adjacent identical characters to single characters.
		/// </summary>
		/// <param name="text">The text to squeeze.</param>
		/// <returns>The squeezed <paramref name="text"/>.</returns>
		public static ReadOnlySpan<Char> Squeeze(this Span<Char> text) => Squeeze((ReadOnlySpan<Char>)text);

		/// <summary>
		/// Squeezes the <paramref name="text"/>, collapsing all adjacent identical characters to single characters.
		/// </summary>
		/// <param name="text">The text to squeeze.</param>
		/// <returns>The squeezed <paramref name="text"/>.</returns>
		public static ReadOnlySpan<Char> Squeeze(this ReadOnlySpan<Char> text) {
			Span<Char> result = new Char[text.Length];
			Int32 r = 0;
			result[r] = text[0];
			for (Int32 t = 1; t < text.Length; t++) {
				if (text[t] != result[r]) {
					result[++r] = text[t];
				}
			}
			return result.Slice(0, ++r);
		}

		/// <summary>
		/// Squeezes the <paramref name="text"/>, collapsing all adjacent identical characters to single characters.
		/// </summary>
		/// <param name="text">The text to squeeze.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <returns>The squeezed <paramref name="text"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<Char> Squeeze(Char* text, Int32 length) {
			Guard.NotNull(text, nameof(text));
			return Squeeze(new ReadOnlySpan<Char>(text, length));
		}
		#endregion

		#region Squeeze(Text, Char)
		/// <summary>
		/// Squeezes the <paramref name="text"/>, collapsing adjacent <paramref name="squeezeChar"/> to single characters.
		/// </summary>
		/// <param name="text">The text to squeeze.</param>
		/// <param name="squeezeChar">The character to squeeze.</param>
		/// <returns>The squeezed <paramref name="text"/>.</returns>
		public static ReadOnlySpan<Char> Squeeze(this String text, Char squeezeChar) {
			Guard.NotNull(text, nameof(text));
			return Squeeze(text.AsSpan(), squeezeChar);
		}

		/// <summary>
		/// Squeezes the <paramref name="text"/>, collapsing adjacent <paramref name="squeezeChar"/> to single characters.
		/// </summary>
		/// <param name="text">The text to squeeze.</param>
		/// <param name="squeezeChar">The character to squeeze.</param>
		/// <returns>The squeezed <paramref name="text"/>.</returns>
		public static ReadOnlySpan<Char> Squeeze(this Char[] text, Char squeezeChar) {
			Guard.NotNull(text, nameof(text));
			return Squeeze(text.AsSpan(), squeezeChar);
		}

		/// <summary>
		/// Squeezes the <paramref name="text"/>, collapsing adjacent <paramref name="squeezeChar"/> to single characters.
		/// </summary>
		/// <param name="text">The text to squeeze.</param>
		/// <param name="squeezeChar">The character to squeeze.</param>
		/// <returns>The squeezed <paramref name="text"/>.</returns>
		public static ReadOnlySpan<Char> Squeeze(this Span<Char> text, Char squeezeChar) => Squeeze((ReadOnlySpan<Char>)text, squeezeChar);

		/// <summary>
		/// Squeezes the <paramref name="text"/>, collapsing adjacent <paramref name="squeezeChar"/> to single characters.
		/// </summary>
		/// <param name="text">The text to squeeze.</param>
		/// <param name="squeezeChar">The character to squeeze.</param>
		/// <returns>The squeezed <paramref name="text"/>.</returns>
		public static ReadOnlySpan<Char> Squeeze(this ReadOnlySpan<Char> text, Char squeezeChar) {
			Span<Char> result = new Char[text.Length];
			Int32 r = 0;
			Boolean AtSqueezeChar = false;
			foreach (Char C in text) {
				if (C == squeezeChar) {
					if (!AtSqueezeChar) {
						AtSqueezeChar = true;
						result[r++] = squeezeChar;
					}
				} else {
					AtSqueezeChar = false;
					result[r++] = C;
				}
			}
			return result.Slice(0, r);
		}

		/// <summary>
		/// Squeezes the <paramref name="text"/>, collapsing adjacent <paramref name="squeezeChar"/> to single characters.
		/// </summary>
		/// <param name="text">The text to squeeze.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="squeezeChar">The character to squeeze.</param>
		/// <returns>The squeezed <paramref name="text"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<Char> Squeeze(Char* text, Int32 length, Char squeezeChar) {
			Guard.NotNull(text, nameof(text));
			return Squeeze(new ReadOnlySpan<Char>(text, length), squeezeChar);
		}
		#endregion

		#region Squeeze(Text, Char[])
		#endregion

		#region Squeeze(Text, Rune)
		/// <summary>
		/// Squeezes the <paramref name="text"/>, collapsing adjacent <paramref name="squeezeRune"/> to single characters.
		/// </summary>
		/// <param name="text">The text to squeeze.</param>
		/// <param name="squeezeRune">The character to squeeze.</param>
		/// <returns>The squeezed <paramref name="text"/>.</returns>
		public static ReadOnlySpan<Char> Squeeze(this String text, Rune squeezeRune) {
			Guard.NotNull(text, nameof(text));
			return Squeeze(text.AsSpan(), squeezeRune);
		}

		/// <summary>
		/// Squeezes the <paramref name="text"/>, collapsing adjacent <paramref name="squeezeRune"/> to single characters.
		/// </summary>
		/// <param name="text">The text to squeeze.</param>
		/// <param name="squeezeRune">The character to squeeze.</param>
		/// <returns>The squeezed <paramref name="text"/>.</returns>
		public static ReadOnlySpan<Char> Squeeze(this Char[] text, Rune squeezeRune) {
			Guard.NotNull(text, nameof(text));
			return Squeeze(text.AsSpan(), squeezeRune);
		}

		/// <summary>
		/// Squeezes the <paramref name="text"/>, collapsing adjacent <paramref name="squeezeRune"/> to single characters.
		/// </summary>
		/// <param name="text">The text to squeeze.</param>
		/// <param name="squeezeRune">The character to squeeze.</param>
		/// <returns>The squeezed <paramref name="text"/>.</returns>
		public static ReadOnlySpan<Char> Squeeze(this Span<Char> text, Rune squeezeRune) => Squeeze((ReadOnlySpan<Char>)text, squeezeRune);

		/// <summary>
		/// Squeezes the <paramref name="text"/>, collapsing adjacent <paramref name="squeezeRune"/> to single characters.
		/// </summary>
		/// <param name="text">The text to squeeze.</param>
		/// <param name="squeezeRune">The character to squeeze.</param>
		/// <returns>The squeezed <paramref name="text"/>.</returns>
		public static ReadOnlySpan<Char> Squeeze(this ReadOnlySpan<Char> text, Rune squeezeRune) {
			Span<Char> result = new Char[text.Length + 1]; // We add one more to this, because the encoding of runes into the result is considerably simpler if we can treat all as surrogate halves, but then advance later by the actual length.
			Int32 r = 0;
			Boolean AtCleanRune = false;
			Rune R;
			while (r < result.Length) {
				R = text.GetRuneAt(r);
				if (R == squeezeRune) {
					if (!AtCleanRune) {
						AtCleanRune = true;
						Utf16.Encode(squeezeRune, out result[r], out result[r + 1]);
						r += squeezeRune.Utf16SequenceLength;
					}
				} else {
					AtCleanRune = false;
					Utf16.Encode(R, out result[r], out result[r + 1]);
					r += R.Utf16SequenceLength;
				}
			}
			return result.Slice(0, r);
		}

		/// <summary>
		/// Squeezes the <paramref name="text"/>, collapsing adjacent <paramref name="squeezeRune"/> to single characters.
		/// </summary>
		/// <param name="text">The text to squeeze.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="squeezeRune">The character to squeeze.</param>
		/// <returns>The squeezed <paramref name="text"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<Char> Squeeze(Char* text, Int32 length, Rune squeezeRune) {
			Guard.NotNull(text, nameof(text));
			return Squeeze(new ReadOnlySpan<Char>(text, length), squeezeRune);
		}
		#endregion

		#region Squeeze(Text, Rune[])
		#endregion

		#region Squeeze(Text, Category)
		/// <summary>
		/// Squeezes the <paramref name="text"/>, collapsing adjacent <paramref name="category"/> to single characters.
		/// </summary>
		/// <param name="text">The text to squeeze.</param>
		/// <param name="category">The category to squeeze.</param>
		/// <returns>The squeezed <paramref name="text"/>.</returns>
		public static ReadOnlySpan<Char> Squeeze(this String text, Category category) {
			Guard.NotNull(text, nameof(text));
			return Squeeze(text.AsSpan(), category);
		}

		/// <summary>
		/// Squeezes the <paramref name="text"/>, collapsing adjacent <paramref name="category"/> to single characters.
		/// </summary>
		/// <param name="text">The text to squeeze.</param>
		/// <param name="category">The category to squeeze.</param>
		/// <returns>The squeezed <paramref name="text"/>.</returns>
		public static ReadOnlySpan<Char> Squeeze(this Char[] text, Category category) {
			Guard.NotNull(text, nameof(text));
			return Squeeze(text.AsSpan(), category);
		}

		/// <summary>
		/// Squeezes the <paramref name="text"/>, collapsing adjacent <paramref name="category"/> to single characters.
		/// </summary>
		/// <param name="text">The text to squeeze.</param>
		/// <param name="category">The category to squeeze.</param>
		/// <returns>The squeezed <paramref name="text"/>.</returns>
		public static ReadOnlySpan<Char> Squeeze(this Span<Char> text, Category category) => Squeeze((ReadOnlySpan<Char>)text, category);

		/// <summary>
		/// Squeezes the <paramref name="text"/>, collapsing adjacent <paramref name="category"/> to single characters.
		/// </summary>
		/// <param name="text">The text to squeeze.</param>
		/// <param name="category">The category to squeeze.</param>
		/// <returns>The squeezed <paramref name="text"/>.</returns>
		public static ReadOnlySpan<Char> Squeeze(this ReadOnlySpan<Char> text, Category category) {
			Span<Char> result = new Char[text.Length];
			Int32 r = 0;
			Boolean AtSqueezeChar = false;
			foreach (Char C in text) {
				if (category.Contains(C)) {
					if (!AtSqueezeChar) {
						AtSqueezeChar = true;
						result[r++] = C;
					}
				} else {
					AtSqueezeChar = false;
					result[r++] = C;
				}
			}
			return result.Slice(0, r);
		}

		/// <summary>
		/// Squeezes the <paramref name="text"/>, collapsing adjacent <paramref name="category"/> to single characters.
		/// </summary>
		/// <param name="text">The text to squeeze.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="category">The category to squeeze.</param>
		/// <returns>The squeezed <paramref name="text"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<Char> Squeeze(Char* text, Int32 length, Category category) {
			Guard.NotNull(text, nameof(text));
			return Squeeze(new ReadOnlySpan<Char>(text, length), category);
		}
		#endregion
	}
}
