using System.Globalization;
using Stringier.Patterns.Nodes;

namespace Stringier.Patterns {
	public abstract partial class Pattern {
		#region Unicode Category Patterns

		public static readonly Pattern ClosePunctuation = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.ClosePunctuation);

		public static readonly Pattern ConnectorPunctutation = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.ConnectorPunctuation);

		public static readonly Pattern Control = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.Control);

		public static readonly Pattern CurrencySymbol = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.CurrencySymbol);

		public static readonly Pattern DashPunctutation = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.DashPunctuation);

		public static readonly Pattern DecimalDigitNumber = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.DecimalDigitNumber);

		public static readonly Pattern EnclosingMark = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.EnclosingMark);

		public static readonly Pattern FinalQuotePunctuation = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.FinalQuotePunctuation);

		public static readonly Pattern Format = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.Format);

		public static readonly Pattern InitialQuotePunctuation = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.InitialQuotePunctuation);

		public static readonly Pattern LetterNumber = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.LetterNumber);

		public static readonly Pattern LineSeparator = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.LineSeparator);

		public static readonly Pattern LowercaseLetter = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.LowercaseLetter);

		public static readonly Pattern MathSymbol = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.MathSymbol);

		public static readonly Pattern ModifierLetter = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.ModifierLetter);

		public static readonly Pattern ModifierSymbol = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.ModifierSymbol);

		public static readonly Pattern NonSpacingMark = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.NonSpacingMark);

		public static readonly Pattern OpenPunctuation = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.OpenPunctuation);

		public static readonly Pattern OtherLetter = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.OpenPunctuation);

		public static readonly Pattern OtherNotAssigned = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherNotAssigned);

		public static readonly Pattern OtherNumber = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherNumber);

		public static readonly Pattern OtherPunctuation = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherPunctuation);

		public static readonly Pattern OtherSymbol = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherSymbol);

		public static readonly Pattern ParagraphSeparator = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.ParagraphSeparator);

		public static readonly Pattern PrivateUse = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.PrivateUse);

		public static readonly Pattern SpaceSeparator = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.SpaceSeparator);

		public static readonly Pattern SpacingCombiningMark = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.SpacingCombiningMark);

		public static readonly Pattern Surrogate = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.Surrogate);

		public static readonly Pattern TitlecaseLetter = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.TitlecaseLetter);

		public static readonly Pattern UppercaseLetter = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.UppercaseLetter);

		public static readonly Pattern Letter = new CharChecker((Char) => Char.GetUnicodeCategory() switch {
			UnicodeCategory.UppercaseLetter => true,
			UnicodeCategory.LowercaseLetter => true,
			UnicodeCategory.TitlecaseLetter => true,
			_ => false
		});

		public static readonly Pattern Mark = new CharChecker((Char) => Char.GetUnicodeCategory() switch {
			UnicodeCategory.EnclosingMark => true,
			UnicodeCategory.NonSpacingMark => true,
			UnicodeCategory.SpacingCombiningMark => true,
			_ => false
		});

		public static readonly Pattern Number = new CharChecker((Char) => Char.GetUnicodeCategory() switch {
			UnicodeCategory.DecimalDigitNumber => true,
			UnicodeCategory.LetterNumber => true,
			UnicodeCategory.OtherNumber => true,
			_ => false
		});

		public static readonly Pattern Punctuation = new CharChecker((Char) => Char.GetUnicodeCategory() switch {
			UnicodeCategory.ConnectorPunctuation => true,
			UnicodeCategory.DashPunctuation => true,
			UnicodeCategory.FinalQuotePunctuation => true,
			UnicodeCategory.InitialQuotePunctuation => true,
			UnicodeCategory.OpenPunctuation => true,
			UnicodeCategory.ClosePunctuation => true,
			UnicodeCategory.OtherPunctuation => true,
			_ => false
		});

		public static readonly Pattern Symbol = new CharChecker((Char) => Char.GetUnicodeCategory() switch {
			UnicodeCategory.CurrencySymbol => true,
			UnicodeCategory.MathSymbol => true,
			UnicodeCategory.ModifierSymbol => true,
			UnicodeCategory.OtherSymbol => true,
			_ => false
		});

		public static readonly Pattern Separator = new CharChecker((Char) => Char.GetUnicodeCategory() switch {
			UnicodeCategory.LineSeparator => true,
			UnicodeCategory.ParagraphSeparator => true,
			UnicodeCategory.SpaceSeparator => true,
			_ => false
		});

		public static readonly Pattern Graphic = new CharChecker((Char) => Char.GetUnicodeCategory() switch {
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
		});

		#endregion

		#region Additional Patterns

		/// <summary>
		/// Matches any possible character.
		/// </summary>
		public static readonly Pattern Any = new CharChecker((_) => true);

		public static readonly Pattern BoxDrawing = new CharChecker((Char) => Char.IsBoxDrawing());

		public static readonly Pattern CombiningMark = new CharChecker((Char) => Char.IsCombiningMark());

		/// <summary>
		/// Check for the end of the <see cref="Source"/>
		/// </summary>
		public static readonly Pattern EndOfSource = new SourceEndChecker();

		/// <summary>
		/// Not a UNICODE group, but instead, the various line terminators Operating Systems recognize.
		/// </summary>
		public static readonly Pattern LineTerminator = new LineEndChecker();

		public static readonly Pattern Subscript = new CharChecker((Char) => Char.IsSubscript());

		public static readonly Pattern Superscript = new CharChecker((Char) => Char.IsSuperscript());

		#endregion
	}
}
