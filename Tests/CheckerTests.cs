using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class CheckerTests {
		[TestMethod]
		public void Span() {
			Pattern Checker = (Pattern)((Char) => 0x30 <= Char && Char <= 0x39);
			ResultAssert.Captures("123456789", Checker.Span("123456789ABCDEF"));
		}
	}
}
