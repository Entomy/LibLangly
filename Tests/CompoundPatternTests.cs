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
			Pattern Identifier = Pattern.Letter & +(Pattern.Letter | "_");
			ResultAssert.Captures("Hello_World", Identifier.Consume("Hello_World"));
		}

		[TestMethod]
		public void OptorSpanner() {
			Pattern Pattern = ~+(Pattern)" ";
			ResultAssert.Captures("  ", Pattern.Consume("  Hello"));
			ResultAssert.Captures("", Pattern.Consume("Hello"));
		}
	}
}
