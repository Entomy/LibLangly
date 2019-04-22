using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class CombinatorTests {
		[TestMethod]
		public void Constructor() {
			Combinator _ = ((Literal)"Hello" | "Goodbye") & " " & "world";
		}

		[TestMethod]
		public void Consume() {
			Combinator Combinator = ((Literal)"Hello" | "Goodbye") & " " & "world";
			Assert.AreEqual("", Combinator.Consume("Hello world"));
			Assert.AreEqual("", Combinator.Consume("Goodbye world"));
			Assert.AreEqual("World", Combinator.Consume("Hello World")); // Remember, string comparisons are case sensitive, so "World" isn't a match
		}
	}
}
