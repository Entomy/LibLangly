using System.Globalization;
using System.Text.RegularExpressions;

namespace System.Text.Patterns {
	/// <summary>
	/// Represents a textual pattern
	/// </summary>
	public struct Pattern : IEquatable<Pattern>, IEquatable<String> {
		internal Node Head;

		internal Pattern(Node Head) => this.Head = Head;

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Source">The <see cref="Result"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		public Result Consume(Result Source) {
			Source source = new Source(Source);
			return Consume(ref source);
		}

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
		public Result Consume(ref Source Source) {
			Result Result = new Result(ref Source);
			Int32 OriginalPosition = Source.Position;
			Head.Consume(ref Source, ref Result);
			if (!Result) {
				Source.Position = OriginalPosition;
			}
			return Result;
		}

		public static Boolean operator ==(Pattern Left, Pattern Right) => Left.Equals(Right);

		public static Boolean operator !=(Pattern Left, Pattern Right) => !Left.Equals(Right);

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override Boolean Equals(Object? obj) => Head.Equals(obj);

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public Boolean Equals(Pattern other) => Head.Equals(other.Head);

		/// <summary>
		/// Determines whether the specified <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> can be represented by this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to check against this <see cref="Pattern"/>.</param>
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns>
		public Boolean Equals(ReadOnlySpan<Char> other) => Head.Equals(other);

		/// <summary>
		/// Determines whether the specified <see cref="String"/> can be represented by this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to check against this <see cref="Pattern"/>.</param>
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns>
		public Boolean Equals(String other) => Head.Equals(other);

		/// <summary>
		/// Returns the hash code for this <see cref="Pattern"/>.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => Head.GetHashCode();

		/// <summary>
		/// Returns a <see cref="String"/> that represents the current <see cref="Pattern"/>.
		/// </summary>
		/// <returns>A <see cref="String"/> that represents the current <see cref="Pattern"/>.</returns>
		public override String ToString() => Head.ToString();

		#region Literals

		public static implicit operator Pattern(Char Char) => new Pattern(new CharLiteral(Char));

		public static implicit operator Pattern(String Pattern) => new Pattern(new StringLiteral(Pattern));

		#endregion

		#region Alternator

		/// <summary>
		/// Declares <paramref name="Right"/> to be an alternate of <paramref name="Left"/>
		/// </summary>
		/// <param name="Left">The <see cref="Pattern"/> to check first</param>
		/// <param name="Right">The <see cref="Pattern"/> to check if <paramref name="Left"/> does not match</param>
		/// <returns></returns>
		public static Pattern operator |(Pattern Left, Pattern Right) => new Pattern(Left.Head.Alternate(Right.Head));

		/// <summary>
		/// Declares <paramref name="Right"/> to be an alternate of <paramref name="Left"/>
		/// </summary>
		/// <param name="Left">The <see cref="Pattern"/> to check first</param>
		/// <param name="Right">The <see cref="Char"/> to check if <paramref name="Left"/> does not match</param>
		/// <returns></returns>
		public static Pattern operator |(Pattern Left, Char Right) => new Pattern(Left.Head.Alternate(new CharLiteral(Right)));

		/// <summary>
		/// Declares <paramref name="Right"/> to be an alternate of <paramref name="Left"/>
		/// </summary>
		/// <param name="Left">The <see cref="Char"/> to check first</param>
		/// <param name="Right">The <see cref="Pattern"/> to check if <paramref name="Left"/> does not match</param>
		/// <returns></returns>
		public static Pattern operator |(Char Left, Pattern Right) => new Pattern(new CharLiteral(Left).Alternate(Right.Head));

		/// <summary>
		/// Declares <paramref name="Right"/> to be an alternate of <paramref name="Left"/>
		/// </summary>
		/// <param name="Left">The <see cref="Pattern"/> to check first</param>
		/// <param name="Right">The <see cref="String"/> to check if <paramref name="Left"/> does not match</param>
		/// <returns></returns>
		public static Pattern operator |(Pattern Left, String Right) => new Pattern(Left.Head.Alternate(new StringLiteral(Right)));

		/// <summary>
		/// Declares <paramref name="Right"/> to be an alternate of <paramref name="Left"/>
		/// </summary>
		/// <param name="Left">The <see cref="String"/> to check first</param>
		/// <param name="Right">The <see cref="Pattern"/> to check if <paramref name="Left"/> does not match</param>
		/// <returns></returns>
		public static Pattern operator |(String Left, Pattern Right) => new Pattern(new StringLiteral(Left).Alternate(Right.Head));

