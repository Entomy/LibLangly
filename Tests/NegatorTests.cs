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
			ResultAssert.Fails(Negator.Consume("Hello"));
			ResultAssert.Fails(Negator.Consume("Goodbye"));
			ResultAssert.Captures("World", Negator.Consume("Worldeater"));
		}

		[TestMethod]
		public void ConsumeChecker() {
			Pattern Negator = !Pattern.Check(nameof(Negator), (Char) => 0x30 <= Char && Char <= 0x39);
			ResultAssert.Fails(Negator.Consume("3"));
			ResultAssert.Fails(Negator.Consume("7"));
			ResultAssert.Captures("A", Negator.Consume("A"));
		}

		[TestMethod]
		public void ConsumeConcatenator() {
			Pattern Negator = !((Pattern)"Hello" & '!');
			ResultAssert.Fails(Negator.Consume("Hello"));
			ResultAssert.Fails(Negator.Consume("Hello!"));
			ResultAssert.Captures("Hello.", Negator.Consume("Hello."));
			ResultAssert.Captures("Oh no!", Negator.Consume("Oh no!"));
			ResultAssert.Captures("Oh no?", Negator.Consume("Oh no?"));
		}

		[TestMethod]
		public void ConsumeLiteral() {
			Pattern Negator = !(Pattern)"Hello";
			ResultAssert.Fails(Negator.Consume("Hello"));
			ResultAssert.Captures("World", Negator.Consume("World"));
		}

		[TestMethod]
		public void ConsumeOptor() {
			Pattern Negator = !-(Pattern)"Hello";

			ResultAssert.Captures("", Negator.Consume("Hello"));

			ResultAssert.Captures("World", Negator.Consume("World"));
		}

		[TestMethod]
		public void ConsumeRepeater() {
			Pattern Negator = !((Pattern)"Hi!" * 2);
			ResultAssert.Fails(Negator.Consume("Hi!Hi!"));
			ResultAssert.Captures("Oh!Oh!", Negator.Consume("Oh!Oh!"));
		}

		[TestMethod]
		public void ConsumeSpanner() {
			Pattern Negator = !+(Pattern)";";
			ResultAssert.Fails(Negator.Consume(";"));
			ResultAssert.Captures("123456789", Negator.Consume("123456789;"));
		}

		[TestMethod]
		public void Equal() {
			Pattern Negator = !(Pattern)"Hello";
			Assert.IsTrue(Negator.Equals("World"));
			Assert.IsTrue(Negator.Equals("Hello "));
			Assert.IsFalse(Negator.Equals("Hello"));
		}
	}
}
