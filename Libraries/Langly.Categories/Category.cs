using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Unicode;
using Langly.DataStructures;

namespace Langly {
	/// <summary>
	/// Represents the category of a UNICODE Character.
	/// </summary>
	/// <remarks>
	/// <para>While this has analogues to <see cref="UnicodeCategory"/>, there are a number of issues with how Microsoft approached that. First and foremost, there's no convenient way to group categories, even though UAX#44-5.7.1 does exactly this. This grouping of categories is important from a usability standpoint, for example, removing all symbols from a given text, or identifying any punctuation. Furthermore, <see cref="UnicodeCategory"/> strays from the names that the UNICODE Consortium gave, which is confusing, such as <see cref="UnicodeCategory.OtherNotAssigned"/> versus <see cref="Unassigned"/>.</para>
	/// <para>This has been designed with respect to Set Theory and Set Algebra, so far more complicated situations than <see cref="UnicodeCategory"/> can provide are possible through this.</para>
	/// </remarks>
	/// <seealso href="http://www.unicode.org/reports/tr44/#General_Category_Values"/>
	/// <seealso href="https://www.unicode.org/notes/tn36/"/>
	public class Category : Set<Glyph>, IContains<Char>, IContains<Rune> {
		#region Discrete
		/// <summary>
		/// A box-drawing character.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category BoxDrawing { get; } = Range('\u2500', '\u257F');

		/// <summary>
		/// A closing punctuation mark (of a pair).
		/// </summary>
		[DisallowNull, NotNull]
		public static Category ClosePunctuation { get; } = new(UnicodeCategory.ClosePunctuation);

		/// <summary>
		/// A connecting punctuation mark, like a tie.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category ConnectorPunctuation { get; } = new(UnicodeCategory.ConnectorPunctuation);

		/// <summary>
		/// A C0 or C1 control code.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category Control { get; } = new(UnicodeCategory.Control);

		/// <summary>
		/// A currency sign.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category CurrencySymbol { get; } = new(UnicodeCategory.CurrencySymbol);

		/// <summary>
		/// A dash or hyphen punctuation mark.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category DashPunctuation { get; } = new(UnicodeCategory.DashPunctuation);

		/// <summary>
		/// A decimal digit.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category DecimalNumber { get; } = new(UnicodeCategory.DecimalDigitNumber);

		/// <summary>
		/// An enclosing combining mark.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category EnclosingMark { get; } = new(UnicodeCategory.EnclosingMark);

		/// <summary>
		/// A final quotation mark.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category FinalPunctuation { get; } = new(UnicodeCategory.FinalQuotePunctuation);

		/// <summary>
		/// A format control character.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category Format { get; } = new(UnicodeCategory.Format);

		/// <summary>
		/// A hexadecimal digit.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category HexadecimalNumber { get; } = new(ContributoryProperties.HexDigit | ContributoryProperties.AsciiHexDigit);

		/// <summary>
		/// An initial quotation mark.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category InitialPunctuation { get; } = new(UnicodeCategory.InitialQuotePunctuation);

		/// <summary>
		/// A letterlike numeric character.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category LetterNumber { get; } = new(UnicodeCategory.LetterNumber);

		/// <summary>
		/// U+2028 LINE SEPARATOR only.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category LineSeparator { get; } = new(UnicodeCategory.LineSeparator);

		/// <summary>
		/// A lowercase letter.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category LowercaseLetter { get; } = new(UnicodeCategory.LowercaseLetter);

		/// <summary>
		/// A symbol of mathematical use.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category MathSymbol { get; } = new(UnicodeCategory.MathSymbol);

		/// <summary>
		/// A modifier letter.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category ModifierLetter { get; } = new(UnicodeCategory.ModifierLetter);

		/// <summary>
		/// A non-letterlike modifier symbol.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category ModifierSymbol { get; } = new(UnicodeCategory.ModifierSymbol);

		/// <summary>
		/// A nonspacing combining mark (zero advance width);
		/// </summary>
		[DisallowNull, NotNull]
		public static Category NonspacingMark { get; } = new(UnicodeCategory.NonSpacingMark);

		/// <summary>
		/// An opening punctuation mark (of a pair).
		/// </summary>
		[DisallowNull, NotNull]
		public static Category OpenPunctuation { get; } = new(UnicodeCategory.OpenPunctuation);

		/// <summary>
		/// Other letters, including syllables and ideographs.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category OtherLetter { get; } = new(UnicodeCategory.OtherLetter);

