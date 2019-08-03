using System.Globalization;

namespace System.Text.Patterns {
	public class Pattern : IEquatable<String> {

		internal readonly Node Head;

		internal Pattern(Node Head) => this.Head = Head;

		public static explicit operator Pattern(Func<Char, Boolean> Check) => new Pattern(new Checker(Check));

		public static implicit operator Pattern(String String) => new Pattern(new Literal(String));

		public static implicit operator Pattern((String String, StringComparison ComparisonType) Pattern) => new Pattern(new Literal(Pattern.String, Pattern.ComparisonType));

		/// <summary>
		/// Combine the two patterns, one after another
		/// </summary>
		/// <param name="Left"></param>
		/// <param name="Right"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Pattern operator &(Pattern Left, Pattern Right) => new Pattern(new Combinator(Left, Right));

		/// <summary>
		/// Combine the two patterns, one after another
		/// </summary>
		/// <param name="Left"></param>
		/// <param name="Right"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Pattern operator &(Pattern Left, String Right) => new Pattern(new Combinator(Left, Right));

		/// <summary>
		/// Combine the two patterns, one after another
		/// </summary>
		/// <param name="Left"></param>
		/// <param name="Right"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Pattern operator &(String Left, Pattern Right) => new Pattern(new Combinator(Left, Right));

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
		public static Pattern operator |(Pattern Left, String Right) => new Pattern(new Alternator(Left, Right));

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

		public override Boolean Equals(Object obj) => Head.Equals(obj);

		public Boolean Equals(String other) => Head.Equals(other);

		public override Int32 GetHashCode() => Head.GetHashCode();

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

		#endregion

		#region Predefined Patterns

		public static readonly Pattern Letter = LowercaseLetter | TitlecaseLetter | UppercaseLetter;

		#endregion
	}
}