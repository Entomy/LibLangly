using System.Globalization;

namespace System.Text.Patterns {
	/// <summary>
	/// Represents a textual pattern
	/// </summary>
	public readonly struct Pattern : IEquatable<Pattern>, IEquatable<String> {
		/// <summary>
		/// The head node of the pattern
		/// </summary>
		/// <remarks>
		/// Any pattern itself is essentially an unballanced binary tree; this is the starting point
		/// </remarks>
		internal readonly Node Head;

		/// <summary>
		/// Construct a new Pattern with the specified <paramref name="Head"/>
		/// </summary>
		/// <param name="Head">The <see cref="Node"/> to set as the head of this pattern</param>
		internal Pattern(Node Head) => this.Head = Head;

		public static explicit operator Pattern(Func<Char, Boolean> Check) => new Pattern(new Checker(Check));

		public static implicit operator Pattern(Char Char) => new Pattern(new CharLiteral(Char));

		public static implicit operator Pattern((Char Char, StringComparison ComparisonType) Pattern) => new Pattern(new CharLiteral(Pattern.Char, Pattern.ComparisonType));

		public static implicit operator Pattern(String String) => new Pattern(new StringLiteral(String));

		public static implicit operator Pattern((String String, StringComparison ComparisonType) Pattern) => new Pattern(new StringLiteral(Pattern.String, Pattern.ComparisonType));

		public static implicit operator Pattern((String From, String To) Range) => new Pattern(new Ranger(Range.From, Range.To));

		public static implicit operator Pattern((Pattern From, Pattern To) Range) => new Pattern(new Ranger(Range.From, Range.To));

		public static implicit operator Pattern((String From, String To, String Escape) Range) => new Pattern(new Ranger(Range.From, Range.To, Range.Escape));

		public static implicit operator Pattern((Pattern From, Pattern To, Pattern Escape) Range) => new Pattern(new Ranger(Range.From, Range.To, Range.Escape));

		/// <summary>
		/// Combine the two patterns, one after another
		/// </summary>
		/// <param name="Left"></param>
		/// <param name="Right"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Pattern operator &(Pattern Left, Pattern Right) => new Pattern(new Concatenator(Left, Right));

		/// <summary>
		/// Combine the two patterns, one after another
		/// </summary>
		/// <param name="Left"></param>
		/// <param name="Right"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Pattern operator &(Pattern Left, Char Right) => new Pattern(new Concatenator(Left, Right));

		/// <summary>
		/// Combine the two patterns, one after another
		/// </summary>
		/// <param name="Left"></param>
		/// <param name="Right"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Pattern operator &(Pattern Left, String Right) => new Pattern(new Concatenator(Left, Right));

		/// <summary>
		/// Combine the two patterns, one after another
		/// </summary>
		/// <param name="Left"></param>
		/// <param name="Right"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Pattern operator &(Char Left, Pattern Right) => new Pattern(new Concatenator(Left, Right));

		/// <summary>
		/// Combine the two patterns, one after another
		/// </summary>
		/// <param name="Left"></param>
		/// <param name="Right"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Pattern operator &(String Left, Pattern Right) => new Pattern(new Concatenator(Left, Right));

		/// <summary>
		/// Repeats the pattern the specified number of times
		/// </summary>
		/// <param name="Left">The <see cref="Pattern"/> to repeat</param>
		/// <param name="Right">The number of repetitions</param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Pattern operator *(Pattern Left, Int32 Right) => new Pattern(new Repeater(Left, Right));

		/// <summary>
		/// Alternate the two patterns, accepting either
		/// </summary>
		/// <param name="Left"></param>
		/// <param name="Right"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Pattern operator |(Pattern Left, Pattern Right) => new Pattern(new Alternator(Left, Right));

		/// <summary>
		/// Alternate the two patterns, accepting either
		/// </summary>
		/// <param name="Left"></param>
		/// <param name="Right"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Pattern operator |(Pattern Left, Char Right) => new Pattern(new Alternator(Left, Right));

		/// <summary>
		/// Alternate the two patterns, accepting either
		/// </summary>
		/// <param name="Left"></param>
		/// <param name="Right"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Pattern operator |(Pattern Left, String Right) => new Pattern(new Alternator(Left, Right));

		/// <summary>
		/// Alternate the two patterns, accepting either
		/// </summary>
		/// <param name="Left"></param>
		/// <param name="Right"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Pattern operator |(Char Left, Pattern Right) => new Pattern(new Alternator(Left, Right));

		/// <summary>
		/// Alternate the two patterns, accepting either
		/// </summary>
		/// <param name="Left"></param>
		/// <param name="Right"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Pattern operator |(String Left, Pattern Right) => new Pattern(new Alternator(Left, Right));

		/// <summary>
		/// Makes the <paramref name="Pattern"/> optional
		/// </summary>
		/// <param name="Pattern"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Pattern operator ~(Pattern Pattern) => new Pattern(new Optor(Pattern));

		/// <summary>
		/// Makes the <paramref name="Pattern"/> negative
		/// </summary>
		/// <param name="Pattern"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Pattern operator !(Pattern Pattern) => new Pattern(new Negator(Pattern));

		/// <summary>
		/// Makes the <paramref name="Pattern"/> span
		/// </summary>
		/// <param name="Pattern"></param>
		/// <returns></returns>
		public static Pattern operator +(Pattern Pattern) => new Pattern(new Spanner(Pattern));

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Source">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured string</returns>
		public Result Consume(String Source) {
			Source source = new Source(Source);
			return Consume(ref source);
		}

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured string</returns>
		public Result Consume(ref Source Source) => Head.Consume(ref Source);

		/// <summary>
		/// Determines whether two object instances are equal.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Pattern other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public Boolean Equals(Pattern other) => Head.Equals(other.Head);

		public Boolean Equals(String other) => Head.Equals(other);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => Head.GetHashCode();

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() => Head.ToString();

		#region Unicode Category Patterns

		public static readonly Pattern ClosePunctuation = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.ClosePunctuation);