		/// <summary>
		/// A numeric character of other type.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category OtherNumber { get; } = new(UnicodeCategory.OtherNumber);

		/// <summary>
		/// A punctuation mark of other type.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category OtherPunctuation { get; } = new(UnicodeCategory.OtherPunctuation);

		/// <summary>
		/// A symbol of other type.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category OtherSymbol { get; } = new(UnicodeCategory.OtherSymbol);

		/// <summary>
		/// U+2029 PARAGRAPH SEPARATOR only.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category ParagraphSeparator { get; } = new(UnicodeCategory.ParagraphSeparator);

		/// <summary>
		/// A private-use character.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category PrivateUse { get; } = new(UnicodeCategory.PrivateUse);

		/// <summary>
		/// A space character (of various non-zero widths).
		/// </summary>
		[DisallowNull, NotNull]
		public static Category SpaceSeparator { get; } = new(UnicodeCategory.SpaceSeparator);

		/// <summary>
		/// A spacing combining mark (positive advance width).
		/// </summary>
		[DisallowNull, NotNull]
		public static Category SpacingMark { get; } = new(UnicodeCategory.SpacingCombiningMark);

		/// <summary>
		/// A subscript character.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category Subscript { get; } = Range('\u2080', '\u209C');

		/// <summary>
		/// A superscript character.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category Superscript { get; } = new((element) => element == '\u00B2' || element == '\u00B3' || element == '\u00B9' || ('\u2070' <= element && element <= '\u207F'));

		/// <summary>
		/// A surrogate code point.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category Surrogate { get; } = new(UnicodeCategory.Surrogate);

		/// <summary>
		/// A digraphic character, with first part uppercase.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category TitlecaseLetter { get; } = new(UnicodeCategory.TitlecaseLetter);

		/// <summary>
		/// A reserved unassigned code point or a noncharacter.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category Unassigned { get; } = new(UnicodeCategory.OtherNotAssigned);

		/// <summary>
		/// An uppercase letter.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category UppercaseLetter { get; } = new(UnicodeCategory.UppercaseLetter);

		/// <summary>
		/// A whitespace character.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category WhiteSpace { get; } = new(ContributoryProperties.WhiteSpace);
		#endregion

		#region Composed
		/// <summary>
		/// Any cased letter character.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category CasedLetter { get; } = LowercaseLetter | UppercaseLetter | TitlecaseLetter;

		/// <summary>
		/// Any letter character.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category Letter { get; } = CasedLetter | ModifierLetter | OtherLetter;

		/// <summary>
		/// Any mark character.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category Mark { get; } = NonspacingMark | SpacingMark | EnclosingMark;

		/// <summary>
		/// Any number character.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category Number { get; } = DecimalNumber | LetterNumber | OtherNumber;

		/// <summary>
		/// Any other character.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category Other { get; } = Control | Format | Surrogate | PrivateUse | Unassigned;

		/// <summary>
		/// Any punctuation character.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category Punctuation { get; } = ConnectorPunctuation | DashPunctuation | OpenPunctuation | ClosePunctuation | InitialPunctuation | FinalPunctuation | OtherPunctuation;

		/// <summary>
		/// Any separator character.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category Separator { get; } = SpaceSeparator | LineSeparator | ParagraphSeparator;

		/// <summary>
		/// Any symbol character.
		/// </summary>
		[DisallowNull, NotNull]
		public static Category Symbol { get; } = MathSymbol | CurrencySymbol | ModifierSymbol | OtherSymbol;
		#endregion

		/// <summary>
		/// Initializes a new <see cref="Category"/>.
		/// </summary>
		/// <param name="predicate">The <see cref="Predicate{T}"/> used to determine inclusion into the category.</param>
		protected Category([DisallowNull] Predicate<Glyph> predicate) : base(predicate) { }

		/// <summary>
		/// Initializes a new <see cref="Category"/>.
		/// </summary>
		/// <param name="elements">The elements of the set.</param>
		protected Category([DisallowNull] params Glyph[] elements) : base(elements) { }

		/// <summary>
		/// Initializes a new <see cref="Category"/>.
		/// </summary>
		/// <param name="collection">The elements of the set.</param>
		protected Category([DisallowNull] IContains<Glyph> collection) : base(collection) { }