		#endregion

		#region Capturer

		public static implicit operator Pattern(Capture Capture) => new Pattern(new CaptureLiteral(Capture));

		/// <summary>
		/// Declares this <see cref="Pattern"/> should be captured into <paramref name="Capture"/> for later reference
		/// </summary>
		/// <param name="Capture">A <see cref="Patterns.Capture"/> object to store into.</param>
		/// <returns></returns>
		public Pattern Capture(out Capture Capture) => new Pattern(Head.Capture(out Capture));

		#endregion

		#region Checker

		/// <summary>
		/// Use the <paramref name="Check"/> to represent a single character.
		/// </summary>
		/// <param name="Name">Name to display this pattern as.</param>
		/// <param name="Check">A <see cref="Func{T, TResult}"/> to validate the character.</param>
		/// <returns></returns>
		public static Pattern Check(String Name, Func<Char, Boolean> Check) => new Pattern(new CharChecker(Name, Check));

		/// <summary>
		/// Use the specified <paramref name="HeadCheck"/>, <paramref name="BodyCheck"/>, and <paramref name="TailCheck"/> to represent a variable length string. The head and tail are only present once, with the body being repeatable.
		/// </summary>
		/// <param name="Name">Name to display this pattern as.</param>
		/// <param name="HeadCheck">A <see cref="Func{T, TResult}"/> to validate the head.</param>
		/// <param name="BodyCheck">A <see cref="Func{T, TResult}"/> to validate the body, which may repeat.</param>
		/// <param name="TailCheck">A <see cref="Func{T, TResult}"/> to validate the tail.</param>
		/// <returns></returns>
		public static Pattern Check(String Name, Func<Char, Boolean> HeadCheck, Func<Char, Boolean> BodyCheck, Func<Char, Boolean> TailCheck) => new Pattern(new StringChecker(Name, HeadCheck, BodyCheck, TailCheck));

		/// <summary>
		/// Use the specified <paramref name="HeadCheck"/>, <paramref name="BodyCheck"/>, and <paramref name="TailCheck"/> to represent a variable length string, along with whether each check is required for a valid string. The head and tail are only present once, with the body being repeatable.
		/// </summary>
		/// <param name="Name">Name to display this pattern as.</param>
		/// <param name="HeadCheck">A <see cref="Func{T, TResult}"/> to validate the head.</param>
		/// <param name="HeadRequired">Whether the <paramref name="HeadCheck"/> is required.</param>
		/// <param name="BodyCheck">A <see cref="Func{T, TResult}"/> to validate the body, which may repeat.</param>
		/// <param name="BodyRequired">Whether the <paramref name="BodyCheck"/> is required.</param>
		/// <param name="TailCheck">A <see cref="Func{T, TResult}"/> to validate the tail.</param>
		/// <param name="TailRequired">Whether the <paramref name="TailRequired"/> is required.</param>
		/// <returns></returns>
		public static Pattern Check(String Name, Func<Char, Boolean> HeadCheck, Boolean HeadRequired, Func<Char, Boolean> BodyCheck, Boolean BodyRequired, Func<Char, Boolean> TailCheck, Boolean TailRequired) => new Pattern(new StringChecker(Name, HeadCheck, HeadRequired, BodyCheck, BodyRequired, TailCheck, TailRequired));

		/// <summary>
		/// Use the specified <paramref name="HeadCheck"/>, <paramref name="BodyCheck"/>, and <paramref name="TailCheck"/> to represent the valid form of a word, along with the <paramref name="Bias"/>.
		/// </summary>
		/// <param name="Name">Name to display this pattern as.</param>
		/// <param name="Bias">Endian bias of the word. Head bias requires the head if only one letter is present. Tail bias requires the tail if only one letter is present.</param>
		/// <param name="HeadCheck">A <see cref="Func{T, TResult}"/> to validate the head.</param>
		/// <param name="BodyCheck">A <see cref="Func{T, TResult}"/> to validate the body, which may repeat.</param>
		/// <param name="TailCheck">A <see cref="Func{T, TResult}"/> to validate the tail.</param>
		/// <returns></returns>
		public static Pattern Check(String Name, Bias Bias, Func<Char, Boolean> HeadCheck, Func<Char, Boolean> BodyCheck, Func<Char, Boolean> TailCheck) => new Pattern(new WordChecker(Name, Bias, HeadCheck, BodyCheck, TailCheck));

		#endregion

		#region Concatenator

