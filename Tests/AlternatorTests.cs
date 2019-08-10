using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class AlternatorTests {
		[TestMethod]
		public void Constructor() {
			Pattern _ = (Pattern)"Hello" | "Goodbye";
		}

		[TestMethod]
		public void Consume() {
			Pattern Alternator = (Pattern)"Hello" | "Goodbye";
			Assert.That.Captures("Hello", Alternator.Consume("Hello"));
			Assert.That.Captures("Goodbye", Alternator.Consume("Goodbye"));
			Assert.That.Captures("", Alternator.Consume("!"));
		}

		[TestMethod]
		public void ConsumeFail() {
			Pattern Alternator = (Pattern)"Hello" | "Goodbye";
			Assert.That.Fails(Alternator.Consume("How are you?"));
		}
	}
}
