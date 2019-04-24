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
			String Capture;
			ResultAssert.Remains("", Combinator.Consume("Hello world", out Capture));
			Assert.AreEqual("Hello world", Capture);
			ResultAssert.Remains("", Combinator.Consume("Goodbye world", out Capture));
			Assert.AreEqual("Goodbye world", Capture);
			ResultAssert.Remains("World", Combinator.Consume("Hello World", out Capture)); // Remember, string comparisons are case sensitive, so "World" isn't a match
			Assert.AreEqual("Hello ", Capture);
		}
	}
}
