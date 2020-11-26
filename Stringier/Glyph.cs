using Langly;
using Stringier.Linguistics;
using System;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using Stringier.Encodings;

namespace Stringier {
	/// <summary>
	/// Represents a UNICODE grapheme cluster.
	/// </summary>
	/// <seealso cref="Rune"/>
	/// <seealso cref="Char"/>
	public readonly partial struct Glyph : ITextElement<Glyph> {
		/// <summary>
		/// The <see cref="UInt32"/> code describing invariant equivalence rules.
		/// </summary>
		internal readonly UInt32 Code;

		/// <summary>
		/// Initializes a new <see cref="Glyph"/> from the given UTF-16 code unit.
		/// </summary>
		/// <param name="char">The <see cref="Char"/> representing this <see cref="Glyph"/> as it was declared.</param>
		public Glyph(Char @char) => Code = @char;

		/// <summary>
		/// Initializes a new <see cref="Glyph"/> from the given UNICODE character.
		/// </summary>
		/// <param name="rune">The <see cref="Rune"/> representing this <see cref="Glyph"/> as it was declared.</param>
		public Glyph(Rune rune) => Code = unchecked((UInt32)rune.Value);

		/// <summary>
		/// Initializes a new <see cref="Glyph"/> from the given <paramref name="code"/>.
		/// </summary>
		/// <param name="code">The <see cref="UInt32"/> code describing invariant equivalence rules.</param>
		internal Glyph(UInt32 code) => Code = code;

		/// <summary>
		/// Returns the length in code units (<see cref="Char"/>) of the UTF-16 sequence required to represent this grapheme.
		/// </summary>
		public Int32 Utf16SequenceLength => Info[Code].Utf16SequenceLength;

		/// <summary>
		/// Returns the length in code units (<see cref="Byte"/>) of the UTF-8 sequence required to represent this grapheme.
		/// </summary>
		public Int32 Utf8SequenceLength => Info[Code].Utf8SequenceLength;

		/// <summary>
		/// Attempt to convert the <paramref name="sequence"/> to a <see cref="Glyph"/>.
		/// </summary>
		/// <param name="sequence">The sequence to convert.</param>
		/// <returns>A <see cref="Glyph"/> object representing the <paramref name="sequence"/>.</returns>
		/// <exception cref="GlyphOverlongSequenceException">Thrown if the sequence is longer than a single glyph.</exception>
		public static explicit operator Glyph(String sequence) {
			if (sequence is null) {
				return new Glyph();
			}
			return (Glyph)sequence.AsMemory();
		}

		/// <summary>
		/// Attempt to convert the <paramref name="sequence"/> to a <see cref="Glyph"/>.
		/// </summary>
		/// <param name="sequence">The sequence to convert.</param>
		/// <returns>A <see cref="Glyph"/> object representing the <paramref name="sequence"/>.</returns>
		/// <exception cref="GlyphOverlongSequenceException">Thrown if the sequence is longer than a single glyph.</exception>
		public static explicit operator Glyph(ReadOnlyMemory<Char> sequence) {
			Int32 pos = 0;
			UInt32 code = Equivalencies.Parse(sequence, ref pos);
			if (pos == sequence.Length) {
				return new Glyph(code);
			} else {
				throw GlyphOverlongSequenceException.With(sequence, pos);
			}
		}

		[SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "The constructor takes this role.")]
		public static implicit operator Glyph(Char @char) => new Glyph(@char);

