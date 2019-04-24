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
			String Capture;
			ResultAssert.Remains("", Alternator.Consume("Hello", out Capture));
			Assert.AreEqual("Hello", Capture);
			ResultAssert.Remains("", Alternator.Consume("Goodbye", out Capture));
			Assert.AreEqual("Goodbye", Capture);
			ResultAssert.Remains("!", Alternator.Consume("!", out Capture));
			Assert.AreEqual("", Capture);
		}
	}
}
