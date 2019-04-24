using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class RepeaterTests {
		[TestMethod]
		public void Constructor() {
			Repeater _ = (Literal)"Hi! " * 2;
		}

		[TestMethod]
		public void Consume() {
			String Capture;
			Repeater Repeater = (Literal)"Hi! " * 2;
			ResultAssert.Remains("Hi!", Repeater.Consume("Hi! Hi! Hi!", out Capture));
			Assert.AreEqual("Hi! Hi! ", Capture);
			Pattern Pattern = (((Literal)"Hi" | "Bye") & "! ") * 2;
			ResultAssert.Remains("Hi!", Pattern.Consume("Hi! Bye! Hi!", out Capture));
			Assert.AreEqual("Hi! Bye! ", Capture);
		}
	}
}
