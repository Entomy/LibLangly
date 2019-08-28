using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class CompoundPatternTests {

		[TestMethod]
		public void AlernateRepeater() {
			Pattern Pattern = (((Pattern)"Hi" | "Bye") & "! ") * 2;
			Assert.That.Captures("Hi! Bye! ", Pattern.Consume("Hi! Bye! Hi!"));
		}

		[TestMethod]
		public void AlternateSpanner() {
			Pattern Indentation = +(Pattern.SpaceSeparator | "\t");
			Assert.That.Captures("  \t ", Indentation.Consume("  \t Hi!"));
		}

		[TestMethod]
		public void Comment() {
			Pattern Range = (From: "--", To: Pattern.LineTerminator);
			Result Result;

			Result = Range.Consume("--This should fail");
			Assert.That.Fails(Result);

			Result = Range.Consume("--This is a comment\n");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("--This is a comment\n", Result);

			Result = Range.Consume("--This is a comment\nExample_Function();");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("--This is a comment\n", Result);

		}

		[TestMethod]
		public void Identifier() {
			Pattern Pattern = Pattern.Letter & +(Pattern.Letter | Pattern.DecimalDigitNumber | "_");

			Assert.That.Succeeds(Pattern.Consume("hello"));
			Assert.That.Captures("hello", Pattern.Consume("hello"));

			Assert.That.Succeeds(Pattern.Consume("example_name"));
			Assert.That.Captures("example_name", Pattern.Consume("example_name"));

			Assert.That.Fails(Pattern.Consume("_fail"));
		}

		[TestMethod]
		public void IPv4Address() {
			Pattern Digit = (~(((Pattern)'1' | '2') & Pattern.DecimalDigitNumber) | Pattern.DecimalDigitNumber) & ~Pattern.DecimalDigitNumber;
			Pattern Address = Digit & "." & Digit & "." & Digit & "." & Digit;
			Result Result;

			Result = Digit.Consume("1");
			Assert.That.Captures("1", Result);
			Result = Digit.Consume("11");
			Assert.That.Captures("11", Result);
			Result = Digit.Consume("111");
			Assert.That.Captures("111",Result);

			Result = Address.Consume("192.168.1.1");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("192.168.1.1", Result);
		}

		[TestMethod]
		public void NestedPackage() {
			Pattern Identifier = Pattern.Letter & +(Pattern.Letter | Pattern.DecimalDigitNumber | "_");
			Pattern Package = (
				From: "package" & +Pattern.SpaceSeparator & Identifier.Capture(out Capture Name),
				To: "end" & +Pattern.SpaceSeparator & Name & ';');
			Result Result;

			Result = Package.Consume("package Top\nend Top;");
			//Assert.That.Succeeds(Result);
			Assert.That.Captures("Top", Name);
			Assert.That.Captures("package Top\nend Top;", Result);

			Result = Package.Consume("package Top\npackage Nest\nend Nest;\nend Top;");
			//Assert.That.Succeeds(Result);
			Assert.That.Captures("Top", Name);
			Assert.That.Captures("package Top\npackage Nest\nend Nest;\nend Top;", Result);
	}

	[TestMethod]
		public void Number() {
			Result Result;

			Pattern NumeralPattern = Pattern.DecimalDigitNumber & ~+("_" | Pattern.DecimalDigitNumber);

			Pattern ExtendedDigitPattern = Pattern.DecimalDigitNumber | "a" | "A" | "b" | "B" | "c" | "C" | "d" | "D" | "e" | "E" | "f" | "F";

			Pattern BasedNumeralPattern = ExtendedDigitPattern & +("_" | ExtendedDigitPattern);

			Pattern SignPattern = (Pattern)"+" | "-";

			Pattern ExponentPattern = ("E", StringComparison.OrdinalIgnoreCase) & ~SignPattern & NumeralPattern;

			Pattern Numeral = NumeralPattern & ~("." & NumeralPattern) & ~ExponentPattern;

			Result = Numeral.Consume("42");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("42", Result);

			Result = Numeral.Consume("4_2");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("4_2", Result);

			Pattern Fraction = "." & Numeral;

			Result = Fraction.Consume(".0");
			Assert.That.Succeeds(Result);
			Assert.That.Captures(".0", Result);

			Pattern RealNumeral = Numeral & ~Fraction;

			Result = RealNumeral.Consume("42.0");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("42.0", Result);
		}

		[TestMethod]
		public void OptorSpanner() {
			Pattern Pattern = ~+(Pattern)" ";
			Assert.That.Captures("  ", Pattern.Consume("  Hello"));
			Assert.That.Captures("", Pattern.Consume("Hello"));
		}

		[TestMethod]
		public void PhoneNumber() {
			Pattern Pattern = Pattern.Number * 3 & "-" & Pattern.Number * 3 & "-" & Pattern.Number * 4;
			Result Result = Pattern.Consume("555-555-5555");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("555-555-5555", Result);
		}

		[TestMethod]
		public void Separator() {
			Pattern Pattern = +(Pattern.Separator | "\t");
			Assert.That.Captures("  \t ", Pattern.Consume("  \t Hello"));
		}

		[TestMethod]
		public void StringLiteral() {
			Pattern Range = (From: "\"", To: "\"", Escape: "\\\"");
			Assert.That.Captures("\"hello\\\"world\"", Range.Consume("\"hello\\\"world\""));
		}

		[TestMethod]
		public void WebAddress() {
			Pattern Protocol = "http" & ~(Pattern)"s" & "://";
			Pattern Host = +(Pattern.Letter | Pattern.Number | "-") & "." & ~(+(Pattern.Letter | Pattern.Number | "-") & ".") & Pattern.Letter * 3;
			Pattern Location = +("/" & +(Pattern.Letter | Pattern.Number | "-" | "_"));
			Pattern Address = ~Protocol & Host & ~Location;
			Result Result;

			Result = Protocol.Consume("http://");
			Assert.That.Captures("http://", Result);
			Result = Protocol.Consume("https://");
			Assert.That.Captures("https://", Result);

			Result = Host.Consume("google.com");
			Assert.That.Captures("google.com", Result);
			Result = Host.Consume("www.google.com");
			Assert.That.Captures("www.google.com", Result);

			Result = Location.Consume("/about");
			Assert.That.Captures("/about", Result);

			Result = Address.Consume("www.google.com");
			Assert.That.Captures("www.google.com", Result);
			Result = Address.Consume("http://www.google.com");
			Assert.That.Captures("http://www.google.com", Result);
			Result = Address.Consume("http://www.google.com/about");
			Assert.That.Captures("http://www.google.com/about", Result);
		}

	}
}