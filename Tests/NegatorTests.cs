using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]	
	public class NegatorTests {
		[TestMethod]
		public void Constructor() {
			Pattern _ = !(Pattern)"Hello";
		}

		[TestMethod]
		public void ConsumeAlternator() {
			Pattern Negator = !((Pattern)"Hello" | "Goodbye");
			ResultAssert.Captures("", Negator.Consume("Hello"));
			ResultAssert.Captures("", Negator.Consume("Goodbye"));
			ResultAssert.Captures("World", Negator.Consume("Worldeater"));
		}

		[TestMethod]
		public void ConsumeChecker() {
			Pattern Negator = !(Pattern)((Char) => 0x30 <= Char && Char <= 0x39);
			ResultAssert.Captures("", Negator.Consume("3"));
			ResultAssert.Captures("", Negator.Consume("7"));
			ResultAssert.Captures("A", Negator.Consume("A"));
		}

		[TestMethod]
		public void ConsumeCombinator() {
			Pattern Negator = !((Pattern)"Hello" & "!");
			ResultAssert.Captures("", Negator.Consume("Hello"));
			ResultAssert.Captures("", Negator.Consume("Hello!"));
			ResultAssert.Captures("", Negator.Consume("Oh no!")); // This is supposed to fail because while the first part succeeds because it doesn't match, the second part is a stand alone '!' which matches, causing the whole expression to fail. By contrast: "Hello!".Neglect("Oh no!") would pass. This is correct, albeit a bit surprising, behavior.
			ResultAssert.Captures("Oh no?", Negator.Consume("Oh no?"));
		}

		[TestMethod]
		public void ConsumeLiteral() {
			Pattern Negator = !(Pattern)"Hello";
			ResultAssert.Captures("", Negator.Consume("Hello"));
			ResultAssert.Captures("World", Negator.Consume("World"));
		}

		[TestMethod]
		public void ConsumeOptor() {
			Pattern Negator = !~(Pattern)"Hello";

			ResultAssert.Captures("", Negator.Consume("Hello"));
			ResultAssert.Succeeds(Negator.Consume("Hello"));

			ResultAssert.Captures("World", Negator.Consume("World"));
			ResultAssert.Succeeds(Negator.Consume("World"));
		}

		[TestMethod]
		public void ConsumeRepeater() {
			Pattern Negator = !((Pattern)"Hi!" * 2);
			ResultAssert.Captures("", Negator.Consume("Hi!Hi!"));
			ResultAssert.Captures("Oh!Oh!", Negator.Consume("Oh!Oh!"));
		}

		[TestMethod]
		public void ConsumeSpanner() {
			Pattern Negator = !+(Pattern)";";
			ResultAssert.Captures("", Negator.Consume(";"));
			ResultAssert.Captures("123456789", Negator.Consume("123456789;"));
		}

	}
}
