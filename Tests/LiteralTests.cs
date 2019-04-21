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
			Assert.AreEqual("!", ((Literal)"Hello" & " " & "World").Consume("Hello World!"));
		}
	}
}
