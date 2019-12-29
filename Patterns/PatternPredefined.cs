using System;
using System.Globalization;
using Stringier.Patterns.Nodes;

namespace Stringier.Patterns {
	public abstract partial class Pattern {
		#region Unicode Category Patterns

		public static readonly Pattern ClosePunctuation = new CharChecker("[Pe]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.ClosePunctuation);

		public static readonly Pattern ConnectorPunctutation = new CharChecker("[Pc]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.ConnectorPunctuation);

		public static readonly Pattern Control = new CharChecker("[Cc]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.Control);

		public static readonly Pattern CurrencySymbol = new CharChecker("[Sc]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.CurrencySymbol);

		public static readonly Pattern DashPunctutation = new CharChecker("[Pd]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.DashPunctuation);

		public static readonly Pattern DecimalDigitNumber = new CharChecker("[Nd]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.DecimalDigitNumber);

		public static readonly Pattern EnclosingMark = new CharChecker("[Me]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.EnclosingMark);

		public static readonly Pattern FinalQuotePunctuation = new CharChecker("[Pf]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.FinalQuotePunctuation);

		public static readonly Pattern Format = new CharChecker("[Cf]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.Format);

		public static readonly Pattern InitialQuotePunctuation = new CharChecker("[Pi]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.InitialQuotePunctuation);

		public static readonly Pattern LetterNumber = new CharChecker("[Nl]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.LetterNumber);

		public static readonly Pattern LineSeparator = new CharChecker("[Zl]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.LineSeparator);

		public static readonly Pattern LowercaseLetter = new CharChecker("[Ll]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.LowercaseLetter);

		public static readonly Pattern MathSymbol = new CharChecker("[Sm]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.MathSymbol);

		public static readonly Pattern ModifierLetter = new CharChecker("[Lm]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.ModifierLetter);

		public static readonly Pattern ModifierSymbol = new CharChecker("[Sk]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.ModifierSymbol);

		public static readonly Pattern NonSpacingMark = new CharChecker("[Mn]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.NonSpacingMark);

		public static readonly Pattern OpenPunctuation = new CharChecker("[Ps]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.OpenPunctuation);

		public static readonly Pattern OtherLetter = new CharChecker("[Lo]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.OpenPunctuation);

		public static readonly Pattern OtherNotAssigned = new CharChecker("[Cn]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherNotAssigned);

		public static readonly Pattern OtherNumber = new CharChecker("[No]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherNumber);

		public static readonly Pattern OtherPunctuation = new CharChecker("[Po]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherPunctuation);

		public static readonly Pattern OtherSymbol = new CharChecker("[So]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherSymbol);

		public static readonly Pattern ParagraphSeparator = new CharChecker("[Zp]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.ParagraphSeparator);

		public static readonly Pattern PrivateUse = new CharChecker("[Co]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.PrivateUse);

		public static readonly Pattern SpaceSeparator = new CharChecker("[Zs]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.SpaceSeparator);

		public static readonly Pattern SpacingCombiningMark = new CharChecker("[Mc]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.SpacingCombiningMark);

		public static readonly Pattern Surrogate = new CharChecker("[Cs]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.Surrogate);

		public static readonly Pattern TitlecaseLetter = new CharChecker("[Lt]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.TitlecaseLetter);

		public static readonly Pattern UppercaseLetter = new CharChecker("[Lu]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.UppercaseLetter);

		public static readonly Pattern Letter = new CharChecker("[L*]", (Char) => Char.GetUnicodeCategory() switch {
			UnicodeCategory.UppercaseLetter => true,
			UnicodeCategory.LowercaseLetter => true,
			UnicodeCategory.TitlecaseLetter => true,
			_ => false
		});

		public static readonly Pattern Mark = new CharChecker("[M*]", (Char) => Char.GetUnicodeCategory() switch {
			UnicodeCategory.EnclosingMark => true,
			UnicodeCategory.NonSpacingMark => true,
			UnicodeCategory.SpacingCombiningMark => true,
			_ => false
		});

		public static readonly Pattern Number = new CharChecker("[N*]", (Char) => Char.GetUnicodeCategory() switch {
			UnicodeCategory.DecimalDigitNumber => true,
			UnicodeCategory.LetterNumber => true,
			UnicodeCategory.OtherNumber => true,
			_ => false
		});

		public static readonly Pattern Punctuation = new CharChecker("[P*]", (Char) => Char.GetUnicodeCategory() switch {
			UnicodeCategory.ConnectorPunctuation => true,
			UnicodeCategory.DashPunctuation => true,
			UnicodeCategory.FinalQuotePunctuation => true,
			UnicodeCategory.InitialQuotePunctuation => true,
			UnicodeCategory.OpenPunctuation => true,
			UnicodeCategory.ClosePunctuation => true,
			UnicodeCategory.OtherPunctuation => true,
			_ => false
		});

		public static readonly Pattern Symbol = new CharChecker("[S*]", (Char) => Char.GetUnicodeCategory() switch {
			UnicodeCategory.CurrencySymbol => true,
			UnicodeCategory.MathSymbol => true,
			UnicodeCategory.ModifierSymbol => true,
			UnicodeCategory.OtherSymbol => true,
			_ => false
		});

		public static readonly Pattern Separator = new CharChecker("[Z*]", (Char) => Char.GetUnicodeCategory() switch {
			UnicodeCategory.LineSeparator => true,
			UnicodeCategory.ParagraphSeparator => true,
			UnicodeCategory.SpaceSeparator => true,
			_ => false
		});

		public static readonly Pattern Graphic = new CharChecker("[G*]", (Char) => Char.GetUnicodeCategory() switch {
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
		/// Matches any possible character
		/// </summary>
		public static readonly Pattern Any = new CharChecker("*", (_) => true);

		/// <summary>
		/// Not a UNICODE group, but instead, the various line terminators Operating Systems recognize.
		/// </summary>
		/// <remarks>
		/// The CR+LF used by Windows, DOS, OS2, PalmOS, and others is checked first, because otherwise only the single CR would be matched. Similarly, because RISC OS uses LF+CR this check occurs directly after CR+LF, before any single characters.
		/// </remarks>
		public static readonly Pattern LineTerminator = new LineEndChecker();

		/// <summary>
		/// Check for the end of the <see cref="Source"/>
		/// </summary>
		public static readonly Pattern EndOfSource = new SourceEndChecker();

		#endregion
	}
}