		/// <summary>
		/// Concatenates the patterns so that <paramref name="Left"/> comes before <paramref name="Right"/>
		/// </summary>
		/// <param name="Left">The preceeding <see cref="Pattern"/></param>
		/// <param name="Right">The succeeding <see cref="Pattern"/></param>
		/// <returns></returns>
		public static Pattern operator &(Pattern Left, Pattern Right) => new Pattern(Left.Head.Concatenate(Right.Head));

		/// <summary>
		/// Concatenates the patterns so that <paramref name="Left"/> comes before <paramref name="Right"/>
		/// </summary>
		/// <param name="Left">The preceeding <see cref="Pattern"/></param>
		/// <param name="Right">The succeeding <see cref="Char"/></param>
		/// <returns></returns>
		public static Pattern operator &(Pattern Left, Char Right) => new Pattern(Left.Head.Concatenate(new CharLiteral(Right)));

		/// <summary>
		/// Concatenates the patterns so that <paramref name="Left"/> comes before <paramref name="Right"/>
		/// </summary>
		/// <param name="Left">The preceeding <see cref="Char"/></param>
		/// <param name="Right">The succeeding <see cref="Pattern"/></param>
		/// <returns></returns>
		public static Pattern operator &(Char Left, Pattern Right) => new Pattern(new CharLiteral(Left).Concatenate(Right.Head));

		/// <summary>
		/// Concatenates the patterns so that <paramref name="Left"/> comes before <paramref name="Right"/>
		/// </summary>
		/// <param name="Left">The preceeding <see cref="Pattern"/></param>
		/// <param name="Right">The succeeding <see cref="String"/></param>
		/// <returns></returns>
		public static Pattern operator &(Pattern Left, String Right) => new Pattern(Left.Head.Concatenate(new StringLiteral(Right)));

		/// <summary>
		/// Concatenates the patterns so that <paramref name="Left"/> comes before <paramref name="Right"/>
		/// </summary>
		/// <param name="Left">The preceeding <see cref="String"/></param>
		/// <param name="Right">The succeeding <see cref="Pattern"/></param>
		/// <returns></returns>
		public static Pattern operator &(String Left, Pattern Right) => new Pattern(new StringLiteral(Left).Concatenate(Right.Head));

		#endregion

		#region Negator

		/// <summary>
		/// Marks the <paramref name="Pattern"/> as negated
		/// </summary>
		/// <param name="Pattern"></param>
		/// <returns></returns>
		public static Pattern operator !(Pattern Pattern) => new Pattern(Pattern.Head.Negate());

		#endregion

		#region Optor

		/// <summary>
		/// Marks the <paramref name="Pattern"/> as optional
		/// </summary>
		/// <param name="Pattern"></param>
		/// <returns></returns>
		public static Pattern operator -(Pattern Pattern) => new Pattern(Pattern.Head.Optional());

		#endregion

		#region Ranger

		/// <summary>
		/// Create a pattern representing the range <paramref name="From"/> until <paramref name="To"/>.
		/// </summary>
		/// <param name="From">Begining <see cref="Pattern"/>.</param>
		/// <param name="To">Ending <see cref="Pattern"/>.</param>
		public static Pattern Range(Pattern From, Pattern To) => new Pattern(new Ranger(From.Head, To.Head));

		/// <summary>
		/// Create a pattern representing the range <paramref name="From"/> until <paramref name="To"/>, allowing an <paramref name="Escape"/>.
		/// </summary>
		/// <param name="From">Begining <see cref="Pattern"/>.</param>
		/// <param name="To">Ending <see cref="Pattern"/>.</param>
		/// <param name="Escape">Escape <see cref="Pattern"/>./</param>
		public static Pattern Range(Pattern From, Pattern To, Pattern Escape) => new Pattern(new EscapedRanger(From.Head, To.Head, Escape.Head));

		/// <summary>
		/// Create a pattern representing the range <paramref name="From"/> until <paramref name="To"/>, that allows nesting of this pattern inside of itself.
		/// </summary>
		/// <remarks>
		/// The easiest way to explain this is that is shows up a lot in programming, with things like if-then-else statements which can contain other if-then-else statements.
		/// </remarks>
		/// <param name="From">Begining <see cref="Pattern"/>.</param>
		/// <param name="To">Ending <see cref="Pattern"/>.</param>
		public static Pattern NestedRange(Pattern From, Pattern To) => new Pattern(new NestedRanger(From.Head, To.Head));

		#endregion

		#region RegexAdapter

		public static implicit operator Pattern(Regex Regex) => new Pattern(new RegexAdapter(Regex));

		#endregion

