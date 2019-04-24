using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class OptorTests {
		[TestMethod]
		public void Constructor() {
			Optor _ = ~(Literal)"Hello";
		}

		[TestMethod]
		public void Consume() {
			Optor Optor = ~(Literal)"Hello";
			String Capture;
			ResultAssert.Remains(" world!", Optor.Consume("Hello world!", out Capture));
			Assert.AreEqual("Hello", Capture);
			ResultAssert.Remains("Goodbye world!", Optor.Consume("Goodbye world!", out Capture));
			Assert.AreEqual("", Capture);
		}
	}
}
