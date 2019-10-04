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
			Result Result;

			Result = Alternator.Consume("Hello");
			ResultAssert.Captures("Hello", Result);

			Result = Alternator.Consume("Goodbye");
			ResultAssert.Captures("Goodbye", Result);

			Result = Alternator.Consume("!");
			ResultAssert.Fails(Result);

			ResultAssert.Fails(Alternator.Consume("How are you?"));

			Pattern ChainAlternator = (Pattern)"Hello" | "Hi" | "Howdy";

			Result = ChainAlternator.Consume("Hello");
			ResultAssert.Captures("Hello", Result);

			Result = ChainAlternator.Consume("Hi");
			ResultAssert.Captures("Hi", Result);

			Result = ChainAlternator.Consume("Howdy");
			ResultAssert.Captures("Howdy", Result);
		}

		[TestMethod]
		public void Equal() {
			Pattern Alternator = (Pattern)"Hello" | "Goodbye";
			Assert.IsTrue(Alternator.Equals("Hello"));
			Assert.IsTrue(Alternator.Equals("Goodbye"));
			Assert.IsFalse(Alternator.Equals("World"));
		}
	}
}
