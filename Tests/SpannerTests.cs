using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class SpannerTests {
		[TestMethod]
		public void Constructor() {
			Pattern _ = +(Pattern)" ";
		}

		[TestMethod]
		public void Consume() {
			Pattern Whitespace = +(Pattern)" ";
			Assert.That.Captures(" ", Whitespace.Consume(" Hi!"));
			Assert.That.Captures("    ", Whitespace.Consume("    Hi!"));
		}

		[TestMethod]
		public void ConsumeFail() {
			Pattern Whitespace = +(Pattern)" ";
			Assert.That.Fails(Whitespace.Consume("Hi!  "));
		}
	}
}