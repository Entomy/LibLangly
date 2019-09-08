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
			Assert.That.Captures("", Negator.Consume("Hello"));
			Assert.That.Captures("", Negator.Consume("Goodbye"));
			Assert.That.Captures("World", Negator.Consume("Worldeater"));
		}

		[TestMethod]
		public void ConsumeChecker() {
			Pattern Negator = !(Pattern)(nameof(Negator), (Char) => 0x30 <= Char && Char <= 0x39);
			Assert.That.Captures("", Negator.Consume("3"));
			Assert.That.Captures("", Negator.Consume("7"));
			Assert.That.Captures("A", Negator.Consume("A"));
		}

		[TestMethod]
		public void ConsumeConcatenator() {
			Pattern Negator = !((Pattern)"Hello" & '!');
			Assert.That.Captures("", Negator.Consume("Hello"));
			Assert.That.Captures("", Negator.Consume("Hello!"));
			Assert.That.Captures("Hello.", Negator.Consume("Hello."));
			Assert.That.Captures("Oh no!", Negator.Consume("Oh no!"));
			Assert.That.Captures("Oh no?", Negator.Consume("Oh no?"));
		}

		[TestMethod]
		public void ConsumeLiteral() {
			Pattern Negator = !(Pattern)"Hello";
			Assert.That.Captures("", Negator.Consume("Hello"));
			Assert.That.Captures("World", Negator.Consume("World"));
		}

		[TestMethod]
		public void ConsumeOptor() {
			Pattern Negator = !-(Pattern)"Hello";

			Assert.That.Captures("", Negator.Consume("Hello"));
			Assert.That.Succeeds(Negator.Consume("Hello"));

			Assert.That.Captures("World", Negator.Consume("World"));
			Assert.That.Succeeds(Negator.Consume("World"));
		}

		[TestMethod]
		public void ConsumeRepeater() {
			Pattern Negator = !((Pattern)"Hi!" * 2);
			Assert.That.Captures("", Negator.Consume("Hi!Hi!"));
			Assert.That.Captures("Oh!Oh!", Negator.Consume("Oh!Oh!"));
		}

		[TestMethod]
		public void ConsumeSpanner() {
			Pattern Negator = !+(Pattern)";";
			Assert.That.Captures("", Negator.Consume(";"));
			Assert.That.Captures("123456789", Negator.Consume("123456789;"));
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
