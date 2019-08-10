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
			Assert.That.Captures("Hello", Optor.Consume("Hello world!"));
			Assert.That.Captures("", Optor.Consume("Goodbye world!"));
			Assert.That.Succeeds(Optor.Consume("Goodbye world!"));
		}
	}
}
