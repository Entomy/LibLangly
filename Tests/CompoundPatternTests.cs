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
		public void Identifier() {
			Pattern Pattern = Pattern.Letter & +(Pattern.Letter | Pattern.DecimalDigitNumber | "_");

			Assert.That.Succeeds(Pattern.Consume("hello"));
			Assert.That.Captures("hello", Pattern.Consume("hello"));

			Assert.That.Succeeds(Pattern.Consume("example_name"));
			Assert.That.Captures("example_name", Pattern.Consume("example_name"));

			Assert.That.Fails(Pattern.Consume("_fail"));
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