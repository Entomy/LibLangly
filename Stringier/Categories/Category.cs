using System;
using System.Globalization;
using System.Text;
using System.Unicode;
using Collectathon.Sets;
using Philosoft;
using Defender;

namespace Stringier.Categories {
	/// <summary>
	/// The category of a UNICODE Character.
	/// </summary>
	/// <para>While this has analogues to <see cref="UnicodeCategory"/>, there are a number of issues with how Microsoft approached that. First and foremost, there's no convenient way to group categories, even though UAX#44-5.7.1 does exactly this. This grouping of categories is important from a usability standpoint, for example, removing all symbols from a given text, or identifying any punctuation. Furthermore, <see cref="UnicodeCategory"/> strays from the names that the UNICODE Consortium gave, which is confusing, such as <see cref="UnicodeCategory.OtherNotAssigned"/> versus <see cref="Unassigned"/>.</para>
	/// <para>This has been designed with respect to Set Theory and Set Algebra, so far more complicated situations than <see cref="UnicodeCategory"/> can provide are possible through this.</para>
	/// </remarks>
	/// <seealso href="http://www.unicode.org/reports/tr44/#General_Category_Values"/>
	/// <seealso href="https://www.unicode.org/notes/tn36/"/>
	public abstract class Category : Set<Glyph>, IContainable<Char>, IContainable<Rune>, IContainable<Glyph> {
		#region Discrete
		/// <summary>
		/// A box-drawing character.
		/// </summary>
		public static readonly Category BoxDrawing = new RangeCategory(0x2500, 0x257F);

		/// <summary>
		/// A closing punctuation mark (of a pair).
		/// </summary>
		public static readonly Category ClosePunctuation = new StandardCategory(UnicodeCategory.ClosePunctuation);

		/// <summary>
		/// A connecting punctuation mark, like a tie.
		/// </summary>
		public static readonly Category ConnectorPunctuation = new StandardCategory(UnicodeCategory.ConnectorPunctuation);

		/// <summary>
		/// A C0 or C1 control code.
		/// </summary>
		public static readonly Category Control = new StandardCategory(UnicodeCategory.Control);

		/// <summary>
		/// A currency sign.
		/// </summary>
		public static readonly Category CurrencySymbol = new StandardCategory(UnicodeCategory.CurrencySymbol);

		/// <summary>
		/// A dash or hyphen punctuation mark.
		/// </summary>
		public static readonly Category DashPunctuation = new StandardCategory(UnicodeCategory.DashPunctuation);

		/// <summary>
		/// A decimal digit.
		/// </summary>
		public static readonly Category DecimalNumber = new StandardCategory(UnicodeCategory.DecimalDigitNumber);

		/// <summary>
		/// An enclosing combining mark.
		/// </summary>
		public static readonly Category EnclosingMark = new StandardCategory(UnicodeCategory.EnclosingMark);

		/// <summary>
		/// A final quotation mark.
		/// </summary>
		public static readonly Category FinalPunctuation = new StandardCategory(UnicodeCategory.FinalQuotePunctuation);

		/// <summary>
		/// A format control character.
		/// </summary>
		public static readonly Category Format = new StandardCategory(UnicodeCategory.Format);

		/// <summary>
		/// A hexadecimal digit.
		/// </summary>
		public static readonly Category HexadecimalNumber = new PropertyCategory(ContributoryProperties.HexDigit | ContributoryProperties.AsciiHexDigit);

		/// <summary>
		/// An initial quotation mark.
		/// </summary>
		public static readonly Category InitialPunctuation = new StandardCategory(UnicodeCategory.InitialQuotePunctuation);

		/// <summary>
		/// A letterlike numeric character.
		/// </summary>
		public static readonly Category LetterNumber = new StandardCategory(UnicodeCategory.LetterNumber);

		/// <summary>
		/// U+2028 LINE SEPARATOR only.
		/// </summary>
		public static readonly Category LineSeparator = new StandardCategory(UnicodeCategory.LineSeparator);

		/// <summary>
		/// A lowercase letter.
		/// </summary>
		public static readonly Category LowercaseLetter = new StandardCategory(UnicodeCategory.LowercaseLetter);

		/// <summary>
		/// A symbol of mathematical use.
		/// </summary>
		public static readonly Category MathSymbol = new StandardCategory(UnicodeCategory.MathSymbol);

		/// <summary>
		/// A modifier letter.
		/// </summary>
		public static readonly Category ModifierLetter = new StandardCategory(UnicodeCategory.ModifierLetter);

		/// <summary>
		/// A non-letterlike modifier symbol.
		/// </summary>
		public static readonly Category ModifierSymbol = new StandardCategory(UnicodeCategory.ModifierSymbol);

