using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class LiteralTests {
		[TestMethod]
		public void Constructor() {
			Literal _;
			_ = "Hello";
		}

		[TestMethod]
		public void Consume() {
			ResultAssert.Remains("!", ((Literal)"Hello" & " " & "World").Consume("Hello World!", out String Capture));
			Assert.AreEqual("Hello World", Capture);
		}

		[TestMethod]
		public void ConsumeCaseInsensitive() {
			Literal Hello = ("HELLO", StringComparison.OrdinalIgnoreCase);
			Literal World = ("WORLD", StringComparison.OrdinalIgnoreCase);
			ResultAssert.Remains("!", (Hello & " " & World).Consume("HELLO WORLD!"));
			ResultAssert.Remains("!", (Hello & " " & World).Consume("Hello World!"));
			ResultAssert.Remains("!", (Hello & " " & World).Consume("hello world!"));
		}
	}
}
