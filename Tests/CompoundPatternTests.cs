using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class CompoundPatternTests {

		[TestMethod]
		public void AlernateRepeater() {
			Pattern Pattern = (((Pattern)"Hi" | "Bye") & "! ") * 2;
			ResultAssert.Captures("Hi! Bye! ", Pattern.Consume("Hi! Bye! Hi!"));
		}

		[TestMethod]
		public void AlternateSpanner() {
			Pattern Indentation = +(Pattern.SpaceSeparator | "\t");
			ResultAssert.Captures("  \t ", Indentation.Consume("  \t Hi!"));
		}

		[TestMethod]
		public void Backtrack() {
			Pattern End1 = "end" & +(Pattern)' ' & "first";
			Pattern End2 = "end" & +(Pattern)' ' & "second";
			Source Source = new Source("end second");
			//If backtracking doesn't occur, parsing End2 will fail, because "end" and the space will have been consumed
			ResultAssert.Fails(End1.Consume(ref Source));
			ResultAssert.Captures("end second", End2.Consume(ref Source));
		}

		[TestMethod]
		public void Comment() {
			Pattern Comment = "--" & +!Pattern.LineTerminator;
			Result Result;

			Result = Comment.Consume("--This is a comment\n");
			ResultAssert.Captures("--This is a comment", Result);

			Result = Comment.Consume("--This is a comment\nExample_Function();");
			ResultAssert.Captures("--This is a comment", Result);

		}

		[TestMethod]
		public void Identifier() {
			Pattern Pattern = Pattern.Check(nameof(Pattern),
			(Char) => Char.IsLetter(), true,
			(Char) => Char.IsLetter() || Char == '_', true,
			(Char) => Char.IsLetter() || Char == '_', false);

			ResultAssert.Captures("hello", Pattern.Consume("hello"));

			ResultAssert.Captures("example_name", Pattern.Consume("example_name"));

			ResultAssert.Fails(Pattern.Consume("_fail"));
		}

		[TestMethod]
		public void IPv4Address() {
			Pattern Digit = Pattern.Check(nameof(Digit),
			(Char) => '0' <= Char && Char <= '2', false,
			(Char) => '0' <= Char && Char <= '9', false,
			(Char) => '0' <= Char && Char <= '9', true);
			Pattern Address = Digit & "." & Digit & "." & Digit & "." & Digit;
			Result Result;

			Result = Digit.Consume("1");
			ResultAssert.Captures("1", Result);
			Result = Digit.Consume("11");
			ResultAssert.Captures("11", Result);
			Result = Digit.Consume("111");
			ResultAssert.Captures("111", Result);

			Result = Address.Consume("192.168.1.1");
			ResultAssert.Captures("192.168.1.1", Result);
		}

		[TestMethod]
		public void NamedStatement() {
			Result Result;
			Pattern Identifier = Pattern.Check(nameof(Identifier), Bias.Head,
			(Char) => Char.IsLetter() || Char == '_',
			(Char) => Char.IsLetterOrDigit() || Char == '_',
			(Char) => Char.IsLetterOrDigit());
			Result = Identifier.Consume("Name");
			ResultAssert.Captures("Name", Result);

			Pattern Statement = "statement" & +Pattern.Separator & Identifier.Capture(out Capture Name);
			Result = Statement.Consume("statement Name");
			ResultAssert.Captures("statement Name", Result);
			CaptureAssert.Captures("Name", Name);
		}

		[TestMethod]
		public void NestedPackage() {
			Pattern Identifier = Pattern.Letter & +(Pattern.Letter | Pattern.DecimalDigitNumber | "_");
			Pattern Package = Pattern.Range(
				From: "package" & +Pattern.SpaceSeparator & Identifier.Capture(out Capture Name),
				To: "end" & +Pattern.SpaceSeparator & Name & ';');
			Result Result;

			Result = Package.Consume("package Top\nend Top;");
			CaptureAssert.Captures("Top", Name);
			ResultAssert.Captures("package Top\nend Top;", Result);

			Result = Package.Consume("package Top\npackage Nest\nend Nest;\nend Top;");
			CaptureAssert.Captures("Top", Name);
			ResultAssert.Captures("package Top\npackage Nest\nend Nest;\nend Top;", Result);
		}

		[TestMethod]
		public void Number() {
			Result Result;

			Pattern NumeralPattern = Pattern.DecimalDigitNumber & -+("_" | Pattern.DecimalDigitNumber);

			Pattern ExtendedDigitPattern = Pattern.DecimalDigitNumber | "a" | "A" | "b" | "B" | "c" | "C" | "d" | "D" | "e" | "E" | "f" | "F";

			Pattern BasedNumeralPattern = ExtendedDigitPattern & +("_" | ExtendedDigitPattern);

			Pattern SignPattern = (Pattern)"+" | "-";

			Pattern ExponentPattern = "E" & -SignPattern & NumeralPattern;

			Pattern Numeral = NumeralPattern & -("." & NumeralPattern) & -ExponentPattern;

			Result = Numeral.Consume("42");
			ResultAssert.Captures("42", Result);

			Result = Numeral.Consume("4_2");
			ResultAssert.Captures("4_2", Result);

			Pattern Fraction = "." & Numeral;

			Result = Fraction.Consume(".0");
			ResultAssert.Captures(".0", Result);

			Pattern RealNumeral = Numeral & -Fraction;

			Result = RealNumeral.Consume("42.0");
			ResultAssert.Captures("42.0", Result);
		}

		[TestMethod]
		public void OptorSpanner() {
			Pattern Pattern = -+(Pattern)" ";
			ResultAssert.Captures("  ", Pattern.Consume("  Hello"));
			ResultAssert.Captures("", Pattern.Consume("Hello"));
		}

		[TestMethod]
		public void PhoneNumber() {
			Pattern Pattern = Pattern.Number * 3 & "-" & Pattern.Number * 3 & "-" & Pattern.Number * 4;
			Result Result = Pattern.Consume("555-555-5555");
			ResultAssert.Captures("555-555-5555", Result);
		}

		[TestMethod]
		public void Separator() {
			Pattern Pattern = +(Pattern.Separator | "\t");
			ResultAssert.Captures("  \t ", Pattern.Consume("  \t Hello"));
		}

		[TestMethod]
		public void SpannerOptor() {
			Assert.ThrowsException<PatternConstructionException>(() => +-(Pattern)" ");
		}

		[TestMethod]
		public void StringLiteral() {
			Pattern Range = Pattern.Range(From: "\"", To: "\"", Escape: "\\\"");
			ResultAssert.Captures("\"hello\\\"world\"", Range.Consume("\"hello\\\"world\""));
		}

		[TestMethod]
		public void WebAddress() {
			Pattern Protocol = "http" & -(Pattern)"s" & "://";
			Pattern Host = +(Pattern.Letter | Pattern.Number | "-") & "." & (Pattern.Letter * 3 & Pattern.EndOfSource | +(Pattern.Letter | Pattern.Number | "-") & "." & Pattern.Letter * 3);
			Pattern Location = +("/" & +(Pattern.Letter | Pattern.Number | "-" | "_"));
			Pattern Address = -Protocol & Host & -Location;
			Result Result;

			Result = Protocol.Consume("http://");
			ResultAssert.Captures("http://", Result);
			Result = Protocol.Consume("https://");
			ResultAssert.Captures("https://", Result);

			Result = Host.Consume("google.com");
			ResultAssert.Captures("google.com", Result);
			Result = Host.Consume("www.google.com");
			ResultAssert.Captures("www.google.com", Result);

			Result = Location.Consume("/about");
			ResultAssert.Captures("/about", Result);

			Result = Address.Consume("www.google.com");
			ResultAssert.Captures("www.google.com", Result);
			Result = Address.Consume("http://www.google.com");
			ResultAssert.Captures("http://www.google.com", Result);
			Result = Address.Consume("http://www.google.com/about");
			ResultAssert.Captures("http://www.google.com/about", Result);
		}

	}
}