		/// <summary>
		/// A nonspacing combining mark (zero advance width);
		/// </summary>
		public static readonly Category NonspacingMark = new StandardCategory(UnicodeCategory.NonSpacingMark);

		/// <summary>
		/// An opening punctuation mark (of a pair).
		/// </summary>
		public static readonly Category OpenPunctuation = new StandardCategory(UnicodeCategory.OpenPunctuation);

		/// <summary>
		/// Other letters, including syllables and ideographs.
		/// </summary>
		public static readonly Category OtherLetter = new StandardCategory(UnicodeCategory.OtherLetter);

		/// <summary>
		/// A numeric character of other type.
		/// </summary>
		public static readonly Category OtherNumber = new StandardCategory(UnicodeCategory.OtherNumber);

		/// <summary>
		/// A punctuation mark of other type.
		/// </summary>
		public static readonly Category OtherPunctuation = new StandardCategory(UnicodeCategory.OtherPunctuation);

		/// <summary>
		/// A symbol of other type.
		/// </summary>
		public static readonly Category OtherSymbol = new StandardCategory(UnicodeCategory.OtherSymbol);

		/// <summary>
		/// U+2029 PARAGRAPH SEPARATOR only.
		/// </summary>
		public static readonly Category ParagraphSeparator = new StandardCategory(UnicodeCategory.ParagraphSeparator);

		/// <summary>
		/// A private-use character.
		/// </summary>
		public static readonly Category PrivateUse = new StandardCategory(UnicodeCategory.PrivateUse);

		/// <summary>
		/// A space character (of various non-zero widths).
		/// </summary>
		public static readonly Category SpaceSeparator = new StandardCategory(UnicodeCategory.SpaceSeparator);

		/// <summary>
		/// A spacing combining mark (positive advance width).
		/// </summary>
		public static readonly Category SpacingMark = new StandardCategory(UnicodeCategory.SpacingCombiningMark);

		/// <summary>
		/// A subscript character.
		/// </summary>
		public static readonly Category Subscript = new RangeCategory(0x2080, 0x209C);

		/// <summary>
		/// A superscript character.
		/// </summary>
		public static readonly Category Superscript = new SetCategory(Set.From<UInt32>((x) => x == 0xB2 || x == 0xB3 || x == 0xB9 || Check.Within(x, 0x2070, 0x207F)));

		/// <summary>
		/// A surrogate code point.
		/// </summary>
		public static readonly Category Surrogate = new StandardCategory(UnicodeCategory.Surrogate);

		/// <summary>
		/// A digraphic character, with first part uppercase.
		/// </summary>
		public static readonly Category TitlecaseLetter = new StandardCategory(UnicodeCategory.TitlecaseLetter);

		/// <summary>
		/// A reserved unassigned code point or a noncharacter.
		/// </summary>
		public static readonly Category Unassigned = new StandardCategory(UnicodeCategory.OtherNotAssigned);

		/// <summary>
		/// An uppercase letter.
		/// </summary>
		public static readonly Category UppercaseLetter = new StandardCategory(UnicodeCategory.UppercaseLetter);

		/// <summary>
		/// A whitespace character.
		/// </summary>
		public static readonly Category WhiteSpace = new PropertyCategory(ContributoryProperties.WhiteSpace);
		#endregion

		#region Composed
		/// <summary>
		/// Any cased letter character.
		/// </summary>
		public static readonly Category CasedLetter = LowercaseLetter | UppercaseLetter | TitlecaseLetter;

		/// <summary>
		/// Any letter character.
		/// </summary>
		public static readonly Category Letter = CasedLetter | ModifierLetter | OtherLetter;

		/// <summary>
		/// Any mark character.
		/// </summary>
		public static readonly Category Mark = NonspacingMark | SpacingMark | EnclosingMark;

		/// <summary>
		/// Any number character.
		/// </summary>
		public static readonly Category Number = DecimalNumber | LetterNumber | OtherNumber;

		/// <summary>
		/// Any other character.
		/// </summary>
		public static readonly Category Other = Control | Format | Surrogate | PrivateUse | Unassigned;

		/// <summary>
		/// Any punctuation character.
		/// </summary>
		public static readonly Category Punctuation = ConnectorPunctuation | DashPunctuation | OpenPunctuation | ClosePunctuation | InitialPunctuation | FinalPunctuation | OtherPunctuation;

		/// <summary>
		/// Any separator character.
		/// </summary>
		public static readonly Category Separator = SpaceSeparator | LineSeparator | ParagraphSeparator;

		/// <summary>
		/// Any symbol character.
		/// </summary>
		public static readonly Category Symbol = MathSymbol | CurrencySymbol | ModifierSymbol | OtherSymbol;
		#endregion

		/// <summary>
		/// Initializes a new <see cref="Category"/>.
		/// </summary>
		protected Category() { }

