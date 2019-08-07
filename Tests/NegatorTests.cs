using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]	
	public class NegatorTests {
		[TestMethod]
		public void Constructor() {
			Pattern _ = !(Pattern)"Hello";
		}

		[TestMethod]
		public void ConsumeChecker() {
			Pattern Negator = !(Pattern)((Char) => 0x30 <= Char && Char <= 0x39);
			ResultAssert.Captures("", Negator.Consume("3"));
			ResultAssert.Captures("", Negator.Consume("7"));
			ResultAssert.Captures("A", Negator.Consume("A"));
		}

		[TestMethod]
		public void ConsumeLiteral() {
			Pattern Negator = !(Pattern)"Hello";
			ResultAssert.Captures("", Negator.Consume("Hello"));
			ResultAssert.Captures("World", Negator.Consume("World"));
		}

	}
}
