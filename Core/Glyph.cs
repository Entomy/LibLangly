using System;
using System.Globalization;
using System.Linq;
using System.Text;
using Defender;

namespace Stringier {
	/// <summary>
	/// Represents a glyph; a UNICODE Grapheme Cluster.
	/// </summary>
	public readonly partial struct Glyph : IComparable, IComparable<Glyph>, IEquatable<Char>, IEquatable<Glyph>, IEquatable<Rune> {
		/// <summary>
		/// The <see cref="Equivalence"/> instance describing invariant equivalence rules.
		/// </summary>
		/// <remarks>
		/// This is preloaded, not lazy loaded, because the semantics of <see cref="Glyph"/> are entirely built around this, so it will be used.
		/// </remarks>
		private readonly Equivalence? InvariantEquivalence;

		/// <summary>
		/// The sequence representing this <see cref="Glyph"/> as it was found or declared.
		/// </summary>
		private readonly String Sequence;

		/// <summary>
		/// Initializes a new <see cref="Glyph"/> from the given <paramref name="char"/>.
		/// </summary>
		/// <param name="char">The <see cref="Char"/> representing this <see cref="Glyph"/> as it was declared.</param>
		public Glyph(Char @char) {
			if (IsCombiningMark(@char)) {
				throw new ArgumentOutOfRangeException(nameof(@char), "Character must not be a combining or enclosing mark");
			}
			Sequence = @char.ToString();
			InvariantEquivalence = InvariantTable[Sequence];
		}

		/// <summary>
		/// Initializes a new <see cref="Glyph"/> from the given <paramref name="sequence"/>.
		/// </summary>
		/// <param name="sequence">The sequence representing this <see cref="Glyph"/> as it was declared.</param>
		public Glyph(params Char[] sequence) {
			Guard.NotEmpty(sequence, nameof(sequence));
			if (IsCombiningMark(sequence[0])) {
				throw new ArgumentOutOfRangeException(nameof(sequence), "First character must not be a combining or enclosing mark");
			}
			Sequence = new String(sequence);
			InvariantEquivalence = InvariantTable[Sequence];
		}

		/// <summary>
		/// Initializes a new <see cref="Glyph"/> from the given <paramref name="sequence"/>.
		/// </summary>
		/// <param name="sequence">The sequence representing this <see cref="Glyph"/> as it was declared.</param>
		public Glyph(String sequence) {
			Guard.NotNull(sequence, nameof(sequence));
			Guard.NotEmpty(sequence, nameof(sequence));
			if (IsCombiningMark(sequence[0])) {
				throw new ArgumentOutOfRangeException(nameof(sequence), "First character must not be a combining or enclosing mark");
			}
			Sequence = sequence;
			InvariantEquivalence = InvariantTable[Sequence];
		}

		/// <summary>
		/// Returns the length in code units (<see cref="Char"/>) of the UTF-16 sequence required to represent this grapheme.
		/// </summary>
		public Int32 Utf16SequenceLength => Sequence.Length;

		/// <summary>
		/// Gets the <see cref="Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The input <see cref="String"/>.</param>
		/// <param name="index">The index within the <paramref name="input"/> to get the <see cref="Glyph"/>.</param>
		/// <param name="charsConsumed">The number of <see cref="Char"/> consumed as part of the <see cref="Glyph"/>.</param>
		public static Glyph GetGlyphAt(String input, Int32 index, out Int32 charsConsumed) {
			Guard.NotNull(input, nameof(input));
			return GetGlyphAt(input.AsSpan(), index, out charsConsumed);
		}

		/// <summary>
		/// Gets the <see cref="Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The input <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <param name="index">The index within the <paramref name="input"/> to get the <see cref="Glyph"/>.</param>
		/// <param name="charsConsumed">The number of <see cref="Char"/> consumed as part of the <see cref="Glyph"/>.</param>
		public static Glyph GetGlyphAt(ReadOnlySpan<Char> input, Int32 index, out Int32 charsConsumed) {
			Guard.NotEmpty(input, nameof(input));
			Guard.GreaterThanOrEqualTo(index, nameof(index), 0);
			StringBuilder builder = new StringBuilder(); // The use of zalgo text means it's probably unsafe to use a fixed sized buffer. It would need to be huge to accomodate zalgo, which would hurt performance for normal uses. But if a smaller, more suitable, buffer was used for normal purposes, zalgo would crash anything using Glyph, enabling a potential DoS attack.
			//? It might be possible to handle this as an exceptional case. Use a smaller buffer normally and if the buffer is overrun use a zalgo tolerant handler. Zalgo is an edge case and not normal text, so lower performance for that is acceptable.
			charsConsumed = 0;
			if (!IsCombiningMark(input[index])) {
				_ = builder.Append(input[index]);
				charsConsumed++;
			} else {
				throw new ArgumentException("Found a combining mark at this position; This is inside of an existing grapheme.", nameof(index));
			}
			while (++index < input.Length && IsCombiningMark(input[index])) {
				_ = builder.Append(input[index]);
				charsConsumed++;
			}
			return new Glyph(builder.ToString());
		}


		/// <summary>
		/// Indicates whether the specified grapheme is based on a control character.
		/// </summary>
		/// <param name="glyph">The grapheme to evaluate.</param>
		/// <returns><see langword="false"/>, as control characters aren't graphemes.</returns>
		public static Boolean IsControl(Glyph glyph) => glyph.Utf16SequenceLength != 0 && Char.IsControl(glyph.Sequence[0]);

		/// <summary>
		/// Indicates whether the specified grapheme is based on a decimal digit.
		/// </summary>
		/// <param name="glyph">The grapheme to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="glyph"/> is a decimal digit; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsDigit(Glyph glyph) => glyph.Utf16SequenceLength != 0 && Char.IsDigit(glyph.Sequence[0]);

		/// <summary>
		/// Indicates whether the specified grapheme is based on a letter.
		/// </summary>
		/// <param name="glyph">The grapheme to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="glyph"/> is a letter; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsLetter(Glyph glyph) => glyph.Utf16SequenceLength != 0 && Char.IsLetter(glyph.Sequence[0]);

		/// <summary>
		/// Indicates whether the specified grapheme is based on a letter or decimal digit.
		/// </summary>
		/// <param name="glyph">The grapheme to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="glyph"/> is a letter or decimal digit; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsLetterOrDigit(Glyph glyph) => glyph.Utf16SequenceLength != 0 && Char.IsLetterOrDigit(glyph.Sequence[0]);

		/// <summary>
		/// Indicates whether the specified grapheme is based on a lowercase letter.
		/// </summary>
		/// <param name="glyph">The grapheme to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="glyph"/> is a lowercase letter; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsLower(Glyph glyph) => glyph.Utf16SequenceLength != 0 && Char.IsLower(glyph.Sequence[0]);

		/// <summary>
		/// Indicates whether the specified grapheme is based on a number.
		/// </summary>
		/// <param name="glyph">The grapheme to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="glyph"/> is a number; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsNumber(Glyph glyph) => glyph.Utf16SequenceLength != 0 && Char.IsNumber(glyph.Sequence[0]);

		/// <summary>
		/// Indicates whether the specified grapheme is based on a punctuation mark.
		/// </summary>
		/// <param name="glyph">The grapheme to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="glyph"/> is a punctuation mark; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsPunctuation(Glyph glyph) => glyph.Utf16SequenceLength != 0 && Char.IsPunctuation(glyph.Sequence[0]);

		/// <summary>
		/// Indicates whether the specified grapheme is based on a separator.
		/// </summary>
		/// <param name="glyph">The grapheme to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="glyph"/> is a separator; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsSeparator(Glyph glyph) => glyph.Utf16SequenceLength != 0 && Char.IsSeparator(glyph.Sequence[0]);

		/// <summary>
		/// Indicates whether the specified grapheme is based on a symbol.
		/// </summary>
		/// <param name="glyph">The grapheme to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="glyph"/> is a symbol; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsSymbol(Glyph glyph) => glyph.Utf16SequenceLength != 0 && Char.IsSymbol(glyph.Sequence[0]);

		/// <summary>
		/// Indicates whether the specified grapheme is based on an uppercase letter.
		/// </summary>
		/// <param name="glyph">The grapheme to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="glyph"/> is an uppercase letter; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsUpper(Glyph glyph) => glyph.Utf16SequenceLength != 0 && Char.IsUpper(glyph.Sequence[0]);

		/// <summary>
		/// Indicates whether the specified grapheme is based on whitespace.
		/// </summary>
		/// <param name="glyph">The grapheme to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="glyph"/> is whitespace; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsWhiteSpace(Glyph glyph) => glyph.Utf16SequenceLength != 0 && Char.IsWhiteSpace(glyph.Sequence[0]);

		/// <summary>
		/// Split the <paramref name="source"/> into its graphemes.
		/// </summary>
		/// <param name="source">The <see cref="String"/> to split.</param>
		/// <returns>An <see cref="Array"/> of <see cref="Glyph"/>.</returns>
		public static Glyph[] Split(String source) => source.EnumerateGlyphs().ToArray();

		/// <summary>
		/// Split the <paramref name="source"/> into its graphemes.
		/// </summary>
		/// <param name="source">The <see cref="Span{T}"/> of <see cref="Char"/> to split.</param>
		/// <returns>An <see cref="Array"/> of <see cref="Glyph"/>.</returns>
		public static Glyph[] Split(Span<Char> source) => source.EnumerateGlyphs().ToArray();

		/// <summary>
		/// Split the <paramref name="source"/> into its graphemes.
		/// </summary>
		/// <param name="source">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to split.</param>
		/// <returns>An <see cref="Array"/> of <see cref="Glyph"/>.</returns>
		public static Glyph[] Split(ReadOnlySpan<Char> source) => source.EnumerateGlyphs().ToArray();

		/// <summary>
		/// Converts the <paramref name="glyph"/> to its lowercase equivalent.
		/// </summary>
		/// <param name="glyph">The <see cref="Glyph"/> to convert.</param>
		/// <returns>The lowercase equivalent of <paramref name="glyph"/>, or the unchanged value of <paramref name="glyph"/> if <paramref name="glyph"/> is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
		public static Glyph ToLower(Glyph glyph) => new Glyph(glyph.Sequence.ToLower());

		/// <summary>
		/// Converts the <paramref name="glyph"/> to its lowercase equivalent using specified culture-specific formatting information.
		/// </summary>
		/// <param name="glyph">The <see cref="Glyph"/> to convert.</param>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>
		/// <returns>The lowercase equivalent of <paramref name="glyph"/>, modified according to <paramref name="culture"/>, or the unchanged value of <paramref name="glyph"/> if <paramref name="glyph"/> is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
		public static Glyph ToLower(Glyph glyph, CultureInfo culture) {
			Guard.NotNull(culture, nameof(culture));
			return new Glyph(glyph.Sequence.ToLower(culture));
		}

		/// <summary>
		/// Converts the <paramref name="glyph"/> to its lowercase equivalent using the casing rules of the invariant culture.
		/// </summary>
		/// <param name="glyph">The <see cref="Glyph"/> to convert.</param>
		/// <returns>The lowercase equivalent of <paramref name="glyph"/>, or the unchanged value of <paramref name="glyph"/> if <paramref name="glyph"/> is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
		public static Glyph ToLowerInvariant(Glyph glyph) => new Glyph(glyph.Sequence.ToLowerInvariant());

		/// <summary>
		/// Returns a string of the <paramref name="glyphs"/>.
		/// </summary>
		/// <param name="glyphs">The graphemes of the <see	cref="String"/>.</param>
		/// <returns>A <see cref="String"/> of the <paramref name="glyphs"/>.</returns>
		public static String ToString(Glyph[] glyphs) {
			StringBuilder builder = new StringBuilder();
			foreach (Glyph glyph in glyphs) {
				_ = builder.Append(glyph);
			}
			return builder.ToString();
		}

		/// <summary>
		/// Converts the <paramref name="glyph"/> to its uppercase equivalent.
		/// </summary>
		/// <param name="glyph">The <see cref="Glyph"/> to convert.</param>
		/// <returns>The uppercase equivalent of <paramref name="glyph"/>, or the unchanged value of <paramref name="glyph"/> if <paramref name="glyph"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Glyph ToUpper(Glyph glyph) => new Glyph(glyph.Sequence.ToUpper());

		/// <summary>
		/// Converts the <paramref name="glyph"/> to its uppercase equivalent using specified culture-specific formatting information.
		/// </summary>
		/// <param name="glyph">The <see cref="Glyph"/> to convert.</param>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>
		/// <returns>The uppercase equivalent of <paramref name="glyph"/>, modified according to <paramref name="culture"/>, or the unchanged value of <paramref name="glyph"/> if <paramref name="glyph"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Glyph ToUpper(Glyph glyph, CultureInfo culture) {
			Guard.NotNull(culture, nameof(culture));
			return new Glyph(glyph.Sequence.ToUpper(culture));
		}

