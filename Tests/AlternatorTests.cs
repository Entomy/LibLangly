using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class AlternatorTests {
		[TestMethod]
		public void Constructor() {
			Alternator _ = (Literal)"Hello" | "Goodbye";
		}

		[TestMethod]
		public void Consume() {
			Alternator Alternator = (Literal)"Hello" | "Goodbye";
			Assert.AreEqual("", Alternator.Consume("Hello"));
			Assert.AreEqual("", Alternator.Consume("Goodbye"));
			Assert.AreEqual("!", Alternator.Consume("!"));
		}
	}
}
