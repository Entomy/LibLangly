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
			ResultAssert.Captures("Hello", Optor.Consume("Hello world!"));
			ResultAssert.Captures("", Optor.Consume("Goodbye world!"));
		}
	}
}
