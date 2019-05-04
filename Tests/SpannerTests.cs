using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class SpannerTests {
		[TestMethod]
		public void Constructor() {
			Spanner _ = +Latin.Space;
		}

		[TestMethod]
		public void Consume() {
			Spanner Whitespace = +(Literal)" ";
			ResultAssert.Captures("    ", Whitespace.Consume("    Hi!"));
		}
	}
}
