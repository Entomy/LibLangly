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
			_ &= "World";
		}

		[TestMethod]
		public void Consume() {
			ResultAssert.Remains("!", ((Literal)"Hello" & " " & "World").Consume("Hello World!", out String Capture));
			Assert.AreEqual("Hello World", Capture);
		}
	}
}
