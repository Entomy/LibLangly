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
			Pattern Pattern = (From: "--", To: Pattern.LineTerminator);
			Result Result;

			Result = Pattern.Consume("--This should fail");
			Assert.That.Fails(Result);

			Result = Pattern.Consume("--This is a comment\n");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("--This is a comment\n", Result);

			Result = Pattern.Consume("--This is a comment\nExample_Function();");
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
		public void Number() {
			Result Result;

			Pattern Numeral = Pattern.DecimalDigitNumber & ~+("_" | Pattern.DecimalDigitNumber);

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
		public void Separator() {
			Pattern Pattern = +(Pattern.Separator | "\t");
			Assert.That.Captures("  \t ", Pattern.Consume("  \t Hello"));
		}

		[TestMethod]
		public void StringLiteral() {
			Pattern Pattern = (From: "\"", To: "\"", Escape: "\\\"");
			Assert.That.Captures("\"hello\\\"world\"", Pattern.Consume("\"hello\\\"world\""));
		}

	}
}