using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class CheckerTests {
		[TestMethod]
		public void Equal() {
			Pattern Checker = (Pattern)(nameof(Checker), (Char) => Char == 'a' || Char == '1');
			Assert.IsTrue(Checker.Equals("a"));
			Assert.IsTrue(Checker.Equals("1"));
			Assert.IsFalse(Checker.Equals("b"));
			Assert.IsFalse(Checker.Equals("a1"));
		}
	}
}
