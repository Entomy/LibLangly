using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Langly {
	/// <summary>
	/// Represents a UNICODE Grapheme Cluster.
	/// </summary>
	/// <seealso cref="Char"/>
	/// <seealso cref="Rune"/>
	public readonly partial struct Glyph : ICompare<Char>, ICompare<Rune>, ICompare<Glyph> {
		/// <summary>
		/// The <see cref="Int32"/> code describing invariant equivalence rules.
		/// </summary>
		private readonly Int32 Code;

		/// <summary>
		/// Initializes a new <see cref="Glyph"/> from the given UTF-16 Code Unit.
		/// </summary>
		/// <param name="char">The <see cref="Char"/> representing this <see cref="Glyph"/> as it was declared.</param>
		public Glyph(Char @char) => Code = @char;

		/// <summary>
		/// Initializes a new <see cref="Glyph"/> from the given UNICODE Scalar Value.
		/// </summary>
		/// <param name="rune">The <see cref="Rune"/> representing this <see cref="Glyph"/> as it was declared.</param>
		public Glyph(Rune rune) => Code = rune.Value;

		/// <summary>
		/// Initializes a new <see cref="Glyph"/> from the given <paramref name="code"/>.
		/// </summary>
		/// <param name="code">The <see cref="Int32"/> code describing invariant equivalence rules.</param>
		internal Glyph(Int32 code) => Code = code;

		/// <summary>
		/// Returns the length in code units (<see cref="Char"/>) of the UTF-16 sequence required to represent this grapheme.
		/// </summary>
		public Int32 Utf16SequenceLength => Table[Code].UTF16SequenceLength;

		/// <summary>
		/// Returns the length in code units (<see cref="Byte"/>) of the UTF-8 sequence required to represent this grapheme.
		/// </summary>
		public Int32 Utf8SequenceLength => Table[Code].UTF8SequenceLength;

		/// <summary>
		/// Gets the Unicode Grapheme Cluster Equivalency Code as an integer.
		/// </summary>
		public Int32 Value => Code;

		/// <summary>
		/// Converts the <see cref="Char"/> to a <see cref="Glyph"/>.
		/// </summary>
		/// <param name="char">The <see cref="Char"/> to convert.</param>
		public static implicit operator Glyph(Char @char) => new Glyph(@char);

		/// <summary>
		/// Converts the <see cref="Rune"/> to a <see cref="Glyph"/>.
		/// </summary>
		/// <param name="rune">The <see cref="Rune"/> to convert.</param>
		public static implicit operator Glyph(Rune rune) => new Glyph(rune);

		/// <summary>
		/// Returns a value that indicates whether the <see cref="Glyph"/> and <see cref="Char"/> instances are not equal.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">The second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=(Glyph left, Char right) => !left.Equals(right);

		/// <summary>
		/// Returns a value that indicates whether the <see cref="Glyph"/> and <see cref="Rune"/> instances are not equal.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">The second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=(Glyph left, Rune right) => !left.Equals(right);

		/// <summary>
		/// Returns a value that indicates whether the <see cref="Glyph"/> and <see cref="Char"/> instances are not equal.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">The second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=(Char left, Glyph right) => !right.Equals(left);

		/// <summary>
		/// Returns a value that indicates whether the <see cref="Glyph"/> and <see cref="Rune"/> instances are not equal.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">The second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=(Rune left, Glyph right) => !right.Equals(left);

		/// <summary>
		/// Returns a value that indicates whether two <see cref="Glyph"/> instances are not equal.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">The second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=(Glyph left, Glyph right) => !left.Equals(right);

		/// <summary>
		/// Returns a value indicating whether a specified <see cref="Glyph"/> is less than another specified <see cref="Glyph"/>.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">the second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> is less than <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator <(Glyph left, Glyph right) => left.CompareTo(right) < 0;

		/// <summary>
		/// Returns a value indicating whether a specified <see cref="Glyph"/> is less than another specified <see cref="Char"/>.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">the second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> is less than <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator <(Glyph left, Char right) => left.CompareTo(right) < 0;

		/// <summary>
		/// Returns a value indicating whether a specified <see cref="Glyph"/> is less than another specified <see cref="Rune"/>.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">the second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> is less than <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator <(Glyph left, Rune right) => left.CompareTo(right) < 0;

		/// <summary>
		/// Returns a value indicating whether a specified <see cref="Glyph"/> is less than another specified <see cref="Glyph"/>.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">the second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> is less than <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator <(Char left, Glyph right) => right.CompareTo(left) >= 0;

		/// <summary>
		/// Returns a value indicating whether a specified <see cref="Glyph"/> is less than another specified <see cref="Glyph"/>.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">the second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> is less than <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator <(Rune left, Glyph right) => right.CompareTo(left) >= 0;

		/// <summary>
		/// Returns a value indicating whether a specified <see cref="Glyph"/> is less than or equal to another specified <see cref="Glyph"/>.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">the second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> is less than or equal to <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator <=(Glyph left, Glyph right) => left.CompareTo(right) <= 0;

		/// <summary>
		/// Returns a value indicating whether a specified <see cref="Glyph"/> is less than or equal to another specified <see cref="Char"/>.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">the second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> is less than or equal to <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator <=(Glyph left, Char right) => left.CompareTo(right) <= 0;

		/// <summary>
		/// Returns a value indicating whether a specified <see cref="Glyph"/> is less than or equal to another specified <see cref="Rune"/>.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">the second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> is less than or equal to <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator <=(Glyph left, Rune right) => left.CompareTo(right) <= 0;

		/// <summary>
		/// Returns a value indicating whether a specified <see cref="Glyph"/> is less than or equal to another specified <see cref="Glyph"/>.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">the second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> is less than or equal to <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator <=(Char left, Glyph right) => right.CompareTo(left) > 0;

		/// <summary>
		/// Returns a value indicating whether a specified <see cref="Glyph"/> is less than or equal to another specified <see cref="Glyph"/>.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">the second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> is less than or equal to <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator <=(Rune left, Glyph right) => right.CompareTo(left) > 0;

		/// <summary>
		/// Returns a value that indicates whether the <see cref="Glyph"/> and <see cref="Char"/> instances are equal.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">The second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==(Glyph left, Char right) => left.Equals(right);

		/// <summary>
		/// Returns a value that indicates whether the <see cref="Glyph"/> and <see cref="Rune"/> instances are equal.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">The second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==(Glyph left, Rune right) => left.Equals(right);

		/// <summary>
		/// Returns a value that indicates whether the <see cref="Glyph"/> and <see cref="Char"/> instances are equal.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">The second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==(Char left, Glyph right) => right.Equals(left);

		/// <summary>
		/// Returns a value that indicates whether the <see cref="Glyph"/> and <see cref="Rune"/> instances are equal.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">The second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==(Rune left, Glyph right) => right.Equals(left);

		/// <summary>
		/// Returns a value that indicates whether two <see cref="Glyph"/> instances are equal.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">The second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==(Glyph left, Glyph right) => left.Equals(right);

		/// <summary>
		/// Returns a value indicating whether a specified <see cref="Glyph"/> is greater than another specified <see cref="Glyph"/>.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">the second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> is greater than <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator >(Glyph left, Glyph right) => left.CompareTo(right) > 0;

		/// <summary>
		/// Returns a value indicating whether a specified <see cref="Glyph"/> is greater than another specified <see cref="Char"/>.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">the second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> is greater than <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator >(Glyph left, Char right) => left.CompareTo(right) > 0;

		/// <summary>
		/// Returns a value indicating whether a specified <see cref="Glyph"/> is greater than another specified <see cref="Rune"/>.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">the second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> is greater than <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator >(Glyph left, Rune right) => left.CompareTo(right) > 0;

		/// <summary>
		/// Returns a value indicating whether a specified <see cref="Glyph"/> is greater than another specified <see cref="Glyph"/>.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">the second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> is greater than <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator >(Char left, Glyph right) => right.CompareTo(left) <= 0;

		/// <summary>
		/// Returns a value indicating whether a specified <see cref="Glyph"/> is greater than another specified <see cref="Glyph"/>.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">the second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> is greater than <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator >(Rune left, Glyph right) => right.CompareTo(left) <= 0;

		/// <summary>
		/// Returns a value indicating whether a specified <see cref="Glyph"/> is greater than or equal to another specified <see cref="Glyph"/>.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">the second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> is greater than or equal to <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator >=(Glyph left, Glyph right) => left.CompareTo(right) >= 0;

		/// <summary>
		/// Returns a value indicating whether a specified <see cref="Glyph"/> is greater than or equal to another specified <see cref="Char"/>.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">the second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> is greater than or equal to <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator >=(Glyph left, Char right) => left.CompareTo(right) >= 0;

		/// <summary>
		/// Returns a value indicating whether a specified <see cref="Glyph"/> is greater than or equal to another specified <see cref="Rune"/>.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">the second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> is greater than or equal to <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator >=(Glyph left, Rune right) => left.CompareTo(right) >= 0;

		/// <summary>
		/// Returns a value indicating whether a specified <see cref="Glyph"/> is greater than or equal to another specified <see cref="Glyph"/>.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">the second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> is greater than or equal to <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator >=(Char left, Glyph right) => right.CompareTo(left) < 0;

		/// <summary>
		/// Returns a value indicating whether a specified <see cref="Glyph"/> is greater than or equal to another specified <see cref="Glyph"/>.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">the second value to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> is greater than or equal to <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator >=(Rune left, Glyph right) => right.CompareTo(left) < 0;

		/// <summary>
		/// Converts the string representation to its <see cref="Glyph"/> equivalent.
		/// </summary>
		/// <param name="text">Text containing the glyph.</param>
		/// <returns>The <see cref="Glyph"/> represented by the <paramref name="text"/>.</returns>
		/// <exception cref="FormatException">Text contains more than a single grapheme.</exception>
		public static Glyph Parse([AllowNull] String text) {
			Glyph glyph;
			if (text is not null) {
				Int32 i = 0;
				glyph = new(Parser.Parse(text, ref i));
				if (i != text.Length) {
					throw new FormatException("Text contains more than a single grapheme.");
				}
			} else {
				glyph = new Glyph(0);
			}
			return glyph;
		}

		/// <summary>
		/// Converts the string representation to its <see cref="Glyph"/> equivalent.
		/// </summary>
		/// <param name="text">Text containing the glyph.</param>
		/// <returns>The <see cref="Glyph"/> represented by the <paramref name="text"/>.</returns>
		/// <exception cref="FormatException">Text contains more than a single grapheme.</exception>
		public static Glyph Parse([AllowNull] Char[] text) {
			Glyph glyph;
			if (text is not null) {
				Int32 i = 0;
				glyph = new(Parser.Parse(text, ref i));
				if (i != text.Length) {
					throw new FormatException("Text contains more than a single grapheme.");
				}
			} else {
				glyph = new Glyph(0);
			}
			return glyph;
		}

		/// <summary>
		/// Converts the string representation to its <see cref="Glyph"/> equivalent.
		/// </summary>
		/// <param name="text">Text containing the glyph.</param>
		/// <returns>The <see cref="Glyph"/> represented by the <paramref name="text"/>.</returns>
		/// <exception cref="FormatException">Text contains more than a single grapheme.</exception>
		public static Glyph Parse(Memory<Char> text) {
			Int32 i = 0;
			Glyph glyph = new(Parser.Parse(text, ref i));
			if (i != text.Length) {
				throw new FormatException("Text contains more than a single grapheme.");
			}
			return glyph;
		}

		/// <summary>
		/// Converts the string representation to its <see cref="Glyph"/> equivalent.
		/// </summary>
		/// <param name="text">Text containing the glyph.</param>
		/// <returns>The <see cref="Glyph"/> represented by the <paramref name="text"/>.</returns>
		/// <exception cref="FormatException">Text contains more than a single grapheme.</exception>
		public static Glyph Parse(ReadOnlyMemory<Char> text) {
			Int32 i = 0;
			Glyph glyph = new(Parser.Parse(text, ref i));
			if (i != text.Length) {
				throw new FormatException("Text contains more than a single grapheme.");
			}
			return glyph;
		}

		/// <summary>
		/// Converts the string representation to its <see cref="Glyph"/> equivalent.
		/// </summary>
		/// <param name="text">Text containing the glyph.</param>
		/// <returns>The <see cref="Glyph"/> represented by the <paramref name="text"/>.</returns>
		/// <exception cref="FormatException">Text contains more than a single grapheme.</exception>
		public static Glyph Parse(Span<Char> text) {
			Int32 i = 0;
			Glyph glyph = new(Parser.Parse(text, ref i));
			if (i != text.Length) {
				throw new FormatException("Text contains more than a single grapheme.");
			}
			return glyph;
		}

		/// <summary>
		/// Converts the string representation to its <see cref="Glyph"/> equivalent.
		/// </summary>
		/// <param name="text">Text containing the glyph.</param>
		/// <returns>The <see cref="Glyph"/> represented by the <paramref name="text"/>.</returns>
		/// <exception cref="FormatException">Text contains more than a single grapheme.</exception>
		public static Glyph Parse(ReadOnlySpan<Char> text) {
			Int32 i = 0;
			Glyph glyph = new(Parser.Parse(text, ref i));
			if (i != text.Length) {
				throw new FormatException("Text contains more than a single grapheme.");
			}
			return glyph;
		}

		/// <summary>
		/// Converts the string representation to its <see cref="Glyph"/> equivalent.
		/// </summary>
		/// <param name="text">Text containing the glyph.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <returns>The <see cref="Glyph"/> represented by the <paramref name="text"/>.</returns>
		/// <exception cref="FormatException">Text contains more than a single grapheme.</exception>
		[CLSCompliant(false)]
		public static unsafe Glyph Parse([AllowNull] Char* text, Int32 length) => text is not null ? Parse(new ReadOnlySpan<Char>(text, length)) : new Glyph(0);

		/// <summary>
		/// Reverses the graphemes in this <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The <see cref="String"/> to reverse.</param>
		/// <returns>The source <paramref name="text"/> with its graphemes reversed.</returns>
		public static ReadOnlyMemory<Char> Reverse([AllowNull] String text) => text is not null ? Reverse(text.AsMemory()) : null;

		/// <summary>
		/// Reverses the graphemes in this <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The <see cref="Array"/> of <see cref="Char"/> to reverse.</param>
		/// <returns>The source <paramref name="text"/> with its graphemes reversed.</returns>
		public static ReadOnlyMemory<Char> Reverse([AllowNull] Char[] text) => text is not null ? Reverse(text.AsMemory()) : null;

		/// <summary>
		/// Reverses the graphemes in this <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The <see cref="Memory{T}"/> of <see cref="Char"/> to reverse.</param>
		/// <returns>The source <paramref name="text"/> with its graphemes reversed.</returns>
		public static ReadOnlyMemory<Char> Reverse(Memory<Char> text) => Reverse(text.Span);

		/// <summary>
		/// Reverses the graphemes in this <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> to reverse.</param>
		/// <returns>The source <paramref name="text"/> with its graphemes reversed.</returns>
		public static ReadOnlyMemory<Char> Reverse(ReadOnlyMemory<Char> text) => Reverse(text.Span);

		/// <summary>
		/// Reverses the graphemes in this <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The <see cref="Span{T}"/> of <see cref="Char"/> to reverse.</param>
		/// <returns>The source <paramref name="text"/> with its graphemes reversed.</returns>
		public static ReadOnlyMemory<Char> Reverse(Span<Char> text) => Reverse((ReadOnlySpan<Char>)text);

		/// <summary>
		/// Reverses the graphemes in this <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to reverse.</param>
		/// <returns>The source <paramref name="text"/> with its graphemes reversed.</returns>
		public static ReadOnlyMemory<Char> Reverse(ReadOnlySpan<Char> text) {
			Memory<Char> result = new Char[text.Length];
			Int32 r = result.Length;
			foreach (Glyph glyph in text.EnumerateGlyphs()) {
				r -= glyph.Utf16SequenceLength;
				_ = glyph.EncodeToUtf16(result.Span.Slice(r, glyph.Utf16SequenceLength));
			}
			return result.Slice(r);
		}

		/// <summary>
		/// Reverses the graphemes in this <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The <see cref="Char"/>* to reverse.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <returns>The source <paramref name="text"/> with its graphemes reversed.</returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlyMemory<Char> Reverse([AllowNull] Char* text, Int32 length) => Reverse(new ReadOnlySpan<Char>(text, length));

		/// <summary>
		/// Returns a copy of the specified <see cref="Glyph"/> converted to lowercase.
		/// </summary>
		/// <param name="glyph">The UNICODE grapheme cluster to convert.</param>
		/// <returns>The lowercase equivalent of value.</returns>
		public static Glyph ToLowerInvariant(Glyph glyph) => new Glyph(Table[glyph.Code].Lowercase);

		/// <summary>
		/// Returns a copy of the specified <see cref="Glyph"/> converted to titlecase.
		/// </summary>
		/// <param name="glyph">The UNICODE grapheme cluster to convert.</param>
		/// <returns>The titlecase equivalent of value.</returns>
		public static Glyph ToTitleInvariant(Glyph glyph) => new Glyph(Table[glyph.Code].Titlecase);

		/// <summary>
		/// Returns a copy of the specified <see cref="Glyph"/> converted to uppercase.
		/// </summary>
		/// <param name="glyph">The UNICODE grapheme cluster to convert.</param>
		/// <returns>The uppercase equivalent of value.</returns>
		public static Glyph ToUpperInvariant(Glyph glyph) => new Glyph(Table[glyph.Code].Uppercase);

		/// <summary>
		/// Attempts to convert the string representation to its <see cref="Glyph"/> equivalent.
		/// </summary>
		/// <param name="text">Text containing the glyph.</param>
		/// <param name="glyph">The <see cref="Glyph"/> represented by the <paramref name="text"/>.</param>
		/// <returns><see langword="true"/> if the parsing was successful; otherwise, <see langword="false"/>.</returns>
		public static Boolean TryParse([AllowNull] String text, out Glyph glyph) {
			if (text is not null) {
				Int32 i = 0;
				glyph = new(Parser.Parse(text, ref i));
				return i != text.Length;
			} else {
				glyph = new Glyph(0);
				return false;
			}
		}

		/// <summary>
		/// Attempts to convert the string representation to its <see cref="Glyph"/> equivalent.
		/// </summary>
		/// <param name="text">Text containing the glyph.</param>
		/// <param name="glyph">The <see cref="Glyph"/> represented by the <paramref name="text"/>.</param>
		/// <returns><see langword="true"/> if the parsing was successful; otherwise, <see langword="false"/>.</returns>
		public static Boolean TryParse([AllowNull] Char[] text, out Glyph glyph) {
			if (text is not null) {
				Int32 i = 0;
				glyph = new(Parser.Parse(text, ref i));
				return i != text.Length;
			} else {
				glyph = new Glyph(0);
				return false;
			}
		}

		/// <summary>
		/// Attempts to convert the string representation to its <see cref="Glyph"/> equivalent.
		/// </summary>
		/// <param name="text">Text containing the glyph.</param>
		/// <param name="glyph">The <see cref="Glyph"/> represented by the <paramref name="text"/>.</param>
		/// <returns><see langword="true"/> if the parsing was successful; otherwise, <see langword="false"/>.</returns>
		public static Boolean TryParse(Memory<Char> text, out Glyph glyph) {
			Int32 i = 0;
			glyph = new(Parser.Parse(text, ref i));
			return i != text.Length;
		}

		/// <summary>
		/// Attempts to convert the string representation to its <see cref="Glyph"/> equivalent.
		/// </summary>
		/// <param name="text">Text containing the glyph.</param>
		/// <param name="glyph">The <see cref="Glyph"/> represented by the <paramref name="text"/>.</param>
		/// <returns><see langword="true"/> if the parsing was successful; otherwise, <see langword="false"/>.</returns>
		public static Boolean TryParse(ReadOnlyMemory<Char> text, out Glyph glyph) {
			Int32 i = 0;
			glyph = new(Parser.Parse(text, ref i));
			return i != text.Length;
		}

		/// <summary>
		/// Attempts to convert the string representation to its <see cref="Glyph"/> equivalent.
		/// </summary>
		/// <param name="text">Text containing the glyph.</param>
		/// <param name="glyph">The <see cref="Glyph"/> represented by the <paramref name="text"/>.</param>
		/// <returns><see langword="true"/> if the parsing was successful; otherwise, <see langword="false"/>.</returns>
		public static Boolean TryParse(Span<Char> text, out Glyph glyph) {
			Int32 i = 0;
			glyph = new(Parser.Parse(text, ref i));
			return i != text.Length;
		}

		/// <summary>
		/// Attempts to convert the string representation to its <see cref="Glyph"/> equivalent.
		/// </summary>
		/// <param name="text">Text containing the glyph.</param>
		/// <param name="glyph">The <see cref="Glyph"/> represented by the <paramref name="text"/>.</param>
		/// <returns><see langword="true"/> if the parsing was successful; otherwise, <see langword="false"/>.</returns>
		public static Boolean TryParse(ReadOnlySpan<Char> text, out Glyph glyph) {
			Int32 i = 0;
			glyph = new(Parser.Parse(text, ref i));
			return i != text.Length;
		}

		/// <summary>
		/// Attempts to convert the string representation to its <see cref="Glyph"/> equivalent.
		/// </summary>
		/// <param name="text">Text containing the glyph.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="glyph">The <see cref="Glyph"/> represented by the <paramref name="text"/>.</param>
		/// <returns><see langword="true"/> if the parsing was successful; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean TryParse([AllowNull] Char* text, Int32 length, out Glyph glyph) {
			if (text is not null) {
				Int32 i = 0;
				glyph = new(Parser.Parse(text, length, ref i));
				return i != length;
			} else {
				glyph = new Glyph(0);
				return false;
			}
		}

		/// <inheritdoc/>
		public Int32 CompareTo([AllowNull] System.Object obj) {
			switch (obj) {
			case Char @char:
				return CompareTo(@char);
			case Rune rune:
				return CompareTo(rune);
			case Glyph glyph:
				return CompareTo(glyph);
			case IComparable<Glyph> other:
				return 1 - other.CompareTo(this);
			default:
				throw new ArgumentException("obj is not comparable to Glyph", nameof(obj));
			}
		}

		/// <inheritdoc/>
		public Int32 CompareTo(Char other) => Code.CompareTo(other);

		/// <inheritdoc/>
		public Int32 CompareTo(Rune other) => Code.CompareTo(other.Value);

		/// <inheritdoc/>
		public Int32 CompareTo(Glyph other) => Code.CompareTo(other.Code);

		/// <summary>
		/// Encode this <see cref="Glyph"/> to a UTF-16 destination buffer.
		/// </summary>
		/// <param name="destination">The buffer to which to write this value as UTF-16.</param>
		/// <returns>The number of <see cref="Char"/> values written to <paramref name="destination"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="destination"/> is not large enough to hold the output.</exception>
		public Int32 EncodeToUtf16(Span<Char> destination) {
			String sequence = Table[Code].Sequence;
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
			String sequence = Table[Code].Sequence;
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
		public override Boolean Equals([AllowNull] System.Object obj) {
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
		public override Int32 GetHashCode() => Code;

		/// <summary>
		/// Converts the value of this UNICODE grapheme cluster to its lowercase equivalent, invariant of orthography.
		/// </summary>
		/// <returns>The lowercase equivalent of this <see cref="Glyph"/>, or the unchanged value of this <see cref="Glyph"/> if this <see cref="Glyph"/> is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
		public Glyph ToLower() => new Glyph(Table[Code].Lowercase);

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Table[Code].Sequence;

		/// <summary>
		/// Converts the value of this UNICODE grapheme cluster to its titlecase equivalent, invariant of orthography.
		/// </summary>
		/// <returns>The titlecase equivalent of this <see cref="Glyph"/>, or the unchanged value of this <see cref="Glyph"/> if this <see cref="Glyph"/> is already titlecase, has no titlecase equivalent, or is not alphabetic.</returns>
		public Glyph ToTitle() => new Glyph(Table[Code].Titlecase);

		/// <summary>
		/// Converts the value of this UNICODE grapheme cluster to its uppercase equivalent, invariant of orthography.
		/// </summary>
		/// <returns>The uppercase equivalent of this <see cref="Glyph"/>, or the unchanged value of this <see cref="Glyph"/> if this <see cref="Glyph"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public Glyph ToUpper() => new Glyph(Table[Code].Uppercase);
	}
}