		/// <summary>
		/// Initializes a new <see cref="Category"/>
		/// </summary>
		/// <param name="category">The <see cref="UnicodeCategory"/> describing this <see cref="Category"/>.</param>
		protected Category(UnicodeCategory category) : base((element) => UnicodeInfo.GetCategory(element.Value) == category) { }

		/// <summary>
		/// Initializes a new <see cref="Category"/>.
		/// </summary>
		/// <param name="properties">The <see cref="ContributoryProperties"/> describing this <see cref="Category"/>.</param>
		[CLSCompliant(false)]
		protected Category(ContributoryProperties properties) : base((element) => (UnicodeInfo.GetCharInfo(element.Value).ContributoryProperties & properties) != 0) { }

		/// <summary>
		/// Converts the <paramref name="category"/> to a <see cref="Category"/>.
		/// </summary>
		/// <param name="category">The <see cref="UnicodeCategory"/> to convert.</param>
		[return: NotNull]
		public static implicit operator Category(UnicodeCategory category) => new(category);

		/// <summary>
		/// Converts the <paramref name="properties"/> to a <see cref="Category"/>.
		/// </summary>
		/// <param name="properties">The <see cref="ContributoryProperties"/> to convert.</param>
		[return: NotNull]
		[CLSCompliant(false)]
		public static implicit operator Category(ContributoryProperties properties) => new(properties);

		/// <summary>
		/// Singleton instance for the empty category (Ø).
		/// </summary>
		[DisallowNull, NotNull]
		new public static Category Empty { get; } = new((_) => false);

		/// <summary>
		/// Singleton instance for the universe category (U).
		/// </summary>
		[DisallowNull, NotNull]
		new public static Category Universe { get; } = new((_) => true);

		/// <summary>
		/// Returns the difference of <paramref name="right"/> from <paramref name="left"/>.
		/// </summary>
		/// <param name="left">The lefthand category.</param>
		/// <param name="right">The righthand category.</param>
		/// <returns>The difference of <paramref name="right"/> from <paramref name="left"/>.</returns>
		[return: NotNull]
		public static Category operator -([AllowNull] Category left, [AllowNull] Category right) => new(Difference(left, right));

		/// <summary>
		/// Returns the compliment of the <paramref name="category"/>.
		/// </summary>
		/// <param name="category">This category.</param>
		/// <returns>The compliment of the <paramref name="category"/>.</returns>
		[return: NotNull]
		public static Category operator !([AllowNull] Category category) => new(Compliment(category));

		/// <summary>
		/// Returns the intersection of <paramref name="left"/> and <paramref name="right"/>.
		/// </summary>
		/// <param name="left">The lefthand category.</param>
		/// <param name="right">The righthand category.</param>
		/// <returns>The intersection of <paramref name="left"/> and <paramref name="right"/>.</returns>
		[return: NotNull]
		public static Category operator &([AllowNull] Category left, [AllowNull] Category right) => new(Intersection(left, right));

		/// <summary>
		/// Returns the disjunction of <paramref name="left"/> and <paramref name="right"/>.
		/// </summary>
		/// <param name="left">The lefthand category.</param>
		/// <param name="right">The righthand category.</param>
		/// <returns>The disjunction of <paramref name="left"/> and <paramref name="right"/>.</returns>
		[return: NotNull]
		public static Category operator ^([AllowNull] Category left, [AllowNull] Category right) => new(Disjunction(left, right));

		/// <summary>
		/// Returns the union of <paramref name="left"/> and <paramref name="right"/>.
		/// </summary>
		/// <param name="left">The lefthand category.</param>
		/// <param name="right">The righthand category.</param>
		/// <returns>The union of <paramref name="left"/> and <paramref name="right"/>.</returns>
		[return: NotNull]
		public static Category operator |([AllowNull] Category left, [AllowNull] Category right) => new(Union(left, right));

		/// <summary>
		/// Constructs a <see cref="Category"/> from the range <paramref name="lower"/>..<paramref name="upper"/>.
		/// </summary>
		/// <param name="lower">The lower bound.</param>
		/// <param name="upper">The upper bound.</param>
		/// <returns>A <see cref="Set{TElement}"/> for the given range.</returns>
		public static Category Range(Glyph lower, Glyph upper) => new((element) => lower <= element && element <= upper);

		/// <inheritdoc/>
		Boolean IContains<Char>.Contains(Char element) => Predicate(new Glyph(element));

		/// <inheritdoc/>
		Boolean IContains<Rune>.Contains(Rune element) => Predicate(new Glyph(element));
	}
}