		/// <summary>
		/// Converts the <paramref name="glyph"/> to its uppercase equivalent using the casing rules of the invariant culture.
		/// </summary>
		/// <param name="glyph">The <see cref="Glyph"/> to convert.</param>
		/// <returns>The uppercase equivalent of <paramref name="glyph"/>, or the unchanged value of <paramref name="glyph"/> if <paramref name="glyph"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Glyph ToUpperInvariant(Glyph glyph) => new Glyph(glyph.Sequence.ToUpperInvariant());

		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="other">An object to compare with this instance.</param>
		/// <returns>A value that indicates the relative order of the objects being compared.</returns>
		public Int32 CompareTo(Glyph other) => String.Compare(Sequence, other.Sequence, StringComparison.CurrentCulture);

		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="obj">An object to compare with this instance.</param>
		/// <returns>A value that indicates the relative order of the objects being compared.</returns>
		/// <exception cref="ArgumentException"><paramref name="obj"/> is not the same type as this instance.</exception>
		public Int32 CompareTo(Object obj) {
			switch (obj) {
			case Glyph glyph:
				return CompareTo(glyph);
			default:
				throw new ArgumentException("Object is not the same type as this instance.", nameof(obj));
			}
		}

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="obj">The object to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="obj"/> is the same as this instance; otherwise, <see langword="false"/>. If <paramref name="obj"/> is <see langword="null"/>, the method returns <see langword="false"/>.</returns>
		public override Boolean Equals(Object? obj) {
			switch (obj) {
			case Char @char:
				return Equals(@char);
			case Glyph glyph:
				return Equals(glyph);
			case Rune rune:
				return Equals(rune);
			default:
				return false;
			}
		}

