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
		public void Identifier() {
			Pattern Pattern = Pattern.Letter & +(Pattern.Letter | Pattern.DecimalDigitNumber | "_");
			ResultAssert.Captures("hello", Pattern.Consume("hello"));
			ResultAssert.Captures("example_name", Pattern.Consume("example_name"));
		}

		[TestMethod]
		public void OptorSpanner() {
			Pattern Pattern = ~+(Pattern)" ";
			ResultAssert.Captures("  ", Pattern.Consume("  Hello"));
			ResultAssert.Captures("", Pattern.Consume("Hello"));
		}

		[TestMethod]
		public void Separator() {
			Pattern Pattern = +(Pattern.Separator | "\t");
			ResultAssert.Captures("  \t ", Pattern.Consume("  \t Hello"));
		}

		[TestMethod]
		public void StringLiteral() {
			Pattern Pattern = (From: "\"", To: "\"", Escape: "\\\"");
			ResultAssert.Captures("\"hello\\\"world\"", Pattern.Consume("\"hello\\\"world\""));
		}

	}
}