		/// <summary>
		/// Returns the difference of the <paramref name="first"/> collection and the <paramref name="second"/> collection.
		/// </summary>
		/// <param name="first">The first collection of the difference.</param>
		/// <param name="second">The second collection of the difference.</param>
		/// <returns>A new collection representing the difference between the two collections.</returns>
		public static Category operator -(Category first, Category second) => first.Difference(second);

		/// <summary>
		/// Returns the complement of the <paramref name="set"/> collection.
		/// </summary>
		/// <param name="set">The collection to complement.</param>
		/// <returns>A new collection representing the complement of the collection.</returns>
		public static Category operator !(Category set) => (Complement)set.Complement();

		/// <summary>
		/// Returns the intersection of the <paramref name="first"/> collection and the <paramref name="second"/> collection.
		/// </summary>
		/// <param name="first">The first collection of the intersection.</param>
		/// <param name="second">The second collection of the intersection.</param>
		/// <returns>A new collection representing the intersection of the two collections.</returns>
		public static Category operator &(Category first, Category second) => first.Intersection(second);

		/// <summary>
		/// Returns the disjunction of the <paramref name="first"/> collection and the <paramref name="second"/> collection.
		/// </summary>
		/// <param name="first">The first collection of the disjunction.</param>
		/// <param name="second">The second collection of the disjunction.</param>
		/// <returns>A new collection representing the disjunction of the two collections.</returns>
		public static Category operator ^(Category first, Category second) => first.Disjunction(second);

		/// <summary>
		/// Returns the union of the <paramref name="first"/> collection and the <paramref name="second"/> collection.
		/// </summary>
		/// <param name="first">The first collection of the union.</param>
		/// <param name="second">The second collection of the union.</param>
		/// <returns>A new collection representing the union of the two collections.</returns>
		public static Category operator |(Category first, Category second) => first.Union(second);

		/// <inheritdoc/>
		Boolean IContainable<Rune>.Contains(Rune element) => Contains(element);

		/// <summary>
		/// Returns the complement of the this collection.
		/// </summary>
		/// <returns>A new collection representing the complement of the collection.</returns>
		protected override Set<Glyph> Complement() => new Complement(this);

		/// <inheritdoc/>
		Boolean IContainable<Char>.Contains(Char element) => Contains(element);

		/// <summary>
		/// Determines whether a UTF-16 code unit. is categorized within this <see cref="Category"/>.
		/// </summary>
		/// <param name="element">The UTF-16 code unit</param>
		/// <returns><see langword="true"/> if <paramref name="element"/> is in this <see cref="Category"/>; otherwise, <see langword="false"/>.</returns>
		protected virtual Boolean Contains(Char element) => Contains((Glyph)element);

		/// <summary>
		/// Determines whether a UNICODE character is categorized within this <see cref="Category"/>.
		/// </summary>
		/// <param name="element">The UNICODE character.</param>
		/// <returns><see langword="true"/> if <paramref name="element"/> is in this <see cref="Category"/>; otherwise, <see langword="false"/>.</returns>
		protected virtual Boolean Contains(Rune element) => Contains((Glyph)element);

		/// <summary>
		/// Determines whether a UNICODE grapheme cluster is categorized within this <see cref="Category"/>.
		/// </summary>
		/// <param name="element">The UNICODE grapheme cluster.</param>
		/// <returns><see langword="true"/> if <paramref name="value"/> is in this <see cref="Category"/>; otherwise, <see langword="false"/>.</returns>
		protected abstract override Boolean Contains(Glyph element);
		/// <summary>
		/// Returns the difference of this collection and the <paramref name="other"/> collection.
		/// </summary>
		/// <param name="other">The other collection of the difference.</param>
		/// <returns>A new collection representing the difference between the two collections.</returns>
		protected Category Difference(Category other) => new Difference(this, other);

		/// <summary>
		/// Returns the disjunction of this collection and the <paramref name="other"/> collection.
		/// </summary>
		/// <param name="other">The other collection of the disjunction.</param>
		/// <returns>A new collection representing the disjunction of the two collections.</returns>
		protected Category Disjunction(Category other) => new Disjunction(this, other);

		/// <summary>
		/// Returns the intersection of this collection and the <paramref name="other"/> collection.
		/// </summary>
		/// <param name="other">The other collection of the intersection.</param>
		/// <returns>A new collection representing the intersection of the two collections.</returns>
		protected Category Intersection(Category other) => new Intersection(this, other);

		/// <summary>
		/// Returns the union of this collection and the <paramref name="other"/> collection.
		/// </summary>
		/// <param name="other">The other collection of the union.</param>
		/// <returns>A new collection representing the union of the two collections.</returns>
		protected Category Union(Category other) => new Union(this, other);
	}
}