		/// <summary>
		/// Determines whether this instance and another specified <see cref="Char"/> object have the same value.
		/// </summary>
		/// <param name="other">The <see cref="Char"/> to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="other"/> is the same as this instance; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals(Char other) => InvariantEquivalence?.Equals(other) ?? (Sequence.Length == 1 && Equals(Sequence[0], other));

		/// <summary>
		/// Determines whether this instance and another specified <see cref="Glyph"/> object have the same value.
		/// </summary>
		/// <param name="other">The <see cref="Glyph"/> to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="other"/> is the same as this instance; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals(Glyph other) => InvariantEquivalence?.Equals(other) ?? String.Equals(Sequence, other.Sequence, StringComparison.Ordinal);

		/// <summary>
		/// Determines whether this instance and another specified <see cref="Rune"/> object have the same value.
		/// </summary>
		/// <param name="other">The <see cref="Rune"/> to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="other"/> is the same as this instance; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals(Rune other) {
			if (InvariantEquivalence is Object) {
				return InvariantEquivalence.Equals(other);
			} else if (Sequence.Length <= 2) {
				Span<Char> buffer = new Char[2];
				Int32 charsCount = other.EncodeToUtf16(buffer);
				return Sequence.AsSpan().Slice(0, charsCount).Equals(buffer, StringComparison.Ordinal);
			} else {
				return false;
			}
		}

		/// <summary>
		/// Returns the hash code for this glyph.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => InvariantEquivalence?.GetHashCode() ?? Sequence.GetHashCode();

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object</returns>
		public override String ToString() => Sequence;

		/// <summary>
		/// Tests whether the <paramref name="char"/> is a combining or enclosing mark.
		/// </summary>
		/// <param name="char">The <see cref="Char"/> to test.</param>
		/// <returns></returns>
		private static Boolean IsCombiningMark(Char @char) {
			switch (Char.GetUnicodeCategory(@char)) {
			case UnicodeCategory.NonSpacingMark:
			case UnicodeCategory.SpacingCombiningMark:
			case UnicodeCategory.EnclosingMark:
				return true;
			default:
				return false;
			}
		}
	}
}