		#region Repeater

		/// <summary>
		/// Marks the <paramref name="Pattern"/> as repeating <paramref name="Count"/> times
		/// </summary>
		/// <param name="Pattern"></param>
		/// <param name="Count"></param>
		/// <returns></returns>
		public static Pattern operator *(Pattern Pattern, Int32 Count) => new Pattern(Pattern.Head.Repeat(Count));

		#endregion

		#region Spanner

		/// <summary>
		/// Marks the <paramref name="Pattern"/> as spanning
		/// </summary>
		/// <param name="Pattern"></param>
		/// <returns></returns>
		public static Pattern operator +(Pattern Pattern) => new Pattern(Pattern.Head.Span());

		#endregion

		#region Unicode Category Patterns

		public static readonly Pattern ClosePunctuation = new Pattern(new CharChecker("[Pe]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.ClosePunctuation));

		public static readonly Pattern ConnectorPunctutation = new Pattern(new CharChecker("[Pc]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.ConnectorPunctuation));

		public static readonly Pattern Control = new Pattern(new CharChecker("[Cc]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.Control));

		public static readonly Pattern CurrencySymbol = new Pattern(new CharChecker("[Sc]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.CurrencySymbol));

		public static readonly Pattern DashPunctutation = new Pattern(new CharChecker("[Pd]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.DashPunctuation));

		public static readonly Pattern DecimalDigitNumber = new Pattern(new CharChecker("[Nd]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.DecimalDigitNumber));

		public static readonly Pattern EnclosingMark = new Pattern(new CharChecker("[Me]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.EnclosingMark));

		public static readonly Pattern FinalQuotePunctuation = new Pattern(new CharChecker("[Pf]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.FinalQuotePunctuation));

		public static readonly Pattern Format = new Pattern(new CharChecker("[Cf]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.Format));

		public static readonly Pattern InitialQuotePunctuation = new Pattern(new CharChecker("[Pi]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.InitialQuotePunctuation));

		public static readonly Pattern LetterNumber = new Pattern(new CharChecker("[Nl]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.LetterNumber));

		public static readonly Pattern LineSeparator = new Pattern(new CharChecker("[Zl]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.LineSeparator));

		public static readonly Pattern LowercaseLetter = new Pattern(new CharChecker("[Ll]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.LowercaseLetter));

		public static readonly Pattern MathSymbol = new Pattern(new CharChecker("[Sm]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.MathSymbol));

		public static readonly Pattern ModifierLetter = new Pattern(new CharChecker("[Lm]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.ModifierLetter));

		public static readonly Pattern ModifierSymbol = new Pattern(new CharChecker("[Sk]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.ModifierSymbol));

		public static readonly Pattern NonSpacingMark = new Pattern(new CharChecker("[Mn]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.NonSpacingMark));

		public static readonly Pattern OpenPunctuation = new Pattern(new CharChecker("[Ps]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.OpenPunctuation));

		public static readonly Pattern OtherLetter = new Pattern(new CharChecker("[Lo]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.OpenPunctuation));

		public static readonly Pattern OtherNotAssigned = new Pattern(new CharChecker("[Cn]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherNotAssigned));

		public static readonly Pattern OtherNumber = new Pattern(new CharChecker("[No]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherNumber));

		public static readonly Pattern OtherPunctuation = new Pattern(new CharChecker("[Po]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherPunctuation));

		public static readonly Pattern OtherSymbol = new Pattern(new CharChecker("[So]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherSymbol));

		public static readonly Pattern ParagraphSeparator = new Pattern(new CharChecker("[Zp]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.ParagraphSeparator));

		public static readonly Pattern PrivateUse = new Pattern(new CharChecker("[Co]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.PrivateUse));

		public static readonly Pattern SpaceSeparator = new Pattern(new CharChecker("[Zs]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.SpaceSeparator));

		public static readonly Pattern SpacingCombiningMark = new Pattern(new CharChecker("[Mc]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.SpacingCombiningMark));

		public static readonly Pattern Surrogate = new Pattern(new CharChecker("[Cs]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.Surrogate));

		public static readonly Pattern TitlecaseLetter = new Pattern(new CharChecker("[Lt]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.TitlecaseLetter));

		public static readonly Pattern UppercaseLetter = new Pattern(new CharChecker("[Lu]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.UppercaseLetter));

		public static readonly Pattern Letter = new Pattern(new CharChecker("[L*]", (Char) => Char.GetUnicodeCategory() switch {
			UnicodeCategory.UppercaseLetter => true,
			UnicodeCategory.LowercaseLetter => true,
			UnicodeCategory.TitlecaseLetter => true,
			_ => false
		}));

		public static readonly Pattern Mark = new Pattern(new CharChecker("[M*]", (Char) => Char.GetUnicodeCategory() switch {
			UnicodeCategory.EnclosingMark => true,
			UnicodeCategory.NonSpacingMark => true,
			UnicodeCategory.SpacingCombiningMark => true,
			_ => false
		}));

		public static readonly Pattern Number = new Pattern(new CharChecker("[N*]", (Char) => Char.GetUnicodeCategory() switch {
			UnicodeCategory.DecimalDigitNumber => true,
			UnicodeCategory.LetterNumber => true,
			UnicodeCategory.OtherNumber => true,
			_ => false
		}));

		public static readonly Pattern Punctuation = new Pattern(new CharChecker("[P*]", (Char) => Char.GetUnicodeCategory() switch {
			UnicodeCategory.ConnectorPunctuation => true,
			UnicodeCategory.DashPunctuation => true,
			UnicodeCategory.FinalQuotePunctuation => true,
			UnicodeCategory.InitialQuotePunctuation => true,
			UnicodeCategory.OpenPunctuation => true,
			UnicodeCategory.ClosePunctuation => true,
			UnicodeCategory.OtherPunctuation => true,
			_ => false
		}));

		public static readonly Pattern Symbol = new Pattern(new CharChecker("[S*]", (Char) => Char.GetUnicodeCategory() switch {
			UnicodeCategory.CurrencySymbol => true,
			UnicodeCategory.MathSymbol => true,
			UnicodeCategory.ModifierSymbol => true,
			UnicodeCategory.OtherSymbol => true,
			_ => false
		}));

		public static readonly Pattern Separator = new Pattern(new CharChecker("[Z*]", (Char) => Char.GetUnicodeCategory() switch {
			UnicodeCategory.LineSeparator => true,
			UnicodeCategory.ParagraphSeparator => true,
			UnicodeCategory.SpaceSeparator => true,
			_ => false
		}));

		public static readonly Pattern Graphic = new Pattern(new CharChecker("[G*]", (Char) => Char.GetUnicodeCategory() switch {
			UnicodeCategory.UppercaseLetter => true,
			UnicodeCategory.LowercaseLetter => true,
			UnicodeCategory.TitlecaseLetter => true,
			UnicodeCategory.EnclosingMark => true,
			UnicodeCategory.NonSpacingMark => true,
			UnicodeCategory.SpacingCombiningMark => true,
			UnicodeCategory.DecimalDigitNumber => true,
			UnicodeCategory.LetterNumber => true,
			UnicodeCategory.OtherNumber => true,
			UnicodeCategory.ConnectorPunctuation => true,
			UnicodeCategory.DashPunctuation => true,
			UnicodeCategory.FinalQuotePunctuation => true,
			UnicodeCategory.InitialQuotePunctuation => true,
			UnicodeCategory.OpenPunctuation => true,
			UnicodeCategory.ClosePunctuation => true,
			UnicodeCategory.OtherPunctuation => true,
			UnicodeCategory.CurrencySymbol => true,
			UnicodeCategory.MathSymbol => true,
			UnicodeCategory.ModifierSymbol => true,
			UnicodeCategory.OtherSymbol => true,
			UnicodeCategory.LineSeparator => true,
			UnicodeCategory.ParagraphSeparator => true,
			UnicodeCategory.SpaceSeparator => true,
			_ => false
		}));

		#endregion

		#region Additional Patterns

		/// <summary>
		/// Matches any possible character
		/// </summary>
		public static readonly Pattern Any = new Pattern(new CharChecker("*", (_) => true));

		/// <summary>
		/// Not a UNICODE group, but instead, the various line terminators Operating Systems recognize.
		/// </summary>
		/// <remarks>
		/// The CR+LF used by Windows, DOS, OS2, PalmOS, and others is checked first, because otherwise only the single CR would be matched. Similarly, because RISC OS uses LF+CR this check occurs directly after CR+LF, before any single characters.
		/// </remarks>
		public static readonly Pattern LineTerminator = (Pattern)"\u000D\u000A" | "\u000A\u000D" | "\u000A" | "\u000B" | "\u000C" | "\u000D" | "\u0085" | "\u2028" | "\u2029";

		/// <summary>
		/// Check for the end of the <see cref="Source"/>
		/// </summary>
		public static readonly Pattern EndOfSource = new Pattern(new EndChecker());

		#endregion
	}
}
