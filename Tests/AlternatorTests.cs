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
			Assert.That.Succeeds(Result);
			Assert.That.Captures("Hello", Result);

			Result = Alternator.Consume("Goodbye");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("Goodbye", Result);

			Result = Alternator.Consume("!");
			Assert.That.Fails(Result);
			Assert.That.Captures("", Result);

			Assert.That.Fails(Alternator.Consume("How are you?"));
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