		public static readonly Pattern ConnectorPunctutation = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.ConnectorPunctuation);

		public static readonly Pattern Control = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.Control);

		public static readonly Pattern CurrencySymbol = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.CurrencySymbol);

		public static readonly Pattern DashPunctutation = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.DashPunctuation);

		public static readonly Pattern DecimalDigitNumber = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.DecimalDigitNumber);

		public static readonly Pattern EnclosingMark = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.EnclosingMark);

		public static readonly Pattern FinalQuotePunctuation = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.FinalQuotePunctuation);

		public static readonly Pattern Format = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.Format);

		public static readonly Pattern InitialQuotePunctuation = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.InitialQuotePunctuation);

		public static readonly Pattern LetterNumber = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.LetterNumber);

		public static readonly Pattern LineSeparator = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.LineSeparator);

		public static readonly Pattern LowercaseLetter = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.LowercaseLetter);

		public static readonly Pattern MathSymbol = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.MathSymbol);

		public static readonly Pattern ModifierLetter = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.ModifierLetter);

		public static readonly Pattern ModifierSymbol = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.ModifierSymbol);

		public static readonly Pattern NonSpacingMark = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.NonSpacingMark);

		public static readonly Pattern OpenPunctuation = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.OpenPunctuation);

		public static readonly Pattern OtherLetter = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.OpenPunctuation);

		public static readonly Pattern OtherNotAssigned = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherNotAssigned);

		public static readonly Pattern OtherNumber = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherNumber);

		public static readonly Pattern OtherPunctuation = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherPunctuation);

		public static readonly Pattern OtherSymbol = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherSymbol);

		public static readonly Pattern ParagraphSeparator = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.ParagraphSeparator);

		public static readonly Pattern PrivateUse = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.PrivateUse);

		public static readonly Pattern SpaceSeparator = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.SpaceSeparator);

		public static readonly Pattern SpacingCombiningMark = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.SpacingCombiningMark);

		public static readonly Pattern Surrogate = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.Surrogate);

		public static readonly Pattern TitlecaseLetter = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.TitlecaseLetter);

		public static readonly Pattern UppercaseLetter = (Pattern)((Char) => Char.GetUnicodeCategory() == UnicodeCategory.UppercaseLetter);

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
		public static readonly Pattern Any = (Pattern)((Char) => true);

		#endregion
	}
}