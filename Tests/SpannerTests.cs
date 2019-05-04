using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class SpannerTests {
		[TestMethod]
		public void Constructor() {
			Spanner _ = Latin.Space.Span();
		}

		[TestMethod]
		public void Consume() {
			Spanner Whitespace = ((Literal)" ").Span();
			ResultAssert.Captures("    ", Whitespace.Consume("    Hi!"));
		}
	}
}
