using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class OptorTests {
		[TestMethod]
		public void Constructor() {
			Pattern _ = ~(Pattern)"Hello";
		}

		[TestMethod]
		public void Consume() {
			Pattern Optor = ~(Pattern)"Hello";
			ResultAssert.Captures("Hello", Optor.Consume("Hello world!"));
			ResultAssert.Captures("", Optor.Consume("Goodbye world!"));
		}
	}
}
