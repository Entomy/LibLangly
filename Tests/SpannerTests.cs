using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class SpannerTests {
		[TestMethod]
		public void Constructor() {
			Spanner _ = Pattern.Whitespace.Span();
		}

		[TestMethod]
		public void Consume() {
			Spanner Whitespace = Pattern.Whitespace.Span();
			ResultAssert.Remains("Hi!", Whitespace.Consume("  \t Hi!", out String Capture));
			Assert.AreEqual("  \t ", Capture);
		}
	}
}