		[SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "The constructor takes this role.")]
		public static implicit operator Glyph(Rune rune) => new Glyph(rune);

		public static Boolean operator !=(Glyph left, Glyph right) => !left.Equals(right);

		public static Boolean operator !=(Glyph left, Char right) => !left.Equals(right);

		public static Boolean operator !=(Char left, Glyph right) => !right.Equals(left);

		public static Boolean operator !=(Glyph left, Rune right) => !left.Equals(right);

		public static Boolean operator !=(Rune left, Glyph right) => !right.Equals(left);

		public static Boolean operator <(Glyph left, Glyph right) => left.CompareTo(right) < 0;

		public static Boolean operator <(Glyph left, Char right) => left.CompareTo(right) < 0;

		public static Boolean operator <(Char left, Glyph right) => right.CompareTo(left) > 0;

		public static Boolean operator <(Glyph left, Rune right) => left.CompareTo(right) < 0;

		public static Boolean operator <(Rune left, Glyph right) => right.CompareTo(left) > 0;

		public static Boolean operator <=(Glyph left, Glyph right) => left.CompareTo(right) <= 0;

		public static Boolean operator <=(Glyph left, Char right) => left.CompareTo(right) <= 0;

		public static Boolean operator <=(Char left, Glyph right) => right.CompareTo(left) >= 0;

		public static Boolean operator <=(Glyph left, Rune right) => left.CompareTo(right) <= 0;

		public static Boolean operator <=(Rune left, Glyph right) => right.CompareTo(left) >= 0;

		public static Boolean operator ==(Glyph left, Glyph right) => left.Equals(right);

		public static Boolean operator ==(Glyph left, Char right) => left.Equals(right);

		public static Boolean operator ==(Char left, Glyph right) => right.Equals(left);

		public static Boolean operator ==(Glyph left, Rune right) => left.Equals(right);

		public static Boolean operator ==(Rune left, Glyph right) => right.Equals(left);

		public static Boolean operator >(Glyph left, Glyph right) => left.CompareTo(right) > 0;

		public static Boolean operator >(Glyph left, Char right) => left.CompareTo(right) > 0;

		public static Boolean operator >(Char left, Glyph right) => right.CompareTo(left) < 0;

		public static Boolean operator >(Glyph left, Rune right) => left.CompareTo(right) > 0;

		public static Boolean operator >(Rune left, Glyph right) => right.CompareTo(left) < 0;

		public static Boolean operator >=(Glyph left, Glyph right) => left.CompareTo(right) >= 0;

		public static Boolean operator >=(Glyph left, Char right) => left.CompareTo(right) >= 0;

		public static Boolean operator >=(Char left, Glyph right) => right.CompareTo(left) <= 0;

		public static Boolean operator >=(Glyph left, Rune right) => left.CompareTo(right) >= 0;

		public static Boolean operator >=(Rune left, Glyph right) => right.CompareTo(left) <= 0;

		/// <summary>
		/// Reverses the graphemes in this <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The <see cref="String"/> to reverse.</param>
		/// <returns>The source <paramref name="text"/> with its graphemes reversed.</returns>
		public static String Reverse(String text) {
			Guard.NotNull(text, nameof(text));
			return Reverse(text.AsSpan());
		}

		/// <summary>
		/// Reverses the graphemes in this <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The <see cref="Array"/> of <see cref="Char"/> to reverse.</param>
		/// <returns>The source <paramref name="text"/> with its graphemes reversed.</returns>
		public static String Reverse(Char[] text) {
			Guard.NotNull(text, nameof(text));
			return Reverse(text.AsSpan());
		}

		/// <summary>
		/// Reverses the graphemes in this <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The <see cref="Span{T}"/> of <see cref="Char"/> to reverse.</param>
		/// <returns>The source <paramref name="text"/> with its graphemes reversed.</returns>
		public static String Reverse(Span<Char> text) => Reverse((ReadOnlySpan<Char>)text);

		/// <summary>
		/// Reverses the graphemes in this <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to reverse.</param>
		/// <returns>The source <paramref name="text"/> with its graphemes reversed.</returns>
		public static unsafe String Reverse(ReadOnlySpan<Char> text) {
			Span<Char> result = new Char[text.Length];
			Int32 r = result.Length;
			foreach (Glyph glyph in text.EnumerateGlyphs()) {
				r -= glyph.Utf16SequenceLength;
				_ = glyph.EncodeToUtf16(result.Slice(r, glyph.Utf16SequenceLength));
			}
			fixed (Char* res = result) {
				return new String(res, r, result.Length - r);
			}
		}

		/// <inheritdoc/>
		public Int32 CompareTo(Object obj) {
			switch (obj) {
			case Char @char:
				return CompareTo(@char);
			case Rune rune:
				return CompareTo(rune);
			case Glyph glyph:
				return CompareTo(glyph);
			default:
				throw new System.ArgumentException("Object is not the same type as this instance, or another comparable type.", nameof(obj));
			}
		}

		/// <inheritdoc/>
		public Int32 CompareTo(Char other) => Code.CompareTo(other);

		/// <inheritdoc/>
		public Int32 CompareTo(Rune other) => Code.CompareTo(unchecked((UInt32)other.Value));

		/// <inheritdoc/>
		public Int32 CompareTo(Glyph other) => Code.CompareTo(other.Code);

		/// <summary>
		/// Encode this <see cref="Glyph"/> to a UTF-16 destination buffer.
		/// </summary>
		/// <param name="destination">The buffer to which to write this value as UTF-16.</param>
		/// <returns>The number of <see cref="Char"/> values written to <paramref name="destination"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="destination"/> is not large enough to hold the output.</exception>
		public Int32 EncodeToUtf16(Span<Char> destination) {
			Guard.LargerThanOrEqual(destination, nameof(destination), Utf16SequenceLength);
			String sequence = Info[Code].Sequence;
			sequence.AsSpan().CopyTo(destination);
			return sequence.Length;
		}

		/// <summary>
		/// Encode this <see cref="Glyph"/> to a UTF-8 destination buffer.
		/// </summary>
		/// <param name="destination">The buffer to which to write this value as UTF-16.</param>
		/// <returns>The number of <see cref="Byte"/> values written to <paramref name="destination"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="destination"/> is not large enough to hold the output.</exception>
		public Int32 EncodeToUtf8(Span<Byte> destination) {
			Guard.LargerThanOrEqual(destination, nameof(destination), Utf8SequenceLength);
			String sequence = Info[Code].Sequence;
			Int32 d = 0;
			Int32 l = 0;
			foreach (Rune rune in sequence.EnumerateRunes()) {
				UTF8.Encode(rune, out Byte first, out Byte second, out Byte third, out Byte fourth);
				l = rune.Utf8SequenceLength;
				if (l >= 1) {
					destination[d++] = first;
				}
				if (l >= 2) {
					destination[d++] = second;
				}
				if (l >= 3) {
					destination[d++] = third;
				}
				if (l >= 4) {
					destination[d++] = fourth;
				}
			}
			return d;
		}
		/// <inheritdoc/>
		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Char @char:
				return Equals(@char);
			case Rune rune:
				return Equals(rune);
			case Glyph glyph:
				return Equals(glyph);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals(Char other) => Code == other;

		/// <inheritdoc/>
		public Boolean Equals(Rune other) => Code == other.Value;

		/// <inheritdoc/>
		public Boolean Equals(Glyph other) => Code == other.Code;

		/// <inheritdoc/>
		public override Int32 GetHashCode() => unchecked((Int32)Code);

		/// <summary>
		/// Converts the value of this UNICODE grapheme cluster to its lowercase equivalent, invariant of orthography.
		/// </summary>
		/// <returns>The lowercase equivalent of this <see cref="Glyph"/>, or the unchanged value of this <see cref="Glyph"/> if this <see cref="Glyph"/> is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
		public Glyph ToLower() => new Glyph(Info[Code].Lowercase);

		/// <summary>
		/// Converts the value of this UNICODE grapheme cluster to its lowercase equivalent, using the casing rules of the specified orthography.
		/// </summary>
		/// <param name="orthography">The <see cref="Orthography"/> instance describing the rules of the orthography.</param>
		/// <returns>The lowercase equivalent of this <see cref="Glyph"/>, or the unchanged value of this <see cref="Glyph"/> if this <see cref="Glyph"/> is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
		/// <inheritdoc/>
		public Glyph ToLower(Orthography orthography) => orthography?.ToLower(this) ?? ToLower();

		/// <inheritdoc/>
		public override String ToString() => Info[Code].Sequence;

		/// <summary>
		/// Converts the value of this UNICODE grapheme cluster to its titlecase equivalent, invariant of orthography.
		/// </summary>
		/// <returns>The titlecase equivalent of this <see cref="Glyph"/>, or the unchanged value of this <see cref="Glyph"/> if this <see cref="Glyph"/> is already titlecase, has no titlecase equivalent, or is not alphabetic.</returns>
		public Glyph ToTitle() => new Glyph(Info[Code].Titlecase);

		/// <summary>
		/// Converts the value of this UNICODE grapheme cluster to its titlecase equivalent, using the casing rules of the specified orthography.
		/// </summary>
		/// <param name="orthography">The <see cref="Orthography"/> instance describing the rules of the orthography.</param>
		/// <returns>The titlecase equivalent of this <see cref="Glyph"/>, or the unchanged value of this <see cref="Glyph"/> if this <see cref="Glyph"/> is already titlecase, has no titlecase equivalent, or is not alphabetic.</returns>
		/// <inheritdoc/>
		public Glyph ToTitle(Orthography orthography) => orthography?.ToTitle(this) ?? ToTitle();

		/// <summary>
		/// Converts the value of this UNICODE grapheme cluster to its uppercase equivalent, invariant of orthography.
		/// </summary>
		/// <returns>The uppercase equivalent of this <see cref="Glyph"/>, or the unchanged value of this <see cref="Glyph"/> if this <see cref="Glyph"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public Glyph ToUpper() => new Glyph(Info[Code].Uppercase);

		/// <summary>
		/// Converts the value of this UNICODE grapheme cluster to its uppercase equivalent, using the casing rules of the specified orthography.
		/// </summary>
		/// <param name="orthography">The <see cref="Orthography"/> instance describing the rules of the orthography.</param>
		/// <returns>The uppercase equivalent of this <see cref="Glyph"/>, or the unchanged value of this <see cref="Glyph"/> if this <see cref="Glyph"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		/// <inheritdoc/>
		public Glyph ToUpper(Orthography orthography) => orthography?.ToUpper(this) ?? ToUpper();
	}
}
