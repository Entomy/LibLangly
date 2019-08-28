using System.Globalization;

namespace System.Text.Patterns {
	/// <summary>
	/// Represents a textual pattern
	/// </summary>
	public abstract class Pattern : IEquatable<String> {
		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Source">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		public Result Consume(String Source) {
			Source source = new Source(Source);
			return Consume(ref source);
		}

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		public abstract Result Consume(ref Source Source);

		public abstract override Boolean Equals(Object obj);

		public abstract Boolean Equals(ReadOnlySpan<Char> other);

		public abstract Boolean Equals(String other);

		public abstract override Int32 GetHashCode();

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Source">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		internal protected Result Neglect(String Source) {
			Source source = new Source(Source);
			return Consume(ref source);
		}

		/// <summary>
		/// Attempt to consume from the <paramref name="Source"/> while neglecting the <see cref="Pattern"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		internal protected abstract Result Neglect(ref Source Source);

		/// <summary>
		/// Returns a <see cref="String"/> that represents the current object.
		/// </summary>
		/// <returns>A <see cref="String"/> that represents the current object.</returns>
		public abstract override String ToString();

		#region Literals

		public static implicit operator Pattern(Char Char) => new CharLiteral(Char);

		public static implicit operator Pattern((Char Char, StringComparison ComparisonType) Pattern) => new CharLiteral(Pattern.Char, Pattern.ComparisonType);

		public static implicit operator Pattern(String Pattern) => new StringLiteral(Pattern);

		public static implicit operator Pattern((String String, StringComparison ComparisonType) Pattern) => new StringLiteral(Pattern.String, Pattern.ComparisonType);

		#endregion

		#region Alternator

		public abstract Pattern Alternate(Pattern Right);

		public abstract Pattern Alternate(Char Right);

		public abstract Pattern Alternate(String Right);

		public static Pattern operator |(Pattern Left, Pattern Right) => Left.Alternate(Right);

		public static Pattern operator |(Pattern Left, Char Right) => Left.Alternate(Right);

		public static Pattern operator |(Char Left, Pattern Right) => Left.Alternate(Right);

		public static Pattern operator |(Pattern Left, String Right) => Left.Alternate(Right);

		public static Pattern operator |(String Left, Pattern Right) => Left.Alternate(Right);

		#endregion

		#region Capturer

		public abstract Pattern Capture(out Capture Capture);

		#endregion

		#region Checker

		public static implicit operator Pattern(Func<Char, Boolean> Check) => new Checker(Check);

		#endregion

		#region Concatenator

		public abstract Pattern Concatenate(Pattern Right);

		public abstract Pattern Concatenate(Char Right);

		public abstract Pattern Concatenate(String Right);

		public static Pattern operator &(Pattern Left, Pattern Right) => Left.Concatenate(Right);

		public static Pattern operator &(Pattern Left, Char Right) => Left.Concatenate(Right);

		public static Pattern operator &(Char Left, Pattern Right) => Left.Concatenate(Right);

		public static Pattern operator &(Pattern Left, String Right) => Left.Concatenate(Right);

		public static Pattern operator &(String Left, Pattern Right) => Left.Concatenate(Right);

		#endregion

		#region Negator

		public abstract Pattern Negate();

		public static Pattern operator !(Pattern Pattern) => Pattern.Negate();

		#endregion

		#region Optor

		public abstract Pattern Optional();

		public static Pattern operator ~(Pattern Pattern) => Pattern.Optional();

		#endregion

		#region Ranger

		public static implicit operator Pattern((Pattern From, Pattern To) Range) => new Ranger(Range.From, Range.To);

		public static implicit operator Pattern((Pattern From, Pattern To, Pattern Escape) Range) => new EscapedRanger(Range.From, Range.To, Range.Escape);

		public static implicit operator Pattern((Pattern From, Pattern To, Boolean Nested) Range) => Range.Nested ? new NestedRanger(Range.From, Range.To) : new Ranger(Range.From, Range.To);

		#endregion

		#region Repeater

		public abstract Pattern Repeat(Int32 Count);

		public static Pattern operator *(Pattern Left, Int32 Count) => Left.Repeat(Count);

		#endregion

		#region Spanner

		public abstract Pattern Span();

		public static Pattern operator +(Pattern Pattern) => Pattern.Span();

		#endregion

		#region Unicode Category Patterns

		public static readonly Pattern ClosePunctuation = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.ClosePunctuation);

		public static readonly Pattern ConnectorPunctutation = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.ConnectorPunctuation);

		public static readonly Pattern Control = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.Control);

		public static readonly Pattern CurrencySymbol = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.CurrencySymbol);

		public static readonly Pattern DashPunctutation = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.DashPunctuation);

		public static readonly Pattern DecimalDigitNumber = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.DecimalDigitNumber);

		public static readonly Pattern EnclosingMark = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.EnclosingMark);

		public static readonly Pattern FinalQuotePunctuation = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.FinalQuotePunctuation);

		public static readonly Pattern Format = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.Format);

		public static readonly Pattern InitialQuotePunctuation = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.InitialQuotePunctuation);

		public static readonly Pattern LetterNumber = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.LetterNumber);

		public static readonly Pattern LineSeparator = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.LineSeparator);

		public static readonly Pattern LowercaseLetter = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.LowercaseLetter);

		public static readonly Pattern MathSymbol = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.MathSymbol);

		public static readonly Pattern ModifierLetter = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.ModifierLetter);

		public static readonly Pattern ModifierSymbol = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.ModifierSymbol);

		public static readonly Pattern NonSpacingMark = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.NonSpacingMark);

		public static readonly Pattern OpenPunctuation = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.OpenPunctuation);

		public static readonly Pattern OtherLetter = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.OpenPunctuation);

		public static readonly Pattern OtherNotAssigned = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherNotAssigned);

		public static readonly Pattern OtherNumber = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherNumber);

		public static readonly Pattern OtherPunctuation = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherPunctuation);

		public static readonly Pattern OtherSymbol = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherSymbol);

		public static readonly Pattern ParagraphSeparator = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.ParagraphSeparator);

		public static readonly Pattern PrivateUse = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.PrivateUse);

		public static readonly Pattern SpaceSeparator = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.SpaceSeparator);

		public static readonly Pattern SpacingCombiningMark = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.SpacingCombiningMark);

		public static readonly Pattern Surrogate = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.Surrogate);

		public static readonly Pattern TitlecaseLetter = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.TitlecaseLetter);

		public static readonly Pattern UppercaseLetter = new Checker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.UppercaseLetter);

		public static readonly Pattern Letter = LowercaseLetter | TitlecaseLetter | UppercaseLetter;

		public static readonly Pattern Mark = EnclosingMark | NonSpacingMark | SpacingCombiningMark;

		public static readonly Pattern Number = DecimalDigitNumber | LetterNumber | OtherNumber;

		public static readonly Pattern Punctuation = ConnectorPunctutation | DashPunctutation | FinalQuotePunctuation | InitialQuotePunctuation | OpenPunctuation | OtherPunctuation;

		public static readonly Pattern Symbol = CurrencySymbol | MathSymbol | ModifierSymbol | OtherSymbol;

		public static readonly Pattern Separator = LineSeparator | ParagraphSeparator | SpaceSeparator;

		public static readonly Pattern Graphic = Letter | Mark | Number | Punctuation | Symbol | SpaceSeparator;

		#endregion

		#region Additional Patterns

		/// <summary>
		/// Not a UNICODE group, but instead, the various line terminators Operating Systems recognize.
		/// </summary>
		/// <remarks>
		/// The CR+LF used by Windows, DOS, OS2, PalmOS, and others is checked first, because otherwise only the single CR would be matched. Similarly, because RISC OS uses LF+CR this check occurs directly after CR+LF, before any single characters.
		/// </remarks>
		public static readonly Pattern LineTerminator = (Pattern)"\u000D\u000A" | "\u000A\u000D" | "\u000A" | "\u000B" | "\u000C" | "\u000D" | "\u0085" | "\u2028" | "\u2029";

		/// <summary>
		/// Matches any possible character
		/// </summary>
		public static readonly Pattern Any = new Checker((Char) => true);

		#endregion
	}